using CustomerUIAutomation.PageObjects;
using CustomerUIAutomation.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CustomerUIAutomation.StepDefinitions
{
    [Binding]
    class CustomerApplicationsStepDefinitions : StepDefinitionsBase
    {
        private readonly CustomerApplicationsPOM customerApplicationsPage;
        private readonly ScenarioContext _scenarioContext;

        public CustomerApplicationsStepDefinitions(IWebDriver webDriver, ScenarioContext scenarioContext)
            : base(webDriver)
        {
            customerApplicationsPage = new CustomerApplicationsPOM(webDriver);
            _scenarioContext = scenarioContext;

        }
        [Then(@"I validate No Of Apps displayed and No of apps Found")]
        public void AppsValidation()
        {
            customerApplicationsPage.ValidateAppsCountVSAppsDisplayed();
            customerApplicationsPage.NoAppsValidations();
            customerApplicationsPage.FavAppValidation();
        }
    
    }
}
