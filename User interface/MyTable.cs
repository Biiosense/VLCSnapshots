using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace User_interface
{
    public class MyTable : TableLayoutPanel
    {
        #region Add / Remove Row

        public void addRow(int row, Stream stream)
        {
            addRow( row, stream.getIPAddress(), stream.getStreamNumber(), stream.getBrand(), stream.getStreamAddress() );
        }

        public void addRow(int row, string IPadress = "", int streamNumber = 1, string brand = "", string streamAddress = "")
        {
            if (row == RowCount)
            {
                RowStyles.Add(new RowStyle(SizeType.AutoSize));
                RowCount++;
            }


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
            buttonAdd.Click += new EventHandler(((UserControl1)GetContainerControl()).buttonAdd_Click);
            new ToolTip().SetToolTip(buttonAdd, "Add");

            Button buttonUpdate = new Button
            {
                Name = "ButtonUpdate",
                Size = new Size(70, 23),
                Margin = new Padding(0),
                Text = "&Update",
                UseVisualStyleBackColor = true
            };
            buttonUpdate.Click += new EventHandler(((UserControl1)GetContainerControl()).buttonUpdate_Click);
            new ToolTip().SetToolTip(buttonUpdate, "Update");

            Button buttonValidate = new Button
            {
                Name = "ButtonValidate",
                Size = new Size(70, 23),
                Margin = new Padding(0),
                Text = "&Validate",
                UseVisualStyleBackColor = true
            };
            buttonValidate.Click += new EventHandler(((UserControl1)GetContainerControl()).buttonValidate_Click);
            new ToolTip().SetToolTip(buttonValidate, "Validate");

            Button buttonDelete = new Button
            {
                Name = "ButtonDelete",
                Size = new Size(70, 23),
                Margin = new Padding(0),
                Text = "&Delete",
                UseVisualStyleBackColor = true
            };
            buttonDelete.Click += new EventHandler(((UserControl1)GetContainerControl()).buttonDelete_Click);
            new ToolTip().SetToolTip(buttonDelete, "Delete");

            buttonUpdate.Visible = false;
            buttonValidate.Visible = false;
            buttonDelete.Visible = false;

            panel.Controls.AddRange( new Control[] { buttonAdd, buttonUpdate, buttonValidate, buttonDelete });

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
                    var control = GetControlFromPosition(j, i);
                    if (control != null)
                        SetRow(control, i - 1);
                }
            }
            RowStyles.RemoveAt(RowCount-- - 1);
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

        public void disableOtherRows(int row)
        {
            for (int i = 0; i < RowCount; i++)
            {
                if (i != row-1)
                    if (GetControlFromPosition(0, i).Enabled)
                        disableRow(i);
                else
                    enableRow(i);
            }
        }
        #endregion


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

    }
}
