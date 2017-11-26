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
using System.Reflection;
using Settings_Interface;
using System.Security.AccessControl;
using System.Security.Principal;

namespace User_interface
{
    public partial class Form1 : Form
    {
        public string settingsFilePath = Path.Combine(Directory.GetCurrentDirectory(), "settings.json");

        Data.Stream defaultStream1 = new Data.Stream("192.168.1.16", 1, "SONY", "rtsp://admin:admin@192.168.1.16/media/video1");
        Data.Stream defaultStream2 = new Data.Stream("192.168.1.17", 1, "BOSCH", "rtsp://admin:admin@192.168.1.17/");

        public static string TODO = "Auto run of snapshosts" +
                                    "Custom runtime by Playlist" +        "✓" +
                                    "Change the name of a playlist" +       "✓" +
                                    "Add button to add a playlist " +
                                    "Remove button to remove a playlist" +      "✓" +
                                    "Multiple streams by ip address" +
                                    "Save button in playlist view" +        "✓" +
                                    "Size management (minimum size of the form, handle size change" +
                                    "Menu items : " +
                                        "Settings : Customize the target directory of snapshosts" +
                                        "Export a playlist to an Excel file" +
                                        "Open an Excel file to playlist" +
                                    "Read VLC logs and provide infos" +
            "" +
            "Add VLC icon to the main form" +                           "✓" + 
            "Add 'not implemented yet' on Save menu button" +               "✓" +
            "Rename Form1 to MainForm" +
            "Clean Project" +
            "Try the application with online streams" +
            "" +
            "Check Windows version compatibility" +
            "64 vs 86 system" +
            "File not found exception CLR20r3" +
            "";

        public Settings settings;
        public List<Playlist> playlists;

        public Form1()
        {
            InitializeComponent();
            grantAccess(Directory.GetCurrentDirectory());
            setSettings();
            setPlaylists();
            panel1.Controls.AddRange(new Control[] { new PlaylistEditorUserControl(this), new VLCUserControl(this) });
            panel1.Controls.OfType<PlaylistEditorUserControl>().First().Visible = true;
            panel1.Controls.OfType<VLCUserControl>().First().Visible = false;
        }

        #region Form load / close

        private void setSettings()
        {
            settings = getSavedObjects<Settings>(settingsFilePath);
            if (settings == null)
            {
                settings = new Settings
                {
                    SnapshotsFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "snapshots"),
                    DataFilePath = Path.Combine(Directory.GetCurrentDirectory(), "data.json")
                };
            }
        }

        public void setPlaylists()
        {
            playlists = getSavedObjects<List<Playlist>>(settings.DataFilePath);

            if (playlists == null)
            {
                playlists = new List<Playlist>();
                
                Playlist playlist1 = new Playlist("Playlist 1", 5);
                Playlist playlist2 = new Playlist("Playlist 2", 5);
                playlist1.Add(defaultStream1);
                playlist2.Add(defaultStream2);
                playlists.Add(playlist1);
                playlists.Add(playlist2);
                
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveToJson(settings, settingsFilePath);
            if (checkChanges())
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save changes ?", "Exit the application", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                    saveToJson(playlists.ToArray(), settings.DataFilePath);
                else if (dialogResult == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        #endregion

        #region Menu actions


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature not implemented yet", "Save playlist in file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature not implemented yet", "Open playlist from file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.OfType<PlaylistEditorUserControl>().First().Visible = true;
            panel1.Controls.OfType<VLCUserControl>().First().Visible = false;
        }

        private void vLCPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.OfType<PlaylistEditorUserControl>().First().Visible = false;
            panel1.Controls.OfType<VLCUserControl>().First().Visible = true;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm(this).ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        #endregion

        #region Json Save

        private bool checkChanges()
        {
            List<Playlist> savedPlaylists = getSavedObjects<List<Playlist>>(settings.DataFilePath);
            return !( playlists == null && savedPlaylists == null ? true
                    : playlists == null || savedPlaylists == null ? false
                    : playlists.SequenceEqual(savedPlaylists));
        }

        public void saveToJson(object obj, string filename)
        {
            if (File.Exists(filename))
                File.Delete(filename);

            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            using (StreamWriter file = File.CreateText(filename))
                file.Write(json);
        }

        private T getSavedObjects<T>(string filename)
        {
            T objects = default(T);
            if (File.Exists(filename))
            {
                string json;
                using (StreamReader file = File.OpenText(filename))
                {
                    json = file.ReadToEnd();
                }
                objects = JsonConvert.DeserializeObject<T>(json);
            }
            return objects;
        }


        public bool grantAccess(string fullPath)
        {
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
            return true;
        }

        #endregion

    }
}
