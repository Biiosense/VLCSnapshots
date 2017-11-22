using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Data;
using User_interface;

namespace Settings_Interface
{
    public partial class SettingsForm : Form
    {
        Form1 form;
        Settings settings;

        public SettingsForm(Form1 form)
        {
            InitializeComponent();
            this.form = form;
            settings = form.settings;
        }
        protected override void OnLoad(EventArgs e)
        {
            textBoxSnapshotsFolder.Text = settings.SnapshotsFolderPath;
            textBoxDataFile.Text = settings.DataFilePath;
        }

        private void buttonBrowseSnapshotsFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Snapshots directory";
            folderBrowserDialog.SelectedPath = textBoxSnapshotsFolder.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxSnapshotsFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void buttonBrowseDataFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Data File path";
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxDataFile.Text = openFileDialog.FileName;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            buttonApply_Click(sender, e);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            saveSettings();
            form.settings = settings;
        }

        private void saveSettings()
        {
            string snapshotsFolder = textBoxSnapshotsFolder.Text;
            string dataFile = textBoxDataFile.Text;

            if (Directory.Exists(snapshotsFolder))
                settings.SnapshotsFolderPath = snapshotsFolder;
            if (File.Exists(dataFile))
                settings.DataFilePath = dataFile;
        }

       
    }
}
