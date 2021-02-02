using OpenQA.Selenium;
using PlaywrightSharp;

namespace CustomerUIAutomation.Utilities
{
    public class PWHelper : CustomerHelperUtility.PlaywrightUtility

    {
        protected IPage playwright;
        protected IBrowser browser;
        public PWHelper(IPage Playwright) : base(Playwright)
        {
            this.playwright = Playwright;
        }
    }
}
