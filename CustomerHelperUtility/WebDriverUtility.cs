using NLog.Fluent;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using Keys = OpenQA.Selenium.Keys;

namespace CustomerHelperUtility
{
    public class WebDriverUtility
    {
        private readonly IWebDriver WebDriver;
        private readonly TimeSpan WaitTime = TimeSpan.FromSeconds(90);
        private readonly CustomerRepoServiceCall callService = new CustomerRepoServiceCall();
        private readonly static ThreadLocal<IJavaScriptExecutor> JavaScriptExecutor = new ThreadLocal<IJavaScriptExecutor>();

        public WebDriverUtility(IWebDriver driver)
        {
            this.WebDriver = driver;
        }


        /// <summary>
        /// Will take the Screenshot of the browser and Save it in the specified file path.
        /// <param name="screenshotFilePath">Provide the file path to save the screenshot file</param>
        /// </summary>
        /// <return> N/A </return>
        public void TakeScreenshot(string screenshotFilePath)
        {
            try
            {
                ITakesScreenshot screenshotDriver = WebDriver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Close all WebDriver Instances
        /// </summary>
        /// <return> N/A </return>
        public void CloseDriver()
        {
            
            WebDriver.Quit();
            WebDriver.Dispose();
        }

        /// <summary>
        /// Click on WebElement
        /// </summary>      
        /// <param name="element">IWebElement</param>
        /// <return> N/A </return>
        public void ClickOn(IWebElement element)
        {
            WaitForElement(element);
            element.Click();
        }

        /// <summary>
        /// Enter text into a textbox
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <param name="textToEnter">Text to be entered into text box</param>
        /// <return> N/A </return>
        public void EnterText(IWebElement element, string textToEnter)
        {
            try
            {
                element.Click();
                Thread.Sleep(1000);
                element.Clear();
                element.SendKeys(textToEnter);
            }

            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }
        public void Tabs(IWebElement element)
        {
            try
            {
                element.Click();
                Thread.Sleep(1000);
                element.Clear();
                element.SendKeys(Keys.Tab);
            }

            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Get Text from the WebElement
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> string </return>
        public string GetText(IWebElement element)
        {
            try
            {
                return element.Text.ToString();
            }

            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }


        /// <summary>
        /// Switch to Iframe using Index
        /// <param name="frameIndex">Integer frame index value</param>
        /// </summary>        
        /// <return> N/A </return>
        public void SwitchToIFrameByFrameIndex(int frameIndex)
        {
            try
            {
                WebDriver.SwitchTo().Frame(frameIndex);
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Switch to Iframe using Frame Name
        /// <param name="frameName">String frame name value</param>
        /// </summary>        
        /// <return> N/A </return>
        public void SwitchToIFrameByFrameName(string frameName)
        {
            try
            {
                WebDriver.SwitchTo().Frame(frameName);
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Switch Out of Iframe
        /// </summary>        
        /// <return> N/A </return>
        public void SwitchOutOfIFrame()
        {
            try
            {
                WebDriver.SwitchTo().DefaultContent();
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Returns true if Element is displayed in HTML / DOM
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> Boolean </return>
        public bool IsDisplayed(IWebElement element)
        {
            bool result;

            try
            {
                result = element.Displayed;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }


        /// <summary>
        /// Returns true if Element is Enabled
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> Boolean </return>
        public bool IsEnabled(IWebElement element)
        {
            
            return element.Enabled;
        }


        /// <summary>
        /// Select the Check Box
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> N/A </return>
        public void SelectCheckBox(IWebElement element)
        {
            try
            {
                if (!element.Selected)
                {
                    element.Click();
                }
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// UnSelect the Check Box
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> N/A </return>
        public void UnSelectCheckBox(IWebElement element)
        {
            try
            {
                if (element.Selected)
                {
                    element.Click();
                }
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Get attribute Value
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <param name="attributeName">Attribute name to retrieve like id, name, class etc.,</param>
        /// <return> string </return>
        public string GetAttribute(IWebElement element, string attributeName) //String attributeName
        {
            return element.GetAttribute(attributeName);
        }

        /// <summary>
        /// Get CSS Value
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <param name="propertyName">CSS property name like color, font-size, font-weight etc.,</param>
        /// <return> string </return>
        public string GetCssValue(IWebElement element, string propertyName)
        {
            try
            {
                return element.GetCssValue(propertyName);
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        // System.Drawing.Point
        /// <summary>
        /// Get Location of the Element
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> Point </return>
        public Point GetLocation(IWebElement element)
        {
            try
            {
                return element.Location;
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Returns true if element is selected
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> Boolean </return>
        public bool GetSelected(IWebElement element)
        {
            try
            {
                return element.Selected;
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Get Size of the Element
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> Size </return>
        public Size GetSize(IWebElement element)
        {
            return element.Size;
        }

        /// <summary>
        /// Get HTML tag name
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> string </return>
        public string GetTagName(IWebElement element)
        {
            return element.TagName;
        }


        /// <summary>
        /// Wait until element is visible
        /// </summary>        
        /// <return> N/A </return>
        public void WaitForElementVisible(By by, int timeOutInSeconds)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception)
            {
                Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed.Seconds);
            }
            finally
            {
                stopwatch.Stop();
            }
        }

        /// <summary>
        /// Select Dropdown using text
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <param name="textToSelect">Text to Select</param>
        /// <return> N/A </return>
        public void SelectDropDownByText(IWebElement element, string textToSelect)
        {
            try
            {
                OpenQA.Selenium.Support.UI.SelectElement selectElement = new OpenQA.Selenium.Support.UI.SelectElement(element);
                selectElement.SelectByText(textToSelect);
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Select Dropdown using Index
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <param name="indexToSelect">Index of the element to Select</param>       
        /// <return> N/A </return>
        public void SelectDropDownByIndex(IWebElement element, int indexToSelect)
        {
            try
            {
                OpenQA.Selenium.Support.UI.SelectElement selectElement = new OpenQA.Selenium.Support.UI.SelectElement(element);
                selectElement.SelectByIndex(indexToSelect);
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }

        }

        /// <summary>
        /// Select Dropdown using Value
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <param name="valueToSelect">Value of the element to Select</param>
        /// <return> N/A </return>
        public void SelectDropDownByValue(IWebElement element, string valueToSelect)
        {
            try
            {
                OpenQA.Selenium.Support.UI.SelectElement selectElement = new OpenQA.Selenium.Support.UI.SelectElement(element);
                selectElement.SelectByValue(valueToSelect);
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Get all Options displayed in the DropDown
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> List of IWebElement </return>
        public List<string> GetAllOptionsInDropDown(IWebElement element)
        {
            try
            {
                OpenQA.Selenium.Support.UI.SelectElement selectElement = new OpenQA.Selenium.Support.UI.SelectElement(element);
                return selectElement.Options.Select(x => x.Text).ToList();
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Get Selected Value from the DropDown
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> string </return>
        public string GetSelectedValueFromDropDown(IWebElement element)
        {
            try
            {
                return new OpenQA.Selenium.Support.UI.SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }


        /// <summary>
        /// Maximizes the browser.
        /// </summary>        
        public void Maximize()
        {
            try
            {
                WebDriver.Manage().Window.Maximize();
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Bring Browser to focus.
        /// </summary>        
        public void BrowserFocus()
        {
            try
            {
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("window.focus();");
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Opens a New Tab in the browser with specified URL
        /// </summary>
        /// <param name="url">URL to navigate</param>
        /// <return> N/A </return>
        public void OpenBrowserInNewTab(string url)
        {
            try
            {
                WebDriver.FindElement(By.CssSelector("body")).SendKeys(OpenQA.Selenium.Keys.Control + "t");
                WebDriver.Navigate().GoToUrl(url);
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Switch to Tab using Index
        /// </summary>
        /// <param name="tabIndex">Tab Index</param>
        /// <return> N/A </return>
        public void SwitchToTab(int tabIndex)
        {
            try
            {
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles[tabIndex]);
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }


        /// <summary>
        /// Deletes Browser Cookies
        /// </summary>        
        /// <return> N/A </return>
        public void DeleteBrowserCookies()
        {
            try
            {  
                WebDriver.Manage().Cookies.DeleteAllCookies();
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Implicit Wait for the driver
        /// </summary>
        /// <param name="timeInSeconds">Time in Seconds</param>
        /// <return> N/A </return>
        public void TurnOnWait(int timeInSeconds)
        {
            try
            {
                WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeInSeconds);
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Sets the amount of time to wait for a page load to complete before throwing an error. 
        /// </summary>
        /// <param name="timeInSeconds">Time in Seconds</param>
        /// <return> N/A </return>
        public void SetPageLoadTimeOut(int timeInSeconds)
        {
            try
            {
                WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeInSeconds);
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Sets the amount of time to wait for an asynchronous script to finish execution before throwing an error
        /// </summary>
        /// <param name="timeInSeconds">Time in Seconds</param>
        /// <return> N/A </return>
        public void SetScriptTimeOut(int timeInSeconds)
        {
            try
            {
                WebDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(timeInSeconds);
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Navigate to Specified URL
        /// </summary>
        /// <param name="url">URL to Navigate</param>
        /// <return> N/A </return>
        public void Navigate(string url)
        {
            try
            {
                WebDriver.Navigate().GoToUrl(url);
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Get current page URL
        /// </summary>
        /// <return> string </return>
        public string GetCurrentURL()
        {
            try
            {
                return WebDriver.Url;
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Get Text from the Alert Box
        /// </summary>        
        /// <return> string - Text from the AlertBox </return>
        public string AlertText()
        {
            try
            {
                return WebDriver.SwitchTo().Alert().Text;
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Accept the Alert Box
        /// </summary>        
        /// <return> N/A </return>
        public void AcceptAlert()
        {
            try
            {
                WebDriver.SwitchTo().Alert().Accept();
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Dismiss the Alert Box
        /// </summary>        
        /// <return> N/A </return>
        public void DismissAlert()
        {
            try
            {
                WebDriver.SwitchTo().Alert().Dismiss();
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Sets the username and password in the Alert
        /// </summary>        
        /// <return> N/A </return>
        public void SetAuthenticationOnAlert(string username, string password)
        {
            try
            {
                WebDriver.SwitchTo().Alert().SetAuthenticationCredentials(username, password);
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Return True if JavaScript Alert is present on the page otherwise false
        /// </summary>        
        /// <return> Boolean </return>
        public bool IsAlertPresent()
        {
            try
            {
                WebDriver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }

        /// <summary>
        /// Clear the text in TextBox
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> N/A </return>
        public void Clear(IWebElement element)
        {
            element.Clear();
        }

        /// <summary>
        /// Clear the text in text box and will enter new text 
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <param name="textToEnter">Text to ne modified and entered into text box</param>
        /// <return> N/A </return>
        public void ModifyText(IWebElement element, string textToEnter)
        {
            element.Clear();
            Thread.Sleep(1000);
            EnterText(element, textToEnter);
        }


        static readonly Dictionary<dynamic, dynamic> BrowserWindows = new Dictionary<dynamic, dynamic>();

        /// <summary>
        /// Switch to another browser window 
        /// </summary>        
        /// <return> N/A </return>
        public void SwitchToNewBrowserWindow()
        {
            dynamic currentWindow = WebDriver.CurrentWindowHandle;

            if (!BrowserWindows.ContainsKey(currentWindow)) BrowserWindows.Add(currentWindow, null);

            foreach (dynamic eachWindow in WebDriver.WindowHandles)
                if (!BrowserWindows.ContainsKey(eachWindow))
                {
                    BrowserWindows.Add(eachWindow, currentWindow);
                    WebDriver.SwitchTo().Window(eachWindow);
                    BrowserWindows.Clear();
                }
        }

        /// <summary>
        /// WebDriverWaitUsingPolling
        /// </summary>
        /// <param name="element"></param>
        /// <param name="attributeName"></param>
        /// <param name="value"></param>
        public void WebDriverWaitUsingPolling(IWebElement element, string attributeName, string value, int timeOutInMin = 2, int timeIntervalInMilliSec = 250)
        {
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element)
            {
                Timeout = TimeSpan.FromMinutes(timeOutInMin),
                PollingInterval = TimeSpan.FromMilliseconds(timeIntervalInMilliSec)
            };
            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement ele) =>
            {
                string attrib = element.GetAttribute(attributeName);
                if (attrib.Contains(value))
                {
                    return true;
                }
                return false;
            });
            wait.Until(waiter);
        }


        /// <summary>
        /// Get WebDriver instance
        /// </summary>        
        /// <return> IWebdriver instance </return>
        public IWebDriver GetDriver()
        {
            return WebDriver;
        }

        /// <summary>
        /// Returns whether element is clickable or not
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <param name="waitTime">TimeSpan to wait. Default wait time is 90 seconds</param>
        /// <return> bool </return>
        public bool IsElementClickable(IWebElement element, TimeSpan? waitTime = null)
        {
            try
            {
                if (waitTime == null)
                {
                    waitTime = WaitTime;
                }
                var wait = new WebDriverWait(WebDriver, waitTime.Value);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));            
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
            return true;
        }

        /// <summary>
        /// Wait for the element to be enabled
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> bool </return>
        public bool WaitForElement(IWebElement element)
        {
            try
            {
                var wait = new WebDriverWait(WebDriver, WaitTime);
                return wait.Until(d => element.Enabled);
            }
            catch (Exception)
            {
                return false;
            }
        }

        //================================
        public void WaitForTextToBePresentInElementValue(By by, string text, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(by, text));
        }

        public void WaitForTextToBePresentInElementValue(IWebElement element, string text, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(element, text));
        }

        public void WaitUntilClickable(IWebElement element, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public void WaitUntilVisible(By by, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(by));

        }

        public void WaitForSelectionStateToBe(By by, bool selected, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementSelectionStateToBe(by, selected));
        }

        public void WaitUntilInvisible(By by, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        public void WaitForText(IWebElement element, string text, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }

        public IWebElement FindElement(By by)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(60));
            IWebElement ele = wait.Until(ExpectedConditions.ElementIsVisible(by));
            return ele;
        }

        /// <summary>
        /// Find Webelement through using by the key-value of the Dictionary class
        /// </summary>
        /// <param name="locator">Dictionary value from the Locator JSON files</param>
        /// <returns></returns>
        public IWebElement FindElement(Dictionary<string, string> locator)
        {
            IWebElement element = null;
            element = element ?? FindElementFactory.FindElement<FindElementByXpath>(WebDriver).GetElement(locator["xpath"]);
            element = element ?? FindElementFactory.FindElement<FindElementById>(WebDriver).GetElement(locator["id"]);

            return element;
        }

        private readonly Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Counts the number of the webelement is present
        /// </summary>
        /// <param name="by">Webelement that passed</param>
        /// <returns></returns>
        public int CountElements(By by)
        {
            return WebDriver.FindElements(by).Count;
        }

        /// <summary>
        /// Set the Webelement as a List if there are more that one of the same element
        /// Using by the key-value pair of the Dictionary class
        /// </summary>
        /// <param name="locator">Dictionary value from the Locator JSON files</param>
        /// <returns></returns>
        public ICollection<IWebElement> FindElements(Dictionary<string, string> locator)
        {
            try
            {
                IList<IWebElement> element = null;
                element = element ?? FindElementFactory.FindElement<FindElementByXpath>(WebDriver).GetElements(locator["xpath"]);
                element = element ?? FindElementFactory.FindElement<FindElementById>(WebDriver).GetElements(locator["id"]);
                return element;
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }

        }
        /// <summary>
        /// Simulate mouse right click in browser
        /// </summary>
        /// <param name="ele">Webelement</param>
        public void RightClick(IWebElement ele)
        {
            Actions actions = new Actions(WebDriver);
            actions.ContextClick(ele).Perform();
        }

        /// <summary>
        /// Click an element that using a JavaScript arguments[0] click
        /// </summary>
        /// <param name="ele">Webelement that is used</param>
        public void ClickUsingJavaScript(IWebElement ele)
        {
            IJavaScriptExecutor exe = (IJavaScriptExecutor)WebDriver;
            exe.ExecuteScript("arguments[0].click();", ele);
        }

        /// <summary>
        /// Scroll to the desired webelement within the page
        /// </summary>
        /// <param name="ele">WebElement</param>
        public void Scrollintoview(IWebElement ele)
        {
            IJavaScriptExecutor exe = (IJavaScriptExecutor)WebDriver;
            exe.ExecuteScript("arguments[0].scrollIntoView(true);", ele);
        }
        public void ScrollDownPage()
        {
            Actions actns = new Actions(WebDriver);
            actns.SendKeys(Keys.PageDown).Perform();
        }
        

        /// <summary>
        /// Input the path of in the file select window and hits enter once the file path is typed in the text box
        /// </summary>
        /// <param name="fileName">The Name of the file which will be combine with the directory path</param>    
        public void UploadPhoto(string fileName)
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string imageLocation = Path.Combine(executableLocation, fileName);
            Thread.Sleep(2000);
            SendKeys.SendWait("%n");
            SendKeys.SendWait(imageLocation);
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Refresh the current page 
        /// </summary>
        public void RefreshPage()
        {
            try
            {
                WebDriver.Navigate().Refresh();
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }
        /// <summary>
        /// Simulate mouse action by clicking outside of the webelement by using the x and y coordinates
        /// </summary>
        /// <param name="ele">Webelement that will be click outside of</param>
        public void ClickOutsideModalWindow(IWebElement ele)
        {
            Actions builder = new Actions(WebDriver);
            //ele.Click();
            builder.MoveToElement(ele, 530, 150).Click().Build().Perform();
            Thread.Sleep(2000);
            builder.Click();
            Thread.Sleep(2000);
        }
        public void MoveToElement(IWebElement ele)
        {
            Actions builder = new Actions(WebDriver);
            //ele.Click();
            builder.MoveToElement(ele).Perform();
            
        }
        /// <summary>
        /// Service Call to change the customer provision status to pending
        /// </summary>
        /// <param name="customerID">To identify which customer to change</param>
        public void ProvisionStatusToPending(string customerID)
        {
            callService.RunAsync(customerID, "Pending").Wait();
        }

        /// <summary>
        /// Service Call to change the customer provision status to In Progress
        /// </summary>
        /// <param name="customerID">To identify which customer to change</param>
        public void ProvisionStatusToInProgress(string customerID)
        {
            callService.RunAsync(customerID, "InProcess").Wait();
        }

        /// <summary>
        /// Service Call to change the customer provision status to Failed
        /// </summary>
        /// <param name="customerID">To identify which customer to change</param>
        public void ProvisionStatusToFailed(string customerID)
        {
            callService.RunAsync(customerID, "Failed").Wait();
        }

        /// <summary>
        /// Service Call to change the customer provision status to Completed
        /// </summary>
        /// <param name="customerID">To identify which customer to change</param>
        public void ProvisionStatusToCompleted(string customerID)
        {
            callService.RunAsync(customerID, "Completed").Wait();
        }

        /// <summary>
        /// Service call to delete the customer
        /// </summary>
        /// <param name="customerID">To identify which customer to delete</param>
        public void DeleteCustomerCall(string customerID)
        {
            callService.RunAsync(customerID, "DeleteCustomer").Wait();
        }

        /// <summary>
        /// Returns the value of the Javascript excuted
        /// </summary>
        protected IJavaScriptExecutor JsExecutor
        {
            get
            {
                return JavaScriptExecutor.Value;
            }
        }

        /// <summary>
        /// Check the request call the UI is making to the backend services
        /// </summary>
        public void CheckPendingRequests()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    var numberOfAjaxConnections = JsExecutor.ExecuteScript("return window.openHTTPs");
                    if (numberOfAjaxConnections is long n)
                    {
                        Console.WriteLine("Number of active calls In Page: " + n);
                        if (n == 0L) break;
                    }
                    else
                    {
                        InjectXMLHttpRequestScript();
                        Console.WriteLine("Injecting Script");
                    }
                    Wait(1000);
                }


            }
            catch (Exception ex)
            {
                Log.Error("Error while loading page.");
                Log.Error(ex.Message);
            }
            finally
            {
                Log.Debug("Page loaded in " + stopwatch.Elapsed.Seconds + " seconds");
                stopwatch.Stop();
            }
        }

        private void InjectXMLHttpRequestScript()
        {
            try
            {
                var numberOfAjaxConnections = JsExecutor.ExecuteScript("return window.openHTTPs");
                string script = "  (function() {" +
                    "var oldOpen = XMLHttpRequest.prototype.open;" +
                    "window.openHTTPs = 0;" +
                    "XMLHttpRequest.prototype.open = function(method, url, async, user, pass) {" +
                    "window.openHTTPs++;" +
                    "this.addEventListener('readystatechange', function() {" +
                    "if(this.readyState == 4) {" +
                    "window.openHTTPs--;" +
                    "}" +
                    "}, false);" +
                    "oldOpen.call(this, method, url, async, user, pass);" +
                    "}" +
                    "})();";
                JsExecutor.ExecuteScript(script);
            }
            catch (Exception e)
            {
                throw new ConduentUIAutomationException(e.Message);
            }
        }

        /// <summary>
        /// Used to pause the execution for defined time
        /// </summary>
        /// <param name="milliSeconds">Time is defined in milliseconds</param>
        public void Wait(int milliSeconds = 5000)
        {
            Thread.Sleep(milliSeconds);
        }


        public void WaitWhilePageIsLoading(int milliSecondsToWait = 1500)
        {
            if (milliSecondsToWait != 1500)
            {
                _ = Constants.ClientCallTimeOut;
            }
            CheckPendingRequests();
            Wait(Constants.ClientCallTimeOut);
            CheckPendingRequests();
        }

        public void ClickOnPointFromElement(IWebElement element, String position, int length)
        {
            Actions a = new Actions(WebDriver);
            Point point = element.Location;


            int eleWidth = element.Size.Width;
            int eleHeight = element.Size.Height;


            if (position.Equals("left"))
            {
                a.MoveToElement(element, 0-length, (eleHeight / 2)).Perform();
            }
            else if (position.Equals("right"))
            {
                a.MoveToElement(element, eleWidth+length, (eleHeight / 2)).Perform();
            }
            else if (position.Equals("bottom"))
            {
                a.MoveToElement(element, (eleWidth / 2), eleHeight+length).Perform();
            }



            a.Click().Perform();

        }

    }
}

