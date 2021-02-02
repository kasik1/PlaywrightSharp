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
    public class HomePagePom : TestBase
    {
        
        private readonly IWebDriver _WebDriver;
        public HomePagePom(IWebDriver driver)
            : base(driver, "LocatorsJsonFiles\\HomePageLocators.json", "HomePageTestData")
        {
            this._WebDriver = driver;
            WebDriverUtility.TurnOnWait(60);
        }
     
      
        public IWebElement UserIcon => WebDriverUtility.FindElement(MultipleLocators["UserIcon"]);
        public IWebElement EditProfile => WebDriverUtility.FindElement(MultipleLocators["EditProfile"]);
        public IWebElement AvatarIconInDropdown => WebDriverUtility.FindElement(MultipleLocators["AvatarIconInDropdown"]);
        public IWebElement ProfileNameInDropdown => WebDriverUtility.FindElement(MultipleLocators["ProfileNameInDropdown"]);
        public IWebElement EmailInDropdown => WebDriverUtility.FindElement(MultipleLocators["EmailInDropdown"]);
        public IWebElement LanguageInDropdown => WebDriverUtility.FindElement(MultipleLocators["LanguageInDropdown"]);
        public IWebElement ThemeInDropdown => WebDriverUtility.FindElement(MultipleLocators["ThemeInDropdown"]);
        public IWebElement DefaultLanguage => WebDriverUtility.FindElement(MultipleLocators["DefaultLanguage"]);
        public IWebElement DefaultTheme => WebDriverUtility.FindElement(MultipleLocators["DefaultTheme"]);
        public IWebElement UploadPic => WebDriverUtility.FindElement(MultipleLocators["UploadPic"]);
        public IWebElement ApplyAvatar => WebDriverUtility.FindElement(MultipleLocators["ApplyAvatar"]);
        public IWebElement SaveButton => WebDriverUtility.FindElement(MultipleLocators["SaveButton"]);
        public IWebElement CloseSettings => WebDriverUtility.FindElement(MultipleLocators["CloseSettings"]);
        
        public IWebElement MessageNotification => WebDriverUtility.FindElement(MultipleLocators["MessageNotification"]);
        public IWebElement InvalidFormatAvatar => WebDriverUtility.FindElement(MultipleLocators["InvalidFormatAvatar"]);
        public IWebElement UserSettingsIcon => WebDriverUtility.FindElement(MultipleLocators["UserSettingsIcon"]);
        public IWebElement settingsModelPopup => WebDriverUtility.FindElement(MultipleLocators["settingsModelPopup"]);
        public IWebElement SettingsModelCancel => WebDriverUtility.FindElement(MultipleLocators["SettingsModelCancel"]);
        public IWebElement EditYourSettingsFeild => WebDriverUtility.FindElement(MultipleLocators["EditYourSettingsFeild"]);
        public IWebElement languages => WebDriverUtility.FindElement(MultipleLocators["languages"]);
        public IWebElement Theme => WebDriverUtility.FindElement(MultipleLocators["Theme"]);
        public IWebElement ProfileIcon => WebDriverUtility.FindElement(MultipleLocators["ProfileIcon"]);
        public IWebElement UploadORChangePicture => WebDriverUtility.FindElement(MultipleLocators["UploadORChangePicture"]);
        public IWebElement UserName => WebDriverUtility.FindElement(MultipleLocators["UserName"]);
        public IWebElement Email => WebDriverUtility.FindElement(MultipleLocators["Email"]);
        public IWebElement DatePicker => WebDriverUtility.FindElement(MultipleLocators["DatePicker"]);
        public IWebElement LanguageDropdown => WebDriverUtility.FindElement(MultipleLocators["LanguageDropdown"]);

        public IWebElement DatePickerDate => WebDriverUtility.FindElement(MultipleLocators["DatePickerDate"]);
        public IWebElement DatePickerclick => WebDriverUtility.FindElement(MultipleLocators["DatePickerclick"]);

        public IWebElement DatePickerYear => WebDriverUtility.FindElement(MultipleLocators["DatePickerYear"]);

        public IWebElement DatePickerMonth => WebDriverUtility.FindElement(MultipleLocators["DatePickerMonth"]);

        public IWebElement DropdownTextSelection => WebDriverUtility.FindElement(MultipleLocators["DropdownTextSelection"]);
        public IWebElement ThemeSelection => WebDriverUtility.FindElement(MultipleLocators["ThemeSelection"]);

        public IWebElement UpdatedProfileName => WebDriverUtility.FindElement(MultipleLocators["UpdatedProfileName"]);
        public IWebElement EmailIDValidation => WebDriverUtility.FindElement(MultipleLocators["EmailIDValidation"]);
        public IWebElement LanguageValidation => WebDriverUtility.FindElement(MultipleLocators["LanguageValidation"]);
        public IWebElement ThemeValidationLight => WebDriverUtility.FindElement(MultipleLocators["ThemeValidationLight"]);
        public IWebElement UpdatedUserNametext => WebDriverUtility.FindElement(MultipleLocators["UpdatedUserNametext"]);
        public IWebElement Logout => WebDriverUtility.FindElement(MultipleLocators["Logout"]);
        public IWebElement UserProfileLoader => WebDriverUtility.FindElement(MultipleLocators["UserProfileLoader"]);
        public IWebElement WrapperLoader => WebDriverUtility.FindElement(MultipleLocators["WrapperLoader"]);

        public IWebElement Hamburger => WebDriverUtility.FindElement(MultipleLocators["HamburgerMenu"]);
        public IWebElement Users => WebDriverUtility.FindElement(MultipleLocators["UsersMenu"]);
        public IWebElement Roles => WebDriverUtility.FindElement(MultipleLocators["RolesMenu"]);
        public IWebElement DashBoard => WebDriverUtility.FindElement(MultipleLocators["DashBoardMenu"]);
        public IWebElement CustomerApplications => WebDriverUtility.FindElement(MultipleLocators["CustomerApplicationsMenu"]);
        public IWebElement ProductionControl => WebDriverUtility.FindElement(MultipleLocators["ProductionControl"]);
        public IWebElement QueueMonitor => WebDriverUtility.FindElement(MultipleLocators["QueueMonitorMenu"]);
        public IWebElement WorkException => WebDriverUtility.FindElement(MultipleLocators["WorkExceptionMenu"]);
        public IWebElement VoidedItems => WebDriverUtility.FindElement(MultipleLocators["VoidedItemsMenu"]);
        public IWebElement Search => WebDriverUtility.FindElement(MultipleLocators["SearchMenu"]);
        public IWebElement ServiceBusMonitor => WebDriverUtility.FindElement(MultipleLocators["ServiceBusMonitorMenu"]);
        public IWebElement Reports => WebDriverUtility.FindElement(MultipleLocators["ReportsMenu"]);
       
        
        public IWebElement CloseIcon => WebDriverUtility.FindElement(MultipleLocators["CloseIcon"]);









        public void Avatar()
        {

            //WebDriverUtility.WaitUntilInvisible(By.XPath("//nav//div[@class='k-i-loading']"), 30);
            Thread.Sleep(10000);
            WebDriverUtility.ClickOn(UserIcon);
        }

        public void ValidateProfileDetails(string testStep)
        {
        
            Assert.IsTrue(WebDriverUtility.IsDisplayed(AvatarIconInDropdown),"Avatar is not present");
            Assert.IsTrue(WebDriverUtility.IsDisplayed(ProfileNameInDropdown), "Profile is not present");
            Assert.IsTrue(WebDriverUtility.IsDisplayed(EmailInDropdown), "Email is not present");
            Assert.IsTrue(WebDriverUtility.IsDisplayed(LanguageInDropdown), "languague field is not present");
            Assert.IsTrue(WebDriverUtility.IsDisplayed(ThemeInDropdown), "Theme field is not present");
            Assert.AreEqual(WebDriverUtility.GetText(DefaultLanguage), Excel.GetValueFromTestStep(testStep, "DefaultLanguage"));
            Assert.AreEqual(WebDriverUtility.GetText(DefaultTheme), Excel.GetValueFromTestStep(testStep, "DefaultTheme"));
            Assert.IsTrue(WebDriverUtility.IsDisplayed(EditProfile), "EditProfile field is not present");
            //WebDriverUtility.WaitUntilInvisible(By.XPath("//nav//div[@class='k-i-loading']"), 30);
            WebDriverUtility.ClickOn(UserIcon);

        }
        public void ClickOnEditProfile()
        {
            WebDriverUtility.ClickOn(EditProfile);
        }
        public void ValidateUploadAvatar(String fileName)
        {
            WebDriverUtility.ClickOn(UploadPic);
           
            WebDriverUtility.UploadPhoto(fileName);
            
            if (fileName.Contains("gif")|| fileName.Contains("png")|| fileName.Contains("jpg"))
            {
                if (!fileName.Contains("gif"))
                {
                    Thread.Sleep(3000);
                    WebDriverUtility.ClickOn(ApplyAvatar);
                    WebDriverUtility.ScrollDownPage();
                    WebDriverUtility.ClickOn(SaveButton);
                }
                else
                {
                    WebDriverUtility.ScrollDownPage();
                    WebDriverUtility.ClickOn(SaveButton);
                }
            }
            else
            {
                    String errorMessage = WebDriverUtility.GetText(InvalidFormatAvatar);
                    Assert.AreEqual(errorMessage, "docx format is not allowed");
             }
            

        }
        public void ValidateTheNotification(String expectedMessage)
        {
            String notification = WebDriverUtility.GetText(MessageNotification);
            Assert.AreEqual(notification, expectedMessage);
        }


        public void UserSettings()
        {
            
            WebDriverUtility.ClickOn(UserSettingsIcon);
        }

        public void Settingpopup()
        {
            WebDriverUtility.ClickOn(settingsModelPopup);
            WebDriverUtility.IsDisplayed(ProfileIcon);
            WebDriverUtility.IsDisplayed(UploadORChangePicture);
            WebDriverUtility.IsDisplayed(UserName);
            WebDriverUtility.IsDisplayed(Email);
            WebDriverUtility.IsDisplayed(DatePicker);
            WebDriverUtility.IsDisplayed(LanguageDropdown);
                      
        }
        public void SettingModelCancelButton()
        {
            WebDriverUtility.ClickOn(SettingsModelCancel);
        }
        public void EditYourSettings()
        {
            WebDriverUtility.ClickOn(EditYourSettingsFeild);
        }

        public void LanguageField()
        {
            WebDriverUtility.ClickOn(languages);
        }
        public void ThemeFeild()
        {
            WebDriverUtility.ClickOn(Theme);
        }
        public void ValidateEmailIDDOBLaguagae(string testStep)
        {
            
            WebDriverUtility.Clear(UserName);
            WebDriverUtility.EnterText(UserName, Excel.GetValueFromTestStep(testStep, "UserName"));
            WebDriverUtility.ClickOn(settingsModelPopup);
            WebDriverUtility.IsDisplayed(DatePicker);
           
            WebDriverUtility.ClickOn(DatePickerclick);
            
            WebDriverUtility.ClickOn(DatePickerMonth);
            
            WebDriverUtility.ClickOn(DatePickerDate);
            
            WebDriverUtility.Scrollintoview(ThemeSelection);
           
            WebDriverUtility.ClickOn(ThemeSelection);
           
            WebDriverUtility.ClickOn(SaveButton);

            
               
                
                
        }
        public void Successmessage()
        {
            WebDriverUtility.IsDisplayed(MessageNotification);
        }
        public void UpdatedDatavalidation(string testStep)
        {
            Assert.AreEqual(WebDriverUtility.GetText(UpdatedProfileName), Excel.GetValueFromTestStep(testStep, "UpdatedProfileName"));
            Assert.AreEqual(WebDriverUtility.GetText(EmailIDValidation), Excel.GetValueFromTestStep(testStep, "EmailIDValidation"));
            Assert.AreEqual(WebDriverUtility.GetText(LanguageValidation), Excel.GetValueFromTestStep(testStep, "LanguageValidation"));
            Assert.AreEqual(WebDriverUtility.GetText(ThemeValidationLight), Excel.GetValueFromTestStep(testStep, "ThemeValidationLight"));
            
        }

        public void InValidataValidation()
        {
            WebDriverUtility.IsDisplayed(settingsModelPopup);
            WebDriverUtility.IsDisplayed(UserName);
            WebDriverUtility.Wait(10000);
            String text = UserName.GetAttribute("fieldvalue");

            int count = text.Length;
            for (int i = 0; i < count; i++)
            {
                UserName.SendKeys(Keys.Backspace);
            }
            
            WebDriverUtility.Scrollintoview(SaveButton);
            WebDriverUtility.WaitForElement(SaveButton);
            Assert.IsFalse(WebDriverUtility.IsEnabled(SaveButton));
            WebDriverUtility.ClickOn(CloseSettings);
           

        }
        public void ValidateUpateddata(string testStep)
        {
            string UpdatedUserNameValue = WebDriverUtility.GetAttribute(UserName, "fieldvalue");
            if (UpdatedUserNameValue.Equals(Excel.GetValueFromTestStep(testStep, "UpdatedProfileName"))){ 

                Console.WriteLine("UserNameUpdated");

            }
        
            

            string ValidatedEmailValue = WebDriverUtility.GetAttribute(Email, "fieldvalue");
            if (ValidatedEmailValue.Equals(Excel.GetValueFromTestStep(testStep, "EmailIDValidation")))
            {
                Console.WriteLine("EmailIDValidated");
            }
        }
        public void LogoutButton()
        {
            Thread.Sleep(1000);
            WebDriverUtility.ClickOn(Logout);
        }
        public void HamburgerMenu()
        {
            
            WebDriverUtility.ClickOn(Hamburger);
        }

        public void UsersMenu()
        {
            WebDriverUtility.ClickOn(Users);
            Thread.Sleep(10000);
        }
        public void RolesMenu()
        {
            WebDriverUtility.ClickOn(Roles);
        }
        public void ReportsMenu()
        {
            WebDriverUtility.ClickOn(Reports);
        }
        public void WorkExceptionMenu()
        {
            WebDriverUtility.ClickOn(ProductionControl);
            WebDriverUtility.ClickOn(WorkException);
        }
        public void VoidedItemsMenu()
        {
            WebDriverUtility.ClickOn(ProductionControl);
            WebDriverUtility.ClickOn(VoidedItems);
        }
        public void SearchMenu()
        {
            WebDriverUtility.ClickOn(ProductionControl);
            WebDriverUtility.ClickOn(Search);
        }
        

        public void CustomerApplicationsMenu()
        {
            WebDriverUtility.ClickOn(CustomerApplications);
            //WebDriverUtility.ClickOn(CloseIcon);

        }
        public void DashBoardMenu()
        {
            WebDriverUtility.ClickOn(DashBoard);
            //WebDriverUtility.ClickOn(CloseIcon);

        }
        public void ProductioncontrolScreen()
        {
            WebDriverUtility.ClickOn(ProductionControl);

        }
        
    }
}
