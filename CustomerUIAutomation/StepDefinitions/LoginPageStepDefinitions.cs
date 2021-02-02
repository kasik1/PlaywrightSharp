//using CustomerUIAutomation.PageObjects;
//using CustomerUIAutomation.Utilities;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using TechTalk.SpecFlow;

//namespace CustomerUIAutomation.StepDefinitions
//{
//    [Binding]
//    class LoginPageStepDefinitions : StepDefinitionsBase
//    {
//        private readonly LoginPagePOM loginPage;
//        private readonly ScenarioContext _scenarioContext;

//        public LoginPageStepDefinitions(IWebDriver webDriver, ScenarioContext scenarioContext)
//            : base(webDriver)
//        {
//            loginPage = new LoginPagePOM(webDriver);
//            _scenarioContext = scenarioContext;

//        }
//        [Given(@"Navigate to the Customer UI Login pagee")]
//        public void GivenNavigateToTheCAPUIHomePage_()
//        {


//            var testContext = _scenarioContext.ScenarioContainer.Resolve<TestContext>();
//            loginPage.NavigateToUrl("https://customer-ui-hub-dummy-plt-qa.conduent-cap.com/login");


//        }
//        [When(@"I enter with valid login credentials")]
//        public void ThenIEnterThevalidLoginCredentials()
//        {
//            loginPage.EnterLoginDetails("Login");
//        }

//    }
//}
