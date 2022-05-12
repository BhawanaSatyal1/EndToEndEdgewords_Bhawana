using OpenQA.Selenium;
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
        private Utilities.DriverHelper _driverHelper;
        POM_pages.CompletePaymentPOM completePaymentPOM;
        POM_pages.AddToCartPOM addToCartPOM;
        public CompletePayment(Utilities.DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            completePaymentPOM = new POM_pages.CompletePaymentPOM(_driverHelper.Driver);
            addToCartPOM = new POM_pages.AddToCartPOM(_driverHelper.Driver);

        }


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
            Utilities.BillingDetails details = table.CreateInstance<Utilities.BillingDetails>();
            completePaymentPOM.UserFillsUpBillingInformation(details);

        }

        [Then(@"I place order & order number should be generated")]
        public void WhenIPlaceOrderOrderNumberShouldBeGenerated()
        {
            completePaymentPOM.UserClicksOnPlaceOrder();
            completePaymentPOM.UserCompletesOrderAndReturnsToHomePage();
        }

    }
}
