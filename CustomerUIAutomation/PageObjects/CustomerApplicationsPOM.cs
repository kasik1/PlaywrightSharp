using CustomerUIAutomation.Utilities;
using CustomerHelperUtility;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace CustomerUIAutomation.PageObjects
{
    class CustomerApplicationsPOM : TestBase
    {

        private readonly IWebDriver _WebDriver;
        public CustomerApplicationsPOM(IWebDriver driver)
            : base(driver, "LocatorsJsonFiles\\CustomerApplications.json", "HomePageTestData")
        {
            this._WebDriver = driver;
            WebDriverUtility.TurnOnWait(60);
        }
        public IWebElement NoOfAppsFound => WebDriverUtility.FindElement(MultipleLocators["NoOfAppsFound"]);

        //public IWebElement AppsCount => WebDriverUtility.FindElement(MultipleLocators["AppsCount"]);

        public IList<IWebElement> AppsCount => WebDriverUtility.FindElements(MultipleLocators["AppsCount"]).ToList();

        public IWebElement CloseIcon => WebDriverUtility.FindElement(MultipleLocators["CloseIcon"]);

        public IWebElement OCRAPPFav => WebDriverUtility.FindElement(MultipleLocators["OCRAPPFav"]);

        public IWebElement BaselineApps => WebDriverUtility.FindElement(MultipleLocators["BaselineApps"]);
        public IWebElement NoFavAppsValidation => WebDriverUtility.FindElement(MultipleLocators["NoFavAppsValidation"]);

        public IWebElement OCRAPPFavouritedApp => WebDriverUtility.FindElement(MultipleLocators["OCRAPPFavouritedApp"]);
        
        public void ValidateAppsCountVSAppsDisplayed()
        {
            string test = NoOfAppsFound.Text;

            string values = test.Split(' ')[0];
            int count = AppsCount.Count;

            string compare;
            compare = count.ToString();

            if (values.Equals(compare))
            {
                Console.WriteLine("Apps Displayed and Apps found on Header are matching");
            }
        }
        public void NoAppsValidations()
        {
            WebDriverUtility.ClickOn(BaselineApps);
            
            Assert.IsTrue(WebDriverUtility.IsDisplayed(NoFavAppsValidation));
        }
        public void FavAppValidation()
        {
            WebDriverUtility.ClickOn(OCRAPPFav);
            
            Assert.IsTrue(WebDriverUtility.IsDisplayed(OCRAPPFavouritedApp));
            Thread.Sleep(1000);
            WebDriverUtility.ClickOn(OCRAPPFav);
        }
    }
}
