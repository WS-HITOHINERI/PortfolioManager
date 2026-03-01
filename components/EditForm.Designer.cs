namespace PortfolioManager
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtTitle = new TextBox();
            dateTimePickerCreatedAt = new DateTimePicker();
            label2 = new Label();
            txtLink = new TextBox();
            label3 = new Label();
            txtSummary = new TextBox();
            label4 = new Label();
            txtConcept = new TextBox();
            label5 = new Label();
            btnOk = new Button();
            btnCancel = new Button();
            labelImageUrl = new Label();
            txtImageUrl = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(103, 24);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 0;
            label1.Text = "名称";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(190, 20);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(498, 23);
            txtTitle.TabIndex = 1;
            // 
            // dateTimePickerCreatedAt
            // 
            dateTimePickerCreatedAt.CustomFormat = "yyyy/MM";
            dateTimePickerCreatedAt.Format = DateTimePickerFormat.Custom;
            dateTimePickerCreatedAt.Location = new Point(190, 66);
            dateTimePickerCreatedAt.Name = "dateTimePickerCreatedAt";
            dateTimePickerCreatedAt.ShowUpDown = true;
            dateTimePickerCreatedAt.Size = new Size(498, 23);
            dateTimePickerCreatedAt.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(103, 70);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 2;
            label2.Text = "作成時期";
            // 
            // txtLink
            // 
            txtLink.Location = new Point(188, 112);
            txtLink.Name = "txtLink";
            txtLink.Size = new Size(498, 23);
            txtLink.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(101, 116);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 4;
            label3.Text = "リンク";
            // 
            // txtSummary
            // 
            txtSummary.Location = new Point(186, 202);
            txtSummary.Multiline = true;
            txtSummary.Name = "txtSummary";
            txtSummary.ScrollBars = ScrollBars.Vertical;
            txtSummary.Size = new Size(498, 80);
            txtSummary.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(99, 206);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 6;
            label4.Text = "概要";
            // 
            // txtConcept
            // 
            txtConcept.Location = new Point(190, 305);
            txtConcept.Multiline = true;
            txtConcept.Name = "txtConcept";
            txtConcept.ScrollBars = ScrollBars.Vertical;
            txtConcept.Size = new Size(498, 80);
            txtConcept.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(103, 309);
            label5.Name = "label5";
            label5.Size = new Size(87, 15);
            label5.TabIndex = 8;
            label5.Text = "技術的コンセプト";
            // 
            // btnOk
            // 
            btnOk.Location = new Point(472, 407);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 10;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(612, 407);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "キャンセル";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // labelImageUrl
            // 
            labelImageUrl.AutoSize = true;
            labelImageUrl.Location = new Point(101, 161);
            labelImageUrl.Name = "labelImageUrl";
            labelImageUrl.Size = new Size(57, 15);
            labelImageUrl.TabIndex = 6;
            labelImageUrl.Text = "画像リンク";
            // 
            // txtImageUrl
            // 
            txtImageUrl.Location = new Point(188, 157);
            txtImageUrl.Name = "txtImageUrl";
            txtImageUrl.Size = new Size(498, 23);
            txtImageUrl.TabIndex = 7;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtConcept);
            Controls.Add(label5);
            Controls.Add(txtSummary);
            Controls.Add(label4);
            Controls.Add(txtLink);
            Controls.Add(label3);
            Controls.Add(dateTimePickerCreatedAt);
            Controls.Add(label2);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            Controls.Add(labelImageUrl);
            Controls.Add(txtImageUrl);
            Name = "EditForm";
            Text = "EditForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTitle;
        private DateTimePicker dateTimePickerCreatedAt;
        private Label labelImageUrl;
        private TextBox txtImageUrl;
        private Label label2;
        private TextBox txtLink;
        private Label label3;
        private TextBox txtSummary;
        private Label label4;
        private TextBox txtConcept;
        private Label label5;
        private Button btnOk;
        private Button btnCancel;
    }
}