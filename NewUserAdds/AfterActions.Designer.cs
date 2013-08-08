namespace NewUserAdds
{
    partial class AfterActions
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
            this.toDoListView = new BrightIdeasSoftware.ObjectListView();
            this.done = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.category = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.userName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clinic = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.toDoListView)).BeginInit();
            this.SuspendLayout();
            // 
            // toDoListView
            // 
            this.toDoListView.AllColumns.Add(this.done);
            this.toDoListView.AllColumns.Add(this.category);
            this.toDoListView.AllColumns.Add(this.userName);
            this.toDoListView.AllColumns.Add(this.clinic);
            this.toDoListView.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.toDoListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toDoListView.BackColor = System.Drawing.Color.White;
            this.toDoListView.CheckBoxes = true;
            this.toDoListView.CheckedAspectName = "";
            this.toDoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.done,
            this.category,
            this.userName,
            this.clinic});
            this.toDoListView.EmptyListMsg = "Nothing to do.";
            this.toDoListView.EmptyListMsgFont = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDoListView.FullRowSelect = true;
            this.toDoListView.HasCollapsibleGroups = false;
            this.toDoListView.Location = new System.Drawing.Point(0, 0);
            this.toDoListView.Name = "toDoListView";
            this.toDoListView.Size = new System.Drawing.Size(500, 278);
            this.toDoListView.SortGroupItemsByPrimaryColumn = false;
            this.toDoListView.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.toDoListView.TabIndex = 0;
            this.toDoListView.UnfocusedHighlightBackgroundColor = System.Drawing.Color.White;
            this.toDoListView.UseCompatibleStateImageBehavior = false;
            this.toDoListView.View = System.Windows.Forms.View.Details;
            // 
            // done
            // 
            this.done.CheckBoxes = true;
            this.done.Groupable = false;
            this.done.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.done.Hideable = false;
            this.done.MaximumWidth = 25;
            this.done.MinimumWidth = 25;
            this.done.Searchable = false;
            this.done.ShowTextInHeader = false;
            this.done.Sortable = false;
            this.done.Text = "";
            this.done.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.done.UseFiltering = false;
            this.done.Width = 25;
            // 
            // category
            // 
            this.category.AspectName = "Category";
            this.category.Hideable = false;
            this.category.IsEditable = false;
            this.category.Text = "Need to do...";
            this.category.ToolTipText = "Task needed to be done";
            this.category.Width = 106;
            // 
            // userName
            // 
            this.userName.AspectName = "UserName";
            this.userName.IsEditable = false;
            this.userName.Text = "User";
            this.userName.Width = 117;
            // 
            // clinic
            // 
            this.clinic.AspectName = "ClinicName";
            this.clinic.Text = "Clinic";
            this.clinic.Width = 249;
            // 
            // AfterActions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(500, 278);
            this.Controls.Add(this.toDoListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AfterActions";
            this.ShowIcon = false;
            this.Text = "AfterActions";
            this.Load += new System.EventHandler(this.AfterActions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.toDoListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView toDoListView;
        private BrightIdeasSoftware.OLVColumn category;
        private BrightIdeasSoftware.OLVColumn userName;
        private BrightIdeasSoftware.OLVColumn done;
        private BrightIdeasSoftware.OLVColumn clinic;
    }
}