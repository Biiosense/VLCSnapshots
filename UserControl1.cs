using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VLCSnapshots
{
    public partial class UserControl1 : UserControl
    {

        TableLayoutPanel table;

        public UserControl1()
        {
            InitializeComponent();
            setTable();
        }

        #region Library 

        public void remove_row(TableLayoutPanel panel, int row_index_to_remove)
        {
            if (row_index_to_remove >= panel.RowCount)
                return;

            for (int i = 0; i < panel.ColumnCount; i++)
                panel.Controls.Remove(panel.GetControlFromPosition(i, row_index_to_remove));

            // move up row controls that comes after row we want to remove
            for (int i = row_index_to_remove + 1; i < panel.RowCount; i++)
            {
                for (int j = 0; j < panel.ColumnCount; j++)
                {
                    var control = panel.GetControlFromPosition(j, i);
                    if (control != null)
                        panel.SetRow(control, i - 1);
                }
            }

            panel.RowStyles.RemoveAt(panel.RowCount-- - 1);
        }

        #endregion


        #region Init Board

        private void setTable()
        {
            table = new TableLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                MaximumSize = new Size(0, 1000),
                
            };
            table.SuspendLayout();
            table.Location = new Point(0, 0);
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowCount++;
            string[] columnTitles = { "IP Adress", "Stream number", "Brand", "Stream address", "Actions" };
            for( int i=0; i < columnTitles.Count(); i++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                table.ColumnCount++;
                createCellLabel(i, 0, columnTitles[i]);
            }
            addNewRow(1, "192.168.100.160", 1, "SONY", "rtsp://admin:admin@192.168.1.16/media/video1");
            table.ResumeLayout();
            tabPage1.Controls.Add(table);

        }

        public void createCellLabel(int column, int row, string message )
        {
            Label label = new Label
            {
                AutoSize = true,
                Text = message
            };
            table.Controls.Add(label, column, row);
        }

        #endregion

        #region Buttons Click

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int column = table.GetColumn(button.Parent);
            int row = table.GetRow(button.Parent);
            Console.WriteLine("column number : " + column + "  row number : " + row );

            string ipAddress = ((TextBox)table.GetControlFromPosition(0, row)).Text;
            int streamNumber = (int) ((NumericUpDown)table.GetControlFromPosition(1, row)).Value;
            string brand = ((TextBox)table.GetControlFromPosition(2, row)).Text;
            string streamAddress = ((TextBox)table.GetControlFromPosition(3, row)).Text;

            Stream stream = new Stream(brand, ipAddress, streamNumber, streamAddress);
            Form1.streams.Add(stream);

            changeToAddedRow(column, row );
            addNewRow(row+1);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int row = table.GetRow(button.Parent);
            enableRow(row);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            table.SuspendLayout();

            Button button = (Button)sender;
            int row = table.GetRow(button.Parent);
            for (int column = 0; column < table.ColumnCount; column++)
                Controls.Remove(table.GetControlFromPosition(column, row));
            remove_row(table, row);
                
            table.ResumeLayout();
        }

        #endregion

        #region Button Actions

        private void changeToAddedRow(int column , int row)
        {
            Button buttonUpdate = new Button
            {
                Size = new Size(70, 23),
                Margin = new Padding(0),
                Text = "Update",
                UseVisualStyleBackColor = true
            };
            buttonUpdate.Click += new EventHandler(buttonUpdate_Click);

            Button buttonDelete = new Button
            {
                Size = new Size(70, 23),
                Margin = new Padding(0),
                Text = "Delete",
                UseVisualStyleBackColor = true
            };
            buttonDelete.Click += new EventHandler(buttonDelete_Click);


            FlowLayoutPanel panel = (FlowLayoutPanel)table.GetControlFromPosition(column, row);
            panel.Controls.Clear();
            panel.Controls.AddRange(new Control[] { buttonUpdate, buttonDelete });
           
            disableRow(row);

        }

        private void disableRow(int row)
        {
            for (int column = 0; column < table.ColumnCount - 1; column++)
                table.GetControlFromPosition(column, row).Enabled = false;
        }
        private void enableRow(int row)
        {
            for (int column = 0; column < table.ColumnCount - 1; column++)
                table.GetControlFromPosition(column, row).Enabled = true;
        }


        private void addNewRow(int row, string IPadress="", int streamNumber=1, string brand="", string streamAddress="")
        {
            if (row >= table.RowCount)
            {
                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                table.RowCount++;
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

            Button buttonAdd1 = new Button
            {
                Size = new Size(50, 23),
                Margin = new Padding(0),
                Text = "Add",
                UseVisualStyleBackColor = true
            };
            buttonAdd1.Click += new EventHandler(buttonAdd_Click);
            panel.Controls.Add(buttonAdd1);

            table.SuspendLayout();
            table.Controls.Add(textBoxIPAddress, 0, row);
            table.Controls.Add(numericUpDownStreamNumber, 1, row);
            table.Controls.Add(textBoxBrand, 2, row);
            table.Controls.Add(textBoxStreamAddress, 3, row);
            table.Controls.Add(panel, 4, row);
            table.ResumeLayout();
        }

        #endregion
    }
}
