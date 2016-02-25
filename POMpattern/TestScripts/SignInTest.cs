using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace POMpattern
{
    [TestClass]
    public class SignInTest : BaseTest
    {
        private string incorrectUserPassErrorTxt = "Incorrect username or password.";

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
        public void BadCredentialTest()
        {
            string actualErrorMessage = new MainPage(driver).
                ClikSignin().
                SetPassword(usernameIncorrect).
                SetUserame(passwordIncorrect).
                ClickSignIn().
                GetErrorMessage();

            Assert.AreEqual(incorrectUserPassErrorTxt, actualErrorMessage);
        }

        [TestMethod]
        public void SuccessSignInTest()
        {
            throw new System.NotImplementedException();
        }
                
    }
}
