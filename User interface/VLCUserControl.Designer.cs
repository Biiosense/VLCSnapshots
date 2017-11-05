namespace User_interface
{
    partial class VLCUserControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VLCUserControl));
            this.stopButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.snapshotButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.vlc = new AxAXVLC.AxVLCPlugin2();
            this.listBoxPlaylist = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.vlc)).BeginInit();
            this.SuspendLayout();
            // 
            // stopButton
            // 
            this.stopButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.stopButton.Location = new System.Drawing.Point(309, 295);
            this.stopButton.Margin = new System.Windows.Forms.Padding(4);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(76, 42);
            this.stopButton.TabIndex = 19;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.pauseButton.Location = new System.Drawing.Point(226, 295);
            this.pauseButton.Margin = new System.Windows.Forms.Padding(4);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(76, 42);
            this.pauseButton.TabIndex = 18;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // snapshotButton
            // 
            this.snapshotButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.snapshotButton.Location = new System.Drawing.Point(393, 295);
            this.snapshotButton.Margin = new System.Windows.Forms.Padding(4);
            this.snapshotButton.Name = "snapshotButton";
            this.snapshotButton.Size = new System.Drawing.Size(76, 42);
            this.snapshotButton.TabIndex = 17;
            this.snapshotButton.Text = "Take Snapshot";
            this.snapshotButton.UseVisualStyleBackColor = true;
            this.snapshotButton.Click += new System.EventHandler(this.snapshotButton_Click);
            // 
            // playButton
            // 
            this.playButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.playButton.Location = new System.Drawing.Point(142, 295);
            this.playButton.Margin = new System.Windows.Forms.Padding(4);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(76, 42);
            this.playButton.TabIndex = 16;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // vlc
            // 
            this.vlc.Enabled = true;
            this.vlc.Location = new System.Drawing.Point(0, 0);
            this.vlc.Name = "vlc";
            this.vlc.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("vlc.OcxState")));
            this.vlc.Size = new System.Drawing.Size(617, 288);
            this.vlc.TabIndex = 20;
            // 
            // listBoxPlaylist
            // 
            this.listBoxPlaylist.Enabled = false;
            this.listBoxPlaylist.FormattingEnabled = true;
            this.listBoxPlaylist.ItemHeight = 16;
            this.listBoxPlaylist.Location = new System.Drawing.Point(652, 63);
            this.listBoxPlaylist.Name = "listBoxPlaylist";
            this.listBoxPlaylist.Size = new System.Drawing.Size(211, 212);
            this.listBoxPlaylist.TabIndex = 21;
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(652, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(206, 24);
            this.comboBox1.TabIndex = 23;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // VLCUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBoxPlaylist);
            this.Controls.Add(this.vlc);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.snapshotButton);
            this.Controls.Add(this.playButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VLCUserControl";
            this.Size = new System.Drawing.Size(917, 351);
            this.VisibleChanged += new System.EventHandler(this.VLCUserControl_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.vlc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button snapshotButton;
        private System.Windows.Forms.Button playButton;
        private AxAXVLC.AxVLCPlugin2 vlc;
        private System.Windows.Forms.ListBox listBoxPlaylist;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
