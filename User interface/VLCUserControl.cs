using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using Data;

namespace User_interface
{
    public partial class VLCUserControl : UserControl
    {
        Form1 form;

        public VLCUserControl(Form1 form)
        {
            InitializeComponent();
            this.form = form;
            setComboBox();
        }

        private void setComboBox()
        {
            comboBox1.DataSource = form.playlists;
            if(comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count <= 0)
                return;

            Playlist playlist = (Playlist)comboBox1.SelectedItem;
            Timer timer = new Timer();
            timer.Interval = playlist.getRunTime() * 1000;

            loadPlaylist(playlist);
            if (vlc.playlist.itemCount > 0)
            {
                listBoxPlaylist.SelectedIndex = 0;
                vlc.playlist.play();

                timer.Tick += delegate
                {
                    timer.Enabled = false;
                    vlc.playlist.pause();
                    takeSnapshot();
                    int currentIndex = listBoxPlaylist.SelectedIndex;
                    if (currentIndex + 1 < listBoxPlaylist.Items.Count)
                    {
                        listBoxPlaylist.SelectedIndex++;
                        vlc.playlist.next();
                        timer.Enabled = true;
                    }
                    else
                    {
                        listBoxPlaylist.ClearSelected();
                        vlc.playlist.stop();
                        timer.Stop();
                    }
                };
                timer.Start();
            }
        }
        
        private void loadPlaylist(Playlist playlist)
        {
            foreach (Data.Stream stream in playlist)
                vlc.playlist.add(stream.getStreamAddress(), stream.getStreamName());
        }

        private void takeSnapshot()
        {
            vlc.video.takeSnapshot();

            DirectoryInfo currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo bmpfile = currentDir.GetFiles()[0];
            foreach (FileInfo file in currentDir.GetFiles())
                if (file.CreationTime >
                    bmpfile.CreationTime)
                    bmpfile = file;

            if (bmpfile.Extension == ".bmp")
            {
                Image image;
                using (var bmpTmp = new Bitmap(bmpfile.FullName))
                    image = new Bitmap(bmpTmp);
                bmpfile.Delete();

                String subDir = "ScanVideo" + DateTime.Now.ToString("yyyyMMdd_HHmm");
                String targetDir = Path.Combine(form.settings.SnapshotsFolderPath, subDir);
                Directory.CreateDirectory(targetDir);

                Data.Stream currentStream = (Data.Stream)listBoxPlaylist.SelectedItem;
                String filename = Path.Combine(targetDir, currentStream.getStreamName() + ".jpg");
                image.Save(filename, ImageFormat.Jpeg);
                MessageBox.Show(filename + " created !", "Snapshot created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Data.Stream currentStream = (Data.Stream)listBoxPlaylist.SelectedItem;
                MessageBox.Show("Couldn't create snapshot for stream" + currentStream.getStreamName(), "Snapshot error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0)
            {
                listBoxPlaylist.Items.Clear();
                listBoxPlaylist.Items.AddRange(((Playlist)comboBox1.SelectedItem).ToArray());
            }
        }
        private void VLCUserControl_VisibleChanged(object sender, EventArgs e)
        {
            if ( Visible == true)
            {
                comboBox1.DataSource = form.playlists;
                comboBox1_SelectedIndexChanged(sender, e);
            }
        }
    }
}
