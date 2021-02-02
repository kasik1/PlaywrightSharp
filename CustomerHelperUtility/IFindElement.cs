using OpenQA.Selenium;

namespace CustomerHelperUtility
{
    public interface IFindElement
    {
        IWebElement GetElement(string locator);
        void IntiateDriver(IWebDriver driver);
    }
}
