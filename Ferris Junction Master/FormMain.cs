using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ferris_Junction_Master.ExplorerContextMenu;

namespace Ferris_Junction_Master
{
    public partial class FormMain : MetroFramework.Forms.MetroForm
    {
        public FormMain()
        {
            InitializeComponent();
            int linecounter = 1;
            foreach(var s in Environment.GetCommandLineArgs())
            {
                metroTextBox1.Text += $"Line {linecounter.ToString()}:{s}" + Environment.NewLine;
                linecounter++;
            }
            for (int i = 0; i < 3; i++) metroTextBox1.Text += Environment.NewLine;
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            CreateContextMenu_ClassesRoot();
            CreateSelectCommand_LocalMaschine();
        }

        private void MetroButton2_Click(object sender, EventArgs e)
        {
            DeleteClassesRoot();
            DeleteLocalMaschine();
            DeleteAllBackground();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FormPasteFolder fpf = new FormPasteFolder();
            fpf.Show();

        }
    }
}
