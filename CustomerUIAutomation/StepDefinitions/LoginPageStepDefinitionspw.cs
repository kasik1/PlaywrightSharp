using CustomerUIAutomation.PageObjects;
using CustomerUIAutomation.Utilities;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlaywrightSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace CustomerUIAutomation.StepDefinitions
{
    [Binding]
    public class LoginPageStepDefinitionspw : StepDefinitionsBasePw
    {
        private readonly LoginPagePWPOM loginPage;
        private readonly ScenarioContext _scenarioContext;
        Context Context;

        public LoginPageStepDefinitionspw(IPage page, ScenarioContext scenarioContext)
            : base(page)
        {
            //Context = context;
            loginPage = new LoginPagePWPOM(page);
            _scenarioContext = scenarioContext;
           // page.DefaultNavigationTimeout = 60000;


        }
        [Given(@"Navigate to the Customer UI Login pagee")]
        [Fact(Timeout = TestConstants.DefaultTestTimeout)]
        public async Task GivenNavigateToTheCAPUIHomePage_()
        {
    
           await loginPage.ShouldDisableTimeoutWhenItsSetTo();
        }

           
        [When(@"I enter with valid login credentials")]
      
        public async Task EnterLoginCredentials()


        {
             await loginPage.EnterLoginDetails("login");
            await loginPage.ClickProductionControl("login");
        }


        [Then(@"I Logout From Portal")]
        public async Task ThenILogout()
        {
            await loginPage.ClickLogout();
            
        }



    }
}

