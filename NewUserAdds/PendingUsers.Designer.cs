namespace NewUserAdds
{
    partial class PendingUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PendingUsers));
            this.pendingList = new System.Windows.Forms.ListView();
            this.delCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.userType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.company = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.jobCat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.arf = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.expUsers = new System.Windows.Forms.Button();
            this.sndEmailsBtn = new System.Windows.Forms.Button();
            this.clrPendingBtn = new System.Windows.Forms.Button();
            this.toDo = new System.Windows.Forms.Button();
            this.progressBar = new NewUserAdds.Classes.StatusOverlayProgressBar();
            this.SuspendLayout();
            // 
            // pendingList
            // 
            this.pendingList.AllowColumnReorder = true;
            this.pendingList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pendingList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.delCol,
            this.name,
            this.userType,
            this.company,
            this.jobCat,
            this.arf});
            this.pendingList.FullRowSelect = true;
            this.pendingList.GridLines = true;
            this.pendingList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.pendingList.Location = new System.Drawing.Point(13, 13);
            this.pendingList.MultiSelect = false;
            this.pendingList.Name = "pendingList";
            this.pendingList.Size = new System.Drawing.Size(906, 317);
            this.pendingList.TabIndex = 0;
            this.pendingList.UseCompatibleStateImageBehavior = false;
            this.pendingList.View = System.Windows.Forms.View.Details;
            this.pendingList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pendingList_MouseDown);
            this.pendingList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pendingList_MouseMove);
            // 
            // delCol
            // 
            this.delCol.Text = "Delete";
            this.delCol.Width = 59;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 148;
            // 
            // userType
            // 
            this.userType.Text = "User Type";
            this.userType.Width = 107;
            // 
            // company
            // 
            this.company.Text = "Company";
            this.company.Width = 235;
            // 
            // jobCat
            // 
            this.jobCat.Text = "Job Category";
            this.jobCat.Width = 191;
            // 
            // arf
            // 
            this.arf.Text = "Request Form";
            this.arf.Width = 177;
            // 
            // expUsers
            // 
            this.expUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.expUsers.Location = new System.Drawing.Point(13, 351);
            this.expUsers.Name = "expUsers";
            this.expUsers.Size = new System.Drawing.Size(92, 23);
            this.expUsers.TabIndex = 1;
            this.expUsers.Text = "Export to Notes";
            this.expUsers.UseVisualStyleBackColor = true;
            this.expUsers.Click += new System.EventHandler(this.expUsers_Click);
            // 
            // sndEmailsBtn
            // 
            this.sndEmailsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sndEmailsBtn.Location = new System.Drawing.Point(111, 351);
            this.sndEmailsBtn.Name = "sndEmailsBtn";
            this.sndEmailsBtn.Size = new System.Drawing.Size(75, 23);
            this.sndEmailsBtn.TabIndex = 2;
            this.sndEmailsBtn.Text = "Send Emails";
            this.sndEmailsBtn.UseVisualStyleBackColor = true;
            this.sndEmailsBtn.Visible = false;
            this.sndEmailsBtn.Click += new System.EventHandler(this.sndEmailsBtn_Click);
            // 
            // clrPendingBtn
            // 
            this.clrPendingBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clrPendingBtn.Location = new System.Drawing.Point(834, 351);
            this.clrPendingBtn.Name = "clrPendingBtn";
            this.clrPendingBtn.Size = new System.Drawing.Size(85, 23);
            this.clrPendingBtn.TabIndex = 4;
            this.clrPendingBtn.Text = "Clear Pending";
            this.clrPendingBtn.UseVisualStyleBackColor = true;
            this.clrPendingBtn.Click += new System.EventHandler(this.clrPendingBtn_Click);
            // 
            // toDo
            // 
            this.toDo.Enabled = false;
            this.toDo.Location = new System.Drawing.Point(783, 351);
            this.toDo.Name = "toDo";
            this.toDo.Size = new System.Drawing.Size(45, 23);
            this.toDo.TabIndex = 6;
            this.toDo.Text = "To Do";
            this.toDo.UseVisualStyleBackColor = true;
            this.toDo.Visible = false;
            this.toDo.Click += new System.EventHandler(this.toDo_Click);
            // 
            // progressBar
            // 
            this.progressBar.Font_Face = "Arial Unicode MS";
            this.progressBar.Font_Size = 8;
            this.progressBar.Font_Style = System.Drawing.FontStyle.Regular;
            this.progressBar.Location = new System.Drawing.Point(216, 351);
            this.progressBar.Message = "0/100";
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(530, 23);
            this.progressBar.TabIndex = 7;
            this.progressBar.Visible = false;
            // 
            // PendingUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 397);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.toDo);
            this.Controls.Add(this.clrPendingBtn);
            this.Controls.Add(this.sndEmailsBtn);
            this.Controls.Add(this.expUsers);
            this.Controls.Add(this.pendingList);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::NewUserAdds.Properties.Settings.Default, "PendingUsersLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::NewUserAdds.Properties.Settings.Default.PendingUsersLocation;
            this.Name = "PendingUsers";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Pending Users";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView pendingList;
        private System.Windows.Forms.ColumnHeader company;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader userType;
        private System.Windows.Forms.ColumnHeader jobCat;
        private System.Windows.Forms.Button expUsers;
        private System.Windows.Forms.Button sndEmailsBtn;
        private System.Windows.Forms.ColumnHeader delCol;
        private System.Windows.Forms.ColumnHeader arf;
        private System.Windows.Forms.Button clrPendingBtn;
        private Classes.StatusOverlayProgressBar progressBar;
        private System.Windows.Forms.Button toDo;
    }
}