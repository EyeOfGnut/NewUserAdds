namespace NewUserAdds
{
    partial class ClinicMaint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClinicMaint));
            this.addNewBtn = new System.Windows.Forms.Button();
            this.clinicsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.clinicDropDown = new System.Windows.Forms.ComboBox();
            this.clinicsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.clinicsDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clinicsDataSet = new NewUserAdds.Data_Sets.ClinicsDataSet();
            this.clinicsTableAdapter = new NewUserAdds.Data_Sets.ClinicsDataSetTableAdapters.ClinicsTableAdapter();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.viewBtn = new System.Windows.Forms.Button();
            this.editChkBx = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.clinicsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinicsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinicsDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinicsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(86, 12);
            this.addNewBtn.Name = "addNewBtn";
            this.addNewBtn.Size = new System.Drawing.Size(118, 35);
            this.addNewBtn.TabIndex = 50;
            this.addNewBtn.Text = "Add New Clinic";
            this.addNewBtn.UseVisualStyleBackColor = true;
            this.addNewBtn.Click += new System.EventHandler(this.addNewBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Clinic List";
            // 
            // clinicDropDown
            // 
            this.clinicDropDown.DataSource = this.clinicsBindingSource1;
            this.clinicDropDown.DisplayMember = "Company";
            this.clinicDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clinicDropDown.FormattingEnabled = true;
            this.clinicDropDown.Location = new System.Drawing.Point(23, 113);
            this.clinicDropDown.Name = "clinicDropDown";
            this.clinicDropDown.Size = new System.Drawing.Size(345, 21);
            this.clinicDropDown.TabIndex = 26;
            this.clinicDropDown.ValueMember = "id";
            // 
            // clinicsBindingSource1
            // 
            this.clinicsBindingSource1.DataMember = "Clinics";
            this.clinicsBindingSource1.DataSource = this.clinicsDataSetBindingSource;
            // 
            // clinicsDataSetBindingSource
            // 
            this.clinicsDataSetBindingSource.DataSource = this.clinicsDataSet;
            this.clinicsDataSetBindingSource.Position = 0;
            // 
            // clinicsDataSet
            // 
            this.clinicsDataSet.DataSetName = "ClinicsDataSet";
            this.clinicsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clinicsTableAdapter
            // 
            this.clinicsTableAdapter.ClearBeforeFill = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(293, 141);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 52;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // viewBtn
            // 
            this.viewBtn.Location = new System.Drawing.Point(23, 140);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(75, 23);
            this.viewBtn.TabIndex = 53;
            this.viewBtn.Text = "View";
            this.viewBtn.UseVisualStyleBackColor = true;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // editChkBx
            // 
            this.editChkBx.AutoSize = true;
            this.editChkBx.Location = new System.Drawing.Point(118, 144);
            this.editChkBx.Name = "editChkBx";
            this.editChkBx.Size = new System.Drawing.Size(44, 17);
            this.editChkBx.TabIndex = 54;
            this.editChkBx.Text = "Edit";
            this.editChkBx.UseVisualStyleBackColor = true;
            // 
            // ClinicMaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 205);
            this.Controls.Add(this.editChkBx);
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addNewBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clinicDropDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClinicMaint";
            this.Text = "Clinic Maintanance";
            this.Load += new System.EventHandler(this.ClinicMaint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clinicsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinicsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinicsDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinicsDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addNewBtn;
        private System.Windows.Forms.BindingSource clinicsBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox clinicDropDown;
        private NewUserAdds.Data_Sets.ClinicsDataSet clinicsDataSet;
        private System.Windows.Forms.BindingSource clinicsDataSetBindingSource;
        private System.Windows.Forms.BindingSource clinicsBindingSource1;
        private NewUserAdds.Data_Sets.ClinicsDataSetTableAdapters.ClinicsTableAdapter clinicsTableAdapter;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button viewBtn;
        private System.Windows.Forms.CheckBox editChkBx;
    }
}