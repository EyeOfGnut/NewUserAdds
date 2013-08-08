namespace NewUserAdds
{
    partial class ChangeUserName
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
            this.errorLabel = new System.Windows.Forms.Label();
            this.unameText = new System.Windows.Forms.TextBox();
            this.textBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(13, 13);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(86, 13);
            this.errorLabel.TabIndex = 0;
            this.errorLabel.Text = "Shortname Used";
            // 
            // unameText
            // 
            this.unameText.Location = new System.Drawing.Point(12, 40);
            this.unameText.Name = "unameText";
            this.unameText.Size = new System.Drawing.Size(241, 20);
            this.unameText.TabIndex = 0;
            // 
            // textBtn
            // 
            this.textBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.textBtn.Location = new System.Drawing.Point(259, 38);
            this.textBtn.Name = "textBtn";
            this.textBtn.Size = new System.Drawing.Size(111, 23);
            this.textBtn.TabIndex = 1;
            this.textBtn.Text = "Update";
            this.textBtn.UseVisualStyleBackColor = true;
            this.textBtn.Click += new System.EventHandler(this.textBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(376, 38);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ChangeUserName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 71);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.textBtn);
            this.Controls.Add(this.unameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChangeUserName";
            this.Text = "ChangeUserName";
            this.Load += new System.EventHandler(this.ChangeUserName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.TextBox unameText;
        private System.Windows.Forms.Button textBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}