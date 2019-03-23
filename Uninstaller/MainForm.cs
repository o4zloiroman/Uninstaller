using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uninstaller
{
    public partial class MainForm : Form
    {
        List<Program> list = Parser.ParseLocations();

        public MainForm()
        {
            InitializeComponent();
            PopulateList();
            SubscribeEvents();

            ListOfPrograms.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left);
            ListOfPrograms.ContextMenuStrip = righClickList;
        }

        private void SubscribeEvents()
        {
            mnRefresh.Click += mnRefresh_Click;
            ListOfPrograms.MouseDoubleClick += ListOfPrograms_MouseDoubleClick;
            mnExit.Click += MnExit_Click;
            mnAbout.Click += MnAbout_Click;
            rmUninstall.Click += RmUninstall_Click;
            ListOfPrograms.MouseDown += ListOfPrograms_MouseDown;
            rmForceRemoval.Click += RmForceRemoval_Click;
        }

        private void RmForceRemoval_Click(object sender, EventArgs e)
        {
            var program = list[ListOfPrograms.SelectedIndex];
            Cleaner.CleanUp(program);
        }

        private void ListOfPrograms_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //select the item under the mouse pointer
                ListOfPrograms.SelectedIndex = ListOfPrograms.IndexFromPoint(e.Location);
                if (ListOfPrograms.SelectedIndex != -1)
                {
                    ListOfPrograms.Show();
                }
            }
        }

        private void RmUninstall_Click(object sender, EventArgs e)
        {
            var program = list[ListOfPrograms.SelectedIndex];
            IO.LaunchUninstaller(program);
        }

        private void MnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("About", "About", MessageBoxButtons.OK);
        }

        private void MnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void mnRefresh_Click(object sender, EventArgs e)
        {
            PopulateList();
        }

        private void ListOfPrograms_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //TODO: try to use object sender instead of list
            var program = list[ListOfPrograms.IndexFromPoint(e.Location)];
            IO.LaunchUninstaller(program);
        }

        public void PopulateList()
        {
            ListOfPrograms.ClearSelected();
            ListOfPrograms.DataSource = list;
            ListOfPrograms.DisplayMember = "DisplayName";
        }
    }
}
