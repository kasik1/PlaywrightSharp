using CustomerUIAutomation.Utilities;
using PlaywrightSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerUIAutomation.PageObjects
{
    public class LoginPagePWPOM : TestBasePw
    {
        private readonly IPage page;
        private readonly IBrowser browser;
        Context Context;
        public LoginPagePWPOM(IPage pageP)
            : base(pageP, "LocatorsJsonFiles\\LoginPageLocators.json", "LoginPageTestData")
        {
            // Context = context;
            this.page = pageP;
            //this.browser = plBrowser;

        }
        string HamburgerMenu = "//div[@class='menu-btn__burger']";
        string Homemenu = "//body[@class='card-no-border']";
        string ProductionControl = "//span[contains(text(),'Production Control')]";
        string avatar = "//span[@class='user-avatar']";
        string logout = "//span[contains(text(),'Logout')]";

        public string SignInInputEmail => PlaywrightUtility.FindElement(MultipleLocators["signInInputEmail"]).ToString();
        public string SignInPassword => PlaywrightUtility.FindElement(MultipleLocators["signInPassword"]).ToString();
        public string SignInButton => PlaywrightUtility.FindElement(MultipleLocators["signInButton"]).ToString();
        public string SelectNo => PlaywrightUtility.FindElement(MultipleLocators["selectNo"]).ToString();

        public string LoginButton => PlaywrightUtility.FindElement(MultipleLocators["LoginButton"]).ToString();

        public async Task EnterLoginDetails(string testStep)
        {
        await PlaywrightUtility.EnterText(SignInInputEmail, Excel.GetValueFromTestStep(testStep, "Email"));
            //PlaywrightUtility.DefaultTimeout(2000);
            // PlaywrightUtility.ClickOn(LoginButton);
           await  PlaywrightUtility.EnterText(SignInPassword, Excel.GetValueFromTestStep(testStep, "Password"));
          await PlaywrightUtility.ClickOn(LoginButton);
            await ShouldDisableTimeoutWhenItsSetTo0();
           
        }

       


        public async Task ClickProductionControl(string testStep)
        {
            await page.WaitForSelectorAsync(HamburgerMenu);
            await page.ClickAsync(HamburgerMenu);
            await page.ClickAsync(ProductionControl);
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
        [Fact(Timeout = TestConstants.DefaultTestTimeout)]
        public async Task ShouldDisableTimeoutWhenItsSetTo()
        {
            bool loaded = false;
            void OnLoad(object sender, EventArgs e)
            {
                loaded = true;
                page.Load -= OnLoad;
            }
            page.Load += OnLoad;

            await page.GoToAsync(TestConstants.ServerUrl, LifecycleEvent.Load, null, 0);
            Assert.True(loaded);
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



        public async Task ClickLogout()
        {
           // await ShouldBeAbleToSaveFile();
            //await ShouldWork();
            await page.ClickAsync(avatar);
            await page.ClickAsync(logout);
            //await page.CloseAsync();
           await ShouldDisableTimeoutWhenItsSetTo0();



        }

        [PlaywrightTest("page-screenshot.spec.js", "should work")]
        [Fact(Timeout = TestConstants.DefaultTestTimeout)]
        public async Task ShouldWork()
        {
            await page.SetViewportSizeAsync(new ViewportSize
            {
                Width = 500,
                Height = 500
            });
            // await Page.GoToAsync(TestConstants.ServerUrl + "/grid.html");
            byte[] screenshot = await page.ScreenshotAsync();
            Assert.True(ScreenshotHelper.PixelMatch("screenshot-sanity.png", screenshot));
        }

            [SkipBrowserAndPlatformFact(skipFirefox: true, skipWebkit: true)]
            public async Task ShouldBeAbleToSaveFile()
            {
                string outputFile = Path.Combine(BaseDirectory, "output.pdf");
                var fileInfo = new FileInfo(outputFile);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
                await page.GetPdfAsync(outputFile, format: PaperFormat.Letter);
                fileInfo = new FileInfo(outputFile);
                Assert.True(new FileInfo(outputFile).Length > 0);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
            }


        }

    }



