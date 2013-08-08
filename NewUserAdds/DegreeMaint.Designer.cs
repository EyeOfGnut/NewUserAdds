using NewUserAdds.Data_Sets;
namespace NewUserAdds
{
    partial class DegreeMaint
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
            this.degCB = new System.Windows.Forms.ComboBox();
            this.degreesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.degreesDataSet = new NewUserAdds.Data_Sets.DegreesDataSet();
            this.degLbl = new System.Windows.Forms.Label();
            this.degreesTableAdapter = new NewUserAdds.Data_Sets.DegreesDataSetTableAdapters.DegreesTableAdapter();
            this.lhpFilter = new System.Windows.Forms.Button();
            this.mdFilter = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.filterLbl = new System.Windows.Forms.Label();
            this.editBox = new System.Windows.Forms.GroupBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.degreeTxt = new System.Windows.Forms.TextBox();
            this.mdRB = new System.Windows.Forms.RadioButton();
            this.lhpRB = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.degreesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.degreesDataSet)).BeginInit();
            this.editBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // degCB
            // 
            this.degCB.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.degreesBindingSource, "ID", true));
            this.degCB.DataSource = this.degreesBindingSource;
            this.degCB.DisplayMember = "Degree";
            this.degCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.degCB.FormattingEnabled = true;
            this.degCB.Location = new System.Drawing.Point(15, 27);
            this.degCB.Name = "degCB";
            this.degCB.Size = new System.Drawing.Size(75, 21);
            this.degCB.TabIndex = 0;
            this.degCB.ValueMember = "ID";
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
            // degLbl
            // 
            this.degLbl.AutoSize = true;
            this.degLbl.Location = new System.Drawing.Point(12, 8);
            this.degLbl.Name = "degLbl";
            this.degLbl.Size = new System.Drawing.Size(86, 13);
            this.degLbl.TabIndex = 1;
            this.degLbl.Text = "Existing Degrees";
            // 
            // degreesTableAdapter
            // 
            this.degreesTableAdapter.ClearBeforeFill = true;
            // 
            // lhpFilter
            // 
            this.lhpFilter.Location = new System.Drawing.Point(134, 56);
            this.lhpFilter.Name = "lhpFilter";
            this.lhpFilter.Size = new System.Drawing.Size(75, 23);
            this.lhpFilter.TabIndex = 2;
            this.lhpFilter.Text = "LHP Only";
            this.lhpFilter.UseVisualStyleBackColor = true;
            this.lhpFilter.Click += new System.EventHandler(this.lhpFilter_Click);
            // 
            // mdFilter
            // 
            this.mdFilter.Location = new System.Drawing.Point(134, 27);
            this.mdFilter.Name = "mdFilter";
            this.mdFilter.Size = new System.Drawing.Size(75, 23);
            this.mdFilter.TabIndex = 3;
            this.mdFilter.Text = "MD Only";
            this.mdFilter.UseVisualStyleBackColor = true;
            this.mdFilter.Click += new System.EventHandler(this.mdFilter_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(15, 54);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(75, 23);
            this.editBtn.TabIndex = 4;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(9, 54);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(78, 23);
            this.addBtn.TabIndex = 5;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // filterLbl
            // 
            this.filterLbl.AutoSize = true;
            this.filterLbl.Location = new System.Drawing.Point(134, 8);
            this.filterLbl.Name = "filterLbl";
            this.filterLbl.Size = new System.Drawing.Size(34, 13);
            this.filterLbl.TabIndex = 6;
            this.filterLbl.Text = "Filters";
            // 
            // editBox
            // 
            this.editBox.Controls.Add(this.cancelBtn);
            this.editBox.Controls.Add(this.degreeTxt);
            this.editBox.Controls.Add(this.mdRB);
            this.editBox.Controls.Add(this.lhpRB);
            this.editBox.Controls.Add(this.addBtn);
            this.editBox.Location = new System.Drawing.Point(3, 108);
            this.editBox.Name = "editBox";
            this.editBox.Size = new System.Drawing.Size(227, 83);
            this.editBox.TabIndex = 7;
            this.editBox.TabStop = false;
            this.editBox.Text = "Add New Degree";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(142, 54);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 9;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Visible = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // degreeTxt
            // 
            this.degreeTxt.Location = new System.Drawing.Point(9, 19);
            this.degreeTxt.Name = "degreeTxt";
            this.degreeTxt.Size = new System.Drawing.Size(100, 20);
            this.degreeTxt.TabIndex = 8;
            // 
            // mdRB
            // 
            this.mdRB.AutoSize = true;
            this.mdRB.Location = new System.Drawing.Point(123, 19);
            this.mdRB.Name = "mdRB";
            this.mdRB.Size = new System.Drawing.Size(42, 17);
            this.mdRB.TabIndex = 7;
            this.mdRB.TabStop = true;
            this.mdRB.Text = "MD";
            this.mdRB.UseVisualStyleBackColor = true;
            // 
            // lhpRB
            // 
            this.lhpRB.AutoSize = true;
            this.lhpRB.Location = new System.Drawing.Point(171, 19);
            this.lhpRB.Name = "lhpRB";
            this.lhpRB.Size = new System.Drawing.Size(46, 17);
            this.lhpRB.TabIndex = 6;
            this.lhpRB.TabStop = true;
            this.lhpRB.Text = "LHP";
            this.lhpRB.UseVisualStyleBackColor = true;
            // 
            // DegreeMaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 203);
            this.Controls.Add(this.editBox);
            this.Controls.Add(this.filterLbl);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.mdFilter);
            this.Controls.Add(this.lhpFilter);
            this.Controls.Add(this.degLbl);
            this.Controls.Add(this.degCB);
            this.Name = "DegreeMaint";
            this.Text = "DegreeMaint";
            this.Load += new System.EventHandler(this.DegreeMaint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.degreesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.degreesDataSet)).EndInit();
            this.editBox.ResumeLayout(false);
            this.editBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox degCB;
        private System.Windows.Forms.Label degLbl;
        private DegreesDataSet degreesDataSet;
        private System.Windows.Forms.BindingSource degreesBindingSource;
        private NewUserAdds.Data_Sets.DegreesDataSetTableAdapters.DegreesTableAdapter degreesTableAdapter;
        private System.Windows.Forms.Button lhpFilter;
        private System.Windows.Forms.Button mdFilter;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Label filterLbl;
        private System.Windows.Forms.GroupBox editBox;
        private System.Windows.Forms.TextBox degreeTxt;
        private System.Windows.Forms.RadioButton mdRB;
        private System.Windows.Forms.RadioButton lhpRB;
        private System.Windows.Forms.Button cancelBtn;
    }
}