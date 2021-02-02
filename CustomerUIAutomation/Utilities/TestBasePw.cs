using CustomerHelperUtility;
using OpenQA.Selenium;
using PlaywrightSharp;
using System.Collections.Generic;

namespace CustomerUIAutomation.Utilities
{
    public class TestBasePw
    {
        public PlaywrightUtility PlaywrightUtility { get; set; }

        private readonly HooksPw hooks;
        public Dictionary<string, Dictionary<string, string>> MultipleLocators { get; set; }
        public ExcelHelper Excel { get; set; }

     

        public TestBasePw(IPage pageP,string locatorsPath, string sheetName)
        {
            PlaywrightUtility = new PlaywrightUtility(pageP);
            hooks = new HooksPw();
            MultipleLocators = hooks.GetJsonMultipleLocators(locatorsPath);
            Excel = hooks.ReadExcel(sheetName);
             
        }
    }
}
