using Microsoft.VisualStudio.TestTools.UnitTesting;
using POMpattern.Support;
using System.Threading.Tasks;

namespace POMpattern
{  
    [TestClass]
    public class GitDesktopTest : BaseTest
    {
        //add deletion of GitHub exe files in Download folder
        [TestInitialize]
        public void BeforeTest()
        {
            BeforeMethod();
            new TestSupport().DeleteGitInstallerFileFromDownloads(gitDesktopInstallerFileName);
        }

        [TestCleanup]
        public void AfterTest()
        {
            TearDown();
        }

        [TestMethod]
        public void DownloadGitDesktopTest()
        {
            var page = new MainPage(driver).GoToGitDesktopPage();
            page.ClickDownloadBtn();

            TestSupport support = new TestSupport();

            // System.Action<string, string> action = TestSupport.DownloadFileWebClientWrapper(page.GetFileLinkPath(page), gitDesktopInstallerFileName));



            // var task = await support.DownloadFileWebClient(page.GetFileLinkPath(page),gitDesktopInstallerFileName);

            support.DownloadFileWebClient(page.GetFileLinkPath(page), gitDesktopInstallerFileName);
            
            EventCustom.eAuto.WaitOne();

            try
            {
                support.GetDownloadedFileFullName(gitDesktopInstallerFileName);
            }
            catch(System.IO.FileNotFoundException ex)
            {
                Assert.Fail(ex.StackTrace);
            }
        }

        [TestMethod]
        public void DesktopGitInstallerHashCorrectnessTest()
        {
            var page = new DesktopPage(driver);
            TestSupport support = new TestSupport();
            support.DownloadFileWebClient(page.GetFileLinkPath(page), gitDesktopInstallerFileName);

            try
            {
                string installerPath = support.GetDownloadedFileFullName(gitDesktopInstallerFileName);
                Assert.IsTrue(support.ComputeFileHash(installerPath,true)==installerGITDesktopSHA1Expected &&
                    support.ComputeFileHash(installerPath,false)==installerGITDesktopMD5Expected);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Assert.Fail(ex.StackTrace);
            }
        }
    }
}