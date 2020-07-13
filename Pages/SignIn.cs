using MarsFramework.Config;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace MarsFramework.Pages
{
    class SignIn
    {
        public SignIn()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
#pragma warning restore CS0618 // Type or member is obsolete
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//A[@class='item'][text()='Sign In']")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps()
        {
            GlobalDefinitions.waitClickableElement(GlobalDefinitions.driver, "XPath", "//A[@class='item'][text()='Sign In']");
            SignIntab.Click();
            GlobalDefinitions.TurnOnWait();
            Email.SendKeys(MarsResource.Username);
            Password.SendKeys(MarsResource.Password);
            LoginBtn.Click();
            
        }
    }
}