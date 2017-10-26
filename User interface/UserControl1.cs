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

        Stream defaultStream = new Stream("192.168.100.160", 1, "SONY", "rtsp://admin:admin@192.168.1.16/media/video1");

        public UserControl1(Form1 form)
        {
            this.form = form;
            InitializeComponent();
            setTables();
        }


        #region Init Board

        private void setTables()
        {
            table = initTable();
            tabPage1.Controls.Add(table);

            fillTableFromPlaylist(table, 0);
        }

        public MyTable initTable()
        {
            MyTable table = new MyTable
            {
                AutoScroll = true,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
            };
            table.Location = new Point(0, 0);
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowCount++;
            createTitleRow(table);
            
            return table;
        }

        public void fillTableFromPlaylist(MyTable table, int tabIndex)
        {
            Playlist playlist = form.playlists[tabIndex];

            if (playlist != null)
            {
                foreach (Stream stream in playlist)
                { 
                    table.addRow(table.RowCount, stream);
                    table.changeToAddedRow(table.RowCount-1);
                }
            }
            table.addRow(table.RowCount);
        }

        public void createTitleRow(MyTable table)
        {
            string[] columnTitles = { "IP Adress", "Stream number", "Brand", "Stream address", "Actions" };
            for (int i = 0; i < columnTitles.Count(); i++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                table.ColumnCount++;
                createCellLabel(table, i, 0, columnTitles[i]);
            }
        }

        public void createCellLabel(MyTable table, int column, int row, string message )
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

            Stream stream = getStreamFromRow(row);
            if (!stream.isEmpty())
            {
                form.playlists[0].Add(stream);
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

            Stream previousStream = form.playlists[0][row - 1];

            Stream newStream = getStreamFromRow(row);
            if (!newStream.isEmpty() && previousStream != newStream)
                form.playlists[0][row - 1] = newStream;

            table.changeToAddedRow(row);

            table.ResumeLayout();
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            table.SuspendLayout();

            Button button = (Button)sender;
            int row = table.GetRow(button.Parent);

            if (MessageBox.Show("Do you really want to delete this stream ?", "Stream deletion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                form.playlists[0].RemoveAt(row - 1);
                table.remove_row(row);
            }

            table.ResumeLayout();
        }

        #endregion

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(form.playlists[0].ToArray());
        }


        public Stream getStreamFromRow(int row)
        {
            string ipAddress = ((TextBox)table.GetControlFromPosition(0, row)).Text;
            int streamNumber = (int)((NumericUpDown)table.GetControlFromPosition(1, row)).Value;
            string brand = ((TextBox)table.GetControlFromPosition(2, row)).Text;
            string streamAddress = ((TextBox)table.GetControlFromPosition(3, row)).Text;

            return new Stream(ipAddress, streamNumber, brand, streamAddress);
        }
    }
}
