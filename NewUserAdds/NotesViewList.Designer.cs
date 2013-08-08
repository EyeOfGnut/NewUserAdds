namespace NewUserAdds
{
    partial class NotesViewList
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
            this.viewListBox = new System.Windows.Forms.ComboBox();
            this.viewButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // viewListBox
            // 
            this.viewListBox.FormattingEnabled = true;
            this.viewListBox.Location = new System.Drawing.Point(12, 56);
            this.viewListBox.Name = "viewListBox";
            this.viewListBox.Size = new System.Drawing.Size(259, 21);
            this.viewListBox.TabIndex = 0;
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(12, 83);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(75, 23);
            this.viewButton.TabIndex = 1;
            this.viewButton.Text = "Select View";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // NotesViewList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 118);
            this.Controls.Add(this.viewButton);
            this.Controls.Add(this.viewListBox);
            this.Name = "NotesViewList";
            this.Text = "NotesViewList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox viewListBox;
        private System.Windows.Forms.Button viewButton;
    }
}