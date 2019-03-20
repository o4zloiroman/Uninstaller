using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Uninstaller
{
    class IO
    {
        public static void LaunchUninstaller(Program program)
        {
            string path = null;
            string argument = null;
            string uninstaller = program.UninstallString;
            Process process;

            Regex regex = new Regex("^(?<path>\".*\") (?<args>.*)$", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match match = regex.Match(program.UninstallString);
            if (match.Success)
            {
                path = match.Groups[1].Value;
                argument = uninstaller.Replace(path, "");
                process = Process.Start(path, argument);
                WaitForExit(process);
            }
            else if(uninstaller.Contains("MsiExec.exe"))
            {
                string[] result = uninstaller.Split(' ');
                path = result[0];
                argument = result[1];
                process = Process.Start(path, argument);
                WaitForExit(process);
            }
            else
            {
                process = Process.Start(program.UninstallString);
                WaitForExit(process);
            }
            //if(!File.Exists(program.UninstallString))
            //    Cleaner.CleanUp(program);
        }

        public static void WaitForExit(Process process)
        {
            UInt32 pid = (UInt32)process.Id;

            try
            {
                process.WaitForExit();

                var listChildren = Cleaner.GetChildren(pid);
                if (listChildren != null)
                {
                    foreach (var item in listChildren)
                    {
                        var p = Process.GetProcessById(item.Id);
                        p.WaitForExit();
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Debugger.Break();
            }
        }
    }
}
