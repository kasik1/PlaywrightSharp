using CustomerHelperUtility;
using OpenQA.Selenium;

namespace CustomerUIAutomation.Utilities
{
    public class StepDefinitionsBase
    {
        protected readonly IWebDriver WebDriver;
        protected readonly WebDriverHelper Driver;
        protected readonly WebDriverUtility webDriverUtility;

        public StepDefinitionsBase(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
            Driver = new WebDriverHelper(webDriver);
            webDriverUtility = new WebDriverUtility(webDriver);
        }
    }
}
