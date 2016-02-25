using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace POMpattern
{
    public class EnterprisePage : BasePage
    {
        public EnterprisePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
    }
}