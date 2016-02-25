using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace POMpattern
{
    public class MainPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/div/div[1]/a[2]")]
        IWebElement signInBtn;
        [FindsBy(How = How.XPath, Using = ".//*[@id='js-pjax-container']/div[4]/div/div/a")]
        IWebElement desktopPageBtn;
        [FindsBy(How = How.XPath, Using = ".//*[@id='js-pjax-container']/div[2]/div[1]/a")]
        IWebElement enterprisePageBtn;


        public MainPage(IWebDriver driver) : base(driver)
        {
            if (!MAIN_PAGE_TITLE.Equals(GetPageTitle()))
                throw new Exception("This is not main page!");
            PageFactory.InitElements(_driver, this);
        }

        public SignInPage ClikSignin()
        {
            signInBtn.Click();            
            return new SignInPage(_driver);
        }

        public DesktopPage GoToGitDesktopPage()
        {
            desktopPageBtn.Click();
            return new DesktopPage(_driver);
        }

        public EnterprisePage GoToGitEnterprisePage()
        {
            enterprisePageBtn.Click();
            return new EnterprisePage(_driver);
        }


    }
}