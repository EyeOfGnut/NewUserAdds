namespace NewUserAdds
{
    partial class SpecDetails
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
            this.idLabel = new System.Windows.Forms.Label();
            this.specLabel = new System.Windows.Forms.Label();
            this.specText = new System.Windows.Forms.TextBox();
            this.abbLabel = new System.Windows.Forms.Label();
            this.abbText = new System.Windows.Forms.TextBox();
            this.updateBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(13, 13);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(21, 13);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "ID:";
            // 
            // specLabel
            // 
            this.specLabel.AutoSize = true;
            this.specLabel.Location = new System.Drawing.Point(13, 39);
            this.specLabel.Name = "specLabel";
            this.specLabel.Size = new System.Drawing.Size(50, 13);
            this.specLabel.TabIndex = 1;
            this.specLabel.Text = "Specialty";
            // 
            // specText
            // 
            this.specText.Location = new System.Drawing.Point(16, 55);
            this.specText.Name = "specText";
            this.specText.Size = new System.Drawing.Size(266, 20);
            this.specText.TabIndex = 2;
            this.specText.TextChanged += new System.EventHandler(this.specText_TextChanged);
            // 
            // abbLabel
            // 
            this.abbLabel.AutoSize = true;
            this.abbLabel.Location = new System.Drawing.Point(13, 88);
            this.abbLabel.Name = "abbLabel";
            this.abbLabel.Size = new System.Drawing.Size(66, 13);
            this.abbLabel.TabIndex = 3;
            this.abbLabel.Text = "Abbreviation";
            // 
            // abbText
            // 
            this.abbText.Location = new System.Drawing.Point(16, 105);
            this.abbText.Name = "abbText";
            this.abbText.Size = new System.Drawing.Size(100, 20);
            this.abbText.TabIndex = 4;
            this.abbText.TextChanged += new System.EventHandler(this.abbText_TextChanged);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(166, 148);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(75, 23);
            this.updateBtn.TabIndex = 5;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(248, 147);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // SpecDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 183);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.abbText);
            this.Controls.Add(this.abbLabel);
            this.Controls.Add(this.specText);
            this.Controls.Add(this.specLabel);
            this.Controls.Add(this.idLabel);
            this.Name = "SpecDetails";
            this.Text = "specDetails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label specLabel;
        private System.Windows.Forms.TextBox specText;
        private System.Windows.Forms.Label abbLabel;
        private System.Windows.Forms.TextBox abbText;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}