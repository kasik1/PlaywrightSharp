using OpenQA.Selenium;

namespace CustomerHelperUtility
{
    public static class FindElementFactory
    {
        public static T FindElement<T>(IWebDriver webDriver) where T : IFindElement, new()
        {
            T t = new T();
            t.IntiateDriver(webDriver);
            return t;
        }
    }
}
