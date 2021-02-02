using CustomerUIAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerUIAutomation.PageObjects
{
    class VoidedItemsPage : TestBase
    {

        private readonly IWebDriver _WebDriver;
        public VoidedItemsPage(IWebDriver driver)
            : base(driver, "LocatorsJsonFiles\\VoidedPageLocators.json", "LoginPageTestData")
        {
            this._WebDriver = driver;
            WebDriverUtility.TurnOnWait(60);
        }
        public IWebElement VoidedScreenHeader => WebDriverUtility.FindElement(MultipleLocators["VoidedScreenHeader"]);
        public IWebElement VoidedScreenDescription => WebDriverUtility.FindElement(MultipleLocators["VoidedScreenDescription"]);
        public IWebElement Search => WebDriverUtility.FindElement(MultipleLocators["Search"]);
        public IWebElement ExportToExcel => WebDriverUtility.FindElement(MultipleLocators["Export"]);
        public IWebElement Reprocess => WebDriverUtility.FindElement(MultipleLocators["Reprocess"]);
        public IList<IWebElement> ReprocessTypesList => WebDriverUtility.FindElements(MultipleLocators["ReprocessTypesList"]).ToList<IWebElement>();
        public IWebElement BackToResults => WebDriverUtility.FindElement(MultipleLocators["BackToResults"]);
        public IWebElement KendoGrid => WebDriverUtility.FindElement(MultipleLocators["KendoGrid"]);
        public IWebElement WorkitemName => WebDriverUtility.FindElement(MultipleLocators["WorkitemName"]);
        public IWebElement WorkitemCheckbox => WebDriverUtility.FindElement(MultipleLocators["WorkitemCheckbox"]);
        public IWebElement EditField => WebDriverUtility.FindElement(MultipleLocators["EditField"]);
        public IWebElement EditStatus => WebDriverUtility.FindElement(MultipleLocators["EditStatus"]);
        public IWebElement ChangeStatus => WebDriverUtility.FindElement(MultipleLocators["ChangeStatus"]);
        public IWebElement AddressInput => WebDriverUtility.FindElement(MultipleLocators["AddressInput"]);
        public IWebElement VariablesTab => WebDriverUtility.FindElement(MultipleLocators["VariablesTab"]);
        public IWebElement AttachmentsTab => WebDriverUtility.FindElement(MultipleLocators["AttachmentsTab"]);
        public IWebElement WorkitemHeader => WebDriverUtility.FindElement(MultipleLocators["WorkitemHeader"]);
        public IWebElement WorkitemDetailsDesc => WebDriverUtility.FindElement(MultipleLocators["WorkitemDetailsDesc"]);
        public IWebElement ReprocessInDetail => WebDriverUtility.FindElement(MultipleLocators["ReprocessInDetail"]);
        public IWebElement ReprocessOptions => WebDriverUtility.FindElement(MultipleLocators["ReprocessOptions"]);
        public IWebElement ReprocessInStep => WebDriverUtility.FindElement(MultipleLocators["ReprocessInStep"]);
        public IWebElement ReprocessInOptions => WebDriverUtility.FindElement(MultipleLocators["ReprocessInOptions"]);
        public IWebElement Void => WebDriverUtility.FindElement(MultipleLocators["Void"]);
        public IWebElement AlertMessage => WebDriverUtility.FindElement(MultipleLocators["AlertMessage"]);
        public IWebElement AlertComments => WebDriverUtility.FindElement(MultipleLocators["AlertComments"]); 
        public IWebElement CancelReprocess => WebDriverUtility.FindElement(MultipleLocators["CancelReprocess"]);
        public IWebElement ReprocessInAlert => WebDriverUtility.FindElement(MultipleLocators["ReprocessInAlert"]);
        public IWebElement SuccessMessage => WebDriverUtility.FindElement(MultipleLocators["SuccessMessage"]);



        public void ValidatePageFields()
        {
            String Header = WebDriverUtility.GetText(VoidedScreenHeader).Trim();
            Assert.AreEqual("Voided Items Monitor", Header);

            String Description = WebDriverUtility.GetText(VoidedScreenDescription).Trim();
            Assert.AreEqual("Monitor and Manage Services", Description);

            Assert.IsTrue(WebDriverUtility.IsEnabled(Search));
            Assert.IsTrue(WebDriverUtility.IsEnabled(ExportToExcel));
            Assert.IsFalse(WebDriverUtility.IsEnabled(Reprocess));
            Assert.IsTrue(WebDriverUtility.IsDisplayed(KendoGrid));
            

        }

        public void ClickOnVoidedItem()
        {
            WebDriverUtility.ClickOn(WorkitemName);

        }
        public void ValidateVoidedItemDetailPage()
        {

            String workitemName = WebDriverUtility.GetText(WorkitemName).Trim();
            WebDriverUtility.ClickOn(WorkitemName);
            Assert.AreEqual("item #"+workitemName.ToLower(), WebDriverUtility.GetText(WorkitemHeader).Trim().ToLower());
            String description = "Monitor and Manage Services #" + workitemName;
            Assert.AreEqual(description.ToLower(), WebDriverUtility.GetText(WorkitemDetailsDesc).Trim().ToLower());
            Assert.IsTrue(WebDriverUtility.IsEnabled(EditField));
            Assert.IsTrue(WebDriverUtility.IsEnabled(BackToResults));
            Assert.IsTrue(WebDriverUtility.IsEnabled(Reprocess));
            WebDriverUtility.ClickOn(ReprocessOptions);
            /*String editStatus = WebDriverUtility.GetAttribute(EditStatus,"value").Trim();
            Assert.AreEqual(editStatus,"true");*/
            Assert.IsTrue(WebDriverUtility.IsEnabled(AddressInput));
            WebDriverUtility.ClickOn(ChangeStatus);
            /*editStatus = WebDriverUtility.GetAttribute(EditStatus, "value").Trim();
            Assert.AreEqual(editStatus, "false");*/
        
            Assert.IsFalse(WebDriverUtility.IsEnabled(AddressInput));
            WebDriverUtility.ClickOn(VariablesTab);
            

        }

        public void ReprocessInDetailsView()
        {
            String workitemName = WebDriverUtility.GetText(WorkitemName).Trim();
            WebDriverUtility.ClickOn(WorkitemName);
            WebDriverUtility.ClickOn(Reprocess);
            String alertMessage = WebDriverUtility.GetText(AlertMessage);
            String expectedAlertMessage = "You are about to reprocess the following item(s) \"" + workitemName + "\"";
            Assert.AreEqual(expectedAlertMessage, alertMessage);
            WebDriverUtility.EnterText(AlertComments, "Automated test run");
            WebDriverUtility.ClickOn(ReprocessInAlert);
            String ReprocessMessage = WebDriverUtility.GetText(SuccessMessage);
            Console.WriteLine(ReprocessMessage);
        }

        public void SelectVoidedItem()
        {
            WebDriverUtility.ClickOn(WorkitemCheckbox);
        }

        public void ReprocessVoidedItem()
        {
            String workitemName = WebDriverUtility.GetText(WorkitemName).Trim();
            WebDriverUtility.ClickOn(Reprocess);
            String alertMessage = WebDriverUtility.GetText(AlertMessage);
            String expectedAlertMessage = "You are about to reprocess the following item(s) \"" + workitemName + "\"";
            Assert.AreEqual(expectedAlertMessage, alertMessage);
            WebDriverUtility.EnterText(AlertComments, "Automated test run");
            WebDriverUtility.ClickOn(ReprocessInAlert);
            String ReprocessMessage = WebDriverUtility.GetText(SuccessMessage);
            Console.WriteLine(ReprocessMessage);
        }

    }
}
