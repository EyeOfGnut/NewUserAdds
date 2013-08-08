using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using NewUserAdds.Data_Sets;
using System.Collections.Generic;
using System.Text;

namespace NewUserAdds
{
    /// <summary>
    /// Flags for Add-On options
    /// </summary>
    [Flags]
    public enum AddOns
    {
        /// <summary>ePrescribing</summary>
        eRx = 0x01,
        /// <summary>Intelligent Ordering</summary>
        Ordering = 0x02,
        /// <summary>Repsoitory access (almost everyone gets this)</summary>
        Repository = 0x04,
        /// <summary>Edit Patient Index</summary>
        Edit = 0x08
    }

    /// <summary>
    /// Class derived from ListView to give ability to display controls like TextBox and Combobox.
    /// Code from http://www.codeproject.com/script/Articles/ViewDownloads.aspx?aid=18111
    /// Original Author: Shine Kumar
    /// </summary>
    public class ListViewEx : ListView
    {
        #region The RECT structure
        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        #endregion

        #region Win32 Class
        internal class Win32
        {
            public const int LVM_GETSUBITEMRECT = (0x1000) + 56;
            public const int LVIR_BOUNDS = 0;
            [DllImport("user32.dll", SetLastError = true)]
            public static extern int SendMessage(IntPtr hWnd, int messageID, int wParam, ref RECT lParam);
        }
        #endregion

        #region SubItem Class
        internal class SubItem
        {
            public readonly int row;
            public readonly int col;
            public SubItem(int row, int col)
            {
                this.row = row;
                this.col = col;
            }
        }
        #endregion

        #region DegreeItem Class

        internal class DegreeItem
        {
            private string intDegree;
            private string intId;

            public DegreeItem(string degree, string id)
            {
                this.intDegree = degree;
                this.intId = id;
            }

            public string Degree
            {
                get { return intDegree; }
            }

            public string ID
            {
                get { return intId; }
            }
        }

        #endregion

        #region Variables & Properties

        private const int EW = 8;
        private const int REP = 4;
        private const int IO = 2;
        private const int ERX = 1;

        private bool addSubItem = false;

        /// <summary>
        /// If this variable is true, then subitems for an item is added automatically if needed.
        /// </summary>
        public bool AddSubItem
        {
            set { addSubItem = value; }
        }

        private bool hideComboAfterSelChange = false;

        /// <summary>
        /// Hide a combo box after a Selection change
        /// </summary>
        public bool HideComboAfterSelChange
        {
            set { hideComboAfterSelChange = value; }
        }

        private bool hideCheckAfterChange = false;

        /// <summary>
        /// Hide the group of check boxes after a Selection change
        /// </summary>
        public bool HideCheckAfterChange
        {
            set { hideCheckAfterChange = value; }
        }

        private int row = -1;
        private int col = -1;

        #region Custom Controls

        private TextBox textBox = new TextBox();
        private ComboBox combo = new ComboBox();

        private GroupBox checkBoxes = new GroupBox();
        private CheckBox rep = new CheckBox();
        private CheckBox io = new CheckBox();
        private CheckBox erx = new CheckBox();
        private CheckBox ew = new CheckBox();

        #endregion


        private Hashtable customCells = new Hashtable();
        #endregion

        #region Methods

        /// <summary>
        /// Extended List View to allow text entry and combo boxes
        /// </summary>
        public ListViewEx()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.textBox.Visible = false;
            textBox.BorderStyle = BorderStyle.FixedSingle;

            checkBoxes.FlatStyle = FlatStyle.Flat;
            //checkBoxes.AutoSize = true;
            checkBoxes.Controls.Add(rep);
            checkBoxes.Controls.Add(ew);
            checkBoxes.Controls.Add(io);
            checkBoxes.Controls.Add(erx);

            rep.Text = "VHR";
            ew.Text = "Edit";
            io.Text = "Ordering";
            erx.Text = "eRx";

            rep.Location = new Point(3, 2);
            rep.AutoSize = true;
            rep.AutoCheck = true;
            ew.Location = new Point(53, 2);
            ew.AutoSize = true;
            io.Location = new Point(103, 2);
            io.AutoSize = true;
            erx.Location = new Point(173, 2);
            erx.AutoSize = true;

            this.checkBoxes.Visible = false;
            this.combo.Visible = false;
            this.combo.DropDownStyle = ComboBoxStyle.DropDownList;

            this.combo.SelectedIndexChanged += new EventHandler(combo_SelectedIndexChanged);
            this.checkBoxes.Leave += new EventHandler(checkBoxes_Leave);
            this.textBox.Leave += new EventHandler(textBox_Leave);

            this.Controls.Add(this.textBox);
            this.Controls.Add(this.combo);
            this.Controls.Add(this.checkBoxes);
        }

        private RECT GetSubItemRect(Point clickPoint)
        {
            RECT subItemRect = new RECT();
            this.row = this.col = -1;
            ListViewItem item = this.GetItemAt(clickPoint.X, clickPoint.Y);

            if (item != null)
            {
                for (int index = 0; index < this.Columns.Count; index++)
                {
                    subItemRect.top = index + 1;
                    subItemRect.left = Win32.LVIR_BOUNDS;
                    try
                    {
                        int result = Win32.SendMessage(this.Handle, Win32.LVM_GETSUBITEMRECT, item.Index, ref subItemRect);
                        if (result != 0)
                        {
                            if (clickPoint.X < subItemRect.left)
                            {
                                this.row = item.Index;
                                this.col = 0;
                                break;
                            }
                            if (clickPoint.X >= subItemRect.left & clickPoint.X <= subItemRect.right)
                            {
                                this.row = item.Index;
                                this.col = index + 1;
                                break;
                            }
                        }
                        else
                        {
                            throw new Win32Exception();
                        }
                    }
                    catch (Win32Exception ex)
                    {
                        Trace.WriteLine(string.Format("Exception while getting subitem rect, {0}", ex.Message));
                    }
                }
            }
            return subItemRect;
        }

        /// <summary>
        /// Add a text-editable Cell
        /// </summary>
        /// <param name="row">Table Row of the cell</param>
        /// <param name="col">Table Column of the cell</param>
        public void AddEditableCell(int row, int col)
        {
            this.customCells[new SubItem(row, col)] = null;
        }

        /// <summary>
        /// Add a check-box cell
        /// </summary>
        /// <param name="row">Table Row of the cell</param>
        /// <param name="col">Table Column of the cell</param>
        public void AddCheckBoxGroup(int row, int col)
        {
            this.customCells[new SubItem(row, col)] = string.Empty;
        }

        /// <summary>
        /// Add a ComboBox cell
        /// </summary>
        /// <param name="row">Table Row of the cell</param>
        /// <param name="col">Table Column of the cell</param>
        /// <param name="data">Data to load into the Combo box</param>
        public void AddComboBoxCell(int row, int col, StringCollection data)
        {
            this.customCells[new SubItem(row, col)] = data;
        }

        /// <summary>
        /// Add a ComboBox cell
        /// </summary>
        /// <param name="row">Table Row of the cell</param>
        /// <param name="col">Table Column of the cell</param>
        /// <param name="data">Data Adapter to load into the Combo box</param>
        public void AddComboBoxCell(int row, int col, DegreesDataSet.DegreesDataTable data)
        {
            try
            {
                /*ArrayList collection = new ArrayList();
                foreach (DataRow dRow in data.Rows)
                {
                    collection.Add(new DegreeItem(dRow.ItemArray[0].ToString(), dRow.ItemArray[2].ToString()));
                }
                this.customCells[new SubItem(row, col)] = collection; */
                this.customCells[new SubItem(row, col)] = data;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Add a ComboBox cell
        /// </summary>
        /// <param name="row">Table Row of the cell</param>
        /// <param name="col">Table Column of the cell</param>
        /// <param name="data">Data to load into the Combo box</param>
        public void AddComboBoxCell(int row, int col, string[] data)
        {
            try
            {
                StringCollection param = new StringCollection();
                param.AddRange(data);
                this.AddComboBoxCell(row, col, param);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Display the Combo Box
        /// </summary>
        /// <param name="location">Coordinates of the Cell</param>
        /// <param name="sz">Width of the cell</param>
        /// <param name="data">Data to be displayed in the ComboBox</param>
        public void ShowComboBox(Point location, Size sz, StringCollection data)
        {
            try
            {
                combo.Size = sz;
                combo.Location = location;
                combo.DataSource = null;
                combo.Items.Clear();
                foreach (string text in data)
                {
                    combo.Items.Add(text);
                }
                combo.Text = this.Items[row].SubItems[col].Text;
                combo.DropDownWidth = this.GetDropDownWidth(data);
                combo.Show();
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }

        private void ShowComboBox(Point location, Size sz, ArrayList data)
        {
            try
            {
                combo.Size = sz;
                combo.Location = location;
                combo.DataSource = data;
                combo.DisplayMember = "Degree";
                combo.ValueMember = "ID";

                combo.DropDownWidth = this.GetDropDownWidth(data);
                combo.Show();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        private void ShowComboBox(Point location, Size sz, DegreesDataSet.DegreesDataTable data)
        {
            try
            {
                combo.Size = sz;
                combo.Location = location;
                combo.SelectedItem = null;
                combo.DataSource = data;
                combo.DisplayMember = "Degree";
                combo.ValueMember = "ID";

                combo.DropDownWidth = this.GetDropDownWidth(data);
                combo.Show();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        private void ShowTextBox(Point location, Size sz)
        {
            try
            {
                textBox.Size = sz;
                textBox.Location = location;
                textBox.Text = this.Items[row].SubItems[col].Text;
                textBox.Show();
                textBox.Focus();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        private void ShowCheckBoxes(Point location, Size sz)
        {
            try
            {
                checkBoxes.Size = sz;
                checkBoxes.Location = location;
                clearCheckBoxes();
                setCheckBoxes();
                checkBoxes.Show();
                checkBoxes.Focus();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        private void clearCheckBoxes()
        {
            erx.Checked = io.Checked = ew.Checked = rep.Checked = false;
        }

        private void setCheckBoxes()
        {
            int value = Convert.ToInt32(this.Items[row].SubItems[col].Tag);

            if (value >= 8) { ew.Checked = true; value -= 8; }
            if (value >= 4) { rep.Checked = true; value -= 4; }
            if (value >= 2) { io.Checked = true; value -= 2; }
            if (value >= 1) { erx.Checked = true; }
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="e">Event</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            try
            {
                this.textBox.Visible = this.combo.Visible = false;

                if (!this.FullRowSelect || this.View != View.Details)
                {
                    return;
                }

                RECT rect = this.GetSubItemRect(new Point(e.X, e.Y));

                if (this.row != -1 && this.col != -1)
                {
                    SubItem cell = GetKey(new SubItem(this.row, this.col));
                    if (cell != null)
                    {
                        Size sz = new Size(this.Columns[col].Width, Items[row].Bounds.Height);
                        // if ? then : else
                        Point location = col == 0 ? new Point(0, rect.top) : new Point(rect.left, rect.top);
                        ValidateAndAddSubItems();

                        if (this.customCells[cell] == null)
                        {
                            this.ShowTextBox(location, sz);
                        }
                        else if(this.customCells[cell].GetType() == typeof(ArrayList))
                        {
                            this.ShowComboBox(location, sz, (ArrayList)customCells[cell]);
                        }
                        else if (this.customCells[cell].GetType() == typeof(DegreesDataSet.DegreesDataTable))
                        {
                            this.ShowComboBox(location, sz, (DegreesDataSet.DegreesDataTable)customCells[cell]);
                        }
                        else if (this.customCells[cell].ToString() == string.Empty)
                        {
                            if (string.IsNullOrEmpty(this.Items[row].SubItems[col].Text.ToString()))
                                this.Items[row].SubItems[col].Text = "4";

                            this.ShowCheckBoxes(location, sz);
                        }
                        else
                        {
                            this.ShowComboBox(location, sz, (StringCollection)customCells[cell]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        private void ValidateAndAddSubItems()
        {
            try
            {
                while (this.Items[this.row].SubItems.Count < this.Columns.Count && addSubItem)
                {
                    this.Items[this.row].SubItems.Add("");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        private int GetDropDownWidth(DegreesDataSet.DegreesDataTable data)
        {
            StringCollection collection = new StringCollection();
            foreach (DataRow drow in data)
            {
                collection.Add(drow.ItemArray[0].ToString());
            }
            return GetDropDownWidth(collection);
        }

        private int GetDropDownWidth(ArrayList data)
        {
            StringCollection collection = new StringCollection();
            foreach(DegreeItem item in data)
            {
                collection.Add(item.Degree);
            }
            return GetDropDownWidth(collection);
        }

        private int GetDropDownWidth(StringCollection data)
        {
            if (data.Count == 0)
            {
                return this.combo.Width;
            }

            string maximum = data[0];

            foreach (string text in data)
            {
                if (maximum.Length < text.Length)
                {
                    maximum = text;
                }
            }
            return (int)(this.CreateGraphics().MeasureString(maximum, this.Font).Width);
        }

        private SubItem GetKey(SubItem cell)
        {
            try
            {
                foreach (SubItem key in this.customCells.Keys)
                {
                    if (key.row == cell.row && key.col == cell.col) return key;
                    else if (key.row == -1 && key.col == cell.col) return key;
                    else if (key.row == cell.row && key.col == -1) return key;
                    else if (key.row == -1 && key.col == -1) return key;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return null;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.row != -1 && this.col != -1)
                {
                    this.Items[row].SubItems[col].Text = this.textBox.Text;
                    this.textBox.Hide();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.row != -1 && this.col != -1)
                {
                    this.Items[row].SubItems[col].Text = this.combo.Text;
                    if(this.combo.SelectedValue != null)
                        this.Items[row].SubItems[col].Tag = this.combo.SelectedValue.ToString();
                    this.combo.Visible = !hideComboAfterSelChange;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        void checkBoxes_Leave(object sender, EventArgs e)
        {
            string addons = string.Empty;
            /*int value = 0;
            if (io.Checked) { value ^= IO; ew.Checked = true; addons = ", Ordering" + addons; }
            if (erx.Checked) { value ^= ERX; ew.Checked = true; addons += ", eRx"; }
            if (ew.Checked) { value ^= EW; rep.Checked = true; addons = ", Edit" + addons; }
            if (rep.Checked) { value ^= REP; addons = "VHR" + addons; }
            this.Items[row].SubItems[col].Text = addons.ToString();
            this.Items[row].SubItems[col].Tag = value.ToString();
             */
            AddOns addonflags = AddOns.Repository;
            if (io.Checked) addonflags |= AddOns.Ordering;
            if (erx.Checked) addonflags |= AddOns.eRx;
            if (ew.Checked) addonflags |= AddOns.Edit;
            if (rep.Checked) addonflags |= AddOns.Repository;

            this.Items[row].SubItems[col].Text = addonflags.ToString();
            this.Items[row].SubItems[col].Tag = (int)addonflags;
            clearCheckBoxes();
            this.checkBoxes.Visible = !hideCheckAfterChange;
        }

        #endregion
    }
}