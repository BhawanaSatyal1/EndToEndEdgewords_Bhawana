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

    public class AddToCart : Utilities.Helpers
    {
        //action class defined and invoked to handle keyboard and mouse events 
        Actions actions = new Actions(driver);
        // Locate element using By class
        By _btn_Shop = By.LinkText("Shop");
        By _btn_Home = By.LinkText("Home");
        By _btn_Cart = By.LinkText("Cart");
        By _btn_Hoodie = By.XPath("//a[@href='/demo-site/shop/?add-to-cart=32']");
        By _btn_Viewcart = By.XPath("//a[@title='View cart']");
        By _btn_Coupon = By.CssSelector("input#coupon_code");
        By _btn_Apply_Coupon = By.CssSelector("button[name='apply_coupon']");
        By _btn_Coupon_Calculation = By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount");
        By _btn_Subtotal = By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount");
        By _btn_LogOut = By.PartialLinkText("Logout");
        By _btn_MyAcc = By.LinkText("My account");
        By _btn_SubTotal = By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount");
        By _txt_Disc_Amt = By.CssSelector(".cart-discount.coupon-edgewords > td");
        By _txt_Total_Amt = By.CssSelector("strong > .amount.woocommerce-Price-amount");
        By _txt_Shipping_Cost = By.CssSelector(".shipping > td");



        public void UserLogsIn()
        {

            StepDefinitions.LogIn login = new StepDefinitions.LogIn();
            login.WhenITypeInValidUsername();
            login.WhenITypeInValidPassword();




        }



        // this method is used to move mouse pointer between tabs 
        public void HoverAroundCatergories()
        {
            actions.MoveToElement(driver.FindElement(_btn_Home)).Build().Perform();

            actions.MoveToElement(driver.FindElement(_btn_Shop)).Build().Perform();
            ImpWait05Secs();

            actions.MoveToElement(driver.FindElement(_btn_Cart)).Build().Perform();

            Console.WriteLine("Hover Action performed");// system output 

        }

        public void ClickOnShop()
        {
            ClickOnElement(_btn_Shop);
        }

        public void ClickOnHoodieWithPocket()
        {
            ClickOnElement(_btn_Hoodie);

        }

        public void ClickOnViewcartButton()
        {
            ClickOnElement(_btn_Viewcart);
        }
        // method applies coupon code 
        public void ApplyCoupon()
        {


            ClickOnElement(_btn_Coupon);

            TypeText(_btn_Coupon, ReadValuesFromFile("Coupon"));
            Console.WriteLine(" the value of coupon is: " + ReadValuesFromFile("Coupon"));
            ClickOnElement(_btn_Apply_Coupon);
            Thread.Sleep(3000);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5)); //applied explicit wait 
            wait.Until(drv => drv.FindElement(By.CssSelector(".alt.button.checkout-button.wc-forward")).Displayed);// waits for condition to be displayed before proceeding with execution 
            Console.WriteLine("Proceed to checkout button present");//console output 
        }


        public void VerifyDiscountIsAppliedCorrectly()
        {

            GetTextFromElement(_btn_SubTotal); //returns string from element 
            Console.WriteLine("The SubTotal is : " + GetTextFromElement(_btn_SubTotal));// console output 

            GetTextFromElement(_txt_Disc_Amt);//returns string from element 
            Console.WriteLine("discount amount:" + GetTextFromElement(_txt_Disc_Amt));// console output


            GetTextFromElement(_txt_Total_Amt);
            Console.WriteLine("The total amount is:" + GetTextFromElement(_txt_Total_Amt));


            GetTextFromElement(_txt_Shipping_Cost);
            Console.WriteLine("The Shipping cost is: " + GetTextFromElement(_txt_Shipping_Cost));

            var subTotalCalc = Convert.ToDouble(GetTextFromElement(_btn_SubTotal).Substring(1));// converts string to double and substring method returns the part of the string
            var disCalc = Convert.ToDouble(GetTextFromElement(_txt_Disc_Amt).Substring(2, 4));// converts string to double and substring method returns the part of the string
            var totalAmtCalc = Convert.ToDouble(GetTextFromElement(_txt_Total_Amt).Substring(1));
            var shippingCostCalc = double.Parse(GetTextFromElement(_txt_Shipping_Cost).Substring(12, 4));


            var TotalDisc = 0.15 * subTotalCalc; //  calculates Total discount 
            var FinalTotalAmt = (subTotalCalc - disCalc) + (shippingCostCalc);


            if (TotalDisc == disCalc) // checks for condition 
            {
                Console.WriteLine("Correct discount applied");// this will be printed if condition is true 
            }

            else
            {
                Console.WriteLine("Discount applied incorrectly");// this will be  an output message if condition is false 
            }

            //   Assert.That(disCalc, Is.EqualTo(subTotalCalc).Within(10).Percent);

            try
            {
                Assert.AreEqual(TotalDisc, disCalc, "Not Equal");// try this block 
            }
            catch (Exception e) // catch exception here 
            {

                Console.WriteLine(e);
            }

            Assert.AreEqual(totalAmtCalc, FinalTotalAmt, "Not Equal");


        }

        public void UserLogsOut()
        {
       
            ClickOnElement(_btn_MyAcc);
            ClickOnElement(_btn_LogOut);
        }


    }
}