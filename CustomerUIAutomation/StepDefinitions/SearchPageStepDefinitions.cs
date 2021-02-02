using CustomerUIAutomation.PageObjects;
using CustomerUIAutomation.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CustomerUIAutomation.StepDefinitions
{
    [Binding]
    class SearchPageStepDefinitions : StepDefinitionsBase
    {
        private readonly AdvancedItemSearch AdvancedItemSearch;
        private readonly ScenarioContext _scenarioContext;

        public SearchPageStepDefinitions(IWebDriver webDriver, ScenarioContext scenarioContext)
            : base(webDriver)
        {
            AdvancedItemSearch = new AdvancedItemSearch(webDriver);
            _scenarioContext = scenarioContext;

        }

        [Then(@"I validate the current search and saved search details")]
        public void ValidateSearchScreen()
        {
            AdvancedItemSearch.ValidateSearchScreen();
        }
        [When(@"I fill the search criteria details and click on Search")]
        public void CreateSearchCriteria()
        {
            AdvancedItemSearch.CreateSearchCriteria();
        }
        [Then(@"validate the search results")]
        public void ValidateSearchResults()
        {
            AdvancedItemSearch.ValidateSearchResults();
        }
        [When(@"I fill the search criteria details and click on Save")]
        public void SaveSearchCriteria()
        {
            AdvancedItemSearch.SaveSearchCriteria();
        }
        [When(@"I Fill the Save search pop-up and click on Save")]
        public void SaveSearchInPopup()
        {
            AdvancedItemSearch.SaveSearchInPopup();
        }
        
        [Then(@"Validate the Saved search item")]
        public void ValidateSavedSearch()
        {
            AdvancedItemSearch.ValidateSavedSearch();
        }
        

    }
}
