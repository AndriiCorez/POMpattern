using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace POMpattern
{
    [TestClass]
    public class BaseTest : System.Attribute
    {
        protected IWebDriver driver;
        private string url;

        protected string username;
        protected string password;
        protected string email;
        protected string usernameIncorrect;
        protected string passwordIncorrect;
        protected string emailIncorrect;
        protected string gitDesktopInstallerFileName;
        protected string installerGITDesktopSHA1Expected;
        protected string installerGITDesktopMD5Expected;
        

        public BaseTest()
        {
            if (url == null || 
                username == null || password == null || email == null ||
                usernameIncorrect == null || passwordIncorrect == null || emailIncorrect == null)
                Initialize();            
        }

        private void Initialize()
        {
            try
            {
                gitDesktopInstallerFileName = "GitHubSetup.exe";
                usernameIncorrect = "IncorrectName";
                passwordIncorrect = "IncorrectPassword";
                url = "https://github.com/";
                SetUp();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        
        //[ClassInitialize]
        protected void SetUp()
        {
            Console.WriteLine("ClassInitialize");
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(BasePage.WAIT_SECONDS));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(BasePage.WAIT_SECONDS));
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(BasePage.WAIT_SECONDS));
        }

        //[TestInitialize]
        protected void BeforeMethod()
        {
            Console.WriteLine("TestInitialize");
            driver.Navigate().GoToUrl(url);
        }

        //[TestCleanup]
        protected void TearDown()
        {
            Console.WriteLine("TestCleanup");
            driver.Close();
            driver.Quit();
        }
    }
}