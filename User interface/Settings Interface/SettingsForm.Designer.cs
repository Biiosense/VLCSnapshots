namespace Settings_Interface
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.labelSnapshotsFolder = new System.Windows.Forms.Label();
            this.textBoxSnapshotsFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowseSnapshotsFolder = new System.Windows.Forms.Button();
            this.buttonBrowseDataFile = new System.Windows.Forms.Button();
            this.textBoxDataFile = new System.Windows.Forms.TextBox();
            this.labelDataFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(461, 112);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(78, 37);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(545, 112);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(77, 37);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(628, 112);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(77, 37);
            this.buttonApply.TabIndex = 3;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // labelSnapshotsFolder
            // 
            this.labelSnapshotsFolder.AutoSize = true;
            this.labelSnapshotsFolder.Location = new System.Drawing.Point(12, 15);
            this.labelSnapshotsFolder.Name = "labelSnapshotsFolder";
            this.labelSnapshotsFolder.Size = new System.Drawing.Size(86, 13);
            this.labelSnapshotsFolder.TabIndex = 4;
            this.labelSnapshotsFolder.Text = "Snapshots folder";
            // 
            // textBoxSnapshotsFolder
            // 
            this.textBoxSnapshotsFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSnapshotsFolder.Location = new System.Drawing.Point(104, 12);
            this.textBoxSnapshotsFolder.Name = "textBoxSnapshotsFolder";
            this.textBoxSnapshotsFolder.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxSnapshotsFolder.Size = new System.Drawing.Size(518, 20);
            this.textBoxSnapshotsFolder.TabIndex = 5;
            // 
            // buttonBrowseSnapshotsFolder
            // 
            this.buttonBrowseSnapshotsFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseSnapshotsFolder.Location = new System.Drawing.Point(628, 9);
            this.buttonBrowseSnapshotsFolder.Name = "buttonBrowseSnapshotsFolder";
            this.buttonBrowseSnapshotsFolder.Size = new System.Drawing.Size(78, 24);
            this.buttonBrowseSnapshotsFolder.TabIndex = 6;
            this.buttonBrowseSnapshotsFolder.Text = "Browse";
            this.buttonBrowseSnapshotsFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseSnapshotsFolder.Click += new System.EventHandler(this.buttonBrowseSnapshotsFolder_Click);
            // 
            // buttonBrowseDataFile
            // 
            this.buttonBrowseDataFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseDataFile.Location = new System.Drawing.Point(628, 51);
            this.buttonBrowseDataFile.Name = "buttonBrowseDataFile";
            this.buttonBrowseDataFile.Size = new System.Drawing.Size(78, 24);
            this.buttonBrowseDataFile.TabIndex = 9;
            this.buttonBrowseDataFile.Text = "Browse";
            this.buttonBrowseDataFile.UseVisualStyleBackColor = true;
            this.buttonBrowseDataFile.Click += new System.EventHandler(this.buttonBrowseDataFile_Click);
            // 
            // textBoxDataFile
            // 
            this.textBoxDataFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDataFile.Location = new System.Drawing.Point(104, 54);
            this.textBoxDataFile.Name = "textBoxDataFile";
            this.textBoxDataFile.Size = new System.Drawing.Size(518, 20);
            this.textBoxDataFile.TabIndex = 8;
            // 
            // labelDataFile
            // 
            this.labelDataFile.AutoSize = true;
            this.labelDataFile.Location = new System.Drawing.Point(12, 57);
            this.labelDataFile.Name = "labelDataFile";
            this.labelDataFile.Size = new System.Drawing.Size(46, 13);
            this.labelDataFile.TabIndex = 7;
            this.labelDataFile.Text = "Data file";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(717, 161);
            this.Controls.Add(this.buttonBrowseDataFile);
            this.Controls.Add(this.textBoxDataFile);
            this.Controls.Add(this.labelDataFile);
            this.Controls.Add(this.buttonBrowseSnapshotsFolder);
            this.Controls.Add(this.textBoxSnapshotsFolder);
            this.Controls.Add(this.labelSnapshotsFolder);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.MinimumSize = new System.Drawing.Size(550, 200);
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Label labelSnapshotsFolder;
        private System.Windows.Forms.TextBox textBoxSnapshotsFolder;
        private System.Windows.Forms.Button buttonBrowseSnapshotsFolder;
        private System.Windows.Forms.Button buttonBrowseDataFile;
        private System.Windows.Forms.TextBox textBoxDataFile;
        private System.Windows.Forms.Label labelDataFile;
    }
}