//using CustomerUIAutomation.Utilities;
//using CustomerHelperUtility;
//using NUnit.Framework;
//using OpenQA.Selenium;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using OpenQA.Selenium.Interactions;

//namespace CustomerUIAutomation.PageObjects
//{
//    class LoginPagePOM : TestBase
//    {
//        private readonly IWebDriver _WebDriver;
//        public LoginPagePOM(IWebDriver driver)
//            : base(driver, "LocatorsJsonFiles\\LoginPageLocators.json", "LoginPageTestData")
//        {
//            this._WebDriver = driver;
//            WebDriverUtility.TurnOnWait(60);
//        }

//        public IWebElement SignInInputEmail => WebDriverUtility.FindElement(MultipleLocators["signInInputEmail"]);
//        public IWebElement SignInPassword => WebDriverUtility.FindElement(MultipleLocators["signInPassword"]);
//        public IWebElement SignInButton => WebDriverUtility.FindElement(MultipleLocators["signInButton"]);
//        public IWebElement SelectNo => WebDriverUtility.FindElement(MultipleLocators["selectNo"]);

//        public IWebElement LoginButton => WebDriverUtility.FindElement(MultipleLocators["LoginButton"]);

//        public void NavigateToUrl(string url)
//        {
//            WebDriverUtility.DeleteBrowserCookies();
//            WebDriverUtility.Navigate(url);
//        }


//        public void EnterLoginDetails(string testStep)
//        {
//            WebDriverUtility.EnterText(SignInInputEmail, Excel.GetValueFromTestStep(testStep, "Email"));
//            WebDriverUtility.ClickOn(LoginButton);
//            WebDriverUtility.EnterText(SignInPassword, Excel.GetValueFromTestStep(testStep, "Password"));
//            WebDriverUtility.ClickOn(LoginButton);
//            //WebDriverUtility.ClickOn(SelectNo);

//        }
//    }
//}
