namespace NewUserAdds
{
    partial class ClinicDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClinicDetails));
            this.updateBtn = new System.Windows.Forms.Button();
            this.countryText = new System.Windows.Forms.TextBox();
            this.countryLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.dbidLabel = new System.Windows.Forms.Label();
            this.ecdText = new System.Windows.Forms.TextBox();
            this.ecdLabel = new System.Windows.Forms.Label();
            this.abbrText = new System.Windows.Forms.TextBox();
            this.abbrLabel = new System.Windows.Forms.Label();
            this.zipText = new System.Windows.Forms.TextBox();
            this.zipLabel = new System.Windows.Forms.Label();
            this.stateText = new System.Windows.Forms.TextBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.cityText = new System.Windows.Forms.TextBox();
            this.cityLabel = new System.Windows.Forms.Label();
            this.addressText = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.faxText = new System.Windows.Forms.TextBox();
            this.faxLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.phoneText = new System.Windows.Forms.TextBox();
            this.clinicNameLabel = new System.Windows.Forms.Label();
            this.clinicNameText = new System.Windows.Forms.TextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteClinicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.epicChkBx = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(151, 388);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(75, 23);
            this.updateBtn.TabIndex = 11;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // countryText
            // 
            this.countryText.Location = new System.Drawing.Point(28, 361);
            this.countryText.Name = "countryText";
            this.countryText.Size = new System.Drawing.Size(100, 20);
            this.countryText.TabIndex = 10;
            this.countryText.Text = "USA";
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(25, 344);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(43, 13);
            this.countryLabel.TabIndex = 72;
            this.countryLabel.Text = "Country";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(94, 36);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(90, 13);
            this.idLabel.TabIndex = 71;
            this.idLabel.Text = "[ID Not Assigned]";
            // 
            // dbidLabel
            // 
            this.dbidLabel.AutoSize = true;
            this.dbidLabel.Location = new System.Drawing.Point(25, 36);
            this.dbidLabel.Name = "dbidLabel";
            this.dbidLabel.Size = new System.Drawing.Size(67, 13);
            this.dbidLabel.TabIndex = 70;
            this.dbidLabel.Text = "Clinic DB ID:";
            // 
            // ecdText
            // 
            this.ecdText.Location = new System.Drawing.Point(28, 124);
            this.ecdText.Name = "ecdText";
            this.ecdText.Size = new System.Drawing.Size(262, 20);
            this.ecdText.TabIndex = 3;
            this.ecdText.Enter += new System.EventHandler(this.ecdText_Enter);
            // 
            // ecdLabel
            // 
            this.ecdLabel.AutoSize = true;
            this.ecdLabel.Location = new System.Drawing.Point(25, 106);
            this.ecdLabel.Name = "ecdLabel";
            this.ecdLabel.Size = new System.Drawing.Size(29, 13);
            this.ecdLabel.TabIndex = 68;
            this.ecdLabel.Text = "ECD";
            // 
            // abbrText
            // 
            this.abbrText.Location = new System.Drawing.Point(30, 164);
            this.abbrText.Name = "abbrText";
            this.abbrText.Size = new System.Drawing.Size(58, 20);
            this.abbrText.TabIndex = 2;
            // 
            // abbrLabel
            // 
            this.abbrLabel.AutoSize = true;
            this.abbrLabel.Location = new System.Drawing.Point(27, 146);
            this.abbrLabel.Name = "abbrLabel";
            this.abbrLabel.Size = new System.Drawing.Size(29, 13);
            this.abbrLabel.TabIndex = 66;
            this.abbrLabel.Text = "Abbr";
            // 
            // zipText
            // 
            this.zipText.Location = new System.Drawing.Point(199, 311);
            this.zipText.MaxLength = 5;
            this.zipText.Name = "zipText";
            this.zipText.Size = new System.Drawing.Size(91, 20);
            this.zipText.TabIndex = 9;
            // 
            // zipLabel
            // 
            this.zipLabel.AutoSize = true;
            this.zipLabel.Location = new System.Drawing.Point(196, 295);
            this.zipLabel.Name = "zipLabel";
            this.zipLabel.Size = new System.Drawing.Size(22, 13);
            this.zipLabel.TabIndex = 64;
            this.zipLabel.Text = "Zip";
            // 
            // stateText
            // 
            this.stateText.Location = new System.Drawing.Point(151, 311);
            this.stateText.Name = "stateText";
            this.stateText.Size = new System.Drawing.Size(29, 20);
            this.stateText.TabIndex = 8;
            this.stateText.Text = "WA";
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(148, 295);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(32, 13);
            this.stateLabel.TabIndex = 62;
            this.stateLabel.Text = "State";
            // 
            // cityText
            // 
            this.cityText.Location = new System.Drawing.Point(28, 311);
            this.cityText.Name = "cityText";
            this.cityText.Size = new System.Drawing.Size(100, 20);
            this.cityText.TabIndex = 7;
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(25, 295);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(24, 13);
            this.cityLabel.TabIndex = 60;
            this.cityLabel.Text = "City";
            // 
            // addressText
            // 
            this.addressText.Location = new System.Drawing.Point(28, 266);
            this.addressText.Name = "addressText";
            this.addressText.Size = new System.Drawing.Size(256, 20);
            this.addressText.TabIndex = 6;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(25, 250);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(45, 13);
            this.addressLabel.TabIndex = 58;
            this.addressLabel.Text = "Address";
            // 
            // faxText
            // 
            this.faxText.Location = new System.Drawing.Point(151, 215);
            this.faxText.Name = "faxText";
            this.faxText.Size = new System.Drawing.Size(100, 20);
            this.faxText.TabIndex = 5;
            // 
            // faxLabel
            // 
            this.faxLabel.AutoSize = true;
            this.faxLabel.Location = new System.Drawing.Point(148, 196);
            this.faxLabel.Name = "faxLabel";
            this.faxLabel.Size = new System.Drawing.Size(27, 13);
            this.faxLabel.TabIndex = 56;
            this.faxLabel.Text = "FAX";
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(27, 196);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(38, 13);
            this.phoneLabel.TabIndex = 55;
            this.phoneLabel.Text = "Phone";
            // 
            // phoneText
            // 
            this.phoneText.Location = new System.Drawing.Point(30, 215);
            this.phoneText.Name = "phoneText";
            this.phoneText.Size = new System.Drawing.Size(100, 20);
            this.phoneText.TabIndex = 4;
            // 
            // clinicNameLabel
            // 
            this.clinicNameLabel.AutoSize = true;
            this.clinicNameLabel.Location = new System.Drawing.Point(25, 61);
            this.clinicNameLabel.Name = "clinicNameLabel";
            this.clinicNameLabel.Size = new System.Drawing.Size(63, 13);
            this.clinicNameLabel.TabIndex = 53;
            this.clinicNameLabel.Text = "Clinic Name";
            // 
            // clinicNameText
            // 
            this.clinicNameText.Location = new System.Drawing.Point(28, 77);
            this.clinicNameText.MaxLength = 50;
            this.clinicNameText.Name = "clinicNameText";
            this.clinicNameText.Size = new System.Drawing.Size(262, 20);
            this.clinicNameText.TabIndex = 1;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(232, 388);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 12;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(334, 24);
            this.menuStrip1.TabIndex = 73;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteClinicToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // deleteClinicToolStripMenuItem
            // 
            this.deleteClinicToolStripMenuItem.Name = "deleteClinicToolStripMenuItem";
            this.deleteClinicToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.deleteClinicToolStripMenuItem.Text = "Delete Clinic";
            this.deleteClinicToolStripMenuItem.Click += new System.EventHandler(this.deleteClinicToolStripMenuItem_Click);
            // 
            // epicChkBx
            // 
            this.epicChkBx.AutoSize = true;
            this.epicChkBx.Location = new System.Drawing.Point(151, 166);
            this.epicChkBx.Name = "epicChkBx";
            this.epicChkBx.Size = new System.Drawing.Size(67, 17);
            this.epicChkBx.TabIndex = 74;
            this.epicChkBx.Text = "On EPIC";
            this.epicChkBx.UseVisualStyleBackColor = true;
            // 
            // ClinicDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 423);
            this.Controls.Add(this.epicChkBx);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.countryText);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.dbidLabel);
            this.Controls.Add(this.ecdText);
            this.Controls.Add(this.ecdLabel);
            this.Controls.Add(this.abbrText);
            this.Controls.Add(this.abbrLabel);
            this.Controls.Add(this.zipText);
            this.Controls.Add(this.zipLabel);
            this.Controls.Add(this.stateText);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.cityText);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.addressText);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.faxText);
            this.Controls.Add(this.faxLabel);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.phoneText);
            this.Controls.Add(this.clinicNameLabel);
            this.Controls.Add(this.clinicNameText);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ClinicDetails";
            this.Text = "Clinic Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClinicDetails_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.TextBox countryText;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label dbidLabel;
        private System.Windows.Forms.TextBox ecdText;
        private System.Windows.Forms.Label ecdLabel;
        private System.Windows.Forms.TextBox abbrText;
        private System.Windows.Forms.Label abbrLabel;
        private System.Windows.Forms.TextBox zipText;
        private System.Windows.Forms.Label zipLabel;
        private System.Windows.Forms.TextBox stateText;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.TextBox cityText;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox addressText;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox faxText;
        private System.Windows.Forms.Label faxLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox phoneText;
        private System.Windows.Forms.Label clinicNameLabel;
        private System.Windows.Forms.TextBox clinicNameText;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteClinicToolStripMenuItem;
        private System.Windows.Forms.CheckBox epicChkBx;
    }
}