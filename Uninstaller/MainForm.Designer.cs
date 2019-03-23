namespace Uninstaller
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.ListOfPrograms = new System.Windows.Forms.ListBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.righClickList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rmUninstall = new System.Windows.Forms.ToolStripMenuItem();
            this.rmForceRemoval = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.righClickList.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListOfPrograms
            // 
            this.ListOfPrograms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListOfPrograms.FormattingEnabled = true;
            this.ListOfPrograms.Location = new System.Drawing.Point(0, 27);
            this.ListOfPrograms.Name = "ListOfPrograms";
            this.ListOfPrograms.Size = new System.Drawing.Size(299, 394);
            this.ListOfPrograms.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(299, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnRefresh,
            this.mnExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.fileToolStripMenuItem.Text = "Actions";
            // 
            // mnRefresh
            // 
            this.mnRefresh.Name = "mnRefresh";
            this.mnRefresh.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnRefresh.Size = new System.Drawing.Size(154, 22);
            this.mnRefresh.Text = "Refresh";
            // 
            // mnExit
            // 
            this.mnExit.Name = "mnExit";
            this.mnExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnExit.Size = new System.Drawing.Size(154, 22);
            this.mnExit.Text = "Exit";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnAbout});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // mnAbout
            // 
            this.mnAbout.Name = "mnAbout";
            this.mnAbout.Size = new System.Drawing.Size(107, 22);
            this.mnAbout.Text = "About";
            // 
            // righClickList
            // 
            this.righClickList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rmUninstall,
            this.rmForceRemoval});
            this.righClickList.Name = "contextMenuStrip1";
            this.righClickList.Size = new System.Drawing.Size(153, 48);
            // 
            // rmUninstall
            // 
            this.rmUninstall.Name = "rmUninstall";
            this.rmUninstall.Size = new System.Drawing.Size(152, 22);
            this.rmUninstall.Text = "Uninstall";
            // 
            // rmForceRemoval
            // 
            this.rmForceRemoval.Name = "rmForceRemoval";
            this.rmForceRemoval.Size = new System.Drawing.Size(152, 22);
            this.rmForceRemoval.Text = "Force Removal";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 421);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.ListOfPrograms);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(315, 460);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Uninstaller";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.righClickList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListOfPrograms;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnRefresh;
        private System.Windows.Forms.ToolStripMenuItem mnExit;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip righClickList;
        private System.Windows.Forms.ToolStripMenuItem rmUninstall;
        private System.Windows.Forms.ToolStripMenuItem rmForceRemoval;
        private System.Windows.Forms.ToolStripMenuItem mnAbout;
    }
}

