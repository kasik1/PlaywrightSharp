using CustomerUIAutomation.PageObjects;
using CustomerUIAutomation.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CustomerUIAutomation.StepDefinitions
{
    [Binding]
    class ReportsPageStepDefinitions:StepDefinitionsBase
    {
        private readonly ReportaPagePOM reportsPage;
        private readonly ScenarioContext _scenarioContext;

        public ReportsPageStepDefinitions(IWebDriver webDriver, ScenarioContext scenarioContext)
            : base(webDriver)
        {
            reportsPage = new ReportaPagePOM(webDriver);
            _scenarioContext = scenarioContext;

        }
        [When(@"Switch to Grid View")]
        public void WhenISwitchtoGridView()
        {
            reportsPage.switchtogridview();
            reportsPage.FilterSearch();
        }
        [When(@"Switch to List View")]
        public void WhenISwitchtoListView()
        {
            reportsPage.switchtolistview();
        }
        [Then(@"Reports Cards Should be displayed and also click on report cards should navigate to Detail view of report")]
        public void ThenIValidateCards()
        {
           
            reportsPage.ReportCardsInGrid();
            
        }
        [When (@"Click on Next Button")]

        public void WhenClickOnNextButton()
        {
            reportsPage.NextButtonAction();
        }
        [When(@"Click on Previous Button")]

        public void WhenClickOnPreviousButton()
        {
            reportsPage.PreviousButtonAction();
        }
        [When(@"I click on back to reports")]
        public void WhenClickonBacktoReports()
        {
            reportsPage.BackToReports();
        }
        [Then(@"Grid View is displayed")]
        public void ThenGridViewDisplayed()
        {
            reportsPage.GridViewValidation();

        }
        [Then (@"Select Report and view them")]
        public void ThenSelectAndView()
        {
            reportsPage.SelectAndView();
            
        }
    }
}
