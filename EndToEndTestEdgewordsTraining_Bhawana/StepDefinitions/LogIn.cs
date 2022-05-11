
using OpenQA.Selenium;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace EndToEndTestEdgewordsTraining_Bhawana.StepDefinitions
{
    [Binding]// provides binding between step definition and scenario steps 
    public class LogIn 
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
            
            loginPOM.VerifyUserIsOnLoggedInSuccessfully();
          

        }


    }

}
