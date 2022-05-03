using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndToEndTestEdgewordsTraining_Bhawana.StepDefinitions
{
    [Binding] // provides bindings between step def and scenario steps 
    public class AddToCart:Utilities.Hooks
    {
        POM_pages.AddToCart addToCart = new POM_pages.AddToCart();
        POM_pages.LoginPOM loginPOM = new POM_pages.LoginPOM();
        LogIn logInStepDefinitions = new LogIn();

        [Given(@"I am already logged in")]
        public void GivenIAmAlreadyLoggedIn()
        {
            
            logInStepDefinitions.GivenIAmOnEgdewordstrainingHomepage();
            addToCart.UserLogsIn(); //Calling method with the help of an object 
        }
      
           

        [When(@"I click on Shop Tab")]
        public void WhenIClickOnShopTab()
        {
           addToCart.HoverAroundCatergories();
           addToCart.ClickOnShop(); 
        }

   

        [When(@"I add Hoddie with Pocket & click view cart")]
        public void WhenIAddHoddieWithPocketClickViewCart()
        {
            addToCart.ClickOnHoodieWithPocket();
            addToCart.ClickOnViewcartButton();
            string ProceedTocheckoutButton = driver.FindElement(By.LinkText("Proceed to checkout")).Text;
            Assert.That(ProceedTocheckoutButton, Does.Contain("Proceed to checkout"), "text not found");

         }

        
        [When(@"I  apply discount & The total calculation must be correct")]
        public void WhenIApplyDiscountTheTotalCalculationMustBeCorrect()
        {
            addToCart.ApplyCoupon();
            addToCart.VerifyDiscountIsAppliedCorrectly();
        }

        [Then(@"I log out successfully")]
        public void ThenILogOutSuccessfully()
        {
            addToCart.UserLogsOut();
        }


    }
}
