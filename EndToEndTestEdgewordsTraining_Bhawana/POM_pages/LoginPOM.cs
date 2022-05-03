using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndToEndTestEdgewordsTraining_Bhawana.POM_pages
{
    [Binding]
    public class LoginPOM : Utilities.Helpers
    {

        // Locate element using By class

        By _popup_Alert = By.XPath("//a[@href='#']");
        By _btn_MyAccount = By.LinkText("My account");
        By _btn_Username = By.Id("username");
        By _btn_Password = By.Id("password");
        By _btn_Login = By.CssSelector("button[name='login']");

        public void ClickOnMyAccount()

        {
            ClickOnElement(_popup_Alert);
            ClickOnElement(_btn_MyAccount);
           
        }
        
        // This method types username 
        public void TypeInUserName()
        {

            TypeText(_btn_Username, ReadValuesFromFile("Username"));
            
          
        }
        //method types in paassword 
        public void TypeInPassword()
        {
            TypeText(_btn_Password, ReadValuesFromFile("Password"));
         

        }

        //method clicks on login 
        public void ClickOnLogin()
        {
            ClickOnElement(_btn_Login);
            Console.WriteLine("Login Process Completed");
          
        }

    }
}


