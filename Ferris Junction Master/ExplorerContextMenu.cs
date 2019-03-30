using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferris_Junction_Master
{
    public static class ExplorerContextMenu
    {
        public static void CreateClassesRootKey()
        {
            string classes_sub = @"Directory\shell\";
            string classes_sub_FJM = classes_sub + "FJM";
            try
            {
                using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(classes_sub, true))
                {
                    RegistryKey sub = Registry.ClassesRoot.OpenSubKey(classes_sub_FJM, true);
                    if (sub == null)
                    {
                        sub = key.CreateSubKey("FJM", true);
                        sub.SetValue("MUIVerb", "Ferris Junction Manager", RegistryValueKind.String);
                        sub.SetValue("icon", Environment.CurrentDirectory + @"\FJM.exe", RegistryValueKind.String);
                        sub.SetValue("SubCommands", "FJMSel", RegistryValueKind.String);
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

        public static void CreateLocalMaschineKey()
        {
            string local_sub = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\";
            string local_sub_FJM = local_sub + "FJMSel";
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(local_sub, true))
                {
                    RegistryKey sub = Registry.LocalMachine.OpenSubKey(local_sub_FJM, true);
                    if (sub == null)
                    {
                        sub = key.CreateSubKey("FJMSel", true);
                        sub.SetValue("", "Select for junctioning", RegistryValueKind.String);
                        sub = sub.CreateSubKey("command", true);
                        sub.SetValue("", "cmd.exe", RegistryValueKind.String);
                    }
                    else
                    {
                        MessageBox.Show("Already installed in Local.", "Error",
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



        public static void DeleteDefaultContextMenuEntry()
        {
            
            string classes = @"Directory\shell\";
            string classes_sub = classes + "FJM";
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(classes_sub, true))
            {
                RegistryKey sub = Registry.ClassesRoot.OpenSubKey(classes_sub, true);
                if(key != null)
                {
                    key.DeleteSubKeyTree("FJM");
                    MessageBox.Show("Removed FJM in ClassesRoot: ");
                }
            }

            string local = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\";
            string local_sub = local + "FJMSel";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(local, true))
            {
                RegistryKey sub = Registry.LocalMachine.OpenSubKey(local_sub, true);
                if(sub != null)
                {
                    key.DeleteSubKeyTree("FJMSel", true);
                    MessageBox.Show("Removed FJMSel in LocalMaschine");
                }
            }
        }


    }
    

}
