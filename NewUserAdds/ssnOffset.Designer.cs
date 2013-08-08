namespace NewUserAdds
{
    partial class ssnOffset
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
            this.ssnOffestLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.ssnOffsetText = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.subBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ssnOffestLabel
            // 
            this.ssnOffestLabel.AutoSize = true;
            this.ssnOffestLabel.Location = new System.Drawing.Point(13, 13);
            this.ssnOffestLabel.Name = "ssnOffestLabel";
            this.ssnOffestLabel.Size = new System.Drawing.Size(106, 13);
            this.ssnOffestLabel.TabIndex = 0;
            this.ssnOffestLabel.Text = "Set the starting SSN:";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(16, 92);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(97, 92);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ssnOffsetText
            // 
            this.ssnOffsetText.AutoSize = true;
            this.ssnOffsetText.Location = new System.Drawing.Point(71, 39);
            this.ssnOffsetText.Name = "ssnOffsetText";
            this.ssnOffsetText.Size = new System.Drawing.Size(48, 13);
            this.ssnOffsetText.TabIndex = 4;
            this.ssnOffsetText.Text = "FirstSSN";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(138, 34);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(23, 23);
            this.addBtn.TabIndex = 5;
            this.addBtn.Text = "+";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // subBtn
            // 
            this.subBtn.Location = new System.Drawing.Point(27, 34);
            this.subBtn.Name = "subBtn";
            this.subBtn.Size = new System.Drawing.Size(23, 23);
            this.subBtn.TabIndex = 6;
            this.subBtn.Text = "-";
            this.subBtn.UseVisualStyleBackColor = true;
            this.subBtn.Click += new System.EventHandler(this.subBtn_Click);
            // 
            // ssnOffset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 131);
            this.Controls.Add(this.subBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.ssnOffsetText);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.ssnOffestLabel);
            this.Name = "ssnOffset";
            this.Text = "ssnOffset";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ssnOffestLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label ssnOffsetText;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button subBtn;
    }
}