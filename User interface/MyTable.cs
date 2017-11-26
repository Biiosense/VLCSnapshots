using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using System.ComponentModel;

namespace User_interface
{
    public class MyTable : TableLayoutPanel
    {
        public MyTable()
        {
            InitializeComponent();
            createTitleRow();
            addNewRow();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            Name = "Table";
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            Location = new Point(0, 0);

            ResumeLayout(false);
        }

        public void createTitleRow()
        {
            string[] columnTitles = { "IP Adress", "Stream number", "Brand", "Stream address", "Actions" };

            RowStyles.Add(new RowStyle(SizeType.AutoSize));
            RowCount++;
            for (int i = 0; i < columnTitles.Count(); i++)
            {
                ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                ColumnCount++;
                Label label = new Label
                {
                    AutoSize = true,
                    Text = columnTitles[i]
                };
                Controls.Add(label, i, 0);
            }
        }

        public void importPlaylist( Playlist playlist)
        {
            for (int i = 0; i < playlist.Count; i++)
                addRowFromStream(i + 1, playlist[i]);
        }

        public Playlist exportPlaylist()
        {
            Playlist playlist = new Playlist();
            for( int i=1; i<RowCount-1; i++)
                playlist.Add(getStreamFromRow(i));
            return playlist;
        }

        public Stream getStreamFromRow(int row)
        {
            string ipAddress = ((TextBox)GetControlFromPosition(0, row)).Text;
            int streamNumber = (int)((NumericUpDown)GetControlFromPosition(1, row)).Value;
            string brand = ((TextBox)GetControlFromPosition(2, row)).Text;
            string streamAddress = ((TextBox)GetControlFromPosition(3, row)).Text;

            return new Stream(ipAddress, streamNumber, brand, streamAddress);
        }

        public void Clear()
        { 
            for (int i = RowCount-2; i > 0; i--)
                remove_row(i);
        }

        #region Add / Remove Row

        public void addRowFromStream(int row, Stream stream)
        {
            addRow(row, stream.getIPAddress(), stream.getStreamNumber(), stream.getBrand(), stream.getStreamAddress() );
            changeToAddedRow(row);
        }

        public void addNewRow()
        {
            addRow(RowCount, "", 1, "", "");
        }
   
        public void addRow(int row, string IPadress, int streamNumber, string brand, string streamAddress)
        {
            TextBox textBoxIPAddress = new TextBox
            {
                Size = new Size(100, 23),
                Margin = new Padding(4),
                Text = IPadress
            };

            NumericUpDown numericUpDownStreamNumber = new NumericUpDown
            {
                Size = new Size(50, 23),
                Margin = new Padding(4),
                Minimum = 1,
                Maximum = 3,
                TextAlign = HorizontalAlignment.Center,
                Value = streamNumber
            };

            TextBox textBoxBrand = new TextBox
            {
                Size = new Size(200, 23),
                Margin = new Padding(4),
                Text = brand
            };

            TextBox textBoxStreamAddress = new TextBox
            {
                Size = new Size(400, 23),
                Margin = new Padding(4),
                Text = streamAddress
            };

            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                AutoSize = true
            };

            Button buttonAdd = new Button
            {
                Name = "ButtonAdd",
                Size = new Size(70, 23),
                Margin = new Padding(0),
                Text = "&Add",
                UseVisualStyleBackColor = true
            };
            buttonAdd.Click += buttonAdd_Click;
            new ToolTip().SetToolTip(buttonAdd, "Add");

            Button buttonUpdate = new Button
            {
                Name = "ButtonUpdate",
                Size = new Size(70, 23),
                Margin = new Padding(0),
                Text = "&Update",
                UseVisualStyleBackColor = true
            };
            buttonUpdate.Click += buttonUpdate_Click;
            new ToolTip().SetToolTip(buttonUpdate, "Update");

            Button buttonValidate = new Button
            {
                Name = "ButtonValidate",
                Size = new Size(70, 23),
                Margin = new Padding(0),
                Text = "&Validate",
                UseVisualStyleBackColor = true
            };
            buttonValidate.Click += buttonValidate_Click;
            new ToolTip().SetToolTip(buttonValidate, "Validate");

            Button buttonDelete = new Button
            {
                Name = "ButtonDelete",
                Size = new Size(70, 23),
                Margin = new Padding(0),
                Text = "&Delete",
                UseVisualStyleBackColor = true
            };
            buttonDelete.Click += buttonDelete_Click;
            new ToolTip().SetToolTip(buttonDelete, "Delete");

            buttonUpdate.Visible = false;
            buttonValidate.Visible = false;
            buttonDelete.Visible = false;

            panel.Controls.AddRange( new Control[] { buttonAdd, buttonUpdate, buttonValidate, buttonDelete });

            RowStyles.Add(new RowStyle(SizeType.AutoSize));
            RowCount++;
            if ( row < RowCount-1)
            {
                for (int i = RowCount-2; i >= row; i--)
                    for (int j = 0; j < ColumnCount; j++)
                         SetRow(GetControlFromPosition(j, i), i + 1);
                        
            }

            Controls.Add(textBoxIPAddress, 0, row);
            Controls.Add(numericUpDownStreamNumber, 1, row);
            Controls.Add(textBoxBrand, 2, row);
            Controls.Add(textBoxStreamAddress, 3, row);
            Controls.Add(panel, 4, row);
        }

        public void remove_row( int row_index_to_remove)
        {
            if (row_index_to_remove >= RowCount)
                return;

            for (int column = 0; column < ColumnCount; column++)
                Controls.Remove(GetControlFromPosition(column, row_index_to_remove));

            for (int i = row_index_to_remove + 1; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    Control control = GetControlFromPosition(j, i);
                    if (control != null)
                        SetRow(control, i - 1);
                }
            }
            RowStyles.RemoveAt(RowCount-- - 1);
        }

        #endregion

        #region Clicks actions

        public void buttonAdd_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            int row = GetRow(((Button)sender).Parent);

            Stream stream = getStreamFromRow(row);
            if (!stream.isEmpty())
            {
                changeToAddedRow(row);
                addNewRow();
            }

            PerformLayout();
            ResumeLayout(true);
        }

        public void buttonUpdate_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            int row = GetRow(((Button)sender).Parent);

            changeToBeingModifiedRow(row);

            PerformLayout();
            ResumeLayout(true);
        }

        public void buttonValidate_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            int row = GetRow(((Button)sender).Parent);

            changeToAddedRow(row);

            PerformLayout();
            ResumeLayout(true);
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            int row = GetRow(((Button)sender).Parent);

            if (MessageBox.Show("Do you really want to delete this stream ?", "Stream deletion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                remove_row(row);

            PerformLayout();
            ResumeLayout(true);
        }

        #endregion

        #region Enable / Disable Row

        public void disableRow(int row)
        {
            for (int column = 0; column < ColumnCount - 1; column++)
                GetControlFromPosition(column, row).Enabled = false;
        }

        public void enableRow(int row)
        {
            for (int column = 0; column < ColumnCount - 1; column++)
                GetControlFromPosition(column, row).Enabled = true;
        }

        #endregion

        #region Buttons managment

        public void changeToBeingModifiedRow(int row)
        {
            FlowLayoutPanel panel = (FlowLayoutPanel)GetControlFromPosition(4, row);
            panel.Controls["buttonAdd"].Visible = false;
            panel.Controls["buttonUpdate"].Visible = false;
            panel.Controls["buttonValidate"].Visible = true;
            panel.Controls["buttonDelete"].Visible = true;
            enableRow(row);
        }

        public void changeToAddedRow(int row)
        {
            FlowLayoutPanel panel = (FlowLayoutPanel)GetControlFromPosition(4, row);
            panel.Controls["buttonAdd"].Visible = false;
            panel.Controls["buttonUpdate"].Visible = true;
            panel.Controls["buttonValidate"].Visible = false;
            panel.Controls["buttonDelete"].Visible = true;
            disableRow(row);
        }

        public bool hasBeingModifiedRows()
        {
            for (int i = 1; i < RowCount - 1; i++)
                if (GetControlFromPosition(0, i).Enabled == true)
                    return true;

            return false;
        }

        #endregion

    }
}
