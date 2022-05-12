using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndToEndTestEdgewordsTraining_Bhawana.POM_pages
{

    public class LoginPOM : Utilities.Helpers
    {
        // Locate element using By class
        By PopupAlert = By.XPath("//a[@href='#']");
        By BtnMyAccount = By.LinkText("My account");
        By BtnUsername = By.Id("username");
        By BtnPassword = By.Id("password");
        By BtnLogin = By.CssSelector("button[name='login']");
        By BtnLogout = By.PartialLinkText("Logout");

        private IWebDriver Driver;

        public LoginPOM(IWebDriver driver)
        {

            Driver = driver;
        }

        // this method clicks on Myaccount 
        public void ClickOnMyAccount()

        {
            ClickOnElement(PopupAlert, Driver); // dismiss alert 
            ClickOnElement(BtnMyAccount, Driver);

        }
        // This method types username 
        public void TypeInUserName()
        {

            TypeText(BtnUsername, ReadValuesFromFile("Username", Driver), Driver);
        }
        //method types in paassword 
        public void TypeInPassword()
        {
            TypeText(BtnPassword, ReadValuesFromFile("Password", Driver), Driver);
        }

        //method clicks on login 
        public void ClickOnLogin()
        {
            ClickOnElement(BtnLogin, Driver);
        }

        public Boolean VerifyUserIsOnLoggedInSuccessfully()
        {
            return GetElement(BtnLogout, Driver).Displayed;
        }

    }

}



