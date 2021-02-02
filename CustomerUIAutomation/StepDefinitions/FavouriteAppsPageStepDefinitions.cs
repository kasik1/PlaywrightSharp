
using CustomerUIAutomation.PageObjects;
using CustomerUIAutomation.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CustomerUIAutomation.StepDefinitions
{
    [Binding]
    class FavouriteAppsPageStepDefinitions : StepDefinitionsBase
    {
        private readonly FavouriteAppsPOM favAppPage;
        private readonly ScenarioContext _scenarioContext;

        public FavouriteAppsPageStepDefinitions(IWebDriver webDriver, ScenarioContext scenarioContext)
            : base(webDriver)
        {
            favAppPage = new FavouriteAppsPOM(webDriver);
            _scenarioContext = scenarioContext;

        }
        [Then (@"Customer Portal Home Page is displayed")]
        public void ThenHomePageDisplayed()
        {
            favAppPage.HomepageView();
        }
        [When (@"I click on favourites Apps Tab")]
        public void WhenIClickOnFavTab()
        {
            favAppPage.FavTab();
        }
        [Then (@"View all Apps Tab should be displayed with No Fav Apps")]
        public void ThenViewAppsTabShouldbeDisplayed()
        {
            favAppPage.ViewAllAppsWithNoFav();
        }
        
        [Then (@"All Apps displayed in dashboard")]
        public void ThenAllAppsDisplayed()
        {
            favAppPage.AllAppsDisplayed();
        }
        [When (@"I favourites Apps from all 5 Apps in view and Navigate to DashBoard i validate throught dashboard and fav Apps Tab")]
        public void WhenSelectFiveApps()
        {
            favAppPage.SelectFiveApps("SelectFiveApps");
        }
        [When(@"I favourites Apps from all 5 Apps in view")]
        public void WhenSelectFiveAppsandremovefromoption()
        {
            favAppPage.SelectFiveAppsandremovefromoption();
        }

        [Then (@"Favourited Apps should be displayed in favourite App wrapper")]
        public void ThenFavouriteAppsDisplayedInAppWrapper()
        {
            favAppPage.FavouriteAppsDisplayedInAppWrapper();
        }
        [When (@"I remove all fav apps")]
        public void WhenRemoveAllApps()
        {
            favAppPage.RemoveAllApps();
        }
        [Then (@"selected Fav Should be removed and validated")]

        public void ThenIValidateRemovedFavApps()
        {
            favAppPage.ValidateRemovedFavApps();
        }

        [When (@"I favourites Apps try to favourite 6 Apps")]
        public void WhenFavMorethanFiveApps()
        {
            favAppPage.FavMorethanFiveApps();
        }
        [Then(@"Error Message Should be displayed")]
        public void ThenErrorMessageDisplayed()
        {
            favAppPage.ErrorMessageforMorethanFiveFavApps();
        }
        [When (@"I favourites Apps From Add Fav Apps TaB")]
        public void WhenIfavThroughAddFavTaB()
        {
            favAppPage.favUsingAddFavTaB();
        }
        [When(@"Navigate to DashbOard")]
        public void WhenINavigatetoDashBoard()
        {
            favAppPage.NavigateDashBoard();
        }
        [Then (@"i Remove Added Fav Apps From Star unSelection And validate As unselected")]
        public void WhenIremoveFavApp()
        {
            favAppPage.UnFavApps();
        }
        [When (@"I validate No Apps are favourite")]
        public void NoFavAppsValidation()
        {
            favAppPage.Removevalidation();
        }
        [Then(@"All Apps displayed in dashboard as expected")]
        public void ThenAllAppsDisplayedasexpected()
        {
            favAppPage.AllAppsDisplayedExpectedAsync();
        }
        [Then(@"Verify App Name, description and tool tip values")]
        public void ThenVerifyAppToolTipValue()
        {
            favAppPage.VerifyAppToolTipValue();
        }


        [When(@"click Launch button from App menu")]
        public void WhenIClickOnLaunch()
        {
            favAppPage.ClickLaunchTab();
        }
        [Then(@"URL Should be open as expected")]
        public void ThenURLShouldbeDisplayed()
        {
            favAppPage.Urlopened();
        }



    }

}
