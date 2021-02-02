using CustomerUIAutomation.PageObjects;
using CustomerUIAutomation.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CustomerUIAutomation.StepDefinitions
{
    [Binding]
    class DashBoardStepDefinitions : StepDefinitionsBase
    {
        private readonly DashBoardPOM dashBoardPage;
        private readonly ScenarioContext _scenarioContext;

        public DashBoardStepDefinitions(IWebDriver webDriver, ScenarioContext scenarioContext)
            : base(webDriver)
        {
            dashBoardPage = new DashBoardPOM(webDriver);
            _scenarioContext = scenarioContext;

        }
        [When(@"Verify View And DashBoard Reports")]
        public void VerifyViewAndDashBoardReports()
        {
            dashBoardPage.VerifyDashBoard();

        }

        [Then(@"Validate DashBoard Screen")]
        public void ValidateDashBoard()
        {
            dashBoardPage.ValidateAppsCountVSAppsDisplayed();
            
        }

    }
}
