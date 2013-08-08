using NewUserAdds.Data_Sets;
namespace NewUserAdds
{
    partial class SpecMaint
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
            this.editBtn = new System.Windows.Forms.Button();
            this.addNewBtn = new System.Windows.Forms.Button();
            this.listLabel = new System.Windows.Forms.Label();
            this.specDropDown = new System.Windows.Forms.ComboBox();
            this.specialtiesDataSet = new NewUserAdds.Data_Sets.SpecialtiesDataSet();
            this.specialtiesDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.specialtiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.specialtiesTableAdapter = new NewUserAdds.Data_Sets.SpecialtiesDataSetTableAdapters.SpecialtiesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.specialtiesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialtiesDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialtiesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(22, 142);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(75, 23);
            this.editBtn.TabIndex = 55;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(86, 26);
            this.addNewBtn.Name = "addNewBtn";
            this.addNewBtn.Size = new System.Drawing.Size(118, 35);
            this.addNewBtn.TabIndex = 54;
            this.addNewBtn.Text = "Add New Specialty";
            this.addNewBtn.UseVisualStyleBackColor = true;
            this.addNewBtn.Click += new System.EventHandler(this.addNewBtn_Click);
            // 
            // listLabel
            // 
            this.listLabel.AutoSize = true;
            this.listLabel.Location = new System.Drawing.Point(19, 91);
            this.listLabel.Name = "listLabel";
            this.listLabel.Size = new System.Drawing.Size(69, 13);
            this.listLabel.TabIndex = 53;
            this.listLabel.Text = "Specialty List";
            // 
            // specDropDown
            // 
            this.specDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.specialtiesBindingSource, "id", true));
            this.specDropDown.DataSource = this.specialtiesBindingSource;
            this.specDropDown.DisplayMember = "Specialty";
            this.specDropDown.FormattingEnabled = true;
            this.specDropDown.Location = new System.Drawing.Point(22, 114);
            this.specDropDown.Name = "specDropDown";
            this.specDropDown.Size = new System.Drawing.Size(244, 21);
            this.specDropDown.TabIndex = 52;
            this.specDropDown.ValueMember = "id";
            // 
            // specialtiesDataSet
            // 
            this.specialtiesDataSet.DataSetName = "SpecialtiesDataSet";
            this.specialtiesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // specialtiesDataSetBindingSource
            // 
            this.specialtiesDataSetBindingSource.DataSource = this.specialtiesDataSet;
            this.specialtiesDataSetBindingSource.Position = 0;
            // 
            // specialtiesBindingSource
            // 
            this.specialtiesBindingSource.DataMember = "Specialties";
            this.specialtiesBindingSource.DataSource = this.specialtiesDataSetBindingSource;
            // 
            // specialtiesTableAdapter
            // 
            this.specialtiesTableAdapter.ClearBeforeFill = true;
            // 
            // SpecMaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 195);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.addNewBtn);
            this.Controls.Add(this.listLabel);
            this.Controls.Add(this.specDropDown);
            this.Name = "SpecMaint";
            this.Text = "SpecMaint";
            this.Load += new System.EventHandler(this.SpecMaint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.specialtiesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialtiesDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialtiesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button addNewBtn;
        private System.Windows.Forms.Label listLabel;
        private System.Windows.Forms.ComboBox specDropDown;
        private System.Windows.Forms.BindingSource specialtiesDataSetBindingSource;
        private SpecialtiesDataSet specialtiesDataSet;
        private System.Windows.Forms.BindingSource specialtiesBindingSource;
        private NewUserAdds.Data_Sets.SpecialtiesDataSetTableAdapters.SpecialtiesTableAdapter specialtiesTableAdapter;
    }
}