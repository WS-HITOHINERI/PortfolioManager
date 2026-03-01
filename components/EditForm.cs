using System.Globalization;

namespace PortfolioManager
{
    public partial class EditForm : Form
    {
        public AppInfo AppInfo { get; private set; }
        public EditForm()
        {
            InitializeComponent();
            AppInfo = new AppInfo();
        }
        public EditForm(AppInfo appInfo)
        {
            InitializeComponent();
            AppInfo = appInfo;

            txtTitle.Text = AppInfo.Title;
            dateTimePickerCreatedAt.Value = DateTime.ParseExact(AppInfo.CreatedAt, "yyyy/MM", CultureInfo.InvariantCulture);
            txtImageUrl.Text = AppInfo.ImageUrl;
            txtLink.Text = AppInfo.Link;
            txtSummary.Text = AppInfo.Summary;
            txtSummary.Multiline = true;
            txtSummary.Height = 80;
            txtSummary.ScrollBars = ScrollBars.Vertical;
            txtConcept.Text = AppInfo.Concept;
            txtConcept.Multiline = true;
            txtConcept.Height = 80;
            txtConcept.ScrollBars = ScrollBars.Vertical;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            AppInfo.Title = txtTitle.Text;
            AppInfo.CreatedAt = dateTimePickerCreatedAt.Value.ToString("yyyy/MM");
            AppInfo.Link = txtLink.Text;
            AppInfo.ImageUrl = txtImageUrl.Text;
            AppInfo.Summary = txtSummary.Text;
            AppInfo.Concept = txtConcept.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
