using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Windows.Forms;

namespace Uninstaller
{
    public static class Cleaner
    {
        public static void CleanUp(Program program)
        {
            string installLocation = program.InstallLocation;
            if (installLocation != null)
            {
                DirectoryInfo directory = new DirectoryInfo(installLocation);
            }

            DialogResult result = MessageBox.Show("Found leftovers. Wanna cleanup?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                CleaningRegistry(program.RegistryAddress);
                CleaningFolders(installLocation);
            }
            else if (result == DialogResult.No)
            {
                //code for No
            }
        }

        private static void CleaningFolders(string installLocation)
        {
            if (Directory.Exists(installLocation) && installLocation != null)
            {
                //Found leftovers
                string[] array = Directory.GetFileSystemEntries(installLocation);
                foreach (var entry in array)
                {
                    Console.WriteLine(entry);
                }

                //Ask to clear
                Directory.Delete(installLocation, true);
            }
        }

        private static void CleaningRegistry(RegistryKey registryKey)
        {
            var registryString = registryKey.ToString();
            var result = registryString.Split('\\');
            var registryHiveString = result[0];
            RegistryHive registryHive;
            RegistryKey checkRegistry;

            switch (registryHiveString)
            {
                case "HKEY_LOCAL_MACHINE":
                    registryHive = RegistryHive.LocalMachine;
                    registryString = registryString.Replace("HKEY_LOCAL_MACHINE\\", "");
                    checkRegistry = Registry.LocalMachine.OpenSubKey(registryString);
                    break;
                case "HKEY_CURRENT_USER":
                    registryHive = RegistryHive.CurrentUser;
                    registryString = registryString.Replace("HKEY_CURRENT_USER\\", "");
                    checkRegistry = Registry.CurrentUser.OpenSubKey(registryString);
                    break;
                default:
                    throw new DirectoryNotFoundException("Wrong Hive");
            }

            if (checkRegistry != null)
            {
                //Found leftovers
                try
                {
                    var r = registryKey.GetValueNames();

                    foreach (var item in r)
                    {
                        Console.WriteLine(registryKey + "\\" + item);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //Ask to clean
                try
                {
                    if (registryHive == RegistryHive.LocalMachine)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree(registryString);
                    }
                    else if (registryHive == RegistryHive.CurrentUser)
                    {
                        Registry.CurrentUser.DeleteSubKeyTree(registryString);
                    }
                    //Registry purged
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static List<Process> GetChildren(UInt32 parentProcessId)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE ParentProcessId=" + parentProcessId);
            ManagementObjectCollection collection = searcher.Get();

            if (collection.Count > 0)
            {
                var processList = new List<Process> { };
                foreach (var item in collection)
                {
                    UInt32 childProcessId = (UInt32)item["ProcessId"];
                    var process = Process.GetProcessById((int)childProcessId);
                    processList.Add(Process.GetProcessById(Convert.ToInt32(item.GetPropertyValue("ProcessId"))));
                }
                return processList;
            }
            else
                return null;
        }
    }
}
