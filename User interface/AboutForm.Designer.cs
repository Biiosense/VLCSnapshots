namespace User_interface
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.buttonOk = new System.Windows.Forms.Button();
            this.richTextBoxAbout = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(98, 211);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(92, 33);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // richTextBoxAbout
            // 
            this.richTextBoxAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxAbout.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxAbout.BulletIndent = 5;
            this.richTextBoxAbout.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxAbout.Name = "richTextBoxAbout";
            this.richTextBoxAbout.ReadOnly = true;
            this.richTextBoxAbout.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxAbout.ShowSelectionMargin = true;
            this.richTextBoxAbout.Size = new System.Drawing.Size(264, 193);
            this.richTextBoxAbout.TabIndex = 1;
            this.richTextBoxAbout.Text = resources.GetString("richTextBoxAbout.Text");
            // 
            // AboutForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonOk;
            this.ClientSize = new System.Drawing.Size(288, 256);
            this.Controls.Add(this.richTextBoxAbout);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About VLC Snapshots";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.RichTextBox richTextBoxAbout;
    }
}