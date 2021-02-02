using CustomerUIAutomation.PageObjects;
using CustomerUIAutomation.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CustomerUIAutomation.PageObjects
{

    public class UsersPagePOM : TestBase
    {

        private readonly IWebDriver _WebDriver;
        public UsersPagePOM(IWebDriver driver)
            : base(driver, "LocatorsJsonFiles\\UsersPageLocators.json", "HomePageTestData")
        {
            this._WebDriver = driver;
            WebDriverUtility.TurnOnWait(60);
        }
        public IWebElement AddUser => WebDriverUtility.FindElement(MultipleLocators["AddUser"]);
        public IWebElement DeleteUser => WebDriverUtility.FindElement(MultipleLocators["DeleteUser"]);
        public IWebElement AddUserModalPopup => WebDriverUtility.FindElement(MultipleLocators["AddUserModalPopup"]);
        public IWebElement FirstName => WebDriverUtility.FindElement(MultipleLocators["FirstName"]);
        public IWebElement LastName => WebDriverUtility.FindElement(MultipleLocators["LastName"]);
        public IWebElement Email => WebDriverUtility.FindElement(MultipleLocators["Email"]);
        public IWebElement save => WebDriverUtility.FindElement(MultipleLocators["save"]);

        public IWebElement FilterSearch => WebDriverUtility.FindElement(MultipleLocators["FilterSearch"]);
        public IWebElement EditAssignments => WebDriverUtility.FindElement(MultipleLocators["EditAssignments"]);

        public IWebElement Roletaskandresourcevalidation => WebDriverUtility.FindElement(MultipleLocators["Roletaskandresourcevalidation"]);
        public IWebElement SelectRbacAdmin => WebDriverUtility.FindElement(MultipleLocators["SelectRbacAdmin"]);
        public IWebElement FilterRoles => WebDriverUtility.FindElement(MultipleLocators["FilterRoles"]);
        public IWebElement AssignedRolesSave => WebDriverUtility.FindElement(MultipleLocators["AssignedRolesSave"]);
        public IWebElement DeleteConfirmation => WebDriverUtility.FindElement(MultipleLocators["DeleteConfirmation"]);
        public IWebElement AssignrolesInGridView => WebDriverUtility.FindElement(MultipleLocators["AssignrolesInGridView"]);
        public IWebElement Gridview => WebDriverUtility.FindElement(MultipleLocators["Gridview"]);
        public IWebElement EditRolesinGridViewforUsers => WebDriverUtility.FindElement(MultipleLocators["EditRolesinGridViewforUsers"]);
        public IWebElement AssignedRolesSaveGridView => WebDriverUtility.FindElement(MultipleLocators["AssignedRolesSaveGridView"]);
        public IWebElement SelectUser => WebDriverUtility.FindElement(MultipleLocators["SelectUser"]);
        
        public void AddUsers()
        {
            WebDriverUtility.ClickOn(AddUser);
            WebDriverUtility.EnterText(FirstName, "Automation");
            WebDriverUtility.EnterText(LastName,"Testing");
            WebDriverUtility.EnterText(Email, "AutomationTesting@conduent.com");
            WebDriverUtility.ClickOn(save);
            //WebDriverUtility.Clear(FilterSearch);
            Thread.Sleep(2000);
            WebDriverUtility.EnterText(FilterSearch, "AutomationTesting@conduent.com");
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(EditAssignments);
            
            WebDriverUtility.EnterText(FilterRoles, "RbacAdmin");
            WebDriverUtility.ClickOn(SelectRbacAdmin);
            string value = WebDriverUtility.GetText(Roletaskandresourcevalidation);
            string value1 = "Create and delete new roles, edit features/resources, and add/remove members";
            if (value.Equals(value1))
            {
                Console.WriteLine("Role added successfully");

            }
            WebDriverUtility.ClickOn(AssignedRolesSave);
            
            WebDriverUtility.ClickOn(DeleteUser);
            WebDriverUtility.ClickOn(DeleteConfirmation);
            

        }
        public void AddUsersinGridView()
        {
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(Gridview);
            WebDriverUtility.ClickOn(AddUser);
            WebDriverUtility.EnterText(FirstName, "Automation");
            WebDriverUtility.EnterText(LastName, "Testing");
            WebDriverUtility.EnterText(Email, "AutomationTesting@conduent.com");
            WebDriverUtility.ClickOn(save);
            //WebDriverUtility.Clear(FilterSearch);
            Thread.Sleep(2000);
            WebDriverUtility.EnterText(FilterSearch, "AutomationTesting@conduent.com");
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(EditRolesinGridViewforUsers);
            
            WebDriverUtility.EnterText(FilterRoles, "RbacAdmin");
            WebDriverUtility.ClickOn(SelectRbacAdmin);
            string value = WebDriverUtility.GetText(Roletaskandresourcevalidation);
            string value1 = "Create and delete new roles, edit features/resources, and add/remove members";
            if (value.Equals(value1))
            {
                Console.WriteLine("Role added successfully");

            }
            WebDriverUtility.ClickOn(AssignedRolesSaveGridView);
            WebDriverUtility.ClickOn(SelectUser);
            WebDriverUtility.ClickOn(DeleteUser);
            WebDriverUtility.ClickOn(DeleteConfirmation);

        }






    }
}
