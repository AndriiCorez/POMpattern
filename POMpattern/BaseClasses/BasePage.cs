
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace POMpattern
{
    public class BasePage
    {
        protected IWebDriver _driver;

        public static readonly string MAIN_PAGE_TITLE = "GitHub · Where software is built";
        public static readonly uint WAIT_SECONDS = 20;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetPageTitle()
        {
            return _driver.Title;
        }

        public string GetPageUrl()
        {
            return _driver.Url;
        }
    }
}