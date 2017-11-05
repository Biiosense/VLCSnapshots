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

        public UserControl1(Form1 form)
        {
            this.form = form;
            InitializeComponent();
            generateTabControl();
        }


        #region Init Board

        private void generateTabControl()
        {
            TabControl tabControl = new TabControl
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(tabControl);
            generateTabs(tabControl);
        }

        private void generateTabs(TabControl tabControl)
        {
            int tabCount = form.playlists.Length;
            if (tabCount > 0)
            {
                for (int i = 0; i < tabCount; i++)
                {
                    Playlist playlist = form.playlists[i];
                    TabPage tabPage = generateTab(playlist.getName());
                    tabControl.Controls.Add(tabPage);
                    fillTableFromPlaylist( tabPage.Controls.OfType<MyTable>().First(), playlist);
                }
            }
            else
            {
                tabControl.Controls.Add( generateTab("Playlist 1"));
            }
        }

        private TabPage generateTab(String tabName)
        {
            TabPage tabPage = new TabPage
            {
                Text = tabName
            };
            tabPage.Controls.Add(generateTable());
            return tabPage;
        }


        public MyTable generateTable()
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

        public void fillTableFromPlaylist(MyTable table, Playlist playlist)
        { 
            foreach (Stream stream in playlist)
            { 
                table.addRow(table.RowCount, stream);
                table.changeToAddedRow(table.RowCount-1);
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
            MyTable table = getCurrentTable();
            table.SuspendLayout();
            Button button = (Button)sender;
            int row = table.GetRow(button.Parent);

            Stream stream = getStreamFromRow(table, row);
            if (!stream.isEmpty())
            {
                form.playlists[0].Add(stream);
                table.changeToAddedRow(row);
                table.addRow(row + 1);
            }

            table.PerformLayout();
            table.ResumeLayout(true);
        }

        public void buttonUpdate_Click(object sender, EventArgs e)
        {
            MyTable table = getCurrentTable();
            table.SuspendLayout();
            Button button = (Button)sender;
            int row = table.GetRow(button.Parent);

            table.changeToBeingModifiedRow(row);

            table.PerformLayout();
            table.ResumeLayout(true);
        }

        public void buttonValidate_Click(object sender, EventArgs e)
        {
            MyTable table = getCurrentTable();
            table.SuspendLayout();
            Button button = (Button)sender;
            int row = table.GetRow(button.Parent);

            Stream previousStream = form.playlists[0][row - 1];

            Stream newStream = getStreamFromRow(table, row);
            if (!newStream.isEmpty() && previousStream != newStream)
                form.playlists[0][row - 1] = newStream;

            table.changeToAddedRow(row);

            table.PerformLayout();
            table.ResumeLayout(true);
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            MyTable table = getCurrentTable();
            table.SuspendLayout();

            Button button = (Button)sender;
            int row = table.GetRow(button.Parent);

            if (MessageBox.Show("Do you really want to delete this stream ?", "Stream deletion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                form.playlists[0].RemoveAt(row - 1);
                table.remove_row(row);
            }

            table.PerformLayout();
            table.ResumeLayout(true);
        }

        #endregion

        public MyTable getCurrentTable()
        {
            return Controls.OfType<TabControl>().First().SelectedTab.Controls.OfType<MyTable>().First();
        }

        public Stream getStreamFromRow(MyTable table, int row)
        {
            string ipAddress = ((TextBox)table.GetControlFromPosition(0, row)).Text;
            int streamNumber = (int)((NumericUpDown)table.GetControlFromPosition(1, row)).Value;
            string brand = ((TextBox)table.GetControlFromPosition(2, row)).Text;
            string streamAddress = ((TextBox)table.GetControlFromPosition(3, row)).Text;

            return new Stream(ipAddress, streamNumber, brand, streamAddress);
        }
    }
}
