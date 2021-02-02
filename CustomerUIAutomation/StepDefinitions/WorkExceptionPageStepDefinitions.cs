using CustomerUIAutomation.PageObjects;
using CustomerUIAutomation.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CustomerUIAutomation.StepDefinitions
{
    [Binding]
    class WorkExceptionPageStepDefinitions:StepDefinitionsBase
    {
        private readonly WorkException WorkException;
        private readonly ScenarioContext _scenarioContext;

        public WorkExceptionPageStepDefinitions(IWebDriver webDriver, ScenarioContext scenarioContext)
            : base(webDriver)
        {
            WorkException = new WorkException(webDriver);
            _scenarioContext = scenarioContext;

        }

        [Then(@"Validate Work exception Home page fields and buttons")]
        public void ValidateWorkexceptionPage()
        {
            WorkException.ValidatePageFields();
        }

        [When(@"I Select a Work exception")]
        public void SelectWorkExceptions()
        {
            WorkException.SelectWorkExceptions();
        }

        [Then(@"Reprocess the selected work exception")]
        public void ReprocessWorkExceptions()
        {
            WorkException.ReprocessWorkExceptions();
        }

        [When(@"I click on a Work exception")]
        public void ClickOnWorkexception()
        {
            WorkException.ClickOnWorkexception();
        }
        [Then(@"Validate the Workexception details page fields")]
        public void ValidateWorkitemDetailPage()
        {
            WorkException.ValidateWorkitemDetailPage();
        }
        [Then(@"Reprocess the work exception from details view")]
        public void ReprocessInDetailsView()
        {
            WorkException.ReprocessInDetailsView();
        }
    }
}
