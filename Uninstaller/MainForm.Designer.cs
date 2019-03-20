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
            this.ListOfPrograms = new System.Windows.Forms.ListBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListOfPrograms
            // 
            this.ListOfPrograms.FormattingEnabled = true;
            this.ListOfPrograms.Location = new System.Drawing.Point(-2, 53);
            this.ListOfPrograms.Name = "ListOfPrograms";
            this.ListOfPrograms.Size = new System.Drawing.Size(241, 355);
            this.ListOfPrograms.TabIndex = 0;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(23, 13);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 1;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 409);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.ListOfPrograms);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Uninstaller";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListOfPrograms;
        private System.Windows.Forms.Button RefreshButton;
    }
}

