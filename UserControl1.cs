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

        

        public UserControl1()
        {
            InitializeComponent();
            
        }


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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int column = tableLayoutPanel1.GetColumn(button.Parent);
            int row = tableLayoutPanel1.GetRow(button.Parent);
            Console.WriteLine("column number : " + column + "  row number : " + row );

            string ipAddress = textBoxIPAddress.Text;
            int streamNumber = (int) numericUpDownStreamNumber.Value;
            string brand = textBoxBrand.Text;
            string streamAddress = textBoxStreamAddress.Text;

            Stream stream = new Stream(brand, ipAddress, streamNumber, streamAddress);
            Form1.streams.Add(stream);

            changeToAddedRow(column, row );
            addNewRow(row+1);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int row = tableLayoutPanel1.GetRow(button.Parent);
            enableRow(row);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int row = tableLayoutPanel1.GetRow(button.Parent);

            for (int column = 0; column < tableLayoutPanel1.ColumnCount; column++)
                Controls.Remove(tableLayoutPanel1.GetControlFromPosition(column, row));

            remove_row(tableLayoutPanel1, row);
        }


        private void initTable()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel.MaximumSize = new Size(0, 1000);

        }

        private void changeToAddedRow(int column , int row)
        {
            Panel panel = (Panel)tableLayoutPanel1.GetControlFromPosition(column, row);
            panel.Controls.Clear();

            Button buttonUpdate = new Button();
            buttonUpdate.Size = new Size(70, 23);
            buttonUpdate.Margin = new Padding(0, 0, 0, 0);
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += new EventHandler(buttonUpdate_Click);
           
            Button buttonDelete = new Button();
            buttonDelete.Size = new Size(70, 23);
            buttonDelete.Margin = new Padding(0, 0, 0, 0);
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += new EventHandler(buttonDelete_Click);

            panel.Controls.AddRange(new Control[] { buttonUpdate, buttonDelete });

            disableRow(row);
            return;
        }

        private void disableRow(int row)
        {
            for (int column = 0; column < tableLayoutPanel1.ColumnCount - 1; column++)
                tableLayoutPanel1.GetControlFromPosition(column, row).Enabled = false;
        }
        private void enableRow(int row)
        {
            for (int column = 0; column < tableLayoutPanel1.ColumnCount - 1; column++)
                tableLayoutPanel1.GetControlFromPosition(column, row).Enabled = true;
        }


        private void addNewRow(int row)
        {
            if (row >= tableLayoutPanel1.RowCount)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutPanel1.RowCount++;
            }


            TextBox textBoxIPAddress1 = new TextBox();
            textBoxIPAddress1.Size = new Size(100, 23);
            textBoxIPAddress1.Margin = new Padding(4, 4, 4, 4);

            NumericUpDown numericUpDownStreamNumber1 = new NumericUpDown();
            numericUpDownStreamNumber1.Size = new Size(50, 23);
            numericUpDownStreamNumber1.Margin = new Padding(4, 4, 4, 4);
            numericUpDownStreamNumber1.Minimum = 1;
            numericUpDownStreamNumber1.Maximum = 3;
            numericUpDownStreamNumber1.TextAlign = HorizontalAlignment.Center;

            TextBox textBoxBrand1 = new TextBox();
            textBoxBrand1.Size = new Size(200, 23);
            textBoxBrand1.Margin = new Padding(4, 4, 4, 4);

            TextBox textBoxStreamAddress1 = new TextBox();
            textBoxStreamAddress1.Size = new Size(400, 23);
            textBoxStreamAddress1.Margin = new Padding(4, 4, 4, 4);

            Panel panel11 = new Panel();
            panel11.AutoSize = true;
            Button buttonAdd1 = new Button();
            buttonAdd1.Size = new Size(50, 23);
            buttonAdd1.Margin = new Padding(0, 0, 0, 0);
            buttonAdd1.Text = "Add";
            buttonAdd1.UseVisualStyleBackColor = true;
            buttonAdd1.Click += new EventHandler(buttonAdd_Click);
            panel11.Controls.Add(buttonAdd1);

            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.Controls.Add(textBoxIPAddress1, 0, row);
            tableLayoutPanel1.Controls.Add(numericUpDownStreamNumber1, 1, row);
            tableLayoutPanel1.Controls.Add(textBoxBrand1, 2, row);
            tableLayoutPanel1.Controls.Add(textBoxStreamAddress1, 3, row);
            tableLayoutPanel1.Controls.Add(panel11, 4, row);
            tableLayoutPanel1.ResumeLayout();

            return;

        }


    }
}
