using CustomerUIAutomation.Utilities;
using PlaywrightSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerUIAutomation.PageObjects
{
     public class LoginPagePWPOM  : TestBasePw
    {
        private readonly IPage page;
        private readonly IBrowser browser;
        Context Context;
        public LoginPagePWPOM(IPage pageP)
            : base(pageP,"LocatorsJsonFiles\\LoginPageLocators.json", "LoginPageTestData")
        {
           // Context = context;
            this.page = pageP;
            //this.browser = plBrowser;
            
        }

        public string SignInInputEmail => PlaywrightUtility.FindElement(MultipleLocators["signInInputEmail"]).ToString();
        public string SignInInputEmails => PlaywrightUtility.FindElement(MultipleLocators["signInInputEmail"]).ToString();
        public string SignInPassword => PlaywrightUtility.FindElement(MultipleLocators["signInPassword"]).ToString();
        public string SignInButton => PlaywrightUtility.FindElement(MultipleLocators["signInButton"]).ToString();
        public string SelectNo => PlaywrightUtility.FindElement(MultipleLocators["selectNo"]).ToString();

        public string LoginButton => PlaywrightUtility.FindElement(MultipleLocators["LoginButton"]).ToString();

        public  async Task NavigateToUrl(string url)
        {

             var playwright = await Playwright.CreateAsync();
            string[] str = { "chromium", "firefox", "webkit" };
            // var chromium = playwright.Chromium;
            var browser = await playwright[str[1]].LaunchAsync(new LaunchOptions { Headless = false });
            var page = await browser.NewPageAsync();
            await page.GoToAsync("https://customer-ui-hub-dummy-plt-qa.conduent-cap.com/");
            // WebDriverUtility.DeleteBrowserCookies();
            // const browser = await Playwright.launch({ headless: false });
           // PlaywrightUtility.Navigate(url);
        }
        string btnSubmit => " //button[@name='submit']";
        public async Task EnterLoginDetails(string testStep)
        {
            PlaywrightUtility.EnterText(SignInInputEmail, Excel.GetValueFromTestStep(testStep, "Email"));
            //PlaywrightUtility.DefaultTimeout(2000);
           // PlaywrightUtility.ClickOn(LoginButton);
            PlaywrightUtility.EnterText(SignInPassword, Excel.GetValueFromTestStep(testStep, "Password"));
            ClickLogin();

            //PlaywrightUtility.ClickOn(LoginButton);
            //PlaywrightUtility.ClickOn(SelectNo);

            //await Page.FillAsync(SignInInputEmail, Excel.GetValueFromTestStep(testStep, "Email").ToString());
            //  await Page.FillAsync(txtPassword, password);
        }

        string txtUserName = "//input[@type='email']";
        string txtPassword ="//input[@type ='password']";
     string  kk = "//div[@class='menu-btn__burger";


        string pr = "//span[contains(text(),'Production Control')]";
        string Home = "//body[@class='card-no-border']";



        public async Task Login(string testStep)
        {
           

            await page.FillAsync(txtUserName, Excel.GetValueFromTestStep(testStep, "Email"));
            await page.FillAsync(txtPassword, Excel.GetValueFromTestStep(testStep, "Password"));
            await page.ClickAsync(btnSubmit);
           await ShouldDisableTimeoutWhenItsSetTo0();
           await page.WaitForSelectorAsync(Home);
           //.. await page.ClickAsync(kk);
          //  await page.WaitForSelectorAsync(Home);
           // await page.ClickAsync(pr);
           // await page.ClickAsync(pr);




        }
        [Fact(Timeout = TestConstants.DefaultTestTimeout)]
        public async Task ShouldDisableTimeoutWhenItsSetTo0()
        {
            var watchdog = page.WaitForFunctionAsync(
                @"() => {
                    window.__counter = (window.__counter || 0) + 1;
                    return window.__injected;
                }",
                polling: 10,
                timeout: 0);
            await page.WaitForFunctionAsync("() => window.__counter > 10");
            await page.EvaluateAsync("window.__injected = true");
            await watchdog;
                }

        //public async Task ShouldDisableTimeoutWhenItsSetTo0()
        //{
        //    bool loaded = false;
        //    void OnLoad(object sender, EventArgs e)
        //    {
        //        loaded = true;
        //        page.Load -= OnLoad;
        //    }
        //    page.Load += OnLoad;

            //    await page.WaitForTimeoutAsync = 0;
            //    Assert.True(loaded);
            //}



            public async Task ClickLogin() => await page.ClickAsync(btnSubmit);

    }

    }

