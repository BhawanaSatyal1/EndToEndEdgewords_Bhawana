using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndToEndTestEdgewordsTraining_Bhawana.StepDefinitions
{

    [Binding] // provides binding between step definition and scenario steps 
    public class CompletePayment :Utilities.Hooks
    {

    
        AddToCart addToCartStepDef = new AddToCart();
        POM_pages.CompletePaymentPOM completePaymentPOM = new POM_pages.CompletePaymentPOM();   


        [Given(@"I am logged in  & have item added to cart")]
        public void GivenIAmLoggedInHaveItemAddedToCart()
        {
          addToCartStepDef.GivenIAmAlreadyLoggedIn();
          addToCartStepDef.WhenIClickOnShopTab();
          addToCartStepDef.WhenIAddHoddieWithPocketClickViewCart(); 



        }

        [When(@"I proceed to checkout")]
        public void WhenIProceedToCheckout()
        {
            completePaymentPOM.userClickOnCheckOutButton();
             
            
        }

        [When(@"I complete billing details")]
        public void WhenICompleteBillingDetails()
        {
            completePaymentPOM.userFillsUpBillingInformation();
        }

        [When(@"I place order & order number should be generated")]
        public void WhenIPlaceOrderOrderNumberShouldBeGenerated()
        {
            completePaymentPOM.UserClicksOnPlaceOrder();
        }

        [Then(@"I log out")]
        public void ThenILogOut()
        {
            completePaymentPOM.UserCompletesOrderAndReturnsToHomePage();
        }

    }
}
