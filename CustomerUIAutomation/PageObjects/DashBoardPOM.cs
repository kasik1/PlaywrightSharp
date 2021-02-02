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
    class DashBoardPOM : TestBase
    {

        private readonly IWebDriver _WebDriver;
        public DashBoardPOM(IWebDriver driver)
            : base(driver, "LocatorsJsonFiles\\DashBoardLoactors.json", "HomePageTestData")
        {
            this._WebDriver = driver;
            WebDriverUtility.TurnOnWait(60);
        }
        public IWebElement NoOfAppsFound => WebDriverUtility.FindElement(MultipleLocators["NoOfAppsFound"]);
        public IList<IWebElement> AppsCount => WebDriverUtility.FindElements(MultipleLocators["AppsCount"]).ToList();

        public IWebElement Reports => WebDriverUtility.FindElement(MultipleLocators["Reports"]);

        public IWebElement ViewAllApps => WebDriverUtility.FindElement(MultipleLocators["ViewAllApps"]);

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

        public void VerifyDashBoard()
        {
            Thread.Sleep(5000);
            //WebDriverUtility.IsDisplayed(Reports);
            WebDriverUtility.IsDisplayed(ViewAllApps);
            WebDriverUtility.ClickOn(ViewAllApps);
        }







    }
}
