// 必要な機能を使うための準備（外部の道具を取り込んでいる）
using System.ComponentModel; // データの一覧を画面に表示するために使う
using System.Runtime.InteropServices; // Windowsの機能を使うために必要
using System.Security.Cryptography; // データを暗号化・復号するために使う
using System.Text; // 文字を扱うための道具
using System.Text.Json; // JSONという形式でデータを保存・読み込みするための道具

namespace PortfolioManager // プログラムの名前（グループ名のようなもの）
{
    public partial class Form1 : Form // 画面（フォーム）のクラス
    {
        // インターネットにアクセスするための道具
        private static readonly HttpClient httpClient = new HttpClient();

        // Windowsの機能を使って、テキストボックスに薄い文字（ヒント）を表示する準備
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        // テキストボックスにヒント文字を表示するための関数
        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, placeholder);
        }

        // 全てのデータを保存するリスト
        private List<AppInfo> allData = new List<AppInfo>();
        // 画面に表示するデータのリスト（変更がすぐ反映される）
        private BindingList<AppInfo> appList = new BindingList<AppInfo>();

        // フォーム（画面）が作られるときに呼ばれる部分
        public Form1()
        {
            InitializeComponent(); // 画面の部品を準備する
        }

        // フォームが表示されるときに一度だけ実行される処理
        private void Form1_Load(object sender, EventArgs e)
        {
            // 表の列を自動で作らないようにする
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear(); // 既存の列を消す

            // 表に表示する列を追加する
            dataGridView1.Columns.AddRange(new DataGridViewColumn[]
            {
                TitleColumn,       // タイトル
                CreatedAtColumn,   // 作成日
                ImageColumn,       // 画像
                SummaryColumn,     // 概要
                ConceptColumn      // コンセプト
            });

            // 表の幅や各列の幅を設定
            dataGridView1.Width = 1330;
            TitleColumn.Width = 240;
            CreatedAtColumn.Width = 110;
            ImageColumn.Width = 128;
            SummaryColumn.Width = 340;
            ConceptColumn.Width = 340;

            // 列の幅をマウスで変えられるようにする
            dataGridView1.AllowUserToResizeColumns = true;
            // 表の中の文字を折り返して表示する
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            // 行の高さを自動で調整する
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            // 表の見出しを太字＆中央揃えにする
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // 表を読み取り専用にする（編集できないようにする）
            dataGridView1.ReadOnly = true;

            // 検索ボックスにヒント文字を表示
            SetPlaceholder(txtSearch, "半角スペースを挟んでAND検索可能");

            // 表のセルに関するイベントを登録（画像の表示やクリック時の動作など）
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            //dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellMouseEnter += dataGridView1_CellMouseEnter;
            dataGridView1.CellMouseLeave += dataGridView1_CellMouseLeave;

            // 表にデータを表示する
            dataGridView1.DataSource = appList;
        }

        // 表の列を再設定する関数（検索や並び替えの後に使う）
        private void SetupDataGridViewColumns()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.AddRange(new DataGridViewColumn[]
            {
                TitleColumn,
                CreatedAtColumn,
                ImageColumn,
                SummaryColumn,
                ConceptColumn
            });

            dataGridView1.Width = 1330;
            TitleColumn.Width = 240;
            CreatedAtColumn.Width = 110;
            ImageColumn.Width = 128;
            SummaryColumn.Width = 340;
            ConceptColumn.Width = 340;

            // イベントの重複登録を防ぐために、先に解除してから再登録する
            dataGridView1.ColumnHeaderMouseClick -= dataGridView1_ColumnHeaderMouseClick;
            dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;

            dataGridView1.CellFormatting -= dataGridView1_CellFormatting;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;

            dataGridView1.CellClick -= dataGridView1_CellClick;
            dataGridView1.CellClick += dataGridView1_CellClick;

            dataGridView1.CellMouseEnter -= dataGridView1_CellMouseEnter;
            dataGridView1.CellMouseEnter += dataGridView1_CellMouseEnter;

            dataGridView1.CellMouseLeave -= dataGridView1_CellMouseLeave;
            dataGridView1.CellMouseLeave += dataGridView1_CellMouseLeave;

        }

        // 表の中に画像を表示するための処理
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 画像の列だったら処理を行う
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ImageColumn")
            {
                // 表の行からデータを取り出す
                var appInfo = dataGridView1.Rows[e.RowIndex].DataBoundItem as AppInfo;

                // 画像がまだ読み込まれていなくて、画像のURLがある場合
                if (appInfo != null && appInfo.ImageObject == null && !string.IsNullOrEmpty(appInfo.ImageUrl))
                {
                    try
                    {
                        // URLから画像データをダウンロード
                        using var client = new HttpClient();
                        var bytes = client.GetByteArrayAsync(appInfo.ImageUrl).Result;

                        // ダウンロードした画像を表示用に変換
                        using var ms = new MemoryStream(bytes);
                        var original = Image.FromStream(ms);
                        appInfo.ImageObject = new Bitmap(original, new Size(128, 128));
                    }
                    catch
                    {
                        // 画像の読み込みに失敗したら何もしない
                        appInfo.ImageObject = null;
                    }
                }

                // 表に画像を表示する
                e.Value = appInfo?.ImageObject;
            }
        }

        // 表の画像をクリックしたときの処理（リンクを開く）
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ヘッダー行は無視する
            if (e.RowIndex < 0) return;

            // 画像の列がクリックされた場合
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ImageColumn")
            {
                var appInfo = dataGridView1.Rows[e.RowIndex].DataBoundItem as AppInfo;
                if (!string.IsNullOrWhiteSpace(appInfo?.Link))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = appInfo.Link,
                        UseShellExecute = true
                    });
                }
            }
        }


        // マウスが画像の上に来たとき、カーソルを手の形に変える
        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "ImageColumn")
                dataGridView1.Cursor = Cursors.Hand;
            else
                dataGridView1.Cursor = Cursors.Default;
        }

        // マウスがセルから離れたら、カーソルを元に戻す
        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Cursor = Cursors.Default;
        }

        // 「追加」ボタンを押したときの処理
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 入力用の画面を開く
            using (var form = new EditForm())
            {
                // OKボタンが押されたら、データを追加する
                if (form.ShowDialog() == DialogResult.OK)
                {
                    appList.Add(form.AppInfo); // 表示用リストに追加
                    allData.Add(form.AppInfo); // 全体のリストにも追加
                    dataGridView1.Refresh();   // 表を更新
                }
            }
        }

        // 「編集」ボタンを押したときの処理
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var appInfo = dataGridView1.CurrentRow.DataBoundItem as AppInfo;
            if (appInfo == null) return;

            // 編集前のImageUrlを保存
            string oldImageUrl = appInfo.ImageUrl;

            using (var form = new EditForm(appInfo))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // ImageUrlが変更されていたら画像を再取得
                    if (form.AppInfo.ImageUrl != oldImageUrl)
                    {
                        try
                        {
                            var bytes = httpClient.GetByteArrayAsync(form.AppInfo.ImageUrl).Result;
                            using var ms = new MemoryStream(bytes);
                            var original = Image.FromStream(ms);
                            form.AppInfo.ImageObject = new Bitmap(original, new Size(128, 128));
                        }
                        catch
                        {
                            form.AppInfo.ImageObject = null;
                        }
                    }

                    dataGridView1.Refresh(); // 表示を更新
                }
            }
        }


        // 「削除」ボタンを押したときの処理
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 行が選ばれていなければ何もしない
            if (dataGridView1.SelectedRows.Count == 0) return;

            var row = dataGridView1.SelectedRows[0];
            if (row.IsNewRow) return;

            var appInfo = row.DataBoundItem as AppInfo;
            if (appInfo == null) return;

            // 本当に削除していいか確認する
            var result = MessageBox.Show("この項目を本当に削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                appList.Remove(appInfo); // 表示用リストから削除
                allData.Remove(appInfo); // 全体のリストからも削除
                dataGridView1.Refresh(); // 表を更新
            }
        }

        // 「検索」ボタンを押したときの処理
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string text = txtSearch.Text.Trim(); // 入力された検索文字を取得

            if (string.IsNullOrEmpty(text))
            {
                // 何も入力されていなければ、すべてのデータを表示
                appList = new BindingList<AppInfo>(allData.ToList());
            }
            else
            {
                // 半角スペースで分けて、すべてのキーワードを含むデータを探す
                var keywords = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var filtered = allData
                    .Where(x => keywords.All(k =>
                        (x.Title?.Contains(k, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (x.Summary?.Contains(k, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (x.Concept?.Contains(k, StringComparison.OrdinalIgnoreCase) ?? false)
                    ))
                    .ToList();

                appList = new BindingList<AppInfo>(filtered);
            }

            SetupDataGridViewColumns(); // 表の列を再設定
            dataGridView1.DataSource = appList; // 表にデータを表示
        }

        // 「CSV保存」ボタンを押したときの処理
        private void btnSaveCsv_Click(object sender, EventArgs e)
        {
            // 保存先を選ぶダイアログを表示
            using var dialog = new SaveFileDialog { Filter = "CSVファイル (*.csv)|*.csv", FileName = "portfolio.csv" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using var writer = new StreamWriter(dialog.FileName, false, Encoding.UTF8);
                writer.WriteLine("Title,CreatedAt,Link,ImageUrl,Summary,Concept"); // ヘッダー行

                foreach (var app in appList)
                {
                    // カンマやダブルクォートを正しく処理するための関数
                    string Escape(string s) => "\"" + s.Replace("\"", "\"\"") + "\"";

                    // 1行ずつCSV形式で書き込む
                    writer.WriteLine(string.Join(",",
                        Escape(app.Title),
                        Escape(app.CreatedAt),
                        Escape(app.Link),
                        Escape(app.ImageUrl),
                        Escape(app.Summary),
                        Escape(app.Concept)));
                }
                MessageBox.Show("CSVを保存しました。");
            }
        }

        // 「CSV読み込み」ボタンを押したときの処理
        private void btnLoadCsv_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog { Filter = "CSVファイル (*.csv)|*.csv" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var newList = new BindingList<AppInfo>();
                    using var reader = new StreamReader(dialog.FileName, Encoding.UTF8);
                    reader.ReadLine(); // 最初の行（ヘッダー）を読み飛ばす

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        var fields = ParseCsvLine(line); // 1行を分割
                        if (fields.Length < 6) continue;

                        // データを作ってリストに追加
                        newList.Add(new AppInfo
                        {
                            Title = fields[0],
                            CreatedAt = fields[1],
                            Link = fields[2],
                            ImageUrl = fields[3],
                            Summary = fields[4],
                            Concept = fields[5]
                        });
                    }

                    allData = newList.ToList(); // 全体のリストを更新
                    appList = newList;          // 表示用リストも更新

                    SetupDataGridViewColumns();
                    dataGridView1.DataSource = appList;

                    MessageBox.Show("CSVを読み込みました。");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("読み込み中にエラーが発生しました: " + ex.Message);
                }
            }
        }

        // CSVの1行を正しく分割するための関数（カンマやダブルクォートに対応）
        private string[] ParseCsvLine(string line)
        {
            var result = new List<string>();
            bool inQuotes = false;
            var sb = new StringBuilder();

            foreach (char c in line)
            {
                if (c == '\"')
                {
                    inQuotes = !inQuotes; // ダブルクォートの中か外かを切り替える
                }
                else if (c == ',' && !inQuotes)
                {
                    result.Add(sb.ToString()); // カンマで区切る
                    sb.Clear();
                }
                else
                {
                    sb.Append(c); // 文字を追加
                }
            }

            result.Add(sb.ToString()); // 最後の項目を追加
            return result.ToArray();
        }

        // 暗号化に使うカギ（32文字＝256ビット）
        private static readonly byte[] aesKey = Encoding.UTF8.GetBytes("ThisIsASecretKey1234567890123456");
        // 暗号化の初期値（16文字＝128ビット）
        private static readonly byte[] aesIV = Encoding.UTF8.GetBytes("ThisIsAnInitVect");

        // 文字列を暗号化してバイト配列に変換する関数
        private byte[] EncryptStringToBytes(string plainText)
        {
            using var aes = Aes.Create(); // 暗号化の道具を作る
            aes.Key = aesKey;
            aes.IV = aesIV;

            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV); // 暗号化の準備
            using var ms = new MemoryStream(); // メモリ上に保存
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            using (var sw = new StreamWriter(cs))
            {
                sw.Write(plainText); // 文字列を書き込んで暗号化
            }
            return ms.ToArray(); // 暗号化されたデータを返す
        }

        // 暗号化されたバイト配列を元の文字列に戻す関数
        private string DecryptBytesToString(byte[] cipherBytes)
        {
            using var aes = Aes.Create();
            aes.Key = aesKey;
            aes.IV = aesIV;

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV); // 復号の準備
            using var ms = new MemoryStream(cipherBytes);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd(); // 復号された文字列を返す
        }

        // 並び替えの方向を記録するための変数（trueなら昇順、falseなら降順）
        private bool sortAscending = true;

        // 並び替え中かどうかのフラグ（今は使っていない）
        private bool isSorting = false;

        // 表の列の見出しをクリックしたときの並び替え処理
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;

            List<AppInfo> sorted;

            // タイトルで並び替え
            if (columnName == "Title")
            {
                sorted = sortAscending
                    ? allData.OrderBy(x => x.Title).ToList()
                    : allData.OrderByDescending(x => x.Title).ToList();
            }
            // 作成日で並び替え（"yyyy/MM" 形式の文字列を日付として扱う）
            else if (columnName == "CreatedAt")
            {
                sorted = sortAscending
                    ? allData.OrderBy(x => DateTime.ParseExact(x.CreatedAt, "yyyy/MM", System.Globalization.CultureInfo.InvariantCulture)).ToList()
                    : allData.OrderByDescending(x => DateTime.ParseExact(x.CreatedAt, "yyyy/MM", System.Globalization.CultureInfo.InvariantCulture)).ToList();
            }
            else
            {
                return; // 他の列は並び替えしない
            }

            sortAscending = !sortAscending; // 昇順・降順を切り替える

            appList = new BindingList<AppInfo>(sorted);
            dataGridView1.DataSource = appList;

            // 並び替えのマーク（▲▼）を表示
            dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                sortAscending ? SortOrder.Ascending : SortOrder.Descending;
        }

        // 「JSON保存」ボタンを押したときの処理（暗号化して保存）
        private void btnSaveJson_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "JSONファイル (*.json)|*.json", FileName = "portfolio.json" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // データをJSON形式に変換して、暗号化して保存
                    var json = JsonSerializer.Serialize(appList, new JsonSerializerOptions { WriteIndented = true });
                    var encrypted = EncryptStringToBytes(json);
                    File.WriteAllBytes(dialog.FileName, encrypted);
                    MessageBox.Show("暗号化してJSONを保存しました。");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存中にエラーが発生しました: " + ex.Message);
                }
            }
        }

        // 「JSON読み込み」ボタンを押したときの処理（暗号化されたファイルを復号）
        private void btnLoadJson_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog { Filter = "JSONファイル (*.json)|*.json" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // ファイルを読み込んで復号し、JSONとして解釈
                    var encrypted = File.ReadAllBytes(dialog.FileName);
                    var json = DecryptBytesToString(encrypted);
                    var loadedList = JsonSerializer.Deserialize<List<AppInfo>>(json);

                    if (loadedList != null)
                    {
                        // 画像URLがある場合は画像も読み込む
                        foreach (var app in loadedList)
                        {
                            if (!string.IsNullOrEmpty(app.ImageUrl))
                            {
                                try
                                {
                                    var bytes = httpClient.GetByteArrayAsync(app.ImageUrl).Result;
                                    using var ms = new MemoryStream(bytes);
                                    var original = Image.FromStream(ms);
                                    app.ImageObject = new Bitmap(original, new Size(128, 128));
                                }
                                catch
                                {
                                    app.ImageObject = null;
                                }
                            }
                        }

                        // 読み込んだデータを反映
                        allData = loadedList;
                        appList = new BindingList<AppInfo>(loadedList);

                        SetupDataGridViewColumns();
                        dataGridView1.DataSource = appList;

                        MessageBox.Show("暗号化されたJSONを復号して読み込みました。");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("読み込み中にエラーが発生しました: " + ex.Message);
                }
            }
        }

        // 「このアプリについて」ボタンを押したときの処理
        private void btnAbout_Click(object sender, EventArgs e)
        {
            using var about = new AboutForm(); // 別の画面を開く
            about.ShowDialog(); // モーダル表示（閉じるまで他の操作はできない）
        }
    }
}
