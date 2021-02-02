using CustomerHelperUtility;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace CustomerUIAutomation.Utilities
{
    public class TestBase
    {
        public WebDriverUtility WebDriverUtility { get; set; }

        private readonly Hooks hooks;
        public Dictionary<string, Dictionary<string, string>> MultipleLocators { get; set; }
        public ExcelHelper Excel { get; set; }

     

        public TestBase(IWebDriver driver, string locatorsPath, string sheetName)
        {
            //WebDriverUtility = new WebDriverUtility(driver);
            //hooks = new Hooks();
            //MultipleLocators = hooks.GetJsonMultipleLocators(locatorsPath);
            //Excel = hooks.ReadExcel(sheetName);
             
        }
    }
}
