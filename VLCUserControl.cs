﻿using System;
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

namespace VLCSnapshots
{
    public partial class VLCUserControl : UserControl
    {
        public static string snapshotsPath;
        string options;
        Stream stream;

        public VLCUserControl()
        {
            InitializeComponent();
            snapshotsPath = @"D:\Users\Maxime\Desktop\snapshots\";
            options = ":no-overlay";
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if( Form1.streams.Count > 0)
            {
                stream = Form1.streams.ElementAt(0);
                Console.WriteLine("rtsp : " + stream);

                vlc.playlist.add(stream.streamAddress, "first rtsp", options);
                vlc.playlist.play();
                Console.WriteLine("Play!");
            }
            
        }

        private void snapshotButton_Click(object sender, EventArgs e)
        {
            if (vlc.playlist.isPlaying)
            {
                Console.WriteLine("Let's take a picture !");
                string filename = snapshotsPath + stream.getStreamName() +".jpg";

                vlc.playlist.pause();
                vlc.video.takeSnapshot();
                vlc.playlist.play();

                DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
                FileInfo bmpfile = dir.GetFiles()[0];
                foreach (FileInfo file in dir.GetFiles())
                    if (file.CreationTime > bmpfile.CreationTime)
                        bmpfile = file;

                Image image;
                using (var bmpTmp = new Bitmap(bmpfile.FullName))
                    image = new Bitmap(bmpTmp);

                bmpfile.Delete();

                if (File.Exists(filename))
                    File.Delete(filename);
                image.Save(filename, ImageFormat.Jpeg);
                MessageBox.Show(filename + " created !");
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (vlc.playlist.isPlaying)
                vlc.playlist.pause();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (vlc.playlist.isPlaying)
                vlc.playlist.stop();
        }
    }
}
