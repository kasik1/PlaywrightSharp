
using CustomerUIAutomation.PageObjects;
using CustomerUIAutomation.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CustomerUIAutomation.StepDefinitions
{


    [Binding]

    public class HomePageStepDefinitions : StepDefinitionsBase
    {
        private readonly HomePagePom homePage;
        private readonly ScenarioContext _scenarioContext;

        public HomePageStepDefinitions(IWebDriver webDriver, ScenarioContext scenarioContext)
            : base(webDriver)
        {
            homePage = new HomePagePom(webDriver);
            _scenarioContext = scenarioContext;

        }

       
        [Then(@"I click on User profile Icon and Validate details")]
        public void ThenIValidateTheProfileDetails()
        {
            homePage.ValidateProfileDetails("ValidateProfileDetails");
        }

        [When(@"I click on Edit profile Icon")]
        public void ThenIClickOnEditProfile()
        {
            homePage.ClickOnEditProfile();
        }
        [When(@"I Upload image formats of png with size within 2mb")]
        public void UploadImageWithSize2mbPng()
        {
            homePage.ValidateUploadAvatar("UserAvatar\\PNGImage.png");
        }
        [When(@"I Upload image formats of jpg with size within 2mb")]
        public void UploadImageWithSize2mbJpg()
        {
            homePage.Avatar();
            homePage.ClickOnEditProfile();
            homePage.ValidateUploadAvatar("UserAvatar\\199MB.jpg");
        }
        [When(@"I Upload image formats of gif with size within 2mb")]
        public void UploadImageWithSize2mbGif()
        {
            homePage.Avatar();
            homePage.ClickOnEditProfile();
            homePage.ValidateUploadAvatar("UserAvatar\\GIFImage.gif");
        }
        [Then(@"System should upload icon and Validate Notification")]
        public void ValidateTheSuccessNotification()
        {
            homePage.ValidateTheNotification("Successfully Updated User Details");
        }
        [Then(@"I upload invalid image formats as Avatar and Validate error message")]
        public void ValidateInvalidFormatAvatar()
        {
            homePage.Avatar();
            homePage.ClickOnEditProfile();
            homePage.ValidateUploadAvatar("UserAvatar\\InvalidFile.docx");
        }

        [When(@"I Click on User Settings Icon displayed on image")]
        public void WhenIclickonUserSettingsIcon()
        {
            homePage.UserSettings();
        }
        [Then(@"setting model popup window should be displayed as expected")]
        public void ThenIValidateModelPopup()
        {
            homePage.Settingpopup();
        }
        [Then(@"I click on cancel button")]
        public void ThenIClickOnCancel()
        {
            homePage.SettingModelCancelButton();
        }
        [When(@"I Click on 'Edit your Account Settings' when click on image")]
        public void WhenIclickonEditYourAccountSettings()
        {
            homePage.EditYourSettings();
        }

        [When(@"I Click on 'Languages' when click on image")]
        public void WhenIClickOnLaguages()
        {
            homePage.LanguageField();
        }
        [When(@"I Click on 'Theme' when click on image")]
        public void WhenIClickOnTheme()
        {
            homePage.ThemeFeild();
        }

        [When(@"I Click on User Settings Icon")]
        public void ClickOnAvatar()
        {
            homePage.Avatar();
        }
        [When(@"i enter valid username Dob and language and click on save")]
        public void WhenIValidateEmailIDDOBLaguagae()
        {
            homePage.ValidateEmailIDDOBLaguagae("ValidateEmailIDDOBLaguagae");
        }
        [Then (@"successfull message should be displayed")]
        public void ThenSucessMessageShouldbeDisplayed()
        {
            homePage.Successmessage();
        }
        [Then (@"updated values should be displayed when user click on profile")]
        public void ThenIValidateUpdatedData()
        {
            homePage.UpdatedDatavalidation("UpdatedDatavalidation");
        }
        [When (@"i enter Invalid username Dob and language and click on save")]
        public void WhenIvalidateInValidData()
        {
            homePage.InValidataValidation();
        }
        [Then(@"Valid the updated data for the corresponding feilds")]
        public void ThenIValidateUpateddata()
        {
            homePage.ValidateUpateddata("ValidateUpateddata");
        }
        [Then (@"I Logout From Portal")]
        public void ThenILogout()
        {
            homePage.Avatar();
            homePage.LogoutButton();
        }
        [When (@"I click on Hambuger menu")]
        public void WhenIClickOnHamburgerMenu()
        {
            homePage.HamburgerMenu();
            
        }
        [When(@"I Click on Reports Menu")]
        public void WhenIClickOnreportsMenu()
        {
            homePage.ReportsMenu();
        }
        [When(@"I Navigate to Work exception page")]
        public void WhenIClickOnWorkExceptionMenu()
        {
            homePage.HamburgerMenu();
            homePage.WorkExceptionMenu();
        }
        [When(@"I Navigate to Voided items page")]
        public void WhenIClickOnVoidedItemsMenu()
        {
            homePage.HamburgerMenu();
            homePage.VoidedItemsMenu();
        }
        [Then(@"I Navigate to Search screen")]
        public void WhenIClickOnSearchMenu()
        {
            homePage.HamburgerMenu();
            homePage.SearchMenu();
        }


        [When(@"I Click on CustomerApplications Menu")]
        public void WhenIClickOnCustomerApplicationsMenu()
        {
            homePage.CustomerApplicationsMenu();
        }
        [When(@"I Click on Users Menu")]
        public void WhenIClickOnUsersMenu()
        {
            homePage.UsersMenu();
        }
        [When(@"I Click on DashBoard Menu")]
        public void WhenIClickOnDashBoardMenu()
        {
            homePage.DashBoardMenu();
        }
        [When(@"I Click on Roles Menu")]
        public void WhenIClickOnRolesMenu()
        {
            homePage.RolesMenu();
        }

        [When(@"I Click on Production Control Menu")]
        public void wheniclickonproductioncontrolmenu()
        {
            homePage.ProductioncontrolScreen();
        }
    }
}
