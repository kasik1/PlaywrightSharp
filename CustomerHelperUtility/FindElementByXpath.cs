using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace CustomerHelperUtility
{
    public class FindElementByXpath : IFindElement
    {
        private IWebDriver _WebDriver;
        public void IntiateDriver(IWebDriver driver)
        {
            _WebDriver = driver;
        }
        public IWebElement GetElement(string locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_WebDriver, TimeSpan.FromSeconds(60));
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locator)));
                return element;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public IList<IWebElement> GetElements(string locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_WebDriver, TimeSpan.FromSeconds(60));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(locator)));
                return element;
            }
            catch (Exception)
            {
                IList<IWebElement> emptyList = Array.Empty<IWebElement>();
                return emptyList;
            }

        }
    }
}
