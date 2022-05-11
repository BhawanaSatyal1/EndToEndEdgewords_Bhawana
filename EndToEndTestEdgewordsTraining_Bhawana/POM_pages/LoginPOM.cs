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





        public void ClickOnMyAccount()

        {
            ClickOnElement(PopupAlert); // dismiss alert 
            ClickOnElement(BtnMyAccount);
           
        }
        
        // This method types username 
        public void TypeInUserName()
        {

            TypeText(BtnUsername, ReadValuesFromFile("Username"));            
          
        }
        //method types in paassword 
        public void TypeInPassword()
        {
            TypeText(BtnPassword, ReadValuesFromFile("Password"));
         

        }

        //method clicks on login 
        public void ClickOnLogin()
        {
            ClickOnElement(BtnLogin);
           
          
        }

        public void VerifyUserIsOnLoggedInSuccessfully()
        {
          
            Assert.That(GetElement(BtnLogout).Displayed);
            Console.WriteLine("Login Process Completed");
        }

       

        }

    }



