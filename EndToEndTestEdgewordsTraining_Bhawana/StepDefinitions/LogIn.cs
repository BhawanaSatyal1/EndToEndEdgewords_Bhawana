
using OpenQA.Selenium;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace EndToEndTestEdgewordsTraining_Bhawana.StepDefinitions
{
    [Binding]// provides binding between step definition and scenario steps 
    public class LogIn
    {
        private Utilities.DriverHelper _driverHelper;
        POM_pages.LoginPOM loginPOM;
        public LogIn(Utilities.DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            loginPOM = new POM_pages.LoginPOM(_driverHelper.Driver);
        }

        [Given(@"I am on egdewordstraining homepage")]
        public void GivenIAmOnEgdewordstrainingHomepage()
        {
            loginPOM = new POM_pages.LoginPOM(_driverHelper.Driver);
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
            Assert.That(loginPOM.VerifyUserIsOnLoggedInSuccessfully());
            Console.WriteLine("Login Process Completed");

        }


    }

}
