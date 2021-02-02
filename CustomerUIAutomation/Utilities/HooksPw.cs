using BoDi;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;
using System.Reflection;
using CustomerHelperUtility;
using System.Diagnostics;
using TechTalk.SpecFlow.Tracing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using System.Drawing;
using PlaywrightSharp;
using System.Threading.Tasks;

namespace CustomerUIAutomation.Utilities
{
    [Binding]
    public sealed class HooksPw : BaseTestPw
    {

        private readonly IObjectContainer objectContainer;
        Context Context;


        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private static ExtentReports extent;
        private static ExtentTest featureName;
        private static ExtentTest scenario;

        new  IPage page;
        PWHelper Driver;
        public HooksPw()
        {
        }

        public HooksPw(Context context,ObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
          //  this.page = Page;
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
            this.Context = context;
        }
        [BeforeTestRun]
        public static void InitializeReport()
        {
            string projectpath = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string reportlocation = projectpath + "/TestReports/";
            if (!Directory.Exists(reportlocation))
            {
                Directory.CreateDirectory(reportlocation);
            }

            //Initialize Extent report before test starts
            var htmlReporter = new ExtentHtmlReporter(reportlocation + "CustomerUIReport.html");
            htmlReporter.Configuration().ReportName = ConfigurationManager.AppSettings["ReportName"];

            //Attach report to reporter
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            //Create dynamic feature name
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }


        [BeforeScenario(Order = 0)]
        public async Task InitializeWebDriver()
        {
           // Create dynamic scenario name
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);

            var scenarioIncrement = Increment();

            if (scenarioIncrement == 1)
            {
                var testContextOne = _scenarioContext.ScenarioContainer.Resolve<TestContext>();
                testContextOne.AddResultFile(ConfigurationManager.AppSettings["ReportLocation"] + "CustomerUIReport.html");
            }
            LaunchOptions launchOptions = new LaunchOptions()
            {
                Headless = Convert.ToBoolean(Environment.GetEnvironmentVariable("HEADLESS") ?? "false"),
                Timeout = 0,
            };
            var browserType = _scenarioContext.ScenarioInfo.Tags[0];

            //  page = InitalizePlaywright("loca browserType);
            //  Context.Page = await InitalizePlaywright(Browser.Chromium, launchOptions);
            Context.Page = await InitalizePlaywright(browserType, launchOptions);
            Driver = new PWHelper(Context.Page);
            _objectContainer.RegisterInstanceAs<IPage>(Context.Page);
          
          //  Driver.
        }

        //[BeforeScenario]
        //public async Task Intlize()
        //{

        //  //  PlaywrightDriver playwrightDriver = new PlaywrightDriver();

        //    LaunchOptions launchOptions = new LaunchOptions()
        //    {
        //        Headless = Convert.ToBoolean(Environment.GetEnvironmentVariable("HEADLESS") ?? "false"),
        //        Timeout = 0,
        //    };
        //    Context.Page = await InitalizePlaywright(Browser.Chromium, launchOptions);
        //    objectContainer.RegisterInstanceAs<IPage>(Context.Page);

        //}

      //  public HooksPw() { }


        //    public readonly Playwright pl1;
        //    private readonly IObjectContainer _objectContainer;
        //    private readonly ScenarioContext _scenarioContext;

        //    private static ExtentReports extent;
        //    private static ExtentTest featureName;
        //    private static ExtentTest scenario;

        //    new IPage page;
        //    new IBrowser browserT;
        //    LaunchOptions launchOptions = new LaunchOptions()
        //    {
        //        Headless = false,
        //    };
        //    PWHelper Driver;

        //    public IPage Page1 { get; set; }

        //    public HooksPw(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        //    {
        //        _objectContainer = objectContainer;
        //        _scenarioContext = scenarioContext;
        //    }

        //    public HooksPw() { }

        //    [BeforeTestRun]
        //    public static void InitializeReport()
        //    {
        //        string projectpath = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        //        string reportlocation = projectpath + "/TestReports/";
        //        if (!Directory.Exists(reportlocation))
        //        {
        //            Directory.CreateDirectory(reportlocation);
        //        }

        //        //Initialize Extent report before test starts
        //        var htmlReporter = new ExtentHtmlReporter(reportlocation + "CustomerUIReport.html");
        //        htmlReporter.Configuration().ReportName = ConfigurationManager.AppSettings["ReportName"];

        //        //Attach report to reporter
        //        extent = new ExtentReports();
        //        extent.AttachReporter(htmlReporter);
        //    }

        //    [BeforeFeature]
        //    public static void BeforeFeature(FeatureContext featureContext)
        //    {
        //        //Create dynamic feature name
        //        featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        //    }

        //    [BeforeScenario(Order = 0)]
        //    public async void InitializeWebDriver()
        //    {


        //        //Create dynamic scenario name
        //        scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);

        //        var scenarioIncrement = Increment();

        //        if (scenarioIncrement == 1)
        //        {
        //            var testContextOne = _scenarioContext.ScenarioContainer.Resolve<TestContext>();
        //            testContextOne.AddResultFile(ConfigurationManager.AppSettings["ReportLocation"] + "CustomerUIReport.html");
        //        }
        //        var browserType = _scenarioContext.ScenarioInfo.Tags[0];
        //        //LaunchBrowserAsync();
        //        // var playwright = await Playwright.CreateAsync();
        //        //page = GetDriver("local", browserType);
        //        // var dr= Browsetype("local", browserType);
        //        Page = await InitalizePlaywright (Browser.Chromium, launchOptions);
        //        // Driver = new PWHelper(playwright);
        //        _objectContainer.RegisterInstanceAs<IPage>(page);
        //        // _objectContainer.RegisterInstanceAs(dr);
        //        // Driver.Maximize();
        //    }
        //    //public async Task Browsetype(string executionType, string browserType)
        //    //{

        //    //    //string[] str = { "chromium", "firefox", "webkit" };
        //    //    var chromium = playwright.Chromium;
        //    //    var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions { Headless = false });
        //    //    var page = await browser.NewPageAsync();
        //    //}
        //    ////private IPage GetDriver(string v,  BrowserType br)
        //    ////{
        //    ////    return BrowserType.Chromium.ToString();
        //    ////}

        //    //[AfterStep]
        //    //public void InsertReportingSteps()
        //    //{
        //    //    var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

        //    //    var testContextTwo = _scenarioContext.ScenarioContainer.Resolve<TestContext>();
        //    //    string scenarioBase = string.Format("error_{0}_{1}",
        //    //                          _scenarioContext.ScenarioInfo.Title.ToIdentifier(),
        //    //                          DateTime.Now.ToString("yyyyMMdd_HHmmss"));
        //    //    var artifactDirectory = testContextTwo.ResultsDirectory;
        //    //    string screenshotFilePath = Path.Combine(artifactDirectory, scenarioBase + "_image.jpg");

        //    //    if (_scenarioContext.TestError == null)
        //    //    {
        //    //        if (stepType == "Given")
        //    //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
        //    //        else if (stepType == "When")
        //    //            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
        //    //        else if (stepType == "Then")
        //    //            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
        //    //        else if (stepType == "And")
        //    //            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
        //    //    }
        //    //    else if (_scenarioContext.TestError != null)
        //    //    {
        //    //        //Driver.TakeScreenshot(screenshotFilePath);
        //    //        //testContextTwo.AddResultFile(screenshotFilePath);
        //    //        //scenario.AddScreenCaptureFromPath("data:image/jpg;base64," + ImageToBase64(screenshotFilePath));

        //    //        if (stepType == "Given")
        //    //        {
        //    //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
        //    //        }
        //    //        else if (stepType == "When")
        //    //        {
        //    //            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
        //    //        }
        //    //        else if (stepType == "Then")
        //    //        {
        //    //            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);

        //    //        }
        //    //    }

        //    //    //pending status
        //    //    if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
        //    //    {
        //    //        if (stepType == "Given")
        //    //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
        //    //        else if (stepType == "When")
        //    //            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
        //    //        else if (stepType == "Then")
        //    //            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
        //    //    }
        //    //}

        //    //[AfterScenario]
        //    public void AfterScenario()
        //    {
        //      //  Driver.CloseDriver();




        //    }

        //    [AfterTestRun]
        //    public static void TearDownReport()
        //    {
        //        //Flush report once test completes
        //        extent.Flush();
        //    }

        //    private string ImageToBase64(string pathName)
        //    {
        //        using (Image image = Image.FromFile(pathName))
        //        {
        //            using (MemoryStream m = new MemoryStream())
        //            {
        //                image.Save(m, image.RawFormat);
        //                byte[] imageBytes = m.ToArray();

        //                // Convert byte[] to Base64 String
        //                string base64String = Convert.ToBase64String(imageBytes);
        //                return base64String;
        //            }
        //        }
        //    }
    }

    public enum Browser
    {
        Chromium,
        Firefox,
        WebKit
    }

    public abstract class BaseTestPw
    {
        public IPage Page { get; set; }

        //public  Playwright pl1 { get; set;} 
        public string BrowserConfig => ConfigurationManager.AppSettings["browser"];
        public string SeleniumBaseUrl => ConfigurationManager.AppSettings["SeleniumBaseUrl"];
        public string SeleniumGridUrl => ConfigurationManager.AppSettings["SeleniumGridUrl"];

        /// <summary>
        /// Create and returns the WebDriver / Remote WebDriver instance based on the executionType parameter
        /// </summary>
        /// <param name="browserType">Browser key value which is specified in App.config file</param>
        /// <param name="executionType">When passed with value "local", will execute in your local machine, else will execute in a Selenium Grid</param>
        /// <returns>IWebDriver instance</returns>

        // public IPlaywright GetDriver(string executionType, string browserType)

   
        

        /// <inheritdoc/>
        /// public Task InitializeAsync() => LaunchBrowserAsync();

        /// <inheritdoc/>
        // public Task DisposeAsync() => ShutDownAsync();

        //public static async Task LaunchBrowserAsync()
        //{
        //    try
        //    {
        //        Playwright = await PlaywrightSharp.Playwright.CreateAsync(TestConstants.LoggerFactory, debug: "pw*");
        //        Browser = await Playwright[TestConstants.Product].LaunchAsync(TestConstants.GetDefaultBrowserOptions());
        //        var page = await Browser.NewPageAsync();
        //        await page.GoToAsync(TestConstants.ServerUrl);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        throw new Exception("Launch failed", ex);
        //    }
        //}



        //public async Task<IPage> InitalizePlaywright(Browser browser, LaunchOptions launchOptions)
        //{
        //    // launchOptions.Headless = false;
        //    // launchOptions.ExecutablePath = @"C:\kasi\Backup\UdamyPlaywrightbackup\chromedriver_win32\chromedriver.exe";
        //    await Playwright.InstallAsync();
        //    var playwright = await Playwright.CreateAsync(TestConstants.LoggerFactory, debug: "pw*");

        //    IBrowser pBrowser = null;
        //    if (browser == Browser.Chromium)
        //        pBrowser = await playwright.Chromium.LaunchAsync(launchOptions);
        //    if (browser == Browser.Firefox)
        //        pBrowser = await playwright.Firefox.LaunchAsync(launchOptions);
        //    Page = await pBrowser.NewPageAsync();
        //    // await pBrowser.CloseAsync(); closing browser
        //    return Page;
        //}


        public async Task<IPage> InitalizePlaywright(string browser, LaunchOptions launchOptions)
        {
            // launchOptions.Headless = false;
            // launchOptions.ExecutablePath = @"C:\kasi\Backup\UdamyPlaywrightbackup\chromedriver_win32\chromedriver.exe";
            await Playwright.InstallAsync();
            var playwright = await Playwright.CreateAsync(TestConstants.LoggerFactory, debug: "pw*");

            IBrowser pBrowser = null;
            if (browser == "Chrome")
                pBrowser = await playwright.Chromium.LaunchAsync(launchOptions);
            if (browser == "Firefox")
                pBrowser = await playwright.Firefox.LaunchAsync(launchOptions);
            Page = await pBrowser.NewPageAsync();
            // await pBrowser.CloseAsync(); closing browser
            return Page;
        }
        /// <summary>
        /// Looks up the application setting for the specified key. 
        /// If the setting is not specified the default value is returned.
        /// </summary>
        /// <param name="key">The key of the application setting</param>
        /// <param name="defaultValue">The default value of the application setting</param>
        /// <returns>A string that holds the value of the setting.</returns>
        public string AppSettingOrDefault(string key, string defaultValue)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(appSetting))
                appSetting = defaultValue;
            return appSetting;
        }

        /// <summary>
        /// Looks up the application setting for the specified key. 
        /// </summary>
        /// <param name="key">The key of the application setting</param>
        /// <returns>A string that holds the value of the setting.</returns>
        public string AppSetting(string key)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            return appSetting;
        }

        /// <summary>
        /// Get the locators for the web elements of the application
        /// </summary>
        /// <param name="fileName">The file where the JSON Locator file is located as of now its in the bin directory</param>
        /// <returns></returns>
        public  Dictionary <string, Dictionary<string, string>> GetJsonMultipleLocators(string fileName)
        {
            Dictionary<string, Dictionary<string, string>> locator;
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string JSONLocation = Path.Combine(executableLocation, fileName);
            using (StreamReader reader = new StreamReader(JSONLocation))
            {
                string json = reader.ReadToEnd();
                locator = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
            }
            return locator;
        }
        /// <summary>
        /// Method to Load up the ExcelReader and get the data based on the sheet of an excel
        /// </summary>
        /// <param name="sheetLookup">Name of the sheet to get the data</param>
        /// <returns></returns>
        public ExcelHelper ReadExcel(string sheetLookup)
        {
            ExcelHelper ExcelReader = new ExcelHelper();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string excelLocation = Path.Combine(path, AppSetting("ExcelFileLocation"));
            ExcelReader.LoadFile(excelLocation, sheetLookup);
            return ExcelReader;
        }
        private static int nextRow = 0;
        private static int current;
        public static int Increment()
        {
            return current = (current == 0) ? current = ++nextRow : current++;
        }

    }
}
