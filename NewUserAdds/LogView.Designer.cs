namespace NewUserAdds
{
    partial class LogView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogView));
            this.logList = new System.Windows.Forms.ListView();
            this.dateAdded = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.user = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clinic = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.jobCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.userType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.arfLink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taskNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.adminUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // logList
            // 
            this.logList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.dateAdded,
            this.user,
            this.clinic,
            this.jobCategory,
            this.userType,
            this.arfLink,
            this.taskNumber,
            this.adminUser});
            this.logList.FullRowSelect = true;
            this.logList.GridLines = true;
            this.logList.Location = new System.Drawing.Point(12, 12);
            this.logList.Name = "logList";
            this.logList.Size = new System.Drawing.Size(977, 379);
            this.logList.TabIndex = 0;
            this.logList.UseCompatibleStateImageBehavior = false;
            this.logList.View = System.Windows.Forms.View.Details;
            this.logList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.logList_MouseDown);
            this.logList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.logList_MouseMove);
            // 
            // dateAdded
            // 
            this.dateAdded.Text = "Date Added";
            this.dateAdded.Width = 95;
            // 
            // user
            // 
            this.user.Text = "User";
            this.user.Width = 93;
            // 
            // clinic
            // 
            this.clinic.Text = "Clinic";
            this.clinic.Width = 165;
            // 
            // jobCategory
            // 
            this.jobCategory.Text = "Job Category";
            this.jobCategory.Width = 101;
            // 
            // userType
            // 
            this.userType.Text = "User Type";
            this.userType.Width = 88;
            // 
            // arfLink
            // 
            this.arfLink.Text = "Request Form";
            this.arfLink.Width = 162;
            // 
            // taskNumber
            // 
            this.taskNumber.Text = "Remedy Task";
            this.taskNumber.Width = 86;
            // 
            // adminUser
            // 
            this.adminUser.Text = "Processed By";
            this.adminUser.Width = 183;
            // 
            // LogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 403);
            this.Controls.Add(this.logList);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::NewUserAdds.Properties.Settings.Default, "LogWindowLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::NewUserAdds.Properties.Settings.Default.LogWindowLocation;
            this.Name = "LogView";
            this.Text = "LogView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView logList;
        private System.Windows.Forms.ColumnHeader user;
        private System.Windows.Forms.ColumnHeader dateAdded;
        private System.Windows.Forms.ColumnHeader clinic;
        private System.Windows.Forms.ColumnHeader jobCategory;
        private System.Windows.Forms.ColumnHeader userType;
        private System.Windows.Forms.ColumnHeader arfLink;
        private System.Windows.Forms.ColumnHeader taskNumber;
        private System.Windows.Forms.ColumnHeader adminUser;

    }
}