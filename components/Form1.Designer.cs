namespace PortfolioManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dataGridView1 = new DataGridView();
            TitleColumn = new DataGridViewTextBoxColumn();
            CreatedAtColumn = new DataGridViewTextBoxColumn();
            ImageColumn = new DataGridViewImageColumn();
            SummaryColumn = new DataGridViewTextBoxColumn();
            ConceptColumn = new DataGridViewTextBoxColumn();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnSaveCsv = new Button();
            btnLoadCsv = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnSaveJson = new Button();
            btnLoadJson = new Button();
            btnAbout = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { TitleColumn, CreatedAtColumn, ImageColumn, SummaryColumn, ConceptColumn });
            dataGridView1.Location = new Point(30, 100);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1200, 500);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.CellMouseEnter += dataGridView1_CellMouseEnter;
            dataGridView1.CellMouseLeave += dataGridView1_CellMouseLeave;
            dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
            // 
            // TitleColumn
            // 
            TitleColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TitleColumn.DataPropertyName = "Title";
            TitleColumn.HeaderText = "名称";
            TitleColumn.Name = "TitleColumn";
            TitleColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            TitleColumn.Width = 240;
            // 
            // CreatedAtColumn
            // 
            CreatedAtColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            CreatedAtColumn.DataPropertyName = "CreatedAt";
            CreatedAtColumn.HeaderText = "作成時期";
            CreatedAtColumn.Name = "CreatedAtColumn";
            CreatedAtColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            CreatedAtColumn.Width = 110;
            // 
            // ImageColumn
            // 
            ImageColumn.DataPropertyName = "ImagePath";
            ImageColumn.HeaderText = "ICON & LINK";
            ImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            ImageColumn.Name = "ImageColumn";
            ImageColumn.Width = 128;
            // 
            // SummaryColumn
            // 
            SummaryColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            SummaryColumn.DataPropertyName = "Summary";
            SummaryColumn.HeaderText = "概要";
            SummaryColumn.Name = "SummaryColumn";
            SummaryColumn.Width = 340;
            // 
            // ConceptColumn
            // 
            ConceptColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ConceptColumn.DataPropertyName = "Concept";
            ConceptColumn.HeaderText = "技術的コンセプト";
            ConceptColumn.Name = "ConceptColumn";
            ConceptColumn.Width = 340;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            btnAdd.Location = new Point(105, 615);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "追加";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            btnEdit.Location = new Point(219, 615);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 23);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "編集";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            btnDelete.Location = new Point(333, 615);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "削除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSaveCsv
            // 
            btnSaveCsv.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            btnSaveCsv.Location = new Point(447, 615);
            btnSaveCsv.Name = "btnSaveCsv";
            btnSaveCsv.Size = new Size(100, 23);
            btnSaveCsv.TabIndex = 4;
            btnSaveCsv.Text = "CSV保存";
            btnSaveCsv.UseVisualStyleBackColor = true;
            btnSaveCsv.Click += btnSaveCsv_Click;
            // 
            // btnLoadCsv
            // 
            btnLoadCsv.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            btnLoadCsv.Location = new Point(561, 615);
            btnLoadCsv.Name = "btnLoadCsv";
            btnLoadCsv.Size = new Size(100, 23);
            btnLoadCsv.TabIndex = 5;
            btnLoadCsv.Text = "CSV読み込み";
            btnLoadCsv.UseVisualStyleBackColor = true;
            btnLoadCsv.Click += btnLoadCsv_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(903, 63);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(250, 23);
            txtSearch.TabIndex = 6;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            btnSearch.Location = new Point(1148, 64);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnSaveJson
            // 
            btnSaveJson.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            btnSaveJson.Location = new Point(675, 615);
            btnSaveJson.Name = "btnSaveJson";
            btnSaveJson.Size = new Size(100, 23);
            btnSaveJson.TabIndex = 6;
            btnSaveJson.Text = "JSON保存";
            btnSaveJson.UseVisualStyleBackColor = true;
            btnSaveJson.Click += btnSaveJson_Click;
            // 
            // btnLoadJson
            // 
            btnLoadJson.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            btnLoadJson.Location = new Point(789, 615);
            btnLoadJson.Name = "btnLoadJson";
            btnLoadJson.Size = new Size(100, 23);
            btnLoadJson.TabIndex = 7;
            btnLoadJson.Text = "JSON読み込み";
            btnLoadJson.UseVisualStyleBackColor = true;
            btnLoadJson.Click += btnLoadJson_Click;
            // 
            // btnAbout
            // 
            btnAbout.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            btnAbout.Location = new Point(903, 615);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(100, 23);
            btnAbout.TabIndex = 8;
            btnAbout.Text = "このアプリについて";
            btnAbout.UseVisualStyleBackColor = true;
            btnAbout.Click += btnAbout_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            label1.Location = new Point(30, 30);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 9;
            label1.Text = "説明：";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(70, 30);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(808, 55);
            textBox1.TabIndex = 10;
            textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 681);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(btnSaveJson);
            Controls.Add(btnLoadJson);
            Controls.Add(btnAbout);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnLoadCsv);
            Controls.Add(btnSaveCsv);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "PortfolioManager";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn TitleColumn;
        private DataGridViewTextBoxColumn CreatedAtColumn;
        private DataGridViewImageColumn ImageColumn;
        private DataGridViewTextBoxColumn SummaryColumn;
        private DataGridViewTextBoxColumn ConceptColumn;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSaveCsv;
        private Button btnLoadCsv;
        private Button btnSaveJson;
        private Button btnLoadJson;
        private Button btnAbout;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label label1;
        private TextBox textBox1;
    }
}
