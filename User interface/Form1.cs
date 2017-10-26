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

namespace User_interface
{
    public partial class Form1 : Form
    {
        public const int MAXIMUM_STREAM_PER_IPADRESS = 3;

        string jsonfilepath = Directory.GetCurrentDirectory() + @"\data.json";

        VLCUserControl VLCuc;
        UserControl1 uc;
        public Playlist[] playlists;


        public Form1()
        {
            InitializeComponent();
            playlists = readPlaylistFromJson();
            uc = new UserControl1(this);
            VLCuc = new VLCUserControl(this);
            panel1.Controls.AddRange( new Control[] { uc, VLCuc });
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to save changes ?", "Exit the application", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
                savePlaylistAsJson();
            else if (dialogResult == DialogResult.Cancel)
                e.Cancel = true;

        }
       

        private void tab1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls[0].Visible = false;
            panel1.Controls[1].Visible = true;
        }

        private void tab2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls[1].Visible = false;
            panel1.Controls[0].Visible = true;
        }



        public void savePlaylistAsJson()
        {
            if (File.Exists(jsonfilepath))
                File.Delete(jsonfilepath);


            string json = JsonConvert.SerializeObject(playlists.ToArray(), Formatting.Indented);
            using (StreamWriter file = File.CreateText(jsonfilepath))
                file.Write(json);
        }

        public Playlist[] readPlaylistFromJson()
        {
            string json;
            using (StreamReader file = File.OpenText(jsonfilepath))
            {
                json = file.ReadToEnd();
            }
            Playlist[] p = JsonConvert.DeserializeObject<Playlist[]>(json);

            return p;

        }
        
    }
}
