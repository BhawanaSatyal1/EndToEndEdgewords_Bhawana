using OpenQA.Selenium;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace EndToEndTestEdgewordsTraining_Bhawana.StepDefinitions
{
    [Binding]
    public class LogIn : Utilities.Hooks
    {
        POM_pages.LoginPOM loginPOM = new POM_pages.LoginPOM();


        [Given(@"I am on egdewordstraining homepage")]
        public void GivenIAmOnEgdewordstrainingHomepage()
        {
            loginPOM.ClickOnMyAccount();
        }

        [When(@"I type in valid username")]
        public void WhenITypeInValidUsername()
        {
            loginPOM.TypeInUserName(); 
        }

        [When(@"I type in valid password")]
        public void WhenITypeInValidPassword()
        {
            loginPOM.TypeInPassword();
            loginPOM.ClickOnLogin();
        }

        [Then(@"I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {

           
            string logoutButton = driver.FindElement(By.PartialLinkText("Logout")).Text;
            Assert.That(driver.FindElement(By.PartialLinkText("Logout")).Displayed);

           

        }


    }

}
