using CustomerUIAutomation.PageObjects;
using CustomerUIAutomation.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CustomerUIAutomation.StepDefinitions
{


    [Binding]

    public class UsersStepDefinitions : StepDefinitionsBase
    {
        private readonly UsersPagePOM usersPage;
        private readonly ScenarioContext _scenarioContext;

        public UsersStepDefinitions(IWebDriver webDriver, ScenarioContext scenarioContext)
            : base(webDriver)
        {
            usersPage = new UsersPagePOM(webDriver);
            _scenarioContext = scenarioContext;

        }
        [When(@"Add an new User")]
        public void AddUser()
        {
         
            usersPage.AddUsersinGridView();
        }
        [When(@"Add an new User in grid view")]
        public void gridviews()
        {
            usersPage.AddUsersinGridView();
        }
    }
}
