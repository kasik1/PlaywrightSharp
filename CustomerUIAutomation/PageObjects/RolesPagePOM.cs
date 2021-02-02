using CustomerUIAutomation.PageObjects;
using CustomerUIAutomation.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CustomerUIAutomation.PageObjects
{
    class RolesPagePOM : TestBase
    {

        private readonly IWebDriver _WebDriver;
        public RolesPagePOM(IWebDriver driver)
            : base(driver, "LocatorsJsonFiles\\RolesPageLocators.json", "HomePageTestData")
        {
            this._WebDriver = driver;
            WebDriverUtility.TurnOnWait(60);
        }
        public IWebElement AddRole => WebDriverUtility.FindElement(MultipleLocators["AddRole"]);

        public IWebElement EditIconRoleName => WebDriverUtility.FindElement(MultipleLocators["EditIconRoleName"]);

        public IWebElement EditIconRoleDescription => WebDriverUtility.FindElement(MultipleLocators["EditIconRoleDescription"]);

        public IWebElement RoleNameTextInput => WebDriverUtility.FindElement(MultipleLocators["RoleNameTextInput"]);

        public IWebElement RoleDescriptionInput => WebDriverUtility.FindElement(MultipleLocators["RoleDescriptionInput"]);

        public IWebElement TaskSelection => WebDriverUtility.FindElement(MultipleLocators["TaskSelection"]);
        public IWebElement Save => WebDriverUtility.FindElement(MultipleLocators["Save"]);

        public IWebElement DeleteRole => WebDriverUtility.FindElement(MultipleLocators["DeleteRole"]);
        public IWebElement FilterSearch => WebDriverUtility.FindElement(MultipleLocators["FilterSearch"]);

        public IWebElement DeleteConfirmation => WebDriverUtility.FindElement(MultipleLocators["DeleteConfirmation"]);

        public IWebElement SelectedTaskValidation => WebDriverUtility.FindElement(MultipleLocators["SelectedTaskValidation"]);
        
        public void AddRoles()
        {
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(AddRole);
            Thread.Sleep(2000);
            WebDriverUtility.ClickOn(EditIconRoleName);
            WebDriverUtility.ClickOn(EditIconRoleDescription);
            WebDriverUtility.EnterText(RoleNameTextInput, "AutomationTesting");
            WebDriverUtility.EnterText(RoleDescriptionInput, "AutomationtestingDescription");
            WebDriverUtility.ClickOn(TaskSelection);
            WebDriverUtility.ClickOn(Save);
            WebDriverUtility.EnterText(FilterSearch, "AutomationTesting");
            Thread.Sleep(2000);
           string value= WebDriverUtility.GetText(SelectedTaskValidation);
            if (value.Equals("Create and delete new roles, edit features/resources, and add/remove members"))
            {
                Console.WriteLine("Validated");

            }
            WebDriverUtility.ClickOn(DeleteRole);
            WebDriverUtility.ClickOn(DeleteConfirmation);
            //WebDriverUtility.EnterText(FirstName, "Automation");
            //WebDriverUtility.EnterText(LastName, "Testing");
            //WebDriverUtility.EnterText(Email, "AutomationTesting@conduent.com");
            //WebDriverUtility.ClickOn(save);
            ////WebDriverUtility.Clear(FilterSearch);
            //Thread.Sleep(2000);
            //WebDriverUtility.EnterText(FilterSearch, "AutomationTesting@conduent.com");
            //Thread.Sleep(2000);
            //WebDriverUtility.ClickOn(EditAssignments);

            //WebDriverUtility.EnterText(FilterRoles, "RbacAdmin");
            //WebDriverUtility.ClickOn(SelectRbacAdmin);
            //string value = WebDriverUtility.GetText(Roletaskandresourcevalidation);
            //string value1 = "Create and delete new roles, edit features/resources, and add/remove members";
            //if (value.Equals(value1))
            //{
            //    Console.WriteLine("Role added successfully");

            //}
        }
    }
    }
