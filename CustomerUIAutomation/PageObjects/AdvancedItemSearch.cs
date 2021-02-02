using CustomerUIAutomation.Utilities;
using CustomerHelperUtility;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CustomerUIAutomation.PageObjects
{
    class AdvancedItemSearch : TestBase
    {

        private readonly IWebDriver _WebDriver;
        public AdvancedItemSearch(IWebDriver driver)
            : base(driver, "LocatorsJsonFiles\\AdvancedItemSearchLocators.json", "LoginPageTestData")
        {
            this._WebDriver = driver;
            WebDriverUtility.TurnOnWait(60);
        }

        public IWebElement SearchHeader => WebDriverUtility.FindElement(MultipleLocators["SearchHeader"]);
        public IWebElement SearchDescription => WebDriverUtility.FindElement(MultipleLocators["SearchDescription"]);
        public IWebElement CurrentSearch => WebDriverUtility.FindElement(MultipleLocators["CurrentSearch"]);
        public IWebElement SavedSearch => WebDriverUtility.FindElement(MultipleLocators["SavedSearch"]);
        public IWebElement WorkitemRadio => WebDriverUtility.FindElement(MultipleLocators["WorkitemRadio"]);
        public IWebElement WorkitemAttachmentRadio => WebDriverUtility.FindElement(MultipleLocators["WorkitemAttachmentRadio"]);
        public IWebElement AttachmentRadio => WebDriverUtility.FindElement(MultipleLocators["AttachmentRadio"]);
        public IWebElement AddCriteria => WebDriverUtility.FindElement(MultipleLocators["AddCriteria"]);
        public IWebElement SelectColumnName => WebDriverUtility.FindElement(MultipleLocators["SelectColumnName"]);
        public IWebElement SelectOperator => WebDriverUtility.FindElement(MultipleLocators["SelectOperator"]);
        public IWebElement SelectOperatorArrow => WebDriverUtility.FindElement(MultipleLocators["SelectOperatorArrow"]);
        public IWebElement EnterValue => WebDriverUtility.FindElement(MultipleLocators["EnterValue"]);
        public IWebElement WorkflowNameColumn => WebDriverUtility.FindElement(MultipleLocators["WorkflowNameColumn"]);
        public IWebElement WorkTypeColumn => WebDriverUtility.FindElement(MultipleLocators["WorkTypeColumn"]);
        public IWebElement WorkItemName => WebDriverUtility.FindElement(MultipleLocators["WorkItemName"]);
        public IWebElement StepNameColumn => WebDriverUtility.FindElement(MultipleLocators["StepNameColumn"]);
        public IWebElement StatusColumn => WebDriverUtility.FindElement(MultipleLocators["StatusColumn"]);
        public IWebElement SLATargetColumn => WebDriverUtility.FindElement(MultipleLocators["SLATargetColumn"]);
        public IWebElement SLAStartColumn => WebDriverUtility.FindElement(MultipleLocators["SLAStartColumn"]);
        public IWebElement VisibleColumnsList => WebDriverUtility.FindElement(MultipleLocators["VisibleColumnsList"]);
        public IWebElement SearchButton => WebDriverUtility.FindElement(MultipleLocators["SearchButton"]);
        public IWebElement SearchResultsTitle => WebDriverUtility.FindElement(MultipleLocators["SearchResultsTitle"]);
        public IWebElement SearchResultsColumn => WebDriverUtility.FindElement(MultipleLocators["SearchResultsColumn"]);
        public IWebElement ExportButton => WebDriverUtility.FindElement(MultipleLocators["ExportButton"]);
        public IWebElement ClearButton => WebDriverUtility.FindElement(MultipleLocators["ClearButton"]);
        public IWebElement SaveSearchButton => WebDriverUtility.FindElement(MultipleLocators["SaveSearchButton"]);
        public IWebElement NoSavedSearchMsg => WebDriverUtility.FindElement(MultipleLocators["NoSavedSearchMsg"]);
        public IWebElement SearchName => WebDriverUtility.FindElement(MultipleLocators["SearchName"]);
        public IWebElement SearchDesc => WebDriverUtility.FindElement(MultipleLocators["SearchDesc"]);
        public IWebElement SavePopup => WebDriverUtility.FindElement(MultipleLocators["SavePopup"]);
        public IWebElement SavedTypeDropdown => WebDriverUtility.FindElement(MultipleLocators["SavedTypeDropdown"]);
        public IWebElement SavedSearchHeader => WebDriverUtility.FindElement(MultipleLocators["SavedSearchHeader"]);
        public IWebElement SavedSearchElipse => WebDriverUtility.FindElement(MultipleLocators["SavedSearchElipse"]);
        public IWebElement SavedSearchOptions => WebDriverUtility.FindElement(MultipleLocators["SavedSearchOptions"]);
        public IWebElement SavedSearchName => WebDriverUtility.FindElement(MultipleLocators["SavedSearchName"]);
        public IWebElement SavedSearchDescription => WebDriverUtility.FindElement(MultipleLocators["SavedSearchDescription"]);
        public IWebElement SavedSearchCreateDate => WebDriverUtility.FindElement(MultipleLocators["SavedSearchCreateDate"]);



        public void ValidateSearchScreen()
        {
            String searchHeader = WebDriverUtility.GetText(SearchHeader);
            String searchDescription = WebDriverUtility.GetText(SearchDescription);
            Assert.AreEqual("Advanced item search", searchHeader);
            Assert.AreEqual("Build advanced query for work items or attachments", searchDescription);
            Assert.IsTrue(WebDriverUtility.IsDisplayed(WorkitemRadio));
            Assert.IsTrue(WebDriverUtility.IsDisplayed(WorkitemAttachmentRadio));
            Assert.IsTrue(WebDriverUtility.IsDisplayed(AttachmentRadio));
            Assert.IsTrue(WebDriverUtility.IsDisplayed(AddCriteria));
            Assert.IsTrue(WebDriverUtility.IsDisplayed(WorkItemName));
            Assert.IsFalse(WebDriverUtility.IsEnabled(SearchButton));
            Assert.IsFalse(WebDriverUtility.IsEnabled(SaveSearchButton));
            Assert.IsTrue(WebDriverUtility.IsEnabled(ClearButton));
            WebDriverUtility.ClickOn(SavedSearch);
            Assert.AreEqual("No Saved Searches", WebDriverUtility.GetText(NoSavedSearchMsg));
        }

        /*public void ValidateSavedSearchScreen()
        {
            WebDriverUtility.ClickOn(SavedSearch);
           

           

        }*/
        public void CreateSearchCriteria()
        {
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(AddCriteria);
            WebDriverUtility.EnterText(SelectColumnName, "Work Item Name");
            WebDriverUtility.ClickOn(SelectOperatorArrow);
            WebDriverUtility.ClickOnPointFromElement(SelectOperator, "bottom",25);
            WebDriverUtility.EnterText(EnterValue, "test");
            WebDriverUtility.ClickOn(SearchButton);

        }
        public void ValidateSearchResults()
        {
            Assert.AreEqual("Search Results", SearchResultsTitle);
            Assert.IsTrue(WebDriverUtility.IsDisplayed(SearchResultsColumn));
            Assert.IsTrue(WebDriverUtility.IsDisplayed(ExportButton));

        }
        public void SaveSearchCriteria()
        {
            WebDriverUtility.ClickOn(AddCriteria);
            WebDriverUtility.EnterText(SelectColumnName, "Work Item Name");
            WebDriverUtility.ClickOn(SelectOperatorArrow);
            WebDriverUtility.ClickOnPointFromElement(SelectOperator, "bottom",23);
           // SelectOperator.SelectByValue("Different Than");
            WebDriverUtility.EnterText(EnterValue, "test");
            WebDriverUtility.ClickOn(SaveSearchButton);

        }
        public void SaveSearchInPopup()
        {
            WebDriverUtility.EnterText(SearchName,"");
            WebDriverUtility.EnterText(SearchName, "");
            WebDriverUtility.ClickOn(SavePopup);
        }
        public void ValidateSavedSearch()
        {
            String searchHeader = WebDriverUtility.GetText(SavedSearchHeader);
            Assert.AreEqual("Saved Searches", searchHeader);

            String SearchWorkitemName = WebDriverUtility.GetText(SavedSearchName);
            String SearchWorkitemDesc = WebDriverUtility.GetText(SavedSearchDescription);
            String SearchWorkitemCreateDate = WebDriverUtility.GetText(SavedSearchCreateDate);

            Assert.IsTrue(WebDriverUtility.IsDisplayed(SavedSearchElipse));
            WebDriverUtility.ClickOn(SavedSearchElipse);
            

        }

        



    }
}
