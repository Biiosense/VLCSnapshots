namespace User_interface
{
    partial class PlaylistEditorUserControl
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
            this.panelPlaylistView = new System.Windows.Forms.Panel();
            this.buttonAddPlaylist = new System.Windows.Forms.Button();
            this.buttonDeletePlaylist = new System.Windows.Forms.Button();
            this.labelPlaylists = new System.Windows.Forms.Label();
            this.labelPlaylistView = new System.Windows.Forms.Label();
            this.panelPlaylistSettings = new System.Windows.Forms.Panel();
            this.buttonSaveChanges = new System.Windows.Forms.Button();
            this.numericUpDownRunTime = new System.Windows.Forms.NumericUpDown();
            this.labelRunTime = new System.Windows.Forms.Label();
            this.textBoxPlaylistName = new System.Windows.Forms.TextBox();
            this.labelPlaylistName = new System.Windows.Forms.Label();
            this.labelPlaylistSettings = new System.Windows.Forms.Label();
            this.listBoxPlaylists = new System.Windows.Forms.ListBox();
            this.panelPlaylistSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRunTime)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPlaylistView
            // 
            this.panelPlaylistView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPlaylistView.AutoScroll = true;
            this.panelPlaylistView.BackColor = System.Drawing.SystemColors.Window;
            this.panelPlaylistView.Location = new System.Drawing.Point(4, 69);
            this.panelPlaylistView.Margin = new System.Windows.Forms.Padding(4);
            this.panelPlaylistView.Name = "panelPlaylistView";
            this.panelPlaylistView.Size = new System.Drawing.Size(1024, 252);
            this.panelPlaylistView.TabIndex = 0;
            // 
            // buttonAddPlaylist
            // 
            this.buttonAddPlaylist.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonAddPlaylist.Location = new System.Drawing.Point(243, 24);
            this.buttonAddPlaylist.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddPlaylist.Name = "buttonAddPlaylist";
            this.buttonAddPlaylist.Size = new System.Drawing.Size(101, 47);
            this.buttonAddPlaylist.TabIndex = 2;
            this.buttonAddPlaylist.Text = "Add playlist";
            this.buttonAddPlaylist.UseVisualStyleBackColor = true;
            this.buttonAddPlaylist.Click += new System.EventHandler(this.buttonAddPlaylist_Click);
            // 
            // buttonDeletePlaylist
            // 
            this.buttonDeletePlaylist.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonDeletePlaylist.Location = new System.Drawing.Point(243, 86);
            this.buttonDeletePlaylist.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeletePlaylist.Name = "buttonDeletePlaylist";
            this.buttonDeletePlaylist.Size = new System.Drawing.Size(101, 47);
            this.buttonDeletePlaylist.TabIndex = 3;
            this.buttonDeletePlaylist.Text = "Delete playlist";
            this.buttonDeletePlaylist.UseVisualStyleBackColor = true;
            this.buttonDeletePlaylist.Click += new System.EventHandler(this.buttonDeletePlaylist_Click);
            // 
            // labelPlaylists
            // 
            this.labelPlaylists.AutoSize = true;
            this.labelPlaylists.Location = new System.Drawing.Point(4, 5);
            this.labelPlaylists.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlaylists.Name = "labelPlaylists";
            this.labelPlaylists.Size = new System.Drawing.Size(97, 15);
            this.labelPlaylists.TabIndex = 5;
            this.labelPlaylists.Text = "Playlist selection";
            // 
            // labelPlaylistView
            // 
            this.labelPlaylistView.AutoSize = true;
            this.labelPlaylistView.Location = new System.Drawing.Point(4, 50);
            this.labelPlaylistView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlaylistView.Name = "labelPlaylistView";
            this.labelPlaylistView.Size = new System.Drawing.Size(72, 15);
            this.labelPlaylistView.TabIndex = 6;
            this.labelPlaylistView.Text = "Playlist view";
            // 
            // panelPlaylistSettings
            // 
            this.panelPlaylistSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPlaylistSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPlaylistSettings.Controls.Add(this.buttonSaveChanges);
            this.panelPlaylistSettings.Controls.Add(this.numericUpDownRunTime);
            this.panelPlaylistSettings.Controls.Add(this.labelRunTime);
            this.panelPlaylistSettings.Controls.Add(this.labelPlaylistView);
            this.panelPlaylistSettings.Controls.Add(this.textBoxPlaylistName);
            this.panelPlaylistSettings.Controls.Add(this.labelPlaylistName);
            this.panelPlaylistSettings.Controls.Add(this.panelPlaylistView);
            this.panelPlaylistSettings.Location = new System.Drawing.Point(7, 160);
            this.panelPlaylistSettings.Margin = new System.Windows.Forms.Padding(4);
            this.panelPlaylistSettings.Name = "panelPlaylistSettings";
            this.panelPlaylistSettings.Size = new System.Drawing.Size(1034, 327);
            this.panelPlaylistSettings.TabIndex = 7;
            // 
            // buttonSaveChanges
            // 
            this.buttonSaveChanges.Location = new System.Drawing.Point(520, 5);
            this.buttonSaveChanges.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveChanges.Name = "buttonSaveChanges";
            this.buttonSaveChanges.Size = new System.Drawing.Size(106, 36);
            this.buttonSaveChanges.TabIndex = 10;
            this.buttonSaveChanges.Text = "Save changes";
            this.buttonSaveChanges.UseVisualStyleBackColor = true;
            this.buttonSaveChanges.Click += new System.EventHandler(this.buttonSaveChanges_Click);
            // 
            // numericUpDownRunTime
            // 
            this.numericUpDownRunTime.Location = new System.Drawing.Point(335, 14);
            this.numericUpDownRunTime.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownRunTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRunTime.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownRunTime.Name = "numericUpDownRunTime";
            this.numericUpDownRunTime.Size = new System.Drawing.Size(41, 21);
            this.numericUpDownRunTime.TabIndex = 3;
            this.numericUpDownRunTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownRunTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // labelRunTime
            // 
            this.labelRunTime.AutoSize = true;
            this.labelRunTime.Location = new System.Drawing.Point(270, 16);
            this.labelRunTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRunTime.Name = "labelRunTime";
            this.labelRunTime.Size = new System.Drawing.Size(57, 15);
            this.labelRunTime.TabIndex = 2;
            this.labelRunTime.Text = "Run time";
            // 
            // textBoxPlaylistName
            // 
            this.textBoxPlaylistName.Location = new System.Drawing.Point(66, 13);
            this.textBoxPlaylistName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPlaylistName.Name = "textBoxPlaylistName";
            this.textBoxPlaylistName.Size = new System.Drawing.Size(162, 21);
            this.textBoxPlaylistName.TabIndex = 1;
            // 
            // labelPlaylistName
            // 
            this.labelPlaylistName.AutoSize = true;
            this.labelPlaylistName.Location = new System.Drawing.Point(22, 16);
            this.labelPlaylistName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlaylistName.Name = "labelPlaylistName";
            this.labelPlaylistName.Size = new System.Drawing.Size(41, 15);
            this.labelPlaylistName.TabIndex = 0;
            this.labelPlaylistName.Text = "Name";
            // 
            // labelPlaylistSettings
            // 
            this.labelPlaylistSettings.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelPlaylistSettings.AutoSize = true;
            this.labelPlaylistSettings.Location = new System.Drawing.Point(4, 142);
            this.labelPlaylistSettings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlaylistSettings.Name = "labelPlaylistSettings";
            this.labelPlaylistSettings.Size = new System.Drawing.Size(90, 15);
            this.labelPlaylistSettings.TabIndex = 8;
            this.labelPlaylistSettings.Text = "Playlist settings";
            // 
            // listBoxPlaylists
            // 
            this.listBoxPlaylists.HorizontalScrollbar = true;
            this.listBoxPlaylists.ItemHeight = 15;
            this.listBoxPlaylists.Location = new System.Drawing.Point(4, 24);
            this.listBoxPlaylists.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxPlaylists.Name = "listBoxPlaylists";
            this.listBoxPlaylists.Size = new System.Drawing.Size(231, 109);
            this.listBoxPlaylists.TabIndex = 11;
            this.listBoxPlaylists.SelectedIndexChanged += new System.EventHandler(this.listBoxPlaylists_SelectedIndexChanged);
            // 
            // PlaylistEditorUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxPlaylists);
            this.Controls.Add(this.labelPlaylistSettings);
            this.Controls.Add(this.panelPlaylistSettings);
            this.Controls.Add(this.labelPlaylists);
            this.Controls.Add(this.buttonDeletePlaylist);
            this.Controls.Add(this.buttonAddPlaylist);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PlaylistEditorUserControl";
            this.Size = new System.Drawing.Size(1045, 491);
            this.Load += new System.EventHandler(this.PlaylistEditorUserControl_Load);
            this.VisibleChanged += new System.EventHandler(this.PlaylistEditorUserControl_VisibleChanged);
            this.panelPlaylistSettings.ResumeLayout(false);
            this.panelPlaylistSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRunTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPlaylistView;
        private System.Windows.Forms.Button buttonAddPlaylist;
        private System.Windows.Forms.Button buttonDeletePlaylist;
        private System.Windows.Forms.Label labelPlaylists;
        private System.Windows.Forms.Label labelPlaylistView;
        private System.Windows.Forms.Panel panelPlaylistSettings;
        private System.Windows.Forms.Label labelPlaylistSettings;
        private System.Windows.Forms.TextBox textBoxPlaylistName;
        private System.Windows.Forms.Label labelPlaylistName;
        private System.Windows.Forms.Label labelRunTime;
        private System.Windows.Forms.NumericUpDown numericUpDownRunTime;
        private System.Windows.Forms.Button buttonSaveChanges;
        private System.Windows.Forms.ListBox listBoxPlaylists;
    }
}
