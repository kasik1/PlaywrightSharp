using CustomerHelperUtility;
using OpenQA.Selenium;
using PlaywrightSharp;

namespace CustomerUIAutomation.Utilities
{
    public class StepDefinitionsBasePw

    {



        protected readonly IPage page;
        protected readonly PWHelper pWHelper;
        protected readonly PlaywrightUtility playwrightUtility;

        public StepDefinitionsBasePw(IPage pageP) 
        {
            this.page = pageP;
            pWHelper = new PWHelper(page);
            playwrightUtility = new PlaywrightUtility(page);
        }
    }
}
