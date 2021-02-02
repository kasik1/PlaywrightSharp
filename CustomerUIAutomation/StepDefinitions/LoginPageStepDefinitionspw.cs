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


            await ShouldDisableTimeoutWhenItsSetTo0();
            // var testContext = _scenarioContext.ScenarioContainer.Resolve<TestContext>();
            // await loginPage.NavigateToUrl("https://customer-ui-hub-dummy-plt-qa.conduent-cap.com/login");


            //var response= await page.GoToAsync("https://customer-ui-hub-dummy-plt-qa.conduent-cap.com/login");
            // Assert.Equal(HttpStatusCode.OK, response.Status);


            //page.DefaultTimeout = 0;
            //page.DefaultNavigationTimeout = 1;
            //var exception = await Assert.ThrowsAnyAsync<TimeoutException>(async () => await page.GoToAsync(TestConstants.ServerUrl));
            //Assert.Contains("Timeout 1ms exceeded", exception.Message);
            //Assert.Contains(TestConstants.EmptyPage, exception.Message);


            //page.DefaultNavigationTimeout = 60000;
            //page.DefaultTimeout = 60000;
            // await page.WaitForTimeoutAsync(60000);
            //await page.WaitForNavigationAsync(LifecycleEvent.Networkidle);


            await loginPage.ShouldDisableTimeoutWhenItsSetTo0();
        }

        [Fact(Timeout = TestConstants.DefaultTestTimeout)]
        public async Task ShouldDisableTimeoutWhenItsSetTo0()
        {
            bool loaded = false;
            void OnLoad(object sender, EventArgs e)
            {
                loaded = true;
                page.Load -= OnLoad;
            }
            page.Load += OnLoad;

            await page.GoToAsync(TestConstants.ServerUrl , LifecycleEvent.Load, null, 0);
         Assert.True(loaded);
        }
        [When(@"I enter with valid login credentials")]
        public async Task ThenIEnterThevalidLoginCredentials()


        {
            await loginPage.ShouldDisableTimeoutWhenItsSetTo0();
           await loginPage.Login("login");
            //await loginPage.ClickLogin();
        }


        // string txtUserName => "//input[@type='email']";
        //string txtPassword => "//input[@type ='password']";
        //string btnSubmit => "//span[@class='submit']";

       

    }
}

