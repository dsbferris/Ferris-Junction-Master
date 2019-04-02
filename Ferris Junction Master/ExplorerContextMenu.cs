using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using NLog;

namespace Ferris_Junction_Master
{
    public static class ExplorerContextMenu
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        public static string FLog(string message)
        {
            return "\r\n\t" + message;
        }

        static readonly string ClassesRoot_Background_Directory = @"Directory\Background\shell";
        static readonly string ClassesRoot_Directory = @"Directory\shell\";
        static readonly string LocalMaschine_AllSubCommands = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\";

        public static void CreateContextMenu_ClassesRoot()
        {
            try
            {
                using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(ClassesRoot_Directory, RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.TakeOwnership))
                {
                    RegistryKey sub = key.OpenSubKey("FJM", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.TakeOwnership);
                    if (sub == null)
                    {                  
                        sub = key.CreateSubKey("FJM", true);
                        logger.Debug(FLog($"Created RegKey {key.ToString()}")) ;
                        sub.SetValue("MUIVerb", "Ferris Junction Manager", RegistryValueKind.String);
                        logger.Debug(FLog($"SetValue MUIVerb in {sub.ToString()}"));
                        sub.SetValue("icon", Environment.CurrentDirectory + @"\FJM.exe", RegistryValueKind.String);
                        logger.Debug(FLog($"SetValue icon in {sub.ToString()}"));
                        sub.SetValue("SubCommands", "FJMSel", RegistryValueKind.String);
                        logger.Debug(FLog($"SetValue SubCommands to FJMSel in {sub.ToString()}"));
                        //MessageBox.Show("Create Context Menu key in Classes Root.");
                    }
                    else
                    {
                        logger.Debug(FLog($"{sub.ToString()} was not NULL. Seems like it already exists"));
                        //MessageBox.Show("Already installed in ClassesRoot", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Fatal(ex, FLog("Error while creating RegKey"));
                //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public static void CreateSelectCommand_LocalMaschine()
        { 
            RegistryKey key = null;
            try
            {
                if (Environment.Is64BitOperatingSystem)
                { //This for 64-Bit
                    key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(LocalMaschine_AllSubCommands, true);
                }
                else
                { //This for 32-Bit
                    key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(LocalMaschine_AllSubCommands, true);
                }

                RegistryKey sub = key.OpenSubKey("FJMSel", true);
                if (sub == null)
                {
                    sub = key.CreateSubKey("FJMSel", true);
                    logger.Debug(FLog($"Create RegKey FJMSel in {key.ToString()}"));
                    sub.SetValue("", "Select for junctioning", RegistryValueKind.String);

                    sub = sub.CreateSubKey("command", true);
                    sub.SetValue("", Environment.GetCommandLineArgs()[0] + " -a \"%1\"", RegistryValueKind.String);
                    logger.Debug(FLog($"Created SubKey command in {sub.ToString()} with value: {sub.GetValue("")}"));
                    //MessageBox.Show("Create SelectCommand in LocalMaschine.");
                }
                else
                {
                    logger.Debug(FLog($"{sub.ToString()} was not NULL. Seems like it already exists"));
                    //MessageBox.Show("Already installed in Local.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, FLog($"Error while creating SubKey FJMSel in {key.ToString()}"));
                //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }

        public static void CreateBackgroundMenu_ClassesRoot()
        {
            try
            {
                using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(ClassesRoot_Background_Directory, RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.TakeOwnership))
                {
                    RegistryKey sub = key.OpenSubKey("FJM", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.TakeOwnership);
                    if (sub == null)
                    {
                        sub = key.CreateSubKey("FJM", true);
                        logger.Debug(FLog($"Created SubKey FJM in {key.ToString()}"));
                        sub.SetValue("MUIVerb", "Ferris Junction Manager", RegistryValueKind.String);
                        sub.SetValue("icon", Environment.GetCommandLineArgs()[0], RegistryValueKind.String);
                        logger.Debug(FLog($"SetValues for {sub.ToString()}"));
                        
                    }
                    else
                    {
                        logger.Debug(FLog($"{sub.ToString()} was not NULL. Seems like it already exists"));
                        //MessageBox.Show("Already installed in ClassesRoot_Background", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Fatal(ex, FLog("Error while creating RegKey"));
                //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }



        public static void DeleteClassesRoot()
        {
            try
            {
                using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(ClassesRoot_Directory, true))
                {
                    RegistryKey sub = key.OpenSubKey("FJM", true);
                    if (sub != null)
                    {
                        key.DeleteSubKeyTree("FJM", true);
                        logger.Debug(FLog($"Removd FJM in {key.ToString()}"));
                        //MessageBox.Show("Removed FJM in ClassesRoot: ");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, FLog($"Failed while deleting FJM in ClassesRoot"));
                //MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public static void DeleteLocalMaschine()
        {
            RegistryKey key;
            try
            {
                if (Environment.Is64BitOperatingSystem)
                { //This for 64-Bit
                    key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(LocalMaschine_AllSubCommands, true);
                }
                else
                { //This for 32-Bit
                    key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(LocalMaschine_AllSubCommands, true);
                }
                foreach(var s in key.GetSubKeyNames())
                {
                    if (s.Contains("FJM"))
                    {
                        key.DeleteSubKeyTree(s, true);
                        logger.Debug(FLog($"Removed {s} in {key.ToString()}"));
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, FLog($"Failed removing in LocalMaschine"));
                //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void DeleteAllBackground()
        {
            try
            {
                using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(ClassesRoot_Background_Directory, true))
                {
                    RegistryKey sub = key.OpenSubKey("FJM", true);
                    if (key != null)
                    {
                        key.DeleteSubKeyTree("FJM", true);
                        logger.Debug(FLog($"Removed FJM in {key.ToString()}"));
                        //MessageBox.Show("Removed FJM in ClassesRoot Background: ");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, FLog("Failed while deleting FJM in ClassesRoot_Background"));
                throw;
                //MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static void FolderSelected(string folderpath)
        {
            try
            {
                RegistryKey key;
                RegistryKey sub;
                string foldername = new DirectoryInfo(folderpath).Name;
                string fjmpastenr = "FJMPaste";


                if (Environment.Is64BitOperatingSystem) key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(LocalMaschine_AllSubCommands, true);
                else key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(LocalMaschine_AllSubCommands, true);

                //Get free FJMPaste key number
                int free_number = 1;
                List<string> subs = key.GetSubKeyNames().ToList();
                while (subs.Contains(fjmpastenr + free_number.ToString())) free_number++;
                fjmpastenr += free_number.ToString();

                logger.Info(FLog($"Folderpath: {folderpath}\r\n\tFoldername: {foldername}\r\n\tFJMPasteNr: {fjmpastenr}"));

                //Create LocalMaschine Paste Command
                sub = key.CreateSubKey(fjmpastenr, true);
                sub.SetValue("", "Paste " + foldername + " here", RegistryValueKind.String);
                sub = sub.CreateSubKey("command");
                logger.Debug(FLog($"Created SubKey {sub.ToString()}"));

                //UNDONE

                sub.SetValue("", Environment.GetCommandLineArgs()[0] + $" {folderpath} -p \"%1\" {fjmpastenr}", RegistryValueKind.String);
                logger.Debug(FLog($"SetValue command \"\" to {sub.GetValue("")}"));

                //Create ClassesRoot directory background menu
                key = Registry.ClassesRoot.OpenSubKey(ClassesRoot_Background_Directory, true);
                sub = key.OpenSubKey("FJM", true);
                if (sub == null)
                {
                    CreateBackgroundMenu_ClassesRoot();
                    sub = key.OpenSubKey("FJM", true);
                    //sub = key.CreateSubKey("FJM", true);
                }
                var current_subcommands = sub.GetValue("SubCommands");
                if (current_subcommands == null || string.IsNullOrEmpty(current_subcommands.ToString()))
                {
                    sub.SetValue("SubCommands", fjmpastenr + ";", RegistryValueKind.String);
                }
                else sub.SetValue("SubCommands", current_subcommands + fjmpastenr + ";", RegistryValueKind.String);
                logger.Debug(FLog($"SetValue SubCommands in {sub.ToString()} from {current_subcommands} to {sub.GetValue("SubCommands")}"));
            }
            catch (UnauthorizedAccessException ex)
            {
                logger.Fatal(ex, $"Failed while adding selected Folder");
                //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }


        public static void FolderPasted(string FJMPasteNr)
        {
            if (string.IsNullOrEmpty(FJMPasteNr)) return;

            //LocalMaschine, remove from CommandStore
            #region LocalMaschine
            RegistryKey key;
            try
            {
                if (Environment.Is64BitOperatingSystem)
                { //This for 64-Bit
                    key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(LocalMaschine_AllSubCommands, true);
                }
                else
                { //This for 32-Bit
                    key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(LocalMaschine_AllSubCommands, true);
                }
                key.DeleteSubKeyTree(FJMPasteNr, true);
                logger.Debug(FLog($"Removed {FJMPasteNr} from {key.ToString()}"));
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, FLog($"Error while removing {FJMPasteNr} in LocalMaschine"));
                //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            #endregion

            //ClassesRoot, remove from SubCommands-Value
            try
            {
                key = Registry.ClassesRoot.OpenSubKey(ClassesRoot_Background_Directory, RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.TakeOwnership);
                RegistryKey sub = key.OpenSubKey("FJM", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.TakeOwnership);
                if (sub != null)
                {
                    string subs = sub.GetValue("SubCommands").ToString();
                    if (!subs.Contains(FJMPasteNr + ";"))
                    {
                        logger.Error(FLog($"{sub.ToString()} SubCommands does not contain {FJMPasteNr}.\r\n\tSubCommands: {subs}"));
                        //MessageBox.Show("BackGroundDir is not containing: " + FJMPasteNr);
                    }
                    else
                    {
                        subs = subs.Replace(FJMPasteNr + ";", String.Empty);
                        if (string.IsNullOrEmpty(subs))
                        {
                            logger.Debug(FLog($"After replacement SubCommands contained nothing"));
                            DeleteAllBackground();
                        }
                        else
                        {
                            sub.SetValue("SubCommands", subs, RegistryValueKind.String);
                            logger.Debug(FLog($"SubCommands is now: {subs}"));
                        }

                    }
                }
                else
                {
                    logger.Error(FLog($"SubKey FJM in {key.ToString()} did not exist"));
                    //MessageBox.Show("No FJM key in Background Directory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, FLog("Error while deleting selected folder keys"));
                //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
