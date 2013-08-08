using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace NewUserAdds
{
    /// <summary>
    /// Window to display the Log entries
    /// </summary>
    public partial class LogView : Form
    {
        private static DataTable logTable = new DataTable();

        /// <summary>
        /// Initialize the form
        /// </summary>
        public LogView()
        {
            InitializeComponent();
            if (!logTable.Columns.Contains("Created"))
            {
                logTable.Columns.AddRange(Utils.setDataColumns());

                DataColumn dc2 = new DataColumn("Admin User");
                logTable.Columns.Add(dc2);
                DataColumn dc = new DataColumn("Created");
                logTable.Columns.Add(dc);                
            }
            logTable.Clear();
            Utils.readAuditInfo(logTable);
            LoadTable();
        }

        private void LoadTable()
        {
            if (logTable == null)
                MessageBox.Show("Error, Log list uninitialized.");
            else
            {
                logList.Items.Clear();
                for (int i = 0; i < logTable.Rows.Count; i++)
                {
                    DataRow dRow = logTable.Rows[i];
                    if (dRow.RowState != DataRowState.Deleted)
                    {
                        string name = dRow["Last Name"].ToString() + ", " + dRow["First Name"].ToString() + " " + dRow["Middle Initial"].ToString();
                        string company = dRow["Company Name"].ToString() + " " + dRow["Location"].ToString();

                        ListViewItem lvi = new ListViewItem(dRow["Created"].ToString());
                        lvi.UseItemStyleForSubItems = false;

                        if (i % 2 == 0)
                            lvi.BackColor = Color.FromArgb(0xD1EEEE);
                        else
                            lvi.BackColor = Color.LightGoldenrodYellow;

                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, name.Trim(), lvi.ForeColor, lvi.BackColor, lvi.Font));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, company.Trim(), lvi.ForeColor, lvi.BackColor, lvi.Font));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, dRow["Job Category"].ToString(), lvi.ForeColor, lvi.BackColor, lvi.Font));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, dRow["User Type"].ToString(), lvi.ForeColor, lvi.BackColor, lvi.Font));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, System.IO.Path.GetFileName(dRow["Form"].ToString()), Color.Blue, lvi.BackColor, new Font(lvi.Font, FontStyle.Underline)));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, dRow["Task"].ToString(), lvi.ForeColor, lvi.BackColor, lvi.Font));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, dRow["Admin User"].ToString(), lvi.ForeColor, lvi.BackColor, lvi.Font));
                        lvi.SubItems.Add(dRow["Form"].ToString());
                        lvi.SubItems.Add(i.ToString()); // Row index

                        logList.Items.Add(lvi); // Add the item to the List Control
                    }
                }
            }

        }

        ListViewItem.ListViewSubItem mHovered;
        private void logList_MouseMove(object sender, MouseEventArgs e)
        {
            var info = logList.HitTest(e.Location);
            if (info.SubItem == mHovered) return;
            mHovered = null;
            logList.Cursor = Cursors.Default;
            if (info.SubItem != null && info.Item.SubItems[5] == info.SubItem && !string.IsNullOrEmpty(info.SubItem.Text))
            {
                logList.Cursor = Cursors.Hand;
                mHovered = info.SubItem;
            }
        }

        private void logList_MouseDown(object sender, MouseEventArgs e)
        {
            var info = logList.HitTest(e.Location);
            if (info.SubItem != null && info.Item.SubItems[5] == info.SubItem && !string.IsNullOrEmpty(info.SubItem.Text))
            {
                try
                {
                    Process.Start(info.Item.SubItems[info.Item.SubItems.Count - 2].Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening file: " + ex.Message);
                }
            }
        }
    }
}
