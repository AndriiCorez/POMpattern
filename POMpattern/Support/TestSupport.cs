using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Microsoft.WindowsAPICodePack.Shell;
using System.Security.Cryptography;
using System.Net;
using System.Threading;

namespace POMpattern.Support
{
    public static class EventCustom
    {
        public static AutoResetEvent eAuto = new AutoResetEvent(false);
    }

    class TestSupport
    {

        /*public static Action<string, string> DownloadFileWebClientWrapper(string downloadFilePath, string expectedGITInstallerName)
        {
            Action<string, string> action = delegate(string downloadFilePathArg, string expectedGITInstallerNameArg) { DownloadFileWebClient(downloadFilePath, expectedGITInstallerName); };
            return action;
        }*/

        public void DownloadFileWebClient(string downloadFilePath, string expectedGITInstallerName)
        {
            WebClient wc = new WebClient();
            // wc.DownloadFileAsync(new Uri(downloadFilePath), expectedGITInstallerName);
            // wc.DownloadFileCompleted += Wc_DownloadFileCompleted;

            // wc.DownloadFile(new Uri(downloadFilePath), expectedGITInstallerName);

            // wc.DownloadFileTaskAsync(new Uri(downloadFilePath), expectedGITInstallerName);
            
            wc.DownloadFile(new Uri(downloadFilePath), expectedGITInstallerName);
            wc.DownloadFileCompleted += Wc_DownloadFileCompleted;

            var proc = new Process();
            proc.StartInfo.FileName = "explorer.exe";
            proc.StartInfo.Arguments = downloadFilePath;
            proc.Start();


        }

        private void Wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            EventCustom.eAuto.Set();
        }

        public string GetDownloadedFileFullName(string gitDesktopInstallerFileName)
        {
            FileInfo[] files = GetExeFilesFromDownloadFolder();
            foreach (FileInfo f in files)
            {
                if (f.Name.Equals(gitDesktopInstallerFileName))
                    return f.FullName;
            }
            throw new FileNotFoundException(" gitDesktopInstallerFileName");
        }


        public string ComputeFileHash(string filePath, bool isSHA1Hash = true)
        {
            using (FileStream fs = File.OpenRead(filePath))
            {
                if (isSHA1Hash)
                {
                    SHA1 sha = new SHA1Managed();
                    return BitConverter.ToString(sha.ComputeHash(fs));
                }
                else
                {
                    MD5 md5 = MD5.Create();
                    return BitConverter.ToString(md5.ComputeHash(fs));
                }
            }           
        }

        public FileInfo[] GetExeFilesFromDownloadFolder()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(KnownFolders.Downloads.Path);
            FileInfo[] files = dirInfo.GetFiles("*.exe");
            return files;
        }

        public void DeleteGitInstallerFileFromDownloads(string gitDesktopInstallerFileName)
        {
            FileInfo[] files = GetExeFilesFromDownloadFolder();
            foreach (FileInfo f in files)
            {
                if (f.Name.Equals(gitDesktopInstallerFileName))
                    f.Delete();
            }
        }


  
    }
}
