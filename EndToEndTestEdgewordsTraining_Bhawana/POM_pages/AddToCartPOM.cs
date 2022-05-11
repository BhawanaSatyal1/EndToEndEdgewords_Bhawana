using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndToEndTestEdgewordsTraining_Bhawana.POM_pages
{

    public class AddToCartPOM : Utilities.Helpers
    {
        //action class defined and invoked to handle keyboard and mouse events 
        Actions actions; 
        // Locate element using By class
        By BtnShop = By.LinkText("Shop");
        By BtnHome = By.LinkText("Home");
        By BtnCart = By.LinkText("Cart");
        By BtnHoodie = By.XPath("//a[@href='/demo-site/shop/?add-to-cart=32']");
        By BtnViewcart = By.XPath("//a[@title='View cart']");
        By BtnCoupon = By.CssSelector("input#coupon_code");
        By BtnApplyCoupon = By.CssSelector("button[name='apply_coupon']");
        By BtnSubTotal = By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount");
        By TxtDiscAmt = By.CssSelector(".cart-discount.coupon-edgewords > td");
        By TxtTotalAmt = By.CssSelector("strong > .amount.woocommerce-Price-amount");
        By TxtShippingCost = By.CssSelector(".shipping > td");
        By BtnCheckout = By.CssSelector(".alt.button.checkout-button.wc-forward");


        public void UserLogsIn()
        {
            LoginPOM loginPOM = new LoginPOM();
            loginPOM.ClickOnMyAccount();
            loginPOM.TypeInUserName();
            loginPOM.TypeInPassword();
            loginPOM.ClickOnLogin();
        }



        // this method is used to move mouse pointer between tabs 
        public void HoverAroundCatergories()
        {
            actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(BtnHome)).Build().Perform();
            actions.MoveToElement(driver.FindElement(BtnShop)).Build().Perform();
            WaitForTimeInSec(3);
            actions.MoveToElement(driver.FindElement(BtnCart)).Build().Perform();
            Console.WriteLine("Hover Action performed");// system output 

        }

        public void ClickOnShop()
        {
            ClickOnElement(BtnShop);
        }

        public void ClickOnHoodieWithPocket()
        {
            ClickOnElement(BtnHoodie);

        }

        public void ClickOnViewcartButton()
        {
            ClickOnElement(BtnViewcart);
        }
        // method applies coupon code 
        public void ApplyCoupon()
        {


            ClickOnElement(BtnCoupon);

            TypeText(BtnCoupon, ReadValuesFromFile("Coupon"));
            Console.WriteLine(" the value of coupon is: " + ReadValuesFromFile("Coupon"));
            ClickOnElement(BtnApplyCoupon);
            Thread.Sleep(3000);
            WaitForElementToBeVisible(driver, BtnCheckout, 3);
            Console.WriteLine("Proceed to checkout button present");//console output 
        }


        public void VerifyDiscountIsAppliedCorrectly()
        {

            GetTextFromElement(BtnSubTotal); //returns string from element 
            Console.WriteLine("The SubTotal is : " + GetTextFromElement(BtnSubTotal));// console output 
            GetTextFromElement(TxtDiscAmt);//returns string from element 
            Console.WriteLine("discount amount:" + GetTextFromElement(TxtDiscAmt));// console output
            GetTextFromElement(TxtTotalAmt);
            Console.WriteLine("The total amount is:" + GetTextFromElement(TxtTotalAmt));
            GetTextFromElement(TxtShippingCost);
            Console.WriteLine("The Shipping cost is: " + GetTextFromElement(TxtShippingCost));

            var subTotalCalc = Convert.ToDouble(GetTextFromElement(BtnSubTotal).Substring(1));// converts string to double and substring method returns the part of the string
            var disCalc = Convert.ToDouble(GetTextFromElement(TxtDiscAmt).Substring(2, 4));// converts string to double and substring method returns the part of the string
            var totalAmtCalc = Convert.ToDouble(GetTextFromElement(TxtTotalAmt).Substring(1));
            var shippingCostCalc = double.Parse(GetTextFromElement(TxtShippingCost).Substring(12, 4));


            var TotalDisc = 0.15 * subTotalCalc; //  calculates Total discount 
            var FinalTotalAmt = (subTotalCalc - disCalc) + (shippingCostCalc);// calculates Final amount including shipping cost 


            if (TotalDisc == disCalc) // checks for condition 
            {
                Console.WriteLine("Correct discount applied");// this will be printed if condition is true 
            }

            else
            {
                Console.WriteLine("Discount applied incorrectly");// this will be  an output message if condition is false 
            }

            //   Assert.That(disCalc, Is.EqualTo(subTotalCalc).Within(10).Percent);

            //try
            //{
            //    Assert.AreEqual(TotalDisc, disCalc, "Not Equal");// try this block 
            //}
            //catch (Exception e) // catch exception here 
            //{

            //    Console.WriteLine(e);
            //}

            Assert.AreEqual(totalAmtCalc, FinalTotalAmt, "Not Equal");


        }




    }
}