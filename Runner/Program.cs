using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POMpattern;
using System.Diagnostics;
using System.IO;
using Microsoft.WindowsAPICodePack.Shell;

//console app to run some examples
namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            string gitDesktopInstallerFileName = "GitHubSetup.exe";

            DirectoryInfo dirInfo = new DirectoryInfo(KnownFolders.Downloads.Path);
            FileInfo[] files = dirInfo.GetFiles("*.exe");
            foreach (FileInfo f in files)
            {
                Console.WriteLine(f.Name);
                if (f.Name.Equals(gitDesktopInstallerFileName))
                    Console.WriteLine(f.FullName); 
            }
            Console.ReadKey();
        }
    }
}
