using NewUserAdds.Data_Sets;
namespace NewUserAdds
{
    partial class newUserMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newUserMain));
            this.clinicDropDown = new System.Windows.Forms.ComboBox();
            this.clinicsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clinicsDataSet = new NewUserAdds.Data_Sets.ClinicsDataSet();
            this.clinicName = new System.Windows.Forms.Label();
            this.firstName = new System.Windows.Forms.TextBox();
            this.fNameLabel = new System.Windows.Forms.Label();
            this.middleInitial = new System.Windows.Forms.TextBox();
            this.middleInitLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.lastName = new System.Windows.Forms.TextBox();
            this.degreeDropDown = new System.Windows.Forms.ComboBox();
            this.degreesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.degreesDataSet = new NewUserAdds.Data_Sets.DegreesDataSet();
            this.jobCategoryDropDown = new System.Windows.Forms.ComboBox();
            this.jobCatLabel = new System.Windows.Forms.Label();
            this.degreeLabel = new System.Windows.Forms.Label();
            this.floatCheckBox = new System.Windows.Forms.CheckBox();
            this.specialtyDropDown = new System.Windows.Forms.ComboBox();
            this.specialtiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.specialtiesDataSet = new NewUserAdds.Data_Sets.SpecialtiesDataSet();
            this.specialtyLabel = new System.Windows.Forms.Label();
            this.deaText = new System.Windows.Forms.TextBox();
            this.deaLabel = new System.Windows.Forms.Label();
            this.npiText = new System.Windows.Forms.TextBox();
            this.npiLabel = new System.Windows.Forms.Label();
            this.emailText = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.fmgRB = new System.Windows.Forms.RadioButton();
            this.commRB = new System.Windows.Forms.RadioButton();
            this.intExtGroupBox = new System.Windows.Forms.GroupBox();
            this.taskTxt = new System.Windows.Forms.TextBox();
            this.taskLbl = new System.Windows.Forms.Label();
            this.addUserBtn = new System.Windows.Forms.Button();
            this.userTypeDropDown = new System.Windows.Forms.ComboBox();
            this.userTypeLabel = new System.Windows.Forms.Label();
            this.clinicsTableAdapter1 = new NewUserAdds.Data_Sets.ClinicsDataSetTableAdapters.ClinicsTableAdapter();
            this.specialtiesTableAdapter1 = new NewUserAdds.Data_Sets.SpecialtiesDataSetTableAdapters.SpecialtiesTableAdapter();
            this.pendingBtn = new System.Windows.Forms.Button();
            this.manageClinicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dsPending = new System.Data.DataSet();
            this.fltPwLabel = new System.Windows.Forms.Label();
            this.ecdLabel = new System.Windows.Forms.Label();
            this.clinicText = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.phoneText = new System.Windows.Forms.TextBox();
            this.faxLabel = new System.Windows.Forms.Label();
            this.faxText = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.addressText = new System.Windows.Forms.TextBox();
            this.cityLabel = new System.Windows.Forms.Label();
            this.cityText = new System.Windows.Forms.TextBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.stateText = new System.Windows.Forms.TextBox();
            this.zipLabel = new System.Windows.Forms.Label();
            this.zipText = new System.Windows.Forms.TextBox();
            this.clncMgrTxt = new System.Windows.Forms.TextBox();
            this.clncMgrLbl = new System.Windows.Forms.Label();
            this.faxClncGrp = new System.Windows.Forms.GroupBox();
            this.clncLbl = new System.Windows.Forms.Label();
            this.loginClncGrp = new System.Windows.Forms.GroupBox();
            this.arfLabel = new System.Windows.Forms.LinkLabel();
            this.arfButton = new System.Windows.Forms.Button();
            this.fnameReq = new System.Windows.Forms.Label();
            this.lnameReq = new System.Windows.Forms.Label();
            this.fNameTT = new System.Windows.Forms.ToolTip(this.components);
            this.addOnGroupBox = new System.Windows.Forms.GroupBox();
            this.ioChkBx = new System.Windows.Forms.CheckBox();
            this.rxChkBx = new System.Windows.Forms.CheckBox();
            this.epiChkBx = new System.Windows.Forms.CheckBox();
            this.repChkBx = new System.Windows.Forms.CheckBox();
            this.providerGrpBx = new System.Windows.Forms.GroupBox();
            this.transLbl = new System.Windows.Forms.Label();
            this.transCB = new System.Windows.Forms.ComboBox();
            this.upinTxt = new System.Windows.Forms.TextBox();
            this.upinLbl = new System.Windows.Forms.Label();
            this.starIdTxt = new System.Windows.Forms.TextBox();
            this.starIdLbl = new System.Windows.Forms.Label();
            this.specialtiesDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.specialtiesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.degreesTableAdapter = new NewUserAdds.Data_Sets.DegreesDataSetTableAdapters.DegreesTableAdapter();
            this.editMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.providerInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.faxRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newUserLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mngClinMI = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDegreesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageSpecialtiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.restorePendingListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminAccountsBlastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sSNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssnOffsetMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fltPwText = new System.Windows.Forms.TextBox();
            this.ssoIdTxtBx = new System.Windows.Forms.TextBox();
            this.ssoIdLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clinicsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinicsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.degreesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.degreesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialtiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialtiesDataSet)).BeginInit();
            this.intExtGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsPending)).BeginInit();
            this.faxClncGrp.SuspendLayout();
            this.loginClncGrp.SuspendLayout();
            this.addOnGroupBox.SuspendLayout();
            this.providerGrpBx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.specialtiesDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialtiesBindingSource1)).BeginInit();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // clinicDropDown
            // 
            this.clinicDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.clinicsBindingSource, "id", true));
            this.clinicDropDown.DataSource = this.clinicsBindingSource;
            this.clinicDropDown.DisplayMember = "Company";
            this.clinicDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clinicDropDown.FormattingEnabled = true;
            this.clinicDropDown.Location = new System.Drawing.Point(6, 35);
            this.clinicDropDown.Name = "clinicDropDown";
            this.clinicDropDown.Size = new System.Drawing.Size(318, 21);
            this.clinicDropDown.TabIndex = 0;
            this.clinicDropDown.ValueMember = "id";
            this.clinicDropDown.SelectedIndexChanged += new System.EventHandler(this.clinicDropDown_SelectedIndexChanged);
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
            // clinicName
            // 
            this.clinicName.AutoSize = true;
            this.clinicName.Location = new System.Drawing.Point(6, 21);
            this.clinicName.Name = "clinicName";
            this.clinicName.Size = new System.Drawing.Size(32, 13);
            this.clinicName.TabIndex = 1;
            this.clinicName.Text = "Clinic";
            // 
            // firstName
            // 
            this.firstName.Location = new System.Drawing.Point(12, 136);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(137, 20);
            this.firstName.TabIndex = 4;
            this.firstName.Click += new System.EventHandler(this.firstName_Click);
            this.firstName.Enter += new System.EventHandler(this.firstName_Enter);
            // 
            // fNameLabel
            // 
            this.fNameLabel.AutoSize = true;
            this.fNameLabel.Location = new System.Drawing.Point(9, 116);
            this.fNameLabel.Name = "fNameLabel";
            this.fNameLabel.Size = new System.Drawing.Size(57, 13);
            this.fNameLabel.TabIndex = 3;
            this.fNameLabel.Text = "First Name";
            // 
            // middleInitial
            // 
            this.middleInitial.Location = new System.Drawing.Point(156, 135);
            this.middleInitial.Name = "middleInitial";
            this.middleInitial.Size = new System.Drawing.Size(22, 20);
            this.middleInitial.TabIndex = 5;
            // 
            // middleInitLabel
            // 
            this.middleInitLabel.AutoSize = true;
            this.middleInitLabel.Location = new System.Drawing.Point(153, 116);
            this.middleInitLabel.Name = "middleInitLabel";
            this.middleInitLabel.Size = new System.Drawing.Size(25, 13);
            this.middleInitLabel.TabIndex = 5;
            this.middleInitLabel.Text = "M.I.";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(181, 115);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(58, 13);
            this.lastNameLabel.TabIndex = 6;
            this.lastNameLabel.Text = "Last Name";
            // 
            // lastName
            // 
            this.lastName.Location = new System.Drawing.Point(184, 136);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(139, 20);
            this.lastName.TabIndex = 6;
            // 
            // degreeDropDown
            // 
            this.degreeDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.degreesBindingSource, "ID", true));
            this.degreeDropDown.DataSource = this.degreesBindingSource;
            this.degreeDropDown.DisplayMember = "Degree";
            this.degreeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.degreeDropDown.FormattingEnabled = true;
            this.degreeDropDown.Location = new System.Drawing.Point(411, 90);
            this.degreeDropDown.Name = "degreeDropDown";
            this.degreeDropDown.Size = new System.Drawing.Size(121, 21);
            this.degreeDropDown.TabIndex = 8;
            this.degreeDropDown.ValueMember = "ID";
            this.degreeDropDown.Visible = false;
            // 
            // degreesBindingSource
            // 
            this.degreesBindingSource.DataMember = "Degrees";
            this.degreesBindingSource.DataSource = this.degreesDataSet;
            // 
            // degreesDataSet
            // 
            this.degreesDataSet.DataSetName = "DegreesDataSet";
            this.degreesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // jobCategoryDropDown
            // 
            this.jobCategoryDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jobCategoryDropDown.FormattingEnabled = true;
            this.jobCategoryDropDown.Items.AddRange(new object[] {
            "Staff-I",
            "Licensed Health Professional",
            "Medical Doctor"});
            this.jobCategoryDropDown.Location = new System.Drawing.Point(271, 91);
            this.jobCategoryDropDown.Name = "jobCategoryDropDown";
            this.jobCategoryDropDown.Size = new System.Drawing.Size(121, 21);
            this.jobCategoryDropDown.TabIndex = 3;
            this.jobCategoryDropDown.SelectedIndexChanged += new System.EventHandler(this.jobCategoryDropDown_SelectedIndexChanged);
            // 
            // jobCatLabel
            // 
            this.jobCatLabel.AutoSize = true;
            this.jobCatLabel.Location = new System.Drawing.Point(268, 73);
            this.jobCatLabel.Name = "jobCatLabel";
            this.jobCatLabel.Size = new System.Drawing.Size(69, 13);
            this.jobCatLabel.TabIndex = 10;
            this.jobCatLabel.Text = "Job Category";
            // 
            // degreeLabel
            // 
            this.degreeLabel.AutoSize = true;
            this.degreeLabel.Location = new System.Drawing.Point(408, 71);
            this.degreeLabel.Name = "degreeLabel";
            this.degreeLabel.Size = new System.Drawing.Size(42, 13);
            this.degreeLabel.TabIndex = 11;
            this.degreeLabel.Text = "Degree";
            this.degreeLabel.Visible = false;
            // 
            // floatCheckBox
            // 
            this.floatCheckBox.AutoSize = true;
            this.floatCheckBox.Location = new System.Drawing.Point(422, 45);
            this.floatCheckBox.Name = "floatCheckBox";
            this.floatCheckBox.Size = new System.Drawing.Size(92, 17);
            this.floatCheckBox.TabIndex = 12;
            this.floatCheckBox.Text = "Float Account";
            this.floatCheckBox.UseVisualStyleBackColor = true;
            this.floatCheckBox.CheckedChanged += new System.EventHandler(this.floatCheckBox_CheckedChanged);
            // 
            // specialtyDropDown
            // 
            this.specialtyDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.specialtiesBindingSource, "id", true));
            this.specialtyDropDown.DataSource = this.specialtiesBindingSource;
            this.specialtyDropDown.DisplayMember = "Specialty";
            this.specialtyDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.specialtyDropDown.FormattingEnabled = true;
            this.specialtyDropDown.Location = new System.Drawing.Point(10, 46);
            this.specialtyDropDown.Name = "specialtyDropDown";
            this.specialtyDropDown.Size = new System.Drawing.Size(121, 21);
            this.specialtyDropDown.TabIndex = 13;
            this.specialtyDropDown.ValueMember = "id";
            // 
            // specialtiesBindingSource
            // 
            this.specialtiesBindingSource.DataMember = "Specialties";
            this.specialtiesBindingSource.DataSource = this.specialtiesDataSet;
            // 
            // specialtiesDataSet
            // 
            this.specialtiesDataSet.DataSetName = "SpecialtiesDataSet";
            this.specialtiesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // specialtyLabel
            // 
            this.specialtyLabel.AutoSize = true;
            this.specialtyLabel.Location = new System.Drawing.Point(10, 27);
            this.specialtyLabel.Name = "specialtyLabel";
            this.specialtyLabel.Size = new System.Drawing.Size(50, 13);
            this.specialtyLabel.TabIndex = 14;
            this.specialtyLabel.Text = "Specialty";
            // 
            // deaText
            // 
            this.deaText.Location = new System.Drawing.Point(279, 47);
            this.deaText.Name = "deaText";
            this.deaText.Size = new System.Drawing.Size(121, 20);
            this.deaText.TabIndex = 15;
            // 
            // deaLabel
            // 
            this.deaLabel.AutoSize = true;
            this.deaLabel.Location = new System.Drawing.Point(276, 27);
            this.deaLabel.Name = "deaLabel";
            this.deaLabel.Size = new System.Drawing.Size(29, 13);
            this.deaLabel.TabIndex = 16;
            this.deaLabel.Text = "DEA";
            // 
            // npiText
            // 
            this.npiText.Location = new System.Drawing.Point(157, 47);
            this.npiText.Name = "npiText";
            this.npiText.Size = new System.Drawing.Size(100, 20);
            this.npiText.TabIndex = 17;
            // 
            // npiLabel
            // 
            this.npiLabel.AutoSize = true;
            this.npiLabel.Location = new System.Drawing.Point(154, 27);
            this.npiLabel.Name = "npiLabel";
            this.npiLabel.Size = new System.Drawing.Size(25, 13);
            this.npiLabel.TabIndex = 18;
            this.npiLabel.Text = "NPI";
            // 
            // emailText
            // 
            this.emailText.Enabled = false;
            this.emailText.Location = new System.Drawing.Point(422, 45);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(211, 20);
            this.emailText.TabIndex = 19;
            this.emailText.Visible = false;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Enabled = false;
            this.emailLabel.Location = new System.Drawing.Point(419, 27);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(73, 13);
            this.emailLabel.TabIndex = 20;
            this.emailLabel.Text = "Email Address";
            this.emailLabel.Visible = false;
            // 
            // fmgRB
            // 
            this.fmgRB.AutoSize = true;
            this.fmgRB.Checked = true;
            this.fmgRB.Location = new System.Drawing.Point(6, 44);
            this.fmgRB.Name = "fmgRB";
            this.fmgRB.Size = new System.Drawing.Size(91, 17);
            this.fmgRB.TabIndex = 21;
            this.fmgRB.TabStop = true;
            this.fmgRB.Text = "FMG Account";
            this.fmgRB.UseVisualStyleBackColor = true;
            // 
            // commRB
            // 
            this.commRB.AutoSize = true;
            this.commRB.Location = new System.Drawing.Point(106, 44);
            this.commRB.Name = "commRB";
            this.commRB.Size = new System.Drawing.Size(119, 17);
            this.commRB.TabIndex = 22;
            this.commRB.Text = "Community Account";
            this.commRB.UseVisualStyleBackColor = true;
            this.commRB.CheckedChanged += new System.EventHandler(this.commRB_CheckedChanged);
            // 
            // intExtGroupBox
            // 
            this.intExtGroupBox.Controls.Add(this.taskTxt);
            this.intExtGroupBox.Controls.Add(this.taskLbl);
            this.intExtGroupBox.Controls.Add(this.fmgRB);
            this.intExtGroupBox.Controls.Add(this.commRB);
            this.intExtGroupBox.Location = new System.Drawing.Point(12, 27);
            this.intExtGroupBox.Name = "intExtGroupBox";
            this.intExtGroupBox.Size = new System.Drawing.Size(234, 74);
            this.intExtGroupBox.TabIndex = 23;
            this.intExtGroupBox.TabStop = false;
            // 
            // taskTxt
            // 
            this.taskTxt.Location = new System.Drawing.Point(83, 13);
            this.taskTxt.Name = "taskTxt";
            this.taskTxt.Size = new System.Drawing.Size(142, 20);
            this.taskTxt.TabIndex = 1;
            // 
            // taskLbl
            // 
            this.taskLbl.AutoSize = true;
            this.taskLbl.Location = new System.Drawing.Point(6, 16);
            this.taskLbl.Name = "taskLbl";
            this.taskLbl.Size = new System.Drawing.Size(71, 13);
            this.taskLbl.TabIndex = 23;
            this.taskLbl.Text = "Task Number";
            // 
            // addUserBtn
            // 
            this.addUserBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addUserBtn.Location = new System.Drawing.Point(21, 375);
            this.addUserBtn.Name = "addUserBtn";
            this.addUserBtn.Size = new System.Drawing.Size(88, 23);
            this.addUserBtn.TabIndex = 24;
            this.addUserBtn.Text = "Add to Pending";
            this.addUserBtn.UseVisualStyleBackColor = true;
            this.addUserBtn.Click += new System.EventHandler(this.addUserBtn_Click);
            // 
            // userTypeDropDown
            // 
            this.userTypeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userTypeDropDown.FormattingEnabled = true;
            this.userTypeDropDown.Items.AddRange(new object[] {
            "Workstation",
            "Repository",
            "Fax"});
            this.userTypeDropDown.Location = new System.Drawing.Point(271, 43);
            this.userTypeDropDown.Name = "userTypeDropDown";
            this.userTypeDropDown.Size = new System.Drawing.Size(121, 21);
            this.userTypeDropDown.TabIndex = 2;
            this.userTypeDropDown.SelectedIndexChanged += new System.EventHandler(this.userTypeDropDown_SelectedIndexChanged);
            // 
            // userTypeLabel
            // 
            this.userTypeLabel.AutoSize = true;
            this.userTypeLabel.Location = new System.Drawing.Point(268, 27);
            this.userTypeLabel.Name = "userTypeLabel";
            this.userTypeLabel.Size = new System.Drawing.Size(56, 13);
            this.userTypeLabel.TabIndex = 26;
            this.userTypeLabel.Text = "User Type";
            // 
            // clinicsTableAdapter1
            // 
            this.clinicsTableAdapter1.ClearBeforeFill = true;
            // 
            // specialtiesTableAdapter1
            // 
            this.specialtiesTableAdapter1.ClearBeforeFill = true;
            // 
            // pendingBtn
            // 
            this.pendingBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pendingBtn.Location = new System.Drawing.Point(115, 375);
            this.pendingBtn.Name = "pendingBtn";
            this.pendingBtn.Size = new System.Drawing.Size(122, 23);
            this.pendingBtn.TabIndex = 28;
            this.pendingBtn.Text = "View Pending Users";
            this.pendingBtn.UseVisualStyleBackColor = true;
            this.pendingBtn.Click += new System.EventHandler(this.pendingBtn_Click);
            // 
            // manageClinicsToolStripMenuItem
            // 
            this.manageClinicsToolStripMenuItem.Name = "manageClinicsToolStripMenuItem";
            this.manageClinicsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.manageClinicsToolStripMenuItem.Text = "Manage Clinics";
            // 
            // dsPending
            // 
            this.dsPending.DataSetName = "Pending";
            // 
            // fltPwLabel
            // 
            this.fltPwLabel.AutoSize = true;
            this.fltPwLabel.Location = new System.Drawing.Point(530, 27);
            this.fltPwLabel.Name = "fltPwLabel";
            this.fltPwLabel.Size = new System.Drawing.Size(89, 13);
            this.fltPwLabel.TabIndex = 31;
            this.fltPwLabel.Text = "Orignal Password";
            this.fltPwLabel.Visible = false;
            // 
            // ecdLabel
            // 
            this.ecdLabel.AutoSize = true;
            this.ecdLabel.Location = new System.Drawing.Point(6, 63);
            this.ecdLabel.Name = "ecdLabel";
            this.ecdLabel.Size = new System.Drawing.Size(32, 13);
            this.ecdLabel.TabIndex = 32;
            this.ecdLabel.Text = "ECD:";
            this.ecdLabel.Visible = false;
            // 
            // clinicText
            // 
            this.clinicText.Location = new System.Drawing.Point(6, 37);
            this.clinicText.Name = "clinicText";
            this.clinicText.Size = new System.Drawing.Size(318, 20);
            this.clinicText.TabIndex = 33;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(6, 64);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(38, 13);
            this.phoneLabel.TabIndex = 34;
            this.phoneLabel.Text = "Phone";
            // 
            // phoneText
            // 
            this.phoneText.Location = new System.Drawing.Point(6, 80);
            this.phoneText.Name = "phoneText";
            this.phoneText.Size = new System.Drawing.Size(100, 20);
            this.phoneText.TabIndex = 35;
            // 
            // faxLabel
            // 
            this.faxLabel.AutoSize = true;
            this.faxLabel.Location = new System.Drawing.Point(115, 65);
            this.faxLabel.Name = "faxLabel";
            this.faxLabel.Size = new System.Drawing.Size(24, 13);
            this.faxLabel.TabIndex = 36;
            this.faxLabel.Text = "Fax";
            // 
            // faxText
            // 
            this.faxText.Location = new System.Drawing.Point(118, 80);
            this.faxText.Name = "faxText";
            this.faxText.Size = new System.Drawing.Size(100, 20);
            this.faxText.TabIndex = 37;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(370, 21);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(45, 13);
            this.addressLabel.TabIndex = 38;
            this.addressLabel.Text = "Address";
            // 
            // addressText
            // 
            this.addressText.Location = new System.Drawing.Point(373, 37);
            this.addressText.Name = "addressText";
            this.addressText.Size = new System.Drawing.Size(240, 20);
            this.addressText.TabIndex = 39;
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(370, 62);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(24, 13);
            this.cityLabel.TabIndex = 40;
            this.cityLabel.Text = "City";
            // 
            // cityText
            // 
            this.cityText.Location = new System.Drawing.Point(373, 79);
            this.cityText.Name = "cityText";
            this.cityText.Size = new System.Drawing.Size(100, 20);
            this.cityText.TabIndex = 41;
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(473, 62);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(32, 13);
            this.stateLabel.TabIndex = 42;
            this.stateLabel.Text = "State";
            // 
            // stateText
            // 
            this.stateText.Location = new System.Drawing.Point(476, 79);
            this.stateText.Name = "stateText";
            this.stateText.Size = new System.Drawing.Size(29, 20);
            this.stateText.TabIndex = 43;
            // 
            // zipLabel
            // 
            this.zipLabel.AutoSize = true;
            this.zipLabel.Location = new System.Drawing.Point(510, 62);
            this.zipLabel.Name = "zipLabel";
            this.zipLabel.Size = new System.Drawing.Size(22, 13);
            this.zipLabel.TabIndex = 44;
            this.zipLabel.Text = "Zip";
            // 
            // zipText
            // 
            this.zipText.Location = new System.Drawing.Point(513, 79);
            this.zipText.Name = "zipText";
            this.zipText.Size = new System.Drawing.Size(67, 20);
            this.zipText.TabIndex = 45;
            // 
            // clncMgrTxt
            // 
            this.clncMgrTxt.Location = new System.Drawing.Point(382, 37);
            this.clncMgrTxt.Name = "clncMgrTxt";
            this.clncMgrTxt.Size = new System.Drawing.Size(171, 20);
            this.clncMgrTxt.TabIndex = 46;
            // 
            // clncMgrLbl
            // 
            this.clncMgrLbl.AutoSize = true;
            this.clncMgrLbl.Location = new System.Drawing.Point(379, 21);
            this.clncMgrLbl.Name = "clncMgrLbl";
            this.clncMgrLbl.Size = new System.Drawing.Size(77, 13);
            this.clncMgrLbl.TabIndex = 47;
            this.clncMgrLbl.Text = "Clinic Manager";
            // 
            // faxClncGrp
            // 
            this.faxClncGrp.Controls.Add(this.clinicText);
            this.faxClncGrp.Controls.Add(this.clinicName);
            this.faxClncGrp.Controls.Add(this.addressLabel);
            this.faxClncGrp.Controls.Add(this.addressText);
            this.faxClncGrp.Controls.Add(this.faxText);
            this.faxClncGrp.Controls.Add(this.zipText);
            this.faxClncGrp.Controls.Add(this.faxLabel);
            this.faxClncGrp.Controls.Add(this.phoneLabel);
            this.faxClncGrp.Controls.Add(this.zipLabel);
            this.faxClncGrp.Controls.Add(this.phoneText);
            this.faxClncGrp.Controls.Add(this.stateText);
            this.faxClncGrp.Controls.Add(this.cityText);
            this.faxClncGrp.Controls.Add(this.stateLabel);
            this.faxClncGrp.Controls.Add(this.cityLabel);
            this.faxClncGrp.Location = new System.Drawing.Point(9, 170);
            this.faxClncGrp.Name = "faxClncGrp";
            this.faxClncGrp.Size = new System.Drawing.Size(627, 108);
            this.faxClncGrp.TabIndex = 48;
            this.faxClncGrp.TabStop = false;
            this.faxClncGrp.Text = "Clinic Information";
            this.faxClncGrp.Visible = false;
            // 
            // clncLbl
            // 
            this.clncLbl.AutoSize = true;
            this.clncLbl.Location = new System.Drawing.Point(6, 19);
            this.clncLbl.Name = "clncLbl";
            this.clncLbl.Size = new System.Drawing.Size(32, 13);
            this.clncLbl.TabIndex = 49;
            this.clncLbl.Text = "Clinic";
            // 
            // loginClncGrp
            // 
            this.loginClncGrp.Controls.Add(this.clncMgrTxt);
            this.loginClncGrp.Controls.Add(this.clncMgrLbl);
            this.loginClncGrp.Controls.Add(this.clinicDropDown);
            this.loginClncGrp.Controls.Add(this.ecdLabel);
            this.loginClncGrp.Controls.Add(this.clncLbl);
            this.loginClncGrp.Location = new System.Drawing.Point(9, 171);
            this.loginClncGrp.Name = "loginClncGrp";
            this.loginClncGrp.Size = new System.Drawing.Size(627, 98);
            this.loginClncGrp.TabIndex = 50;
            this.loginClncGrp.TabStop = false;
            this.loginClncGrp.Text = "Clinic Information";
            // 
            // arfLabel
            // 
            this.arfLabel.AutoSize = true;
            this.arfLabel.Location = new System.Drawing.Point(567, 138);
            this.arfLabel.Name = "arfLabel";
            this.arfLabel.Size = new System.Drawing.Size(111, 13);
            this.arfLabel.TabIndex = 51;
            this.arfLabel.TabStop = true;
            this.arfLabel.Text = "Access Request Form";
            this.arfLabel.Visible = false;
            this.arfLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.arfLabel_LinkClicked);
            // 
            // arfButton
            // 
            this.arfButton.Location = new System.Drawing.Point(446, 133);
            this.arfButton.Name = "arfButton";
            this.arfButton.Size = new System.Drawing.Size(116, 23);
            this.arfButton.TabIndex = 7;
            this.arfButton.Text = "Link to Request Form";
            this.arfButton.UseVisualStyleBackColor = true;
            this.arfButton.Click += new System.EventHandler(this.arfButton_Click);
            // 
            // fnameReq
            // 
            this.fnameReq.AutoSize = true;
            this.fnameReq.ForeColor = System.Drawing.Color.Red;
            this.fnameReq.Location = new System.Drawing.Point(61, 115);
            this.fnameReq.Name = "fnameReq";
            this.fnameReq.Size = new System.Drawing.Size(11, 13);
            this.fnameReq.TabIndex = 53;
            this.fnameReq.Text = "*";
            // 
            // lnameReq
            // 
            this.lnameReq.AutoSize = true;
            this.lnameReq.ForeColor = System.Drawing.Color.Red;
            this.lnameReq.Location = new System.Drawing.Point(242, 116);
            this.lnameReq.Name = "lnameReq";
            this.lnameReq.Size = new System.Drawing.Size(11, 13);
            this.lnameReq.TabIndex = 54;
            this.lnameReq.Text = "*";
            // 
            // addOnGroupBox
            // 
            this.addOnGroupBox.Controls.Add(this.ioChkBx);
            this.addOnGroupBox.Controls.Add(this.rxChkBx);
            this.addOnGroupBox.Controls.Add(this.epiChkBx);
            this.addOnGroupBox.Controls.Add(this.repChkBx);
            this.addOnGroupBox.Location = new System.Drawing.Point(662, 170);
            this.addOnGroupBox.Name = "addOnGroupBox";
            this.addOnGroupBox.Size = new System.Drawing.Size(180, 112);
            this.addOnGroupBox.TabIndex = 55;
            this.addOnGroupBox.TabStop = false;
            this.addOnGroupBox.Text = "Add Ons";
            // 
            // ioChkBx
            // 
            this.ioChkBx.AutoSize = true;
            this.ioChkBx.Location = new System.Drawing.Point(7, 87);
            this.ioChkBx.Name = "ioChkBx";
            this.ioChkBx.Size = new System.Drawing.Size(152, 17);
            this.ioChkBx.TabIndex = 3;
            this.ioChkBx.Text = "Elysium Intelligent Ordering";
            this.ioChkBx.UseVisualStyleBackColor = true;
            // 
            // rxChkBx
            // 
            this.rxChkBx.AutoSize = true;
            this.rxChkBx.Location = new System.Drawing.Point(7, 64);
            this.rxChkBx.Name = "rxChkBx";
            this.rxChkBx.Size = new System.Drawing.Size(150, 17);
            this.rxChkBx.TabIndex = 2;
            this.rxChkBx.Text = "Elysium Prescription Writer";
            this.rxChkBx.UseVisualStyleBackColor = true;
            // 
            // epiChkBx
            // 
            this.epiChkBx.AutoSize = true;
            this.epiChkBx.Location = new System.Drawing.Point(7, 41);
            this.epiChkBx.Name = "epiChkBx";
            this.epiChkBx.Size = new System.Drawing.Size(109, 17);
            this.epiChkBx.TabIndex = 1;
            this.epiChkBx.Text = "Edit Patient Index";
            this.epiChkBx.UseVisualStyleBackColor = true;
            // 
            // repChkBx
            // 
            this.repChkBx.AutoSize = true;
            this.repChkBx.Checked = true;
            this.repChkBx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.repChkBx.Location = new System.Drawing.Point(7, 19);
            this.repChkBx.Name = "repChkBx";
            this.repChkBx.Size = new System.Drawing.Size(152, 17);
            this.repChkBx.TabIndex = 0;
            this.repChkBx.Text = "Elysium Repository Access";
            this.repChkBx.UseVisualStyleBackColor = true;
            // 
            // providerGrpBx
            // 
            this.providerGrpBx.Controls.Add(this.transLbl);
            this.providerGrpBx.Controls.Add(this.transCB);
            this.providerGrpBx.Controls.Add(this.upinTxt);
            this.providerGrpBx.Controls.Add(this.upinLbl);
            this.providerGrpBx.Controls.Add(this.starIdTxt);
            this.providerGrpBx.Controls.Add(this.starIdLbl);
            this.providerGrpBx.Controls.Add(this.specialtyLabel);
            this.providerGrpBx.Controls.Add(this.specialtyDropDown);
            this.providerGrpBx.Controls.Add(this.deaText);
            this.providerGrpBx.Controls.Add(this.deaLabel);
            this.providerGrpBx.Controls.Add(this.npiText);
            this.providerGrpBx.Controls.Add(this.npiLabel);
            this.providerGrpBx.Location = new System.Drawing.Point(9, 289);
            this.providerGrpBx.Name = "providerGrpBx";
            this.providerGrpBx.Size = new System.Drawing.Size(833, 81);
            this.providerGrpBx.TabIndex = 56;
            this.providerGrpBx.TabStop = false;
            this.providerGrpBx.Text = "Provider Information";
            this.providerGrpBx.Visible = false;
            // 
            // transLbl
            // 
            this.transLbl.AutoSize = true;
            this.transLbl.Location = new System.Drawing.Point(699, 27);
            this.transLbl.Name = "transLbl";
            this.transLbl.Size = new System.Drawing.Size(107, 13);
            this.transLbl.TabIndex = 24;
            this.transLbl.Text = "Transcription Service";
            // 
            // transCB
            // 
            this.transCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transCB.FormattingEnabled = true;
            this.transCB.Items.AddRange(new object[] {
            "(None | Other)",
            "TNI",
            "OnShore (Axolotl)",
            "Dragon"});
            this.transCB.Location = new System.Drawing.Point(699, 46);
            this.transCB.Name = "transCB";
            this.transCB.Size = new System.Drawing.Size(121, 21);
            this.transCB.TabIndex = 23;
            // 
            // upinTxt
            // 
            this.upinTxt.Location = new System.Drawing.Point(561, 47);
            this.upinTxt.Name = "upinTxt";
            this.upinTxt.Size = new System.Drawing.Size(121, 20);
            this.upinTxt.TabIndex = 21;
            // 
            // upinLbl
            // 
            this.upinLbl.AutoSize = true;
            this.upinLbl.Location = new System.Drawing.Point(558, 27);
            this.upinLbl.Name = "upinLbl";
            this.upinLbl.Size = new System.Drawing.Size(33, 13);
            this.upinLbl.TabIndex = 22;
            this.upinLbl.Text = "UPIN";
            // 
            // starIdTxt
            // 
            this.starIdTxt.Location = new System.Drawing.Point(417, 47);
            this.starIdTxt.Name = "starIdTxt";
            this.starIdTxt.Size = new System.Drawing.Size(121, 20);
            this.starIdTxt.TabIndex = 19;
            // 
            // starIdLbl
            // 
            this.starIdLbl.AutoSize = true;
            this.starIdLbl.Location = new System.Drawing.Point(414, 27);
            this.starIdLbl.Name = "starIdLbl";
            this.starIdLbl.Size = new System.Drawing.Size(50, 13);
            this.starIdLbl.TabIndex = 20;
            this.starIdLbl.Text = "STAR ID";
            // 
            // specialtiesDataSetBindingSource
            // 
            this.specialtiesDataSetBindingSource.DataSource = this.specialtiesDataSet;
            this.specialtiesDataSetBindingSource.Position = 0;
            // 
            // specialtiesBindingSource1
            // 
            this.specialtiesBindingSource1.DataMember = "Specialties";
            this.specialtiesBindingSource1.DataSource = this.specialtiesDataSetBindingSource;
            // 
            // degreesTableAdapter
            // 
            this.degreesTableAdapter.ClearBeforeFill = true;
            // 
            // editMnu
            // 
            this.editMnu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.newUserLogToolStripMenuItem,
            this.toolStripSeparator2,
            this.mngClinMI,
            this.manageDegreesToolStripMenuItem,
            this.manageSpecialtiesToolStripMenuItem,
            this.toolStripSeparator1,
            this.restorePendingListToolStripMenuItem});
            this.editMnu.Name = "editMnu";
            this.editMnu.Size = new System.Drawing.Size(37, 20);
            this.editMnu.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.providerInfoToolStripMenuItem,
            this.faxRequestToolStripMenuItem,
            this.fromFileToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.importToolStripMenuItem.Text = "Import Fax List";
            // 
            // providerInfoToolStripMenuItem
            // 
            this.providerInfoToolStripMenuItem.Name = "providerInfoToolStripMenuItem";
            this.providerInfoToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.providerInfoToolStripMenuItem.Text = "From \"Provider Info\"";
            this.providerInfoToolStripMenuItem.Click += new System.EventHandler(this.providerInfoToolStripMenuItem_Click);
            // 
            // faxRequestToolStripMenuItem
            // 
            this.faxRequestToolStripMenuItem.Name = "faxRequestToolStripMenuItem";
            this.faxRequestToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.faxRequestToolStripMenuItem.Text = "From \"Referral Account Request\"";
            this.faxRequestToolStripMenuItem.Click += new System.EventHandler(this.faxRequestToolStripMenuItem_Click);
            // 
            // fromFileToolStripMenuItem
            // 
            this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
            this.fromFileToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.fromFileToolStripMenuItem.Text = "From File...";
            this.fromFileToolStripMenuItem.Click += new System.EventHandler(this.fromFileToolStripMenuItem_Click);
            // 
            // newUserLogToolStripMenuItem
            // 
            this.newUserLogToolStripMenuItem.Name = "newUserLogToolStripMenuItem";
            this.newUserLogToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.newUserLogToolStripMenuItem.Text = "View Log";
            this.newUserLogToolStripMenuItem.Click += new System.EventHandler(this.newUserLogToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // mngClinMI
            // 
            this.mngClinMI.Name = "mngClinMI";
            this.mngClinMI.Size = new System.Drawing.Size(181, 22);
            this.mngClinMI.Text = "Manage Clinics";
            this.mngClinMI.Click += new System.EventHandler(this.manageClinicsToolStripMenuItem_Click);
            // 
            // manageDegreesToolStripMenuItem
            // 
            this.manageDegreesToolStripMenuItem.Name = "manageDegreesToolStripMenuItem";
            this.manageDegreesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.manageDegreesToolStripMenuItem.Text = "Manage Degrees";
            this.manageDegreesToolStripMenuItem.Click += new System.EventHandler(this.manageDegreesToolStripMenuItem_Click);
            // 
            // manageSpecialtiesToolStripMenuItem
            // 
            this.manageSpecialtiesToolStripMenuItem.Name = "manageSpecialtiesToolStripMenuItem";
            this.manageSpecialtiesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.manageSpecialtiesToolStripMenuItem.Text = "Manage Specialties";
            this.manageSpecialtiesToolStripMenuItem.Click += new System.EventHandler(this.manageSpecialtiesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // restorePendingListToolStripMenuItem
            // 
            this.restorePendingListToolStripMenuItem.Name = "restorePendingListToolStripMenuItem";
            this.restorePendingListToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.restorePendingListToolStripMenuItem.Text = "Restore Pending List";
            this.restorePendingListToolStripMenuItem.Click += new System.EventHandler(this.restorePendingListToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.adminAccountsBlastToolStripMenuItem,
            this.massAddToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // adminAccountsBlastToolStripMenuItem
            // 
            this.adminAccountsBlastToolStripMenuItem.CheckOnClick = true;
            this.adminAccountsBlastToolStripMenuItem.Name = "adminAccountsBlastToolStripMenuItem";
            this.adminAccountsBlastToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.adminAccountsBlastToolStripMenuItem.Text = "Admin Accounts Blast";
            this.adminAccountsBlastToolStripMenuItem.Click += new System.EventHandler(this.adminAccountsBlastToolStripMenuItem_Click);
            // 
            // massAddToolStripMenuItem
            // 
            this.massAddToolStripMenuItem.Name = "massAddToolStripMenuItem";
            this.massAddToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.massAddToolStripMenuItem.Text = "Mass Add";
            this.massAddToolStripMenuItem.Click += new System.EventHandler(this.massAddToolStripMenuItem_Click);
            // 
            // sSNToolStripMenuItem
            // 
            this.sSNToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssnOffsetMnu});
            this.sSNToolStripMenuItem.Name = "sSNToolStripMenuItem";
            this.sSNToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.sSNToolStripMenuItem.Text = "SSN:";
            // 
            // ssnOffsetMnu
            // 
            this.ssnOffsetMnu.Name = "ssnOffsetMnu";
            this.ssnOffsetMnu.Size = new System.Drawing.Size(130, 22);
            this.ssnOffsetMnu.Text = "SSN Offset";
            this.ssnOffsetMnu.Click += new System.EventHandler(this.ssnOffsetMnu_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMnu,
            this.editToolStripMenuItem,
            this.sSNToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mainMenu.Size = new System.Drawing.Size(874, 24);
            this.mainMenu.TabIndex = 29;
            this.mainMenu.Text = "mainMenu";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 60, 0);
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // fltPwText
            // 
            this.fltPwText.Location = new System.Drawing.Point(533, 45);
            this.fltPwText.Name = "fltPwText";
            this.fltPwText.Size = new System.Drawing.Size(228, 20);
            this.fltPwText.TabIndex = 30;
            this.fltPwText.Visible = false;
            // 
            // ssoIdTxtBx
            // 
            this.ssoIdTxtBx.Location = new System.Drawing.Point(336, 135);
            this.ssoIdTxtBx.Name = "ssoIdTxtBx";
            this.ssoIdTxtBx.Size = new System.Drawing.Size(100, 20);
            this.ssoIdTxtBx.TabIndex = 57;
            // 
            // ssoIdLbl
            // 
            this.ssoIdLbl.AutoSize = true;
            this.ssoIdLbl.Location = new System.Drawing.Point(334, 116);
            this.ssoIdLbl.Name = "ssoIdLbl";
            this.ssoIdLbl.Size = new System.Drawing.Size(43, 13);
            this.ssoIdLbl.TabIndex = 58;
            this.ssoIdLbl.Text = "SSO ID";
            // 
            // newUserMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(874, 410);
            this.Controls.Add(this.ssoIdLbl);
            this.Controls.Add(this.ssoIdTxtBx);
            this.Controls.Add(this.providerGrpBx);
            this.Controls.Add(this.addOnGroupBox);
            this.Controls.Add(this.lnameReq);
            this.Controls.Add(this.fnameReq);
            this.Controls.Add(this.arfButton);
            this.Controls.Add(this.arfLabel);
            this.Controls.Add(this.faxClncGrp);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.loginClncGrp);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.middleInitLabel);
            this.Controls.Add(this.fltPwLabel);
            this.Controls.Add(this.middleInitial);
            this.Controls.Add(this.fltPwText);
            this.Controls.Add(this.fNameLabel);
            this.Controls.Add(this.pendingBtn);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.userTypeLabel);
            this.Controls.Add(this.userTypeDropDown);
            this.Controls.Add(this.addUserBtn);
            this.Controls.Add(this.intExtGroupBox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.emailText);
            this.Controls.Add(this.floatCheckBox);
            this.Controls.Add(this.degreeLabel);
            this.Controls.Add(this.jobCatLabel);
            this.Controls.Add(this.jobCategoryDropDown);
            this.Controls.Add(this.degreeDropDown);
            this.Controls.Add(this.mainMenu);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::NewUserAdds.Properties.Settings.Default, "MainWindowLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::NewUserAdds.Properties.Settings.Default.MainWindowLocation;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "newUserMain";
            this.Text = "New User Add";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.newUserMain_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clinicsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinicsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.degreesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.degreesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialtiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialtiesDataSet)).EndInit();
            this.intExtGroupBox.ResumeLayout(false);
            this.intExtGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsPending)).EndInit();
            this.faxClncGrp.ResumeLayout(false);
            this.faxClncGrp.PerformLayout();
            this.loginClncGrp.ResumeLayout(false);
            this.loginClncGrp.PerformLayout();
            this.addOnGroupBox.ResumeLayout(false);
            this.addOnGroupBox.PerformLayout();
            this.providerGrpBx.ResumeLayout(false);
            this.providerGrpBx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.specialtiesDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialtiesBindingSource1)).EndInit();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox clinicDropDown;
        private System.Windows.Forms.Label clinicName;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.Label fNameLabel;
        private System.Windows.Forms.TextBox middleInitial;
        private System.Windows.Forms.Label middleInitLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.ComboBox degreeDropDown;
        private System.Windows.Forms.ComboBox jobCategoryDropDown;
        private System.Windows.Forms.Label jobCatLabel;
        private System.Windows.Forms.Label degreeLabel;
        private System.Windows.Forms.CheckBox floatCheckBox;
        private System.Windows.Forms.ComboBox specialtyDropDown;
        private System.Windows.Forms.Label specialtyLabel;
        private System.Windows.Forms.TextBox deaText;
        private System.Windows.Forms.Label deaLabel;
        private System.Windows.Forms.TextBox npiText;
        private System.Windows.Forms.Label npiLabel;
        private System.Windows.Forms.TextBox emailText;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.RadioButton fmgRB;
        private System.Windows.Forms.RadioButton commRB;
        private System.Windows.Forms.GroupBox intExtGroupBox;
        private System.Windows.Forms.Button addUserBtn;
        private System.Windows.Forms.ComboBox userTypeDropDown;
        private System.Windows.Forms.Label userTypeLabel;
        private ClinicsDataSet clinicsDataSet;
        private System.Windows.Forms.BindingSource clinicsBindingSource;
        private NewUserAdds.Data_Sets.ClinicsDataSetTableAdapters.ClinicsTableAdapter clinicsTableAdapter1;
        private NewUserAdds.Data_Sets.SpecialtiesDataSet specialtiesDataSet;
        private System.Windows.Forms.BindingSource specialtiesBindingSource;
        private NewUserAdds.Data_Sets.SpecialtiesDataSetTableAdapters.SpecialtiesTableAdapter specialtiesTableAdapter1;
        private System.Windows.Forms.Button pendingBtn;
        //private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manageClinicsToolStripMenuItem;
        private System.Data.DataSet dsPending;
        private System.Windows.Forms.Label fltPwLabel;
        private System.Windows.Forms.Label ecdLabel;
        private System.Windows.Forms.TextBox clinicText;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox phoneText;
        private System.Windows.Forms.Label faxLabel;
        private System.Windows.Forms.TextBox faxText;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox addressText;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox cityText;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.TextBox stateText;
        private System.Windows.Forms.Label zipLabel;
        private System.Windows.Forms.TextBox zipText;
        private System.Windows.Forms.TextBox taskTxt;
        private System.Windows.Forms.Label taskLbl;
        private System.Windows.Forms.TextBox clncMgrTxt;
        private System.Windows.Forms.Label clncMgrLbl;
        private System.Windows.Forms.GroupBox faxClncGrp;
        private System.Windows.Forms.GroupBox loginClncGrp;
        private System.Windows.Forms.Label clncLbl;
        private System.Windows.Forms.LinkLabel arfLabel;
        private System.Windows.Forms.Button arfButton;
        private System.Windows.Forms.Label fnameReq;
        private System.Windows.Forms.Label lnameReq;
        private System.Windows.Forms.ToolTip fNameTT;
        private System.Windows.Forms.GroupBox addOnGroupBox;
        private System.Windows.Forms.CheckBox ioChkBx;
        private System.Windows.Forms.CheckBox rxChkBx;
        private System.Windows.Forms.CheckBox epiChkBx;
        private System.Windows.Forms.CheckBox repChkBx;
        private System.Windows.Forms.GroupBox providerGrpBx;
        private System.Windows.Forms.TextBox starIdTxt;
        private System.Windows.Forms.Label starIdLbl;
        private System.Windows.Forms.TextBox upinTxt;
        private System.Windows.Forms.Label upinLbl;
        private System.Windows.Forms.Label transLbl;
        private System.Windows.Forms.ComboBox transCB;
        private System.Windows.Forms.BindingSource specialtiesBindingSource1;
        private System.Windows.Forms.BindingSource specialtiesDataSetBindingSource;
        private DegreesDataSet degreesDataSet;
        private System.Windows.Forms.BindingSource degreesBindingSource;
        private NewUserAdds.Data_Sets.DegreesDataSetTableAdapters.DegreesTableAdapter degreesTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem editMnu;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem providerInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newUserLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mngClinMI;
        private System.Windows.Forms.ToolStripMenuItem manageSpecialtiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem restorePendingListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminAccountsBlastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sSNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ssnOffsetMnu;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.TextBox fltPwText;
        private System.Windows.Forms.ToolStripMenuItem manageDegreesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem faxRequestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem massAddToolStripMenuItem;
        private System.Windows.Forms.TextBox ssoIdTxtBx;
        private System.Windows.Forms.Label ssoIdLbl;
    }
}

