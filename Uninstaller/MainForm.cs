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
            RefreshButton.Click += RefreshButton_Click;
            ListOfPrograms.MouseDoubleClick += ListOfPrograms_MouseDoubleClick;
        }

        private void ListOfPrograms_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //TODO: try to use object sender instead of list
            var program = list[ListOfPrograms.IndexFromPoint(e.Location)];
            IO.LaunchUninstaller(program);
        }

        public void PopulateList()
        {
            ListOfPrograms.DataSource = list;
            ListOfPrograms.DisplayMember = "DisplayName";
        }

        void RefreshButton_Click(object sender, EventArgs e)
        {
            PopulateList();
        }
    }
}
