using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using User_interface;
using Data;

namespace User_interface
{
    public partial class PlaylistEditorUserControl : UserControl
    {
        Form1 form;
        BindingList<Playlist> bindingList;
        int currentPlaylistIndex = -1;
        int currentPlaylistsCount = -1;

        public PlaylistEditorUserControl(Form1 form)
        {
            InitializeComponent();
            this.form = form;
            setBindingList();
        }

        private void setBindingList()
        {
            if (form.playlists != null)
                bindingList = new BindingList<Playlist>(form.playlists);
            else
                bindingList = new BindingList<Playlist>();
            panelPlaylistView.Controls.Add(new MyTable());
            listBoxPlaylists.DataSource = bindingList;
            checkListHasItems();
        }


        private void buttonAddPlaylist_Click(object sender, EventArgs e)
        {
            Playlist playlist = new Playlist();
            playlist.setName("New playlist");
            playlist.setRunTime(5);
            bindingList.Add(playlist);

            currentPlaylistsCount++;
            checkListHasItems();
            updateSelectedItem(bindingList.Count - 1);
        }

        private void buttonDeletePlaylist_Click(object sender, EventArgs e)
        {
            if (listBoxPlaylists.SelectedIndex != -1 && MessageBox.Show("Do you really want to delete this playlist ?", "Playlist deletion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bindingList.RemoveAt(listBoxPlaylists.SelectedIndex);
                currentPlaylistsCount--;
                checkListHasItems();
                checkSelectedItemChanged();
            }
        }

        private void listBoxPlaylists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPlaylists.SelectedIndex != currentPlaylistIndex)
            {
                updateSelectedItem(listBoxPlaylists.SelectedIndex);
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            MyTable table = (MyTable)panelPlaylistView.Controls["Table"];
            Playlist playlist = (Playlist)listBoxPlaylists.SelectedItem;

            if (table.hasBeingModifiedRows())
            {

                DialogResult dialogResult = MessageBox.Show("Save in-edition streams ?", "Playlist save", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                    for (int j = 1; j < table.RowCount - 1; j++)
                        if (table.GetControlFromPosition(0, j).Enabled == true)
                        {
                            table.SuspendLayout();
                            table.changeToAddedRow(j);
                            table.ResumeLayout();
                        }
                        else if (dialogResult == DialogResult.No)
                            for (int i = 1; i < table.RowCount - 1; i++)
                                if (table.GetControlFromPosition(0, i).Enabled == true)
                                {
                                    table.SuspendLayout();
                                    table.remove_row(i);
                                    table.addRowFromStream(i, playlist[i - 1]);
                                    table.ResumeLayout();
                                }
                                else
                                    return;
            }

            Playlist newPlaylist = table.exportPlaylist();
            newPlaylist.setName(textBoxPlaylistName.Text);
            newPlaylist.setRunTime((int)numericUpDownRunTime.Value);

            if (playlist != newPlaylist)
            {
                bindingList[listBoxPlaylists.SelectedIndex] = newPlaylist;
                form.playlists = bindingList.ToList();
            }
        }

        private void checkListHasItems()
        {
            if (bindingList.Count == 0)
            {
                labelPlaylistSettings.Visible = false;
                panelPlaylistSettings.Visible = false;
            }
            else
            {
                labelPlaylistSettings.Visible = true;
                panelPlaylistSettings.Visible = true;
            }
        }

        private void updateSelectedItem(int index)
        {
            currentPlaylistIndex = index;
            listBoxPlaylists.SelectedIndex = index;

            MyTable table = (MyTable)panelPlaylistView.Controls["Table"];
            table.SuspendLayout();
            table.Clear();
            if (index >= 0)
            {
                Playlist playlist = (Playlist)listBoxPlaylists.Items[index];
                textBoxPlaylistName.Text = playlist.getName();
                numericUpDownRunTime.Value = playlist.getRunTime();
                table.importPlaylist(playlist);
            }
            table.ResumeLayout();
        }

        private void checkSelectedItemChanged()
        {
            if (listBoxPlaylists.SelectedIndex == currentPlaylistIndex && bindingList.Count != currentPlaylistsCount)
            {
                updateSelectedItem(listBoxPlaylists.SelectedIndex);
            }
        }
    }
}
