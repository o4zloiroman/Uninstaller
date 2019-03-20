using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Uninstaller
{
    public class Parser
    {
        public static List<Program> programs = new List<Program> { };
        
        public static List<Program> ParseLocations()
        {
            RegistryKey uninstallHive;

            uninstallHive = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\");
            Parse(programs, uninstallHive);

            uninstallHive = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\");
            Parse(programs, uninstallHive);

            uninstallHive = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
            Parse(programs, uninstallHive);

            return SortList(programs);
        }

        private static List<Program> SortList(List<Program> programs)
        {
            programs.Sort();

            var distinctItems = programs
                .GroupBy(x => x.UninstallString)
                .Select(y => y.FirstOrDefault());

            programs = distinctItems.ToList();

            //var distinctLINQ = programs.OrderBy(x => x.DisplayName);
            //var testMethod = programs.Where(x => x.DisplayName.Contains("play"));

            return programs;
        }

        //x86 and x64 will produce different outcomes -- hives
        private static void Parse(List<Program> programs, RegistryKey uninstallHive)
        {
            using (uninstallHive)
            {
                foreach (string folderKey in uninstallHive.GetSubKeyNames())
                {
                    RegistryKey uninstallSubkey = uninstallHive.OpenSubKey(folderKey);
                    using (uninstallHive.OpenSubKey(folderKey))
                    {
                        if (uninstallSubkey != null)
                        {
                            var displayName = (string)uninstallSubkey.GetValue("DisplayName");
                            var installLocation = (string)uninstallSubkey.GetValue("InstallLocation");
                            var uninstallString = (string)uninstallSubkey.GetValue("UninstallString");
                            var releaseType = uninstallSubkey.GetValue("ReleaseType");
                            var systemComponent = uninstallSubkey.GetValue("SystemComponent") as int?;

                            if (!String.IsNullOrEmpty(displayName) && !String.IsNullOrEmpty(uninstallString) && systemComponent != 1 && releaseType == null)
                            {
                                Program outcome = new Program(displayName, uninstallSubkey, installLocation, uninstallString);
                                programs.Add(outcome);
                            }
                        }
                        else throw new NullReferenceException("Uninstaller's registry subkey is empty");
                    }
                }
            }
        }
    }
}
