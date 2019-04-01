using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace Ferris_Junction_Master
{
    public static class ExplorerContextMenu
    {
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
                        sub.SetValue("MUIVerb", "Ferris Junction Manager", RegistryValueKind.String);
                        sub.SetValue("icon", Environment.CurrentDirectory + @"\FJM.exe", RegistryValueKind.String);
                        sub.SetValue("SubCommands", "FJMSel", RegistryValueKind.String);
                        MessageBox.Show("Create Context Menu key in Classes Root.");
                        //rkKey.SetValue("Position", "Top", RegistryValueKind.String);
                    }
                    else
                    {
                        MessageBox.Show("Already installed in ClassesRoot", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public static void CreateSelectCommand_LocalMaschine()
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

                RegistryKey sub = key.OpenSubKey("FJMSel", true);
                if (sub == null)
                {
                    sub = key.CreateSubKey("FJMSel", true);
                    sub.SetValue("", "Select for junctioning", RegistryValueKind.String);
                    sub = sub.CreateSubKey("command", true);
                    sub.SetValue("", Environment.GetCommandLineArgs()[0] + " -a \"%1\"", RegistryValueKind.String);
                    MessageBox.Show("Create SelectCommand in LocalMaschine.");
                }
                else
                {
                    MessageBox.Show("Already installed in Local.", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        sub.SetValue("MUIVerb", "Ferris Junction Manager", RegistryValueKind.String);
                        sub.SetValue("icon", Environment.GetCommandLineArgs()[0], RegistryValueKind.String);
                        //sub.SetValue("SubCommands", subcommand, RegistryValueKind.String);
                        //rkKey.SetValue("Position", "Top", RegistryValueKind.String);
                    }
                    else
                    {
                        MessageBox.Show("Already installed in ClassesRoot_Background", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
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

                //Create LocalMaschine Paste Command
                sub = key.CreateSubKey(fjmpastenr, true);
                sub.SetValue("", "Paste " + foldername + " here", RegistryValueKind.String);
                sub = sub.CreateSubKey("command");

                //UNDONE

                sub.SetValue("", Environment.GetCommandLineArgs()[0] + $" {folderpath} -p \"%1\"", RegistryValueKind.String);

                //Create ClassesRoot directory background menu
                key = Registry.ClassesRoot.OpenSubKey(ClassesRoot_Background_Directory, true);
                sub = key.OpenSubKey("FJM", true);
                if (sub == null)
                {
                    CreateBackgroundMenu_ClassesRoot();
                    sub = key.OpenSubKey("FJM", true);
                    //sub = key.CreateSubKey("FJM", true);
                }
                var current = sub.GetValue("SubCommands");
                if(current == null || string.IsNullOrEmpty(current.ToString()))
                {
                    sub.SetValue("SubCommands", fjmpastenr + ";", RegistryValueKind.String);
                }
                else sub.SetValue("SubCommands", current + fjmpastenr + ";", RegistryValueKind.String);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (key != null)
                    {
                        key.DeleteSubKeyTree("FJM", true);
                        MessageBox.Show("Removed FJM in ClassesRoot: ");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (s.Contains("FJM")) key.DeleteSubKeyTree(s, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Removed FJM in ClassesRoot Background: ");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static void AddToBackground(string subcommand)
        {
            //TODO if no FJM key exists, create new
        }

        public static void RemoveFromBackground(string subcommand)
        {
            if (string.IsNullOrEmpty(subcommand)) return;

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
                key.DeleteSubKeyTree(subcommand, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (subs.Contains(";" + subcommand)) subs = subs.Replace(";" + subcommand, String.Empty);
                    else if (subs.Contains(subcommand + ";")) subs = subs.Replace(subcommand + ";", String.Empty);
                    else MessageBox.Show("BackGroundDir is not containing: " + subcommand);

                    if (string.IsNullOrEmpty(subs))
                    {

                    }
                    sub.SetValue("SubCommands", subs, RegistryValueKind.String);
                }
                else
                {
                    MessageBox.Show("No FJM key in Background Directory", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }



        

    }
    

}
