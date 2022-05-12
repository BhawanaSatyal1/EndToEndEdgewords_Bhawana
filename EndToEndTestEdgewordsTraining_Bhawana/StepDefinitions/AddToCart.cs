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
    public class AddToCart
    {

        private Utilities.DriverHelper _driverHelper;
        POM_pages.AddToCartPOM addToCart;

        public AddToCart(Utilities.DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            addToCart = new POM_pages.AddToCartPOM(_driverHelper.Driver);

        }
        [Given(@"I am Logged in as registered user")]
        public void GivenIAmLoggedInAsRegisteredUser()
        {
            addToCart.UserLogsIn(); //Calling method with the help of an object 
        }

        [When(@"I add an item to the cart")]
        public void WhenIAddAnItemToTheCart()
        {
            addToCart.HoverAroundCatergories();
            addToCart.ClickOnShop();
            addToCart.ClickOnHoodieWithPocket();
            addToCart.ClickOnViewcartButton();

        }

        [Then(@"I  apply discount & The total calculation must be correct")]
        public void ThenIApplyDiscountTheTotalCalculationMustBeCorrect()
        {
            addToCart.ApplyCoupon();
            addToCart.VerifyDiscountIsAppliedCorrectly();
        }

    }
}
