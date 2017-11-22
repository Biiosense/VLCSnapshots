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
        int currentPlaylistIndex;

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
            listBoxPlaylists.DataSource = bindingList;
            panelPlaylistView.Controls.Add(new MyTable());
            currentPlaylistIndex = -1;
        }


        private void buttonAddPlaylist_Click(object sender, EventArgs e)
        {
            Playlist playlist = new Playlist();
            playlist.setName("New playlist");
            playlist.setRunTime(5);
            bindingList.Add(playlist);
        }

        private void buttonDeletePlaylist_Click(object sender, EventArgs e)
        {
            if (listBoxPlaylists.SelectedIndex != -1)
                if (MessageBox.Show("Do you really want to delete this playlist ?", "Playlist deletion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    bindingList.RemoveAt(listBoxPlaylists.SelectedIndex);
        }

        private void listBoxPlaylists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( listBoxPlaylists.SelectedIndex != currentPlaylistIndex)
            {
                currentPlaylistIndex = listBoxPlaylists.SelectedIndex;
                Playlist playlist = (Playlist)listBoxPlaylists.SelectedItem;
                textBoxPlaylistName.Text = playlist.getName();
                numericUpDownRunTime.Value = playlist.getRunTime();

                MyTable table = (MyTable)panelPlaylistView.Controls["Table"];
                table.SuspendLayout();
                table.Clear();
                table.importPlaylist(playlist);
                table.ResumeLayout();
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            MyTable table = (MyTable)panelPlaylistView.Controls["Table"];
            Playlist newPlaylist = table.exportPlaylist();
            newPlaylist.setName(textBoxPlaylistName.Text);
            newPlaylist.setRunTime((int)numericUpDownRunTime.Value);

            Playlist playlist = (Playlist)listBoxPlaylists.SelectedItem;

            if (playlist != newPlaylist)
            {
                bindingList[listBoxPlaylists.SelectedIndex] = newPlaylist;
            }
        }

        private void PlaylistEditorUserControl_VisibleChanged(object sender, EventArgs e)
        {
            if (bindingList != null && Visible == false)
                form.playlists = bindingList.ToList();
        }
    }
}
