using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferris_Junction_Master
{
    public partial class FormMain : MetroFramework.Forms.MetroForm
    {
        public FormMain()
        {
            foreach(var s in Environment.GetCommandLineArgs())
            {
                if (s.ToLower().Contains("select".ToLower())) MessageBox.Show("select in args");
            }
            InitializeComponent();
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            //ExplorerContextMenu.CreateClassesRootKey();
            ExplorerContextMenu.CreateLocalMaschineKey();
        }

        private void MetroButton2_Click(object sender, EventArgs e)
        {
            ExplorerContextMenu.DeleteDefaultContextMenuEntry();
        }
    }
}
