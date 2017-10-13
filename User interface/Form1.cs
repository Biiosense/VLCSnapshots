using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace User_interface
{
    public partial class Form1 : Form
    {
        public const int MAXIMUM_STREAM_PER_IPADRESS = 3;
        
        string fulloptions = "--intf=dummy --dummy-quiet --file-logging --log-verbose=1 --logfile=!vlcLogfile! --ignore-config --rtsp-frame-buffer-size=500000 --no-audio --video-filter=scene --scene-path=%DIR% --scene-format=jpg --scene-prefix=!snapshot! --scene-replace --run-time=!runTime!";

        VLCUserControl VLCuc;
        UserControl1 uc;
        public Playlist playlist;


        public Form1()
        {
            InitializeComponent();
            uc = new UserControl1(this);
            VLCuc = new VLCUserControl(this);       
            panel1.Controls.Add(uc);
            playlist = new Playlist();
        }

        private void tab1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(VLCuc);
        }

        private void tab2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(uc);
        }
    }
}
