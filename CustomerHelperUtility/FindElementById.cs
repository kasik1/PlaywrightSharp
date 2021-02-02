using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace CustomerHelperUtility
{
    public class FindElementById : IFindElement
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
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(locator)));
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
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id(locator)));
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
