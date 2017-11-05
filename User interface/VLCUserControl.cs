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
        public static string snapshotsPath = @"D:\Users\Maxime\Desktop\snapshots\";

        public VLCUserControl(Form1 form)
        {
            this.form = form;
            InitializeComponent();
            setComboBox();
        }

        private void setComboBox()
        {
            comboBox1.DataSource = form.playlists;
            comboBox1.SelectedIndex = 0;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            loadPlaylist( (Playlist)comboBox1.SelectedItem);
            listBoxPlaylist.SelectedIndex = 0;

            if (vlc.playlist.itemCount > 0 )
            {
                Console.WriteLine("Play!");
                vlc.playlist.play();
            } 
        }

        private void snapshotButton_Click(object sender, EventArgs e)
        {
            if (vlc.playlist.isPlaying)
            {
                takeSnapshot();

                int currentIndex = listBoxPlaylist.SelectedIndex;
                if (currentIndex + 1 < listBoxPlaylist.Items.Count)
                {
                    listBoxPlaylist.SelectedIndex++;
                    vlc.playlist.next();
                }
                else
                {
                    vlc.playlist.stop();
                    listBoxPlaylist.ClearSelected();
                }
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (vlc.playlist.isPlaying)
                vlc.playlist.pause();
            else
                vlc.playlist.play();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (vlc.playlist.isPlaying)
                vlc.playlist.stop();
        }
        
        private void loadPlaylist(Playlist playlist)
        {
            foreach (Data.Stream stream in playlist)
            {
                vlc.playlist.add(stream.getStreamAddress(), stream.getStreamName());
            }
        }

        private void takeSnapshot()
        {
            Console.WriteLine("Let's take a picture !");
            vlc.playlist.pause();
            vlc.video.takeSnapshot();
            vlc.playlist.play();

            DirectoryInfo currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo bmpfile = currentDir.GetFiles()[0];
            foreach (FileInfo file in currentDir.GetFiles())
                if (file.CreationTime > bmpfile.CreationTime)
                    bmpfile = file;

            Image image;
            using (var bmpTmp = new Bitmap(bmpfile.FullName))
                image = new Bitmap(bmpTmp);

            bmpfile.Delete();

            String subDir = "ScanVideo" + DateTime.Now.ToString("yyyyMMdd_HHmm");
            String targetDir = Path.Combine( snapshotsPath, subDir);
            Directory.CreateDirectory(targetDir);

            Data.Stream currentStream = (Data.Stream)listBoxPlaylist.SelectedItem;
            String filename = Path.Combine(targetDir, currentStream.getStreamName() + ".jpg");
            image.Save(filename, ImageFormat.Jpeg);
            MessageBox.Show(filename + " created !");
   
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxPlaylist.Items.Clear();
            listBoxPlaylist.Items.AddRange( ((Playlist)comboBox1.SelectedItem).ToArray());
        }
        private void VLCUserControl_VisibleChanged(object sender, EventArgs e)
        {
            if ( Visible == true)
                comboBox1_SelectedIndexChanged(sender, e);
        }
    }
}
