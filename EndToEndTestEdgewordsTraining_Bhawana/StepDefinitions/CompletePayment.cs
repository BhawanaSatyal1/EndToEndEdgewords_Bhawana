using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace EndToEndTestEdgewordsTraining_Bhawana.StepDefinitions
{

    [Binding] // provides binding between step definition and scenario steps 
    public class CompletePayment
    {


        POM_pages.CompletePaymentPOM completePaymentPOM = new POM_pages.CompletePaymentPOM();
        POM_pages.AddToCartPOM addToCartPOM = new POM_pages.AddToCartPOM();


        [Given(@"I am logged in  & have item added to cart")]
        public void GivenIAmLoggedInHaveItemAddedToCart()
        {

            addToCartPOM.UserLogsIn();
            addToCartPOM.ClickOnShop();
            addToCartPOM.ClickOnHoodieWithPocket();
            addToCartPOM.ClickOnViewcartButton();


        }

        [When(@"I proceed to checkout")]
        public void WhenIProceedToCheckout()
        {
            completePaymentPOM.UserClickOnCheckOutButton();


        }

        [When(@"I complete billing details")]
        public void WhenICompleteBillingDetails(Table table)
        {
            
          
            //POM_pages.CompletePaymentPOM details = table.CreateInstance <POM_pages.CompletePaymentPOM>();
            Utilities.BillingDetails details = table.CreateInstance<Utilities.BillingDetails>();
            completePaymentPOM.UserFillsUpBillingInformation(details);
           



        }
        //[When(@"I complete billing details")]
        //public void WhenICompleteBillingDetails()
        //{
        //    completePaymentPOM.userFillsUpBillingInformation();
        //}

        [Then(@"I place order & order number should be generated")]
        public void WhenIPlaceOrderOrderNumberShouldBeGenerated()
        {
            completePaymentPOM.UserClicksOnPlaceOrder();
            completePaymentPOM.UserCompletesOrderAndReturnsToHomePage();
        }




    }
}
