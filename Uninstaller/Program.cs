using Microsoft.Win32;
using System;

namespace Uninstaller
{
    public class Program: IComparable<Program>
    {
        public string DisplayName { get; set; }
        public RegistryKey RegistryAddress { get; set; }
        public string InstallLocation { get; set; }
        public string UninstallString { get; set; }        

        public Program(string displayName, RegistryKey registryAddress, string installLocation, string uninstallString)
        {
            this.DisplayName = displayName;
            this.RegistryAddress = registryAddress;
            this.InstallLocation = installLocation;
            this.UninstallString = uninstallString;
        }

        int IComparable<Program>.CompareTo(Program other)
        {
            return this.DisplayName.CompareTo(other.DisplayName);
        }
    }
}
