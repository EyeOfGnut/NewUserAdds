namespace NewUserAdds
{
    partial class UserSettings
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
            this.intEmailSigBtn = new System.Windows.Forms.Button();
            this.extEmailSigBtn = new System.Windows.Forms.Button();
            this.intEmailSigLabel = new System.Windows.Forms.Label();
            this.extEmailSigLabel = new System.Windows.Forms.Label();
            this.intEmailSigDisp = new System.Windows.Forms.WebBrowser();
            this.extEmailSigDisp = new System.Windows.Forms.WebBrowser();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.applyBtn = new System.Windows.Forms.Button();
            this.ordSrvTxt = new System.Windows.Forms.TextBox();
            this.ordSrvLbl = new System.Windows.Forms.Label();
            this.mainSrvTxt = new System.Windows.Forms.TextBox();
            this.mainSvrLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // intEmailSigBtn
            // 
            this.intEmailSigBtn.Location = new System.Drawing.Point(11, 281);
            this.intEmailSigBtn.Name = "intEmailSigBtn";
            this.intEmailSigBtn.Size = new System.Drawing.Size(66, 23);
            this.intEmailSigBtn.TabIndex = 0;
            this.intEmailSigBtn.Text = "Browse...";
            this.intEmailSigBtn.UseVisualStyleBackColor = true;
            this.intEmailSigBtn.Click += new System.EventHandler(this.intEmailSigBtn_Click);
            // 
            // extEmailSigBtn
            // 
            this.extEmailSigBtn.Location = new System.Drawing.Point(391, 281);
            this.extEmailSigBtn.Name = "extEmailSigBtn";
            this.extEmailSigBtn.Size = new System.Drawing.Size(75, 23);
            this.extEmailSigBtn.TabIndex = 1;
            this.extEmailSigBtn.Text = "Browse...";
            this.extEmailSigBtn.UseVisualStyleBackColor = true;
            this.extEmailSigBtn.Click += new System.EventHandler(this.extEmailSigBtn_Click);
            // 
            // intEmailSigLabel
            // 
            this.intEmailSigLabel.AutoSize = true;
            this.intEmailSigLabel.Location = new System.Drawing.Point(11, 9);
            this.intEmailSigLabel.Name = "intEmailSigLabel";
            this.intEmailSigLabel.Size = new System.Drawing.Size(121, 13);
            this.intEmailSigLabel.TabIndex = 2;
            this.intEmailSigLabel.Text = "Internal Email Signature:";
            // 
            // extEmailSigLabel
            // 
            this.extEmailSigLabel.AutoSize = true;
            this.extEmailSigLabel.Location = new System.Drawing.Point(388, 9);
            this.extEmailSigLabel.Name = "extEmailSigLabel";
            this.extEmailSigLabel.Size = new System.Drawing.Size(124, 13);
            this.extEmailSigLabel.TabIndex = 3;
            this.extEmailSigLabel.Text = "External Email Signature:";
            // 
            // intEmailSigDisp
            // 
            this.intEmailSigDisp.Location = new System.Drawing.Point(12, 25);
            this.intEmailSigDisp.MinimumSize = new System.Drawing.Size(20, 20);
            this.intEmailSigDisp.Name = "intEmailSigDisp";
            this.intEmailSigDisp.Size = new System.Drawing.Size(333, 250);
            this.intEmailSigDisp.TabIndex = 4;
            // 
            // extEmailSigDisp
            // 
            this.extEmailSigDisp.Location = new System.Drawing.Point(391, 25);
            this.extEmailSigDisp.MinimumSize = new System.Drawing.Size(20, 20);
            this.extEmailSigDisp.Name = "extEmailSigDisp";
            this.extEmailSigDisp.Size = new System.Drawing.Size(333, 250);
            this.extEmailSigDisp.TabIndex = 5;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(649, 423);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(568, 423);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(487, 422);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 8;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // ordSrvTxt
            // 
            this.ordSrvTxt.Location = new System.Drawing.Point(11, 410);
            this.ordSrvTxt.Name = "ordSrvTxt";
            this.ordSrvTxt.Size = new System.Drawing.Size(160, 20);
            this.ordSrvTxt.TabIndex = 9;
            // 
            // ordSrvLbl
            // 
            this.ordSrvLbl.AutoSize = true;
            this.ordSrvLbl.Location = new System.Drawing.Point(11, 391);
            this.ordSrvLbl.Name = "ordSrvLbl";
            this.ordSrvLbl.Size = new System.Drawing.Size(81, 13);
            this.ordSrvLbl.TabIndex = 10;
            this.ordSrvLbl.Text = "Ordering Server";
            // 
            // mainSrvTxt
            // 
            this.mainSrvTxt.Location = new System.Drawing.Point(13, 362);
            this.mainSrvTxt.Name = "mainSrvTxt";
            this.mainSrvTxt.Size = new System.Drawing.Size(159, 20);
            this.mainSrvTxt.TabIndex = 11;
            // 
            // mainSvrLbl
            // 
            this.mainSvrLbl.AutoSize = true;
            this.mainSvrLbl.Location = new System.Drawing.Point(13, 342);
            this.mainSvrLbl.Name = "mainSvrLbl";
            this.mainSvrLbl.Size = new System.Drawing.Size(64, 13);
            this.mainSvrLbl.TabIndex = 12;
            this.mainSvrLbl.Text = "Main Server";
            // 
            // UserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 457);
            this.Controls.Add(this.mainSvrLbl);
            this.Controls.Add(this.mainSrvTxt);
            this.Controls.Add(this.ordSrvLbl);
            this.Controls.Add(this.ordSrvTxt);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.extEmailSigDisp);
            this.Controls.Add(this.intEmailSigDisp);
            this.Controls.Add(this.extEmailSigLabel);
            this.Controls.Add(this.intEmailSigLabel);
            this.Controls.Add(this.extEmailSigBtn);
            this.Controls.Add(this.intEmailSigBtn);
            this.Name = "UserSettings";
            this.Text = "UserSettings";
            this.Load += new System.EventHandler(this.UserSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button intEmailSigBtn;
        private System.Windows.Forms.Button extEmailSigBtn;
        private System.Windows.Forms.Label intEmailSigLabel;
        private System.Windows.Forms.Label extEmailSigLabel;
        private System.Windows.Forms.WebBrowser intEmailSigDisp;
        private System.Windows.Forms.WebBrowser extEmailSigDisp;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.TextBox ordSrvTxt;
        private System.Windows.Forms.Label ordSrvLbl;
        private System.Windows.Forms.TextBox mainSrvTxt;
        private System.Windows.Forms.Label mainSvrLbl;
    }
}