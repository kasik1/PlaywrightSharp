using PlaywrightSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerHelperUtility
{
    public class PlaywrightUtility
    {
        public IPage Page { get; set; }
        //private readonly Playwright playwright1
        private readonly IPage page;
        //private readonly IPage page;
        private readonly IBrowser browser;
         //public IPage page { get; set; }
       // public BrowserType br{ get;set;};

    // private readonly Playwright pt1;
    public Frame MainFrame { get; }
        // private readonly FrameChannel _channel;

        public PlaywrightUtility(IPage Page)
        {
            this.page = Page;
             //this.browser = plBrowser;
        }


        public async Task Navigate(string url)
        {

            await page.GoToAsync(url);
            await page.WaitForNavigationAsync();
        }

        public async Task DeleteBrowserCookies(string url)

        {

        }
        public async Task TakeScreenshot(string screenshotFilePath)
        {

            await page.ScreenshotAsync(screenshotFilePath);
        }
        
    public async Task CloseDriver(IBrowser browser)
        {
            // var chromeOptions = playwright.Chromium.;

            await browser.CloseAsync();
        }

        public async Task<BrowserType> NewContextAsync(Playwright pl)
        {
            var chrome = pl.Chromium;
            return (BrowserType)(IBrowserContext)chrome;


        }

        public async Task<string> Browsetype()
        {
            //var chrome = pl.Chromium;
            //return (BrowserType)(IBrowserContext)chrome;

            return BrowserType.Chromium.ToString();
        }

        public async Task WaitForTimeout(int timeout)
        {
            await page.WaitForTimeoutAsync(timeout);
        }
        public async Task FindElement(Dictionary<string, string> locator)
        {
            await page.WaitForSelectorAsync(locator.ToString());

        }

    
         

        public  async Task EnterText(string locator, string textToEnter)
        {
           // await page.ClickAsync(locator);

            await page.FillAsync(locator, textToEnter);
        }
        public async Task ClickOn(string locator)
        {
            await page.WaitForSelectorAsync(locator);
            await page.WaitForTimeoutAsync(20000);
            await page.ClickAsync(locator);
        }

        public int DefaultNavigationTimeout(int timeout)
        {
            page.DefaultNavigationTimeout = timeout;
            return page.DefaultTimeout;
        }

        public int DefaultTimeout(int timeout)
        {
            page.DefaultTimeout = timeout;
            return page.DefaultTimeout;
        }

        }

        //Dictionary<string, string> locator

    }

