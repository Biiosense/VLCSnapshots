using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace User_interface
{
    public partial class UserControl1 : UserControl
    {
        Form1 form;
        MyTable table;

        public UserControl1(Form1 form)
        {
            this.form = form;
            InitializeComponent();
            setTable();
        }


        #region Init Board

        private void setTable()
        {
            table = new MyTable
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

            table.ResumeLayout();
            tabPage1.Controls.Add(table);
            table.addRow(1, "192.168.100.160", 1, "SONY", "rtsp://admin:admin@192.168.1.16/media/video1");
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

        public void buttonAdd_Click(object sender, EventArgs e)
        {
            table.SuspendLayout();

            Button button = (Button)sender;
            int row = table.GetRow(button.Parent);

            string ipAddress = ((TextBox)table.GetControlFromPosition(0, row)).Text;
            int streamNumber = (int) ((NumericUpDown)table.GetControlFromPosition(1, row)).Value;
            string brand = ((TextBox)table.GetControlFromPosition(2, row)).Text;
            string streamAddress = ((TextBox)table.GetControlFromPosition(3, row)).Text;

            if( ipAddress != "" && brand != "" && streamAddress != "" )
            {
                form.playlist.Add(new Stream(brand, ipAddress, streamNumber, streamAddress));
                table.changeToAddedRow(row);
                table.addRow(row + 1);
            }

            table.ResumeLayout();
        }

        public void buttonUpdate_Click(object sender, EventArgs e)
        {
            table.SuspendLayout();

            Button button = (Button)sender;
            int row = table.GetRow(button.Parent);
            table.changeToBeingModifiedRow(row);

            table.ResumeLayout();
        }

        public void buttonValidate_Click(object sender, EventArgs e)
        {
            table.SuspendLayout();

            Button button = (Button)sender;
            int row = table.GetRow(button.Parent);
            Stream previousStream = form.playlist[row-1];

            string ipAddress = ((TextBox)table.GetControlFromPosition(0, row)).Text;
            int streamNumber = (int)((NumericUpDown)table.GetControlFromPosition(1, row)).Value;
            string brand = ((TextBox)table.GetControlFromPosition(2, row)).Text;
            string streamAddress = ((TextBox)table.GetControlFromPosition(3, row)).Text;

            if (ipAddress != "" && brand != "" && streamAddress != "")
            {
                Stream newStream = new Stream(brand, ipAddress, streamNumber, streamAddress);
                if (previousStream != newStream)
                {
                    form.playlist[row-1] = newStream;
                    table.changeToAddedRow(row);
                }
            }

            table.ResumeLayout();
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            table.SuspendLayout();

            Button button = (Button)sender;
            int row = table.GetRow(button.Parent);
            form.playlist.RemoveAt(row-1);
            table.remove_row(row);
                
            table.ResumeLayout();
        }

        #endregion

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(form.playlist.ToArray());
        }
    }
}
