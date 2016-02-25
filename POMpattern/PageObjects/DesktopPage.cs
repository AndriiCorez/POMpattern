using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace POMpattern
{
    public class DesktopPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "html/body/section[1]/div[1]/div/div[2]/a[2]")]
        IWebElement downloadBtn;

        public DesktopPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        //click download
        public void ClickDownloadBtn()
        {
            downloadBtn.Click();
        }

        public string GetFileLinkPath(DesktopPage page)
        {
            return downloadBtn.GetAttribute("href");
        }

        //initiate download

        //add Helper class to helper folder - check if its downloaded and check MD5 and SHA1

    }
}