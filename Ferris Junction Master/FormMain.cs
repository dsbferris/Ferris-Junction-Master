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

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            CreateContextMenu_ClassesRoot();
            CreateSelectCommand_LocalMaschine();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteClassesRoot();
            DeleteLocalMaschine();
            DeleteAllBackground();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            //string[] args = { @"F:\Visual Studio\Projekte\Ferris Junction Master\Ferris Junction Master\bin\Debug\FJM.exe", @"D:\JunctionTest1234", "-a" };
            FolderSelected(@"D:\JunctionTest1234");
        }

        private void BtnPaste_Click(object sender, EventArgs e)
        {
            //string[] args = { @"F:\Visual Studio\Projekte\Ferris Junction Master\Ferris Junction Master\bin\Debug\FJM.exe", "FJMPaste1", @"C:\Users\Ferris\Downloads", @"D:\JunctionTest1234", "-p" };
            FolderPasted("FJMPaste1");
        }
    }
}
