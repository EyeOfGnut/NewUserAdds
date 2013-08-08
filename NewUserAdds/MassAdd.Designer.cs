using NewUserAdds.Data_Sets;
namespace NewUserAdds
{
    /// <summary>
    /// Form to allow adding bulk users to a single ECD
    /// </summary>
    partial class MassAdd
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MassAdd));
            this.massAddList = new NewUserAdds.ListViewEx();
            this.LName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.jobCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.degree = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addOns = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.acctTypeBox = new System.Windows.Forms.GroupBox();
            this.vhrBtn = new System.Windows.Forms.RadioButton();
            this.wkstnBtn = new System.Windows.Forms.RadioButton();
            this.clinicComboBox = new System.Windows.Forms.ComboBox();
            this.clinicsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clinicsDataSet = new NewUserAdds.Data_Sets.ClinicsDataSet();
            this.clinicsTableAdapter = new NewUserAdds.Data_Sets.ClinicsDataSetTableAdapters.ClinicsTableAdapter();
            this.clncLabel = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.clncMgrText = new System.Windows.Forms.TextBox();
            this.clncMgrLbl = new System.Windows.Forms.Label();
            this.locationBox = new System.Windows.Forms.GroupBox();
            this.commBtn = new System.Windows.Forms.RadioButton();
            this.fmgBtn = new System.Windows.Forms.RadioButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.acctTypeBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clinicsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinicsDataSet)).BeginInit();
            this.locationBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // massAddList
            // 
            this.massAddList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.massAddList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LName,
            this.FName,
            this.MI,
            this.jobCategory,
            this.degree,
            this.addOns});
            this.massAddList.FullRowSelect = true;
            this.massAddList.GridLines = true;
            this.massAddList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.massAddList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16,
            listViewItem17,
            listViewItem18,
            listViewItem19,
            listViewItem20});
            this.massAddList.Location = new System.Drawing.Point(13, 104);
            this.massAddList.Name = "massAddList";
            this.massAddList.Size = new System.Drawing.Size(657, 238);
            this.massAddList.SmallImageList = this.imageList1;
            this.massAddList.TabIndex = 8;
            this.massAddList.UseCompatibleStateImageBehavior = false;
            this.massAddList.View = System.Windows.Forms.View.Details;
            // 
            // LName
            // 
            this.LName.Text = "Last Name";
            this.LName.Width = 120;
            // 
            // FName
            // 
            this.FName.Text = "First Name";
            this.FName.Width = 97;
            // 
            // MI
            // 
            this.MI.Text = "M.I.";
            this.MI.Width = 32;
            // 
            // jobCategory
            // 
            this.jobCategory.Text = "Job Category";
            this.jobCategory.Width = 96;
            // 
            // degree
            // 
            this.degree.Text = "Degree";
            this.degree.Width = 85;
            // 
            // addOns
            // 
            this.addOns.Text = "Add-Ons";
            this.addOns.Width = 223;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1.jpg");
            // 
            // acctTypeBox
            // 
            this.acctTypeBox.Controls.Add(this.vhrBtn);
            this.acctTypeBox.Controls.Add(this.wkstnBtn);
            this.acctTypeBox.Location = new System.Drawing.Point(13, 54);
            this.acctTypeBox.Name = "acctTypeBox";
            this.acctTypeBox.Size = new System.Drawing.Size(179, 38);
            this.acctTypeBox.TabIndex = 1;
            this.acctTypeBox.TabStop = false;
            this.acctTypeBox.Text = "Account Type";
            // 
            // vhrBtn
            // 
            this.vhrBtn.AutoSize = true;
            this.vhrBtn.Location = new System.Drawing.Point(96, 15);
            this.vhrBtn.Name = "vhrBtn";
            this.vhrBtn.Size = new System.Drawing.Size(75, 17);
            this.vhrBtn.TabIndex = 1;
            this.vhrBtn.TabStop = true;
            this.vhrBtn.Text = "Repository";
            this.vhrBtn.UseVisualStyleBackColor = true;
            this.vhrBtn.CheckedChanged += new System.EventHandler(this.vhrBtn_CheckedChanged);
            // 
            // wkstnBtn
            // 
            this.wkstnBtn.AutoSize = true;
            this.wkstnBtn.Location = new System.Drawing.Point(7, 15);
            this.wkstnBtn.Name = "wkstnBtn";
            this.wkstnBtn.Size = new System.Drawing.Size(82, 17);
            this.wkstnBtn.TabIndex = 0;
            this.wkstnBtn.TabStop = true;
            this.wkstnBtn.Text = "Workstation";
            this.wkstnBtn.UseVisualStyleBackColor = true;
            // 
            // clinicComboBox
            // 
            this.clinicComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.clinicsBindingSource, "id", true));
            this.clinicComboBox.DataSource = this.clinicsBindingSource;
            this.clinicComboBox.DisplayMember = "Company";
            this.clinicComboBox.FormattingEnabled = true;
            this.clinicComboBox.Location = new System.Drawing.Point(245, 27);
            this.clinicComboBox.Name = "clinicComboBox";
            this.clinicComboBox.Size = new System.Drawing.Size(292, 21);
            this.clinicComboBox.TabIndex = 2;
            this.clinicComboBox.ValueMember = "id";
            // 
            // clinicsBindingSource
            // 
            this.clinicsBindingSource.DataMember = "Clinics";
            this.clinicsBindingSource.DataSource = this.clinicsDataSet;
            // 
            // clinicsDataSet
            // 
            this.clinicsDataSet.DataSetName = "ClinicsDataSet";
            this.clinicsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clinicsTableAdapter
            // 
            this.clinicsTableAdapter.ClearBeforeFill = true;
            // 
            // clncLabel
            // 
            this.clncLabel.AutoSize = true;
            this.clncLabel.Location = new System.Drawing.Point(245, 11);
            this.clncLabel.Name = "clncLabel";
            this.clncLabel.Size = new System.Drawing.Size(32, 13);
            this.clncLabel.TabIndex = 3;
            this.clncLabel.Text = "Clinic";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(595, 75);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 4;
            this.okBtn.Text = "Submit";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // clncMgrText
            // 
            this.clncMgrText.Location = new System.Drawing.Point(245, 68);
            this.clncMgrText.Name = "clncMgrText";
            this.clncMgrText.Size = new System.Drawing.Size(292, 20);
            this.clncMgrText.TabIndex = 5;
            // 
            // clncMgrLbl
            // 
            this.clncMgrLbl.AutoSize = true;
            this.clncMgrLbl.Location = new System.Drawing.Point(245, 53);
            this.clncMgrLbl.Name = "clncMgrLbl";
            this.clncMgrLbl.Size = new System.Drawing.Size(77, 13);
            this.clncMgrLbl.TabIndex = 6;
            this.clncMgrLbl.Text = "Clinic Manager";
            // 
            // locationBox
            // 
            this.locationBox.Controls.Add(this.commBtn);
            this.locationBox.Controls.Add(this.fmgBtn);
            this.locationBox.Location = new System.Drawing.Point(13, 11);
            this.locationBox.Name = "locationBox";
            this.locationBox.Size = new System.Drawing.Size(179, 37);
            this.locationBox.TabIndex = 7;
            this.locationBox.TabStop = false;
            this.locationBox.Text = "Location";
            // 
            // commBtn
            // 
            this.commBtn.AutoSize = true;
            this.commBtn.Location = new System.Drawing.Point(95, 14);
            this.commBtn.Name = "commBtn";
            this.commBtn.Size = new System.Drawing.Size(76, 17);
            this.commBtn.TabIndex = 1;
            this.commBtn.TabStop = true;
            this.commBtn.Text = "Community";
            this.commBtn.UseVisualStyleBackColor = true;
            // 
            // fmgBtn
            // 
            this.fmgBtn.AutoSize = true;
            this.fmgBtn.Location = new System.Drawing.Point(7, 14);
            this.fmgBtn.Name = "fmgBtn";
            this.fmgBtn.Size = new System.Drawing.Size(48, 17);
            this.fmgBtn.TabIndex = 0;
            this.fmgBtn.TabStop = true;
            this.fmgBtn.Text = "FMG";
            this.fmgBtn.UseVisualStyleBackColor = true;
            this.fmgBtn.CheckedChanged += new System.EventHandler(this.fmgBtn_CheckedChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(23, 339);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(639, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 9;
            this.progressBar.Visible = false;
            // 
            // MassAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 354);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.massAddList);
            this.Controls.Add(this.locationBox);
            this.Controls.Add(this.clncMgrLbl);
            this.Controls.Add(this.clncMgrText);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.clncLabel);
            this.Controls.Add(this.clinicComboBox);
            this.Controls.Add(this.acctTypeBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MassAdd";
            this.Text = "MassAdd";
            this.Load += new System.EventHandler(this.MassAdd_Load);
            this.acctTypeBox.ResumeLayout(false);
            this.acctTypeBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clinicsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinicsDataSet)).EndInit();
            this.locationBox.ResumeLayout(false);
            this.locationBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListViewEx massAddList;
        private System.Windows.Forms.ColumnHeader LName;
        private System.Windows.Forms.ColumnHeader FName;
        private System.Windows.Forms.ColumnHeader MI;
        private System.Windows.Forms.ColumnHeader jobCategory;
        private System.Windows.Forms.ColumnHeader degree;
        private System.Windows.Forms.ColumnHeader addOns;
        private System.Windows.Forms.GroupBox acctTypeBox;
        private System.Windows.Forms.RadioButton vhrBtn;
        private System.Windows.Forms.RadioButton wkstnBtn;
        private System.Windows.Forms.ComboBox clinicComboBox;
        private ClinicsDataSet clinicsDataSet;
        private System.Windows.Forms.BindingSource clinicsBindingSource;
        private NewUserAdds.Data_Sets.ClinicsDataSetTableAdapters.ClinicsTableAdapter clinicsTableAdapter;
        private System.Windows.Forms.Label clncLabel;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.TextBox clncMgrText;
        private System.Windows.Forms.Label clncMgrLbl;
        private System.Windows.Forms.GroupBox locationBox;
        private System.Windows.Forms.RadioButton commBtn;
        private System.Windows.Forms.RadioButton fmgBtn;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}