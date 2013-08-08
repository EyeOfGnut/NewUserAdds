using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewUserAdds
{
    /// <summary>
    /// Select a specific sheet from an Excel Workbook.
    /// </summary>
    public partial class SelectSheet : Form
    {
        /// <summary>
        /// The worksheet object
        /// </summary>
        public string worksheet = string.Empty;

        /// <summary>
        /// Initialize the Form
        /// </summary>
        /// <param name="sheets"></param>
        public SelectSheet(List<String> sheets)
        {
            InitializeComponent();
            char[] invalid = { '\'', '$' };
            foreach (string sheet in sheets)
            {
                string sheetBuffer = sheet;
                foreach (char item in invalid)
                {
                    while (sheetBuffer.Contains(item))
                        sheetBuffer = sheetBuffer.Remove(sheetBuffer.IndexOf(item), 1);
                }

                sheetsComboBox.Items.Add(sheetBuffer);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            worksheet = sheetsComboBox.SelectedItem.ToString() + '$';
            Close();
        }
    }
}
