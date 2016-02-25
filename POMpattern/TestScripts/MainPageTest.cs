using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POMpattern
{
    [TestClass]
    public class MainPageTest : BaseTest
    {
        string desktopPageTitleExpected = "GitHub Desktop";
        string desktopPageUrlExpected = "https://desktop.github.com/";

        string enterprisePageTitleExpected = "GitHub Enterprise - The best way to build and ship software";
        string enterprisePageUrlExpected = "https://enterprise.github.com/home";

        [TestInitialize]
        public void BeforeTest()
        {
            BeforeMethod();
        }

        [TestCleanup]
        public void AfterTest()
        {
            TearDown();
        }

        [TestMethod]
        public void NavigateToDesktopPageTest()
        {
            var page = new MainPage(driver).GoToGitDesktopPage();
            string actualTitle = page.GetPageTitle();
            string actualUrl = page.GetPageUrl();

            Assert.IsTrue(desktopPageTitleExpected.Equals(actualTitle) && desktopPageUrlExpected.Equals(actualUrl));
        }

        [TestMethod]
        public void NavigateToEnterprisePageTest()
        {
            var page = new MainPage(driver).GoToGitEnterprisePage();
            string actualTitle = page.GetPageTitle();
            string actualUrl = page.GetPageUrl();

            Assert.IsTrue(enterprisePageTitleExpected.Equals(actualTitle) && enterprisePageUrlExpected.Equals(actualUrl));
        }

        [TestMethod]
        public void SignUpFromMainPageTest()
        {
            throw new System.NotImplementedException();
        }
    }
}