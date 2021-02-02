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
    class ServiceBusMonitorPOM : TestBase

    {
        private readonly IWebDriver _WebDriver;
        public ServiceBusMonitorPOM(IWebDriver driver)
            : base(driver, "LocatorsJsonFiles\\ServiceBusMonitorLocators.json", "HomePageTestData")
        {
            this._WebDriver = driver;
            WebDriverUtility.TurnOnWait(60);
        }
        public IWebElement ServiceBusMonitor => WebDriverUtility.FindElement(MultipleLocators["ServiceBusMonitor"]);
        public IWebElement FilterSearch => WebDriverUtility.FindElement(MultipleLocators["FilterSearch"]);
        public IWebElement Enable => WebDriverUtility.FindElement(MultipleLocators["Enable"]);
        public IWebElement statusValidate => WebDriverUtility.FindElement(MultipleLocators["StatusValidate"]);

        public IWebElement Disable => WebDriverUtility.FindElement(MultipleLocators["Disable"]);
        

        public void ClickonServiceBusMonitor()
        {
            WebDriverUtility.ClickOn(ServiceBusMonitor);
        }
        public void EnterTextInFilter()
        {
            WebDriverUtility.EnterText(FilterSearch,"Mailroom");
        }
        public void ClickonEnable()
        {
          WebDriverUtility.ClickOn(Enable);
         Thread.Sleep(2000);
            //string status=WebDriverUtility.GetText(statusValidate);
            //   //WebDriverUtility.IsDisplayed(statusValidate);
            if (WebDriverUtility.IsDisplayed(statusValidate))
            {
                Console.WriteLine("service enabled");
            }
            Thread.Sleep(3000);
            WebDriverUtility.ClickOn(Disable);
        }



    }
}
