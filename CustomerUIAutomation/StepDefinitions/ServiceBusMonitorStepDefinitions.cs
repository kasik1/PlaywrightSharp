using CustomerUIAutomation.PageObjects;
using CustomerUIAutomation.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CustomerUIAutomation.StepDefinitions
{
    [Binding]
    public class ServiceBusMonitorStepDefinitions : StepDefinitionsBase
    {
        private readonly ServiceBusMonitorPOM serviceBusMonitorPage;
        private readonly ScenarioContext _scenarioContext;

        public ServiceBusMonitorStepDefinitions(IWebDriver webDriver, ScenarioContext scenarioContext)
            : base(webDriver)
        {
            serviceBusMonitorPage = new ServiceBusMonitorPOM(webDriver);
            _scenarioContext = scenarioContext;

        }

        [When(@"I click on ServiceBus Monitor")]
        public void WhenIClickOnServiceBusMonitor()
        {
            serviceBusMonitorPage.ClickonServiceBusMonitor();
        }
        [When(@"I search using filter")]
        public void whenIEnterTextinSearchFilter()
        {
            serviceBusMonitorPage.EnterTextInFilter();
        }
        [When(@"I click on Enable")]
        public void WhenIClickOnEnable()
        {
            serviceBusMonitorPage.ClickonEnable();
        }
    }
}
