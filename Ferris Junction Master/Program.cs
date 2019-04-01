using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferris_Junction_Master
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ProcessCommandLineArgs();
            Application.Run(new FormMain());
        }

        static void ProcessCommandLineArgs()
        {
            string[] args = Environment.GetCommandLineArgs();
            //string[] args = { @"F:\Visual Studio\Projekte\Ferris Junction Master\Ferris Junction Master\bin\Debug\FJM.exe", "-a", @"D:\JunctionTest1234" };
            if (args.Length < 3)
            {
                Application.Run(new FormMain());
            }
            else
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "-a")
                    {
                        AddFolder(args[i + 1]);
                    }
                    if (args[i] == "-p")
                    {
                        PasteFolder(args[i-1], args[i+1]);
                    }
                }
            }
            
        }

        static void AddFolder(string folder)
        {
            if (string.IsNullOrEmpty(folder))
            {
                throw new ArgumentException("message", nameof(folder));
            }
            else
            {
                ExplorerContextMenu.FolderSelected(folder);
            }
        }

        static void PasteFolder(string source, string target)
        {
            MessageBox.Show($"Source: {source}\r\nTarget:{target}", "Paste Folder");
        }
    }
}
