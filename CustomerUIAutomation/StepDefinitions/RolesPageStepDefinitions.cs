using CustomerUIAutomation.PageObjects;
using CustomerUIAutomation.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CustomerUIAutomation.StepDefinitions
{
    [Binding]
   public class RolesPageStepDefinitions : StepDefinitionsBase
    {
        private readonly RolesPagePOM rolesPage;
        private readonly ScenarioContext _scenarioContext;

        public RolesPageStepDefinitions(IWebDriver webDriver, ScenarioContext scenarioContext)
            : base(webDriver)
        {
            rolesPage = new RolesPagePOM(webDriver);
            _scenarioContext = scenarioContext;

        }
        [When(@"Add an new Role")]
        public void AddUser()
        {

            rolesPage.AddRoles();
        }
    }

}
