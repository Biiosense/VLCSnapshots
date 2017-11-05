using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace User_interface
{
    public partial class Form1 : Form
    {
        public const int MAXIMUM_STREAM_PER_IPADRESS = 3;

        public string jsonfilepath = Path.Combine(Directory.GetCurrentDirectory(),  "data.json");


        Data.Stream defaultStream1 = new Data.Stream("192.168.1.16", 1, "SONY", "rtsp://admin:admin@192.168.1.16/media/video1");
        Data.Stream defaultStream2 = new Data.Stream("192.168.1.17", 1, "BOSCH", "rtsp://admin:admin@192.168.1.17/");


        public static string TODO = "Auto run of snapshosts" +
                                    "Custom runtime by Stream" +
                                    "Change the name of a playlist" +
                                    "Add button to add a playlist " +
                                    "Remove button to remove a playlist" +
                                    "Multiple streams by ip address" +
                                    "Save button in playlist view" +
                                    "Size management (minimum size of the form, handle size change" +
                                    "Menu items : " +
                                        "Settings : Customize the target directory of snapshosts" +
                                        "Export a playlist to an Excel file" +
                                        "Open an Excel file to playlist" +
                                    "Read VLC logs and provide infos";
            
        public Playlist[] playlists;


        public Form1()
        {
            InitializeComponent();
            playlists = readPlaylistFromJson();
            panel1.Controls.AddRange( new Control[] { new UserControl1(this) ,  new VLCUserControl(this) });
            panel1.Controls.OfType<UserControl1>().First().Visible = true;
            panel1.Controls.OfType<VLCUserControl>().First().Visible = false;
        }
        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkChanges())
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save changes ?", "Exit the application", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                    savePlaylistAsJson();
                else if (dialogResult == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }
       

        private void tab1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.OfType<UserControl1>().First().Visible = false;
            panel1.Controls.OfType<VLCUserControl>().First().Visible = true;
        }

        private void tab2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.OfType<UserControl1>().First().Visible = true;
            panel1.Controls.OfType<VLCUserControl>().First().Visible = false;
        }

        private bool checkChanges()
        {
            Playlist[] savedPlaylists = getSavedPlaylists();
            return !( playlists == null && savedPlaylists == null ? true
                    : playlists == null || savedPlaylists == null ? false
                    : playlists.SequenceEqual(savedPlaylists));
        }

        public void savePlaylistAsJson()
        {
            if (File.Exists(jsonfilepath))
                File.Delete(jsonfilepath);

            string json = JsonConvert.SerializeObject(playlists.ToArray(), Formatting.Indented);
            using (StreamWriter file = File.CreateText(jsonfilepath))
                file.Write(json);
            Console.WriteLine("Playlists saved : " + jsonfilepath);
        }

        public Playlist[] readPlaylistFromJson()
        {
            Playlist[] playlists = getSavedPlaylists();
            
            if ( playlists == null )
            {
                playlists = new Playlist[1];
                playlists[0] = new Playlist("Playlist 1");
                playlists[0].Add(defaultStream1);
                playlists[0].Add(defaultStream2);
            }
            return playlists;
        }

        private Playlist[] getSavedPlaylists()
        {
            Playlist[] playlists = null;
            if (File.Exists(jsonfilepath))
            {
                string json;
                using (StreamReader file = File.OpenText(jsonfilepath))
                {
                    json = file.ReadToEnd();
                }
                playlists = JsonConvert.DeserializeObject<Playlist[]>(json);
            }
            return playlists;
        }
        
    }
}
