using EndToEndTestEdgewordsTraining_Bhawana.Utilities;
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
        //action class defined to handle keyboard and mouse events 
        Actions Actions;

        private IWebDriver Driver;
        public AddToCartPOM(IWebDriver driver)
        {
            Driver = driver;
        }
        public void UserLogsIn()
        {
            LoginPOM loginPOM = new LoginPOM(Driver);
            loginPOM.ClickOnMyAccount();
            loginPOM.TypeInUserName();
            loginPOM.TypeInPassword();
            loginPOM.ClickOnLogin();
        }

        // this method is used to move mouse pointer between tabs 
        public void HoverAroundCatergories()
        {
            Actions = new Actions(Driver);
            Actions.MoveToElement(Driver.FindElement(BtnHome)).Build().Perform();
            Actions.MoveToElement(Driver.FindElement(BtnShop)).Build().Perform();
            WaitForTimeInSec(3, Driver);
            Actions.MoveToElement(Driver.FindElement(BtnCart)).Build().Perform();
            Console.WriteLine("Hover Action performed");// system output 

        }
        // this method is used to click on shop 
        public void ClickOnShop()
        {
            ClickOnElement(BtnShop, Driver);
        }

        public void ClickOnHoodieWithPocket()
        {
            ClickOnElement(BtnHoodie, Driver);

        }

        public void ClickOnViewcartButton()
        {
            ClickOnElement(BtnViewcart, Driver);
        }
        // method applies coupon code 
        public void ApplyCoupon()
        {


            ClickOnElement(BtnCoupon, Driver);
            TypeText(BtnCoupon, ReadValuesFromFile("Coupon", Driver), Driver);
            Console.WriteLine(" the value of coupon is: " + ReadValuesFromFile("Coupon", Driver));
            ClickOnElement(BtnApplyCoupon, Driver);
            Thread.Sleep(3000); // pauses execution for 3 seconds 
            WaitForElementToBeVisible(Driver, BtnCheckout, 3, Driver);
            Console.WriteLine("Proceed to checkout button present");//console output 
        }


        public void VerifyDiscountIsAppliedCorrectly()
        {

            GetTextFromElement(BtnSubTotal, Driver); //returns string from element 
            Console.WriteLine("The SubTotal is : " + GetTextFromElement(BtnSubTotal, Driver));// console output 
            GetTextFromElement(TxtDiscAmt, Driver);//returns string from element 
            Console.WriteLine("discount amount:" + GetTextFromElement(TxtDiscAmt, Driver));// console output
            GetTextFromElement(TxtTotalAmt, Driver);
            Console.WriteLine("The total amount is:" + GetTextFromElement(TxtTotalAmt, Driver));
            GetTextFromElement(TxtShippingCost, Driver);
            Console.WriteLine("The Shipping cost is: " + GetTextFromElement(TxtShippingCost, Driver));

            var SubTotalCalc = Convert.ToDouble(GetTextFromElement(BtnSubTotal, Driver).Substring(1));// converts string to double and substring method returns the part of the string
            var DisCalc = Convert.ToDouble(GetTextFromElement(TxtDiscAmt, Driver).Substring(2, 4));// converts string to double and substring method returns the part of the string
            var TotalAmtCalc = Convert.ToDouble(GetTextFromElement(TxtTotalAmt, Driver).Substring(1));
            var ShippingCostCalc = double.Parse(GetTextFromElement(TxtShippingCost, Driver).Substring(12, 4));


            var TotalDisc = 0.15 * SubTotalCalc; //  calculates Total discount 
            var FinalTotalAmt = (SubTotalCalc - DisCalc) + (ShippingCostCalc);// calculates Final amount including shipping cost 


            if (TotalDisc == DisCalc) // checks for condition 
            {
                Console.WriteLine("Correct discount applied");// this will be printed if condition is true 
            }

            else
            {
                Console.WriteLine("Discount applied incorrectly");// this will be  an output message if condition is false 
            }

            // Assert.That(disCalc, Is.EqualTo(subTotalCalc).Within(10).Percent);

            try
            {
                Assert.AreEqual(TotalDisc, DisCalc, "Not Equal");// try this block 
            }
            catch (Exception e) // catch exception here 
            {

                Console.WriteLine(e);
            }

            Assert.AreEqual(TotalAmtCalc, FinalTotalAmt, "Not Equal");


        }

    }
}