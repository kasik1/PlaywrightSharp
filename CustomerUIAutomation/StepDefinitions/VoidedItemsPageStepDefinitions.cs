using CustomerUIAutomation.PageObjects;
using CustomerUIAutomation.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CustomerUIAutomation.StepDefinitions
{
    [Binding]
    class VoidedItemsPageStepDefinitions:StepDefinitionsBase
    {
        private readonly VoidedItemsPage VoidedItems;
        private readonly ScenarioContext _scenarioContext;

        public VoidedItemsPageStepDefinitions(IWebDriver webDriver, ScenarioContext scenarioContext)
            : base(webDriver)
        {
            VoidedItems = new VoidedItemsPage(webDriver);
            _scenarioContext = scenarioContext;

        }

        [Then(@"Validate Voided items Home page fields and buttons")]
        public void ValidateVoidedItemsPage()
        {
            VoidedItems.ValidatePageFields();
        }

        [When(@"I Select a Voided item")]
        public void SelectVoidedItem()
        {
            VoidedItems.SelectVoidedItem();
        }

        [Then(@"Reprocess the selected Voided Item")]
        public void ReprocessVoidedItem()
        {
            VoidedItems.ReprocessVoidedItem();
        }

        [When(@"I click on a Voided item")]
        public void ClickOnVoidedItem()
        {
            VoidedItems.ClickOnVoidedItem();
        }
        [Then(@"Validate the Voided Item details page fields")]
        public void ValidateVoidedItemDetailPage()
        {
            VoidedItems.ValidateVoidedItemDetailPage();
        }
        [Then(@"Reprocess the Voided item from details view")]
        public void ReprocessInDetailsView()
        {
            VoidedItems.ReprocessInDetailsView();
        }
    }
}
