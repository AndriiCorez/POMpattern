using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace POMpattern
{
    public class SignInPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "login_field")]
        IWebElement loginOrEmailFld;
        [FindsBy(How = How.Id, Using = "password")]
        IWebElement passwordFld;
        [FindsBy(How = How.Name, Using = "commit")]
        IWebElement signInBtnInternal;
        [FindsBy(How = How.XPath, Using = ".//*[@id='js-flash-container']/div/div")]
        IWebElement errorMessage;

        public SignInPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public SignInPage SetUserame(string username)
        {
            loginOrEmailFld.SendKeys(username);
            return this;
        }

        public SignInPage SetPassword(string password)
        {
            passwordFld.SendKeys(password);
            return this;
        }

        public SignInPage ClickSignIn()
        {
            signInBtnInternal.Click();
            return this;
        }

        public string GetErrorMessage()
        {
            return errorMessage.Text;
        }

    }
}