using OpenQA.Selenium;
namespace CustomerUIAutomation.Utilities
{
    public class WebDriverHelper : CustomerHelperUtility.WebDriverUtility
    {
        protected IWebDriver WebDriver;
        public WebDriverHelper(IWebDriver driver) : base(driver)
        {
            this.WebDriver = driver;
        }
    }
}
