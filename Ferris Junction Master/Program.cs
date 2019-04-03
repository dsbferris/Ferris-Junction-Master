using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace Ferris_Junction_Master
{
    static class Program
    {
        static readonly Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            logger.Debug(ExplorerContextMenu.FLog("Run Application"));
            ProcessCommandLineArgs();
            //Application.Run(new FormMain());
            Application.Exit();
        }


        static void ProcessCommandLineArgs()
        {
            string[] args = Environment.GetCommandLineArgs();
        //string[] args = { @"F:\Visual Studio\Projekte\Ferris Junction Master\Ferris Junction Master\bin\Debug\FJM.exe", @"D:\JunctionTest1234", "-a" };
        //string[] args = { @"F:\Visual Studio\Projekte\Ferris Junction Master\Ferris Junction Master\bin\Debug\FJM.exe", "FJMPaste1", @"C:\Users\Ferris\Downloads", @"D:\JunctionTest1234", "-p" };
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
                        //TODO Check for NTFS
                        AddFolder(args[i - 1]);
                        break;
                    }
                    if (args[i] == "-p")
                    {
                        //TODO Check for NTFS
                        PasteFolder(FJMPasteKey: args[i - 3], target: args[i - 2], source: args[i - 1]);
                        break;
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
        /// <summary>
        /// Paste command execution
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="FJMPasteKey"></param>
        static void PasteFolder(string FJMPasteKey, string target, string source)
        {
            if(string.IsNullOrEmpty(source) || string.IsNullOrEmpty(target) || string.IsNullOrEmpty(FJMPasteKey))
            {
                throw new ArgumentException("source, target, FJMPasteKey");
            }
            else
            {
                ExplorerContextMenu.FolderPasted(FJMPasteKey);
                //TODO : Setup FormPasteFolder, try CustomDiskSpaceControl, make junction code, 
            }
        }
    }
}
