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
    class ReportaPagePOM : TestBase
    {
        private readonly IWebDriver _WebDriver;
        public ReportaPagePOM(IWebDriver driver)
            : base(driver, "LocatorsJsonFiles\\ReportsLocators.json", "LoginPageTestData")
        {
            this._WebDriver = driver;
            WebDriverUtility.TurnOnWait(60);
        }
        public IWebElement GridView => WebDriverUtility.FindElement(MultipleLocators["GridView"]);

        public IWebElement ListView => WebDriverUtility.FindElement(MultipleLocators["ListView"]);
        public IWebElement SearchFilter => WebDriverUtility.FindElement(MultipleLocators["SearchFilter"]);
        public IWebElement ReportCards => WebDriverUtility.FindElement(MultipleLocators["ReportCards"]);
        public IWebElement ViewButton => WebDriverUtility.FindElement(MultipleLocators["ViewButton"]);
        public IWebElement BackToReportsButton => WebDriverUtility.FindElement(MultipleLocators["BackToReportsButton"]);
        public IWebElement PreviousButton => WebDriverUtility.FindElement(MultipleLocators["PreviousButton"]);
        public IWebElement NextButton => WebDriverUtility.FindElement(MultipleLocators["NextButton"]);
        public IWebElement CloseIcon => WebDriverUtility.FindElement(MultipleLocators["CloseIcon"]);
        public IWebElement CheckBoxForReport => WebDriverUtility.FindElement(MultipleLocators["CheckBoxForReport"]);
        public IWebElement ReportInListView => WebDriverUtility.FindElement(MultipleLocators["ReportInListView"]);
        public IWebElement DetailedReport => WebDriverUtility.FindElement(MultipleLocators["DetailedReport"]);
        
        public void switchtogridview()
        {
            Thread.Sleep(2000);
            //WebDriverUtility.ClickOn(CloseIcon);
            WebDriverUtility.ClickOn(GridView);
        }
        public void switchtolistview()
        {
            WebDriverUtility.ClickOn(ListView);
        }
        public void ReportCardsInGrid()
        {
            WebDriverUtility.IsDisplayed(ReportCards);
            WebDriverUtility.ClickOn(ReportCards);
        }
        public void NextButtonAction()
        {
            WebDriverUtility.ClickOn(NextButton);
        }
        public void PreviousButtonAction()
        {
            WebDriverUtility.ClickOn(PreviousButton);
        }
        public void BackToReports()
        {
            WebDriverUtility.ClickOn(BackToReportsButton);
        }
        public void GridViewValidation()
        {
            WebDriverUtility.IsDisplayed(GridView);
        }
        public void SelectAndView()
        {
            WebDriverUtility.IsDisplayed(ReportInListView);
            WebDriverUtility.SelectCheckBox(CheckBoxForReport);
            WebDriverUtility.ClickOn(ViewButton);
        }
        //public void DetailedReportView()
        //{
            
           
        //    WebDriverUtility.IsDisplayed(DetailedReport);
           
        //}

        public void FilterSearch()
        {
            WebDriverUtility.EnterText(SearchFilter, "WorkItem Inventory Report");
        }




    }
}
