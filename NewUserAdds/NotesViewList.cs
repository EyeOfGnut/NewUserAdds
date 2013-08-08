using System;
using System.Linq;
using System.Windows.Forms;
using Domino;

namespace NewUserAdds
{
    /// <summary>
    /// Testing class to list Notes Views in a database. Not implemented in Release.
    /// </summary>
    public partial class NotesViewList : Form
    {
        /// <summary>
        /// The name of the view selected
        /// </summary>
        public string viewName = null;


        /// <summary>
        /// Initialize the form (One overload)
        /// </summary>
        public NotesViewList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the form
        /// </summary>
        /// <param name="views">Notes View to initialize</param>
        public NotesViewList(Object[] views) : this ()
        {            
            if (views.Count() > 0)
            {
                foreach (NotesView view in views)
                {
                    viewListBox.Items.Add(view.Name);
                }
                viewListBox.Sorted = true;
            }
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            viewName = viewListBox.SelectedItem.ToString();
            Close();
        }
    }
}
