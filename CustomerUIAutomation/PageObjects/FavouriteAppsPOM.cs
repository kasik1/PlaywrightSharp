using CustomerUIAutomation.Utilities;
using CustomerHelperUtility;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace CustomerUIAutomation.PageObjects
{
    class FavouriteAppsPOM : TestBase
    {

        private readonly IWebDriver _WebDriver;
        public FavouriteAppsPOM(IWebDriver driver)
            : base(driver, "LocatorsJsonFiles\\FavoriteAppLocators.json", "FavoriteAppTestData")
        {
            this._WebDriver = driver;
            WebDriverUtility.TurnOnWait(60);
        }
        public IWebElement Homepage => WebDriverUtility.FindElement(MultipleLocators["Homepage"]);
        public IWebElement FavouriteAppsLink => WebDriverUtility.FindElement(MultipleLocators["FavouriteAppsLink"]);
        public IWebElement ViewAllApps => WebDriverUtility.FindElement(MultipleLocators["ViewAllApps"]);
        public IWebElement AppCount => WebDriverUtility.FindElement(MultipleLocators["AppCount"]);
        public IWebElement ClickLaunchCopyAttach => WebDriverUtility.FindElement(MultipleLocators["ClickLaunchCopyAttach"]);
        
        public IWebElement AllCardsView => WebDriverUtility.FindElement(MultipleLocators["AllCardsView"]);
        public IWebElement CreateStackFavoriteInViewAllDashboard => WebDriverUtility.FindElement(MultipleLocators["CreateStackFavoriteInViewAllDashboard"]);
        public IWebElement CashReportFavoriteInViewAllDashboard => WebDriverUtility.FindElement(MultipleLocators["CashReportFavoriteInViewAllDashboard"]);
        public IWebElement CopyAttachDataFavoriteInViewAllDashboard => WebDriverUtility.FindElement(MultipleLocators["CopyAttachDataFavoriteInViewAllDashboard"]);
        public IWebElement CreateActionFavoriteInViewAllDashboard => WebDriverUtility.FindElement(MultipleLocators["CreateActionFavoriteInViewAllDashboard"]);
        public IWebElement FaxWatcherFavoriteInViewAllDashboard => WebDriverUtility.FindElement(MultipleLocators["FaxWatcherFavoriteInViewAllDashboard"]);
        public IWebElement FTPIntakeFavoriteInViewAllDashboard => WebDriverUtility.FindElement(MultipleLocators["FTPIntakeFavoriteInViewAllDashboard"]);
        public IWebElement AllAppsDsiplayed => WebDriverUtility.FindElement(MultipleLocators["AllAppsDsiplayed"]);
        public IWebElement AppToolTip => WebDriverUtility.FindElement(MultipleLocators["AppToolTip"]);
        public IWebElement ToolTipValidation => WebDriverUtility.FindElement(MultipleLocators["ToolTipValidation"]);
        public IWebElement AttchDataAppName => WebDriverUtility.FindElement(MultipleLocators["AttchDataAppName"]);
        public IWebElement AttchDataAppDescp => WebDriverUtility.FindElement(MultipleLocators["AttchDataAppDescp"]);
        public IWebElement DasboardIcon => WebDriverUtility.FindElement(MultipleLocators["DasboardIcon"]);
        public IWebElement FavouritedAppsDashBoard => WebDriverUtility.FindElement(MultipleLocators["FavouritedAppsDashBoard"]);
        public IWebElement CopyAttchDatathreedotinwrapper => WebDriverUtility.FindElement(MultipleLocators["CopyAttchDatathreedotinwrapper"]);

        public IWebElement CreateActionthreedotinwrapper => WebDriverUtility.FindElement(MultipleLocators["CreateActionthreedotinwrapper"]);
        public IWebElement CreateStackthreedotinwrapper => WebDriverUtility.FindElement(MultipleLocators["CreateStackthreedotinwrapper"]);
        public IWebElement FaxWatcherthreedotinwrapper => WebDriverUtility.FindElement(MultipleLocators["FaxWatcherthreedotinwrapper"]);
        public IWebElement FTPIntakethreedotinwrapper => WebDriverUtility.FindElement(MultipleLocators["FTPIntakethreedotinwrapper"]);
        public IWebElement RemoveFavourite => WebDriverUtility.FindElement(MultipleLocators["RemoveFavourite"]);

        public IWebElement Removedappsvalidation => WebDriverUtility.FindElement(MultipleLocators["Removedappsvalidation"]);

        public IWebElement ErrorMessageForMorethanFiveApps => WebDriverUtility.FindElement(MultipleLocators["ErrorMessageForMorethanFiveApps"]);

        public IWebElement CashReportAddFavThroughThreeDotOption => WebDriverUtility.FindElement(MultipleLocators["CashReportAddFavThroughThreeDotOption"]);

        public IWebElement CreateStackAddFavThroughThreeDotOption => WebDriverUtility.FindElement(MultipleLocators["CreateStackAddFavThroughThreeDotOption"]);
        public IWebElement CopyAttachAddFavThroughThreeDotOption => WebDriverUtility.FindElement(MultipleLocators["CopyAttachAddFavThroughThreeDotOption"]);
        public IWebElement CreateActionAddFavThroughThreeDotOption => WebDriverUtility.FindElement(MultipleLocators["CreateActionAddFavThroughThreeDotOption"]);
        public IWebElement FaxWatcherAddFavThroughThreeDotOption => WebDriverUtility.FindElement(MultipleLocators["FaxWatcherAddFavThroughThreeDotOption"]);
        public IWebElement FTPIntakeAddFavThroughThreeDotOption => WebDriverUtility.FindElement(MultipleLocators["FTPIntakeAddFavThroughThreeDotOption"]);
        public IWebElement CashReportAddFavTab => WebDriverUtility.FindElement(MultipleLocators["CashReportAddFavTab"]);
        public IWebElement CreateStackAddFavTab => WebDriverUtility.FindElement(MultipleLocators["CreateStackAddFavTab"]);
        public IWebElement CopyAttachAddFavTab => WebDriverUtility.FindElement(MultipleLocators["CopyAttachAddFavTab"]);
        public IWebElement CreateActionAddFavTab => WebDriverUtility.FindElement(MultipleLocators["CreateActionAddFavTab"]);
        public IWebElement FaxWatcherAddFavTab => WebDriverUtility.FindElement(MultipleLocators["FaxWatcherAddFavTab"]);
        public IWebElement FTPIntakeAddFavTab => WebDriverUtility.FindElement(MultipleLocators["FTPIntakeAddFavTab"]);
        public IWebElement ValidateCopyAttachFavAppsFromFavTab => WebDriverUtility.FindElement(MultipleLocators["ValidateCopyAttachFavAppsFromFavTab"]);
        public IWebElement ValidateCreteActionFavAppFromFavTab => WebDriverUtility.FindElement(MultipleLocators["ValidateCreteActionFavAppFromFavTab"]);
        public IWebElement ValidateCreateStackFavAppFromFavTab => WebDriverUtility.FindElement(MultipleLocators["ValidateCreateStackFavAppFromFavTab"]);
        public IWebElement ValidateFaxWatcherFavAppFromFavTab => WebDriverUtility.FindElement(MultipleLocators["ValidateFaxWatcherFavAppFromFavTab"]);
        public IWebElement ValidateFtpIntake => WebDriverUtility.FindElement(MultipleLocators["ValidateFtpIntake"]);
        public IWebElement ValidateViewAllApps => WebDriverUtility.FindElement(MultipleLocators["ValidateViewAllApps"]);
        public IWebElement ValidateCopyAttachFavAppsFromAppDashboard => WebDriverUtility.FindElement(MultipleLocators["ValidateCopyAttachFavAppsFromAppDashboard"]);
        public IWebElement ValidateCreteActionFavAppFromAppDashboard => WebDriverUtility.FindElement(MultipleLocators["ValidateCreteActionFavAppFromAppDashboard"]);
        public IWebElement ValidateCreateStackFavAppFromAppDashboard => WebDriverUtility.FindElement(MultipleLocators["ValidateCreateStackFavAppFromAppDashboard"]);
        public IWebElement ValidateFtpIntakeFromAppDashboard => WebDriverUtility.FindElement(MultipleLocators["ValidateFtpIntakeFromAppDashboard"]);
        public IWebElement ValidateFaxWatcherFavAppFromAppDashboard => WebDriverUtility.FindElement(MultipleLocators["ValidateFaxWatcherFavAppFromAppDashboard"]);
        public IWebElement ValidateViewAllAppsFromFavTab => WebDriverUtility.FindElement(MultipleLocators["ValidateViewAllAppsFromFavTab"]);

        public IWebElement FTPIntakeRemoveFavAppsoption => WebDriverUtility.FindElement(MultipleLocators["FTPIntakeRemoveFavAppsoption"]);

        public IWebElement CopyAttchDataRemoveFavAppsoption => WebDriverUtility.FindElement(MultipleLocators["CopyAttchDataRemoveFavAppsoption"]);
        public IWebElement CreateActionRemoveFavAppsoption => WebDriverUtility.FindElement(MultipleLocators["CreateActionRemoveFavAppsoption"]);
        public IWebElement FaxWatcherRemoveFavAppsoption => WebDriverUtility.FindElement(MultipleLocators["FaxWatcherRemoveFavAppsoption"]);
        public IWebElement CreateStackRemoveFavAppsoption => WebDriverUtility.FindElement(MultipleLocators["CreateStackRemoveFavAppsoption"]);


        public IList<IWebElement> RemovefavthroughElipsy => WebDriverUtility.FindElements(MultipleLocators["RemovefavthroughElipsy"]).ToList();
        public IList<IWebElement> Elipsy => WebDriverUtility.FindElements(MultipleLocators["Elipsy"]).ToList();
        
        public IList<IWebElement> AddedFavAppsValidation => WebDriverUtility.FindElements(MultipleLocators["AddedFavAppsValidation"]).ToList();

        

        public void HomepageView()
        {
            WebDriverUtility.IsDisplayed(Homepage);
            Thread.Sleep(5000);
        }
        public void FavTab()
        {
            WebDriverUtility.ClickOn(FavouriteAppsLink);
            
        }
        public void ViewAllAppsWithNoFav()
        {
            Thread.Sleep(5000);
            WebDriverUtility.ClickOn(ViewAllApps);
        }
        public void AllAppsDisplayed()
        {
            Thread.Sleep(3000);
            WebDriverUtility.IsDisplayed(AllAppsDsiplayed);
        }
        public void SelectFiveApps(string testStep)
        {
            Thread.Sleep(2000);

            WebDriverUtility.ClickOn(FTPIntakeFavoriteInViewAllDashboard);
            Thread.Sleep(2000);

            WebDriverUtility.ClickOn(CopyAttachDataFavoriteInViewAllDashboard);
            Thread.Sleep(2000);

            WebDriverUtility.ClickOn(CreateActionFavoriteInViewAllDashboard);
            Thread.Sleep(2000);

            WebDriverUtility.ClickOn(FaxWatcherFavoriteInViewAllDashboard);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(CreateStackFavoriteInViewAllDashboard);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(DasboardIcon);
            Thread.Sleep(2000);
            Assert.AreEqual(WebDriverUtility.GetText(ValidateFaxWatcherFavAppFromAppDashboard), Excel.GetValueFromTestStep(testStep, "AppName1"));
            Assert.AreEqual(WebDriverUtility.GetText(ValidateFtpIntakeFromAppDashboard), Excel.GetValueFromTestStep(testStep, "AppName2"));
            Assert.AreEqual(WebDriverUtility.GetText(ValidateCreateStackFavAppFromAppDashboard), Excel.GetValueFromTestStep(testStep, "AppName3"));
            Assert.AreEqual(WebDriverUtility.GetText(ValidateCreteActionFavAppFromAppDashboard), Excel.GetValueFromTestStep(testStep, "AppName4"));
            Assert.AreEqual(WebDriverUtility.GetText(ValidateCopyAttachFavAppsFromAppDashboard), Excel.GetValueFromTestStep(testStep, "AppName5"));
            Assert.IsTrue(WebDriverUtility.IsDisplayed(ValidateViewAllApps), "View All apps displayed");
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(FavouriteAppsLink);

            Assert.AreEqual(WebDriverUtility.GetText(ValidateFaxWatcherFavAppFromFavTab), Excel.GetValueFromTestStep(testStep, "AppName1"));
            Assert.AreEqual(WebDriverUtility.GetText(ValidateFtpIntake), Excel.GetValueFromTestStep(testStep, "AppName2"));
            Assert.AreEqual(WebDriverUtility.GetText(ValidateCreateStackFavAppFromFavTab), Excel.GetValueFromTestStep(testStep, "AppName3"));
            Assert.AreEqual(WebDriverUtility.GetText(ValidateCreteActionFavAppFromFavTab), Excel.GetValueFromTestStep(testStep, "AppName4"));
            Assert.AreEqual(WebDriverUtility.GetText(ValidateCopyAttachFavAppsFromFavTab), Excel.GetValueFromTestStep(testStep, "AppName5"));
            Assert.IsTrue(WebDriverUtility.IsDisplayed(ValidateViewAllAppsFromFavTab), "View All apps displayed");
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(DasboardIcon);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(ValidateViewAllApps);
            Thread.Sleep(5000);

          string FTPSelected=  WebDriverUtility.GetAttribute(FTPIntakeFavoriteInViewAllDashboard, "src");

               if(FTPSelected.Equals("https://core-customer-ui-hub.qa.dummy1.cndt.cf/assets/images/star_fill.svg"))
            {
                Console.WriteLine("FTPSelected");
            }
               string CopyAttachData= WebDriverUtility.GetAttribute(CopyAttachDataFavoriteInViewAllDashboard, "src");
            if (CopyAttachData.Equals("https://core-customer-ui-hub.qa.dummy1.cndt.cf/assets/images/star_fill.svg"))
            {
                Console.WriteLine("CopyAttachData selected");
            }
            string CreateActionFavorite = WebDriverUtility.GetAttribute(CreateActionFavoriteInViewAllDashboard, "src");
            if (CreateActionFavorite.Equals("https://core-customer-ui-hub.qa.dummy1.cndt.cf/assets/images/star_fill.svg"))
            {
                Console.WriteLine("CreateActionFavorite selected");
            }
            string FaxWatcher = WebDriverUtility.GetAttribute(FaxWatcherFavoriteInViewAllDashboard, "src");
            if (FaxWatcher.Equals("https://core-customer-ui-hub.qa.dummy1.cndt.cf/assets/images/star_fill.svg"))
            {
                Console.WriteLine("FaxWatcher selected");
            }
            string CreateStack = WebDriverUtility.GetAttribute(CreateStackFavoriteInViewAllDashboard, "src");
            if (CreateStack.Equals("https://core-customer-ui-hub.qa.dummy1.cndt.cf/assets/images/star_fill.svg"))
            {
                Console.WriteLine("CreateStack selected");
            }

            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(DasboardIcon);



        }
        public void FavouriteAppsDisplayedInAppWrapper()
        {
            Thread.Sleep(2000);
            if (WebDriverUtility.IsDisplayed(FavouritedAppsDashBoard))
            {
                Console.WriteLine("Apps favourited are displayed");
            }
            else
            {
                Console.WriteLine("Apps favourited are displayed");
            }


        }
        public void RemoveAllApps()
        {
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(CopyAttchDatathreedotinwrapper);
            WebDriverUtility.WaitUntilClickable(RemoveFavourite, 30);
            WebDriverUtility.ClickOn(RemoveFavourite);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(CreateActionthreedotinwrapper);
            WebDriverUtility.WaitUntilClickable(RemoveFavourite, 30);
            WebDriverUtility.ClickOn(RemoveFavourite);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(CreateStackthreedotinwrapper);
            WebDriverUtility.WaitUntilClickable(RemoveFavourite, 30);
            WebDriverUtility.ClickOn(RemoveFavourite);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(FaxWatcherthreedotinwrapper);
            WebDriverUtility.WaitUntilClickable(RemoveFavourite, 30);
            WebDriverUtility.ClickOn(RemoveFavourite);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(FTPIntakethreedotinwrapper);
            WebDriverUtility.ClickOn(RemoveFavourite);


        }
        public void ValidateRemovedFavApps()
        {
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(FavouriteAppsLink);

            Assert.IsTrue(WebDriverUtility.IsDisplayed(Removedappsvalidation), "AppsRemovedSucessfully");

        }
        public void FavMorethanFiveApps()
        {
            Thread.Sleep(2000);

            WebDriverUtility.ClickOn(FTPIntakeFavoriteInViewAllDashboard);
            Thread.Sleep(3000);

            WebDriverUtility.ClickOn(CopyAttachDataFavoriteInViewAllDashboard);
            Thread.Sleep(2000);

            WebDriverUtility.ClickOn(CreateActionFavoriteInViewAllDashboard);
            Thread.Sleep(2000);

            WebDriverUtility.ClickOn(FaxWatcherFavoriteInViewAllDashboard);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(CreateStackFavoriteInViewAllDashboard);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(CashReportFavoriteInViewAllDashboard);

            //WebDriverUtility.ClickOn(DasboardIcon);
        }
        public void ErrorMessageforMorethanFiveFavApps()
        {
            Assert.IsTrue(WebDriverUtility.IsDisplayed(ErrorMessageForMorethanFiveApps), "cannot add more than 5 apps");
            WebDriverUtility.ClickOn(DasboardIcon);
        }
        public void favUsingAddFavTaB()
        {
            Thread.Sleep(3000);

            WebDriverUtility.ClickOn(FTPIntakeAddFavThroughThreeDotOption);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(FTPIntakeAddFavTab);
            Thread.Sleep(2000);

            WebDriverUtility.ClickOn(CopyAttachAddFavThroughThreeDotOption);
            Thread.Sleep(1000);
            WebDriverUtility.ClickOn(CopyAttachAddFavTab);
            Thread.Sleep(2000);

            WebDriverUtility.ClickOn(CreateActionAddFavThroughThreeDotOption);
            Thread.Sleep(1000);
            WebDriverUtility.ClickOn(CreateActionAddFavTab);
            Thread.Sleep(2000);

            WebDriverUtility.ClickOn(FaxWatcherAddFavThroughThreeDotOption);
            Thread.Sleep(1000);
            WebDriverUtility.ClickOn(FaxWatcherAddFavTab);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(CreateStackAddFavThroughThreeDotOption);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(CreateStackAddFavTab);
           

        }
        public void NavigateDashBoard()
        {
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(DasboardIcon);
        }
        public void UnFavApps()
        {
            
            Thread.Sleep(2000);

            WebDriverUtility.ClickOn(FTPIntakeFavoriteInViewAllDashboard);
            Thread.Sleep(2000);

            WebDriverUtility.ClickOn(CopyAttachDataFavoriteInViewAllDashboard);
            Thread.Sleep(2000);

            WebDriverUtility.ClickOn(CreateActionFavoriteInViewAllDashboard);
            Thread.Sleep(2000);

            WebDriverUtility.ClickOn(FaxWatcherFavoriteInViewAllDashboard);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(CreateStackFavoriteInViewAllDashboard);
            Thread.Sleep(2000);
            string FTPSelected = WebDriverUtility.GetAttribute(FTPIntakeFavoriteInViewAllDashboard, "src");

            if (FTPSelected.Equals("https://core-customer-ui-hub.qa.dummy1.cndt.cf/assets/images/star_empty.svg"))
            {
                Console.WriteLine("FTPSelected");
            }
            string CopyAttachData = WebDriverUtility.GetAttribute(CopyAttachDataFavoriteInViewAllDashboard, "src");
            if (CopyAttachData.Equals("https://core-customer-ui-hub.qa.dummy1.cndt.cf/assets/images/star_empty.svg"))
            {
                Console.WriteLine("CopyAttachData selected");
            }
            string CreateActionFavorite = WebDriverUtility.GetAttribute(CreateActionFavoriteInViewAllDashboard, "src");
            if (CreateActionFavorite.Equals("https://core-customer-ui-hub.qa.dummy1.cndt.cf/assets/images/star_empty.svg"))
            {
                Console.WriteLine("CreateActionFavorite selected");
            }
            string FaxWatcher = WebDriverUtility.GetAttribute(FaxWatcherFavoriteInViewAllDashboard, "src");
            if (FaxWatcher.Equals("https://core-customer-ui-hub.qa.dummy1.cndt.cf/assets/images/star_empty.svg"))
            {
                Console.WriteLine("FaxWatcher selected");
            }
            string CreateStack = WebDriverUtility.GetAttribute(CreateStackFavoriteInViewAllDashboard, "src");
            if (CreateStack.Equals("https://core-customer-ui-hub.qa.dummy1.cndt.cf/assets/images/star_empty.svg"))
            {
                Console.WriteLine("CreateStack selected");
            }
           
        }
        public void SelectFiveAppsandremovefromoption()
        {
            Thread.Sleep(2000);

            WebDriverUtility.ClickOn(FTPIntakeFavoriteInViewAllDashboard);
            Thread.Sleep(2000);

            WebDriverUtility.ClickOn(CopyAttachDataFavoriteInViewAllDashboard);
            Thread.Sleep(2000);

            WebDriverUtility.ClickOn(CreateActionFavoriteInViewAllDashboard);
            Thread.Sleep(2000);

            WebDriverUtility.ClickOn(FaxWatcherFavoriteInViewAllDashboard);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(CreateStackFavoriteInViewAllDashboard);
         
            Thread.Sleep(5000);

            WebDriverUtility.ClickOn(FTPIntakeAddFavThroughThreeDotOption);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(FTPIntakeRemoveFavAppsoption);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(CopyAttachAddFavThroughThreeDotOption);
            Thread.Sleep(1000);
            WebDriverUtility.ClickOn(CopyAttchDataRemoveFavAppsoption);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(CreateActionAddFavThroughThreeDotOption);
            Thread.Sleep(1000);
            WebDriverUtility.ClickOn(CreateActionRemoveFavAppsoption);
            Thread.Sleep(2000);

            WebDriverUtility.ClickOn(FaxWatcherAddFavThroughThreeDotOption);
            Thread.Sleep(1000);
            WebDriverUtility.ClickOn(FaxWatcherRemoveFavAppsoption);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(CreateStackAddFavThroughThreeDotOption);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(CreateStackRemoveFavAppsoption);
        }
        public void Removevalidation()
        {
           
           try 
            {
                if (AddedFavAppsValidation.Count > 1)
                {
                    foreach (var elem in Elipsy)
                    {
                        elem.Click();
                        WebDriverUtility.WaitUntilClickable(RemoveFavourite, 30);
                        WebDriverUtility.ClickOn(RemoveFavourite);
                        Thread.Sleep(1000);
                    }
                }
               
            }
            catch(Exception )
            {
                Console.WriteLine("No App Selected");
            }
        }
        public void AllAppsDisplayedExpectedAsync()
        {
            Thread.Sleep(3000);
            WebDriverUtility.IsDisplayed(AllAppsDsiplayed);
            Assert.IsTrue(WebDriverUtility.GetText(AppCount).Contains("20 Apps Found"));

        }

        public void VerifyAppToolTipValue()
        {


            WebDriverUtility.MoveToElement(AppToolTip);
            String tooltip =WebDriverUtility.GetText(ToolTipValidation);
            Assert.AreEqual(tooltip, Excel.GetValueFromTestStep("AppDetails", "AppToolTip"), "Tooltip not matching as in Service");
            Console.WriteLine(tooltip);
            WebDriverUtility.MoveToElement(AttchDataAppName);
            String AppName = WebDriverUtility.GetText(ToolTipValidation);
            Assert.AreEqual(AppName, Excel.GetValueFromTestStep("AppDetails", "AppName"), "App name not matching as in Service");
            WebDriverUtility.MoveToElement(AttchDataAppDescp);
            String AppDescription = WebDriverUtility.GetText(ToolTipValidation);
            Assert.AreEqual(AppDescription, Excel.GetValueFromTestStep("AppDetails", "AppDescription"), "App descripton not matching as in Service");
        }
        public void ClickLaunchTab()
        {
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(CopyAttachAddFavThroughThreeDotOption);
            WebDriverUtility.ClickOn(ClickLaunchCopyAttach);
        }
        public void Urlopened()
        {
            String resultURL = WebDriverUtility.GetCurrentURL();
            Assert.IsTrue(resultURL.Contains("https://localhost:8081/Medi"));
            WebDriverUtility.GetDriver().Navigate().Back();
            Thread.Sleep(2000);
        }

    }
}