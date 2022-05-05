using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndToEndTestEdgewordsTraining_Bhawana.POM_pages
{
    [Binding]
    public class CompletePaymentPOM : Utilities.Helpers
    {
        // Locate element using By class
        By _btn_Proceed = (By.PartialLinkText("Proceed to checkout"));
        By _txt_FirstName = By.Id("billing_first_name");
        By _txt_LastName = (By.Id("billing_last_name"));
        By _txt_HouseNum_Name = (By.Id("billing_address_1"));
        By _txt_City = (By.Id("billing_city"));
        By _txt_Postcode = (By.Id("billing_postcode"));
        By _txt_PhoneNum = (By.Id("billing_phone"));
        By _btn_PlaceOrder = (By.Id("place_order"));
        By _txt_Billing_Email = (By.Id("billing_email"));
        By _btn_MyAcc = By.LinkText("My account");
        By _btn_Orders = By.PartialLinkText("Orders");
        By _btn_LogOut = By.PartialLinkText("Logout");
        By _check_Payment = By.CssSelector("#payment_method_cheque");
        By _txt_Final_OrderNum = By.XPath("//div/table/tbody/tr[1]/td[@data-title='Order']");
        By _txt_OrderNum = By.CssSelector(".order > strong"); 




        // method clicks on checkout button 
        public void userClickOnCheckOutButton()
        {
            ClickOnElement(_btn_Proceed);


        }

        public void userFillsUpBillingInformation()
        {


            // driver find lists of elements 
            IList<IWebElement> elements = driver.FindElements(By.XPath("//div[@class='woocommerce-billing-fields__field-wrapper']/p/span/input"));
            // for loop used to perform iteration until the condition becomes false  
            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].Clear();

            }

            // reuseable methods used from a parent class Helpers 
            TypeText(_txt_FirstName, ReadValuesFromFile("FirstName"));
            TypeText(_txt_LastName, ReadValuesFromFile("LastName"));
            TypeText(_txt_HouseNum_Name, ReadValuesFromFile("HouseName"));
            TypeText(_txt_City, ReadValuesFromFile("City"));
            TypeText(_txt_Postcode, ReadValuesFromFile("Postcode"));
            TypeText(_txt_PhoneNum, ReadValuesFromFile("PhoneNum"));
            TypeText(_txt_Billing_Email, ReadValuesFromFile("Bil_Email"));


            string checkPayment = driver.FindElement(By.CssSelector("#payment_method_cheque")).GetAttribute("checked");

            if (checkPayment.Equals("true")) // checks for condition 
            {
                Console.WriteLine("Checkbox Selected"); // if condition is true this will get printed 

            }
            else
            {
                ClickOnElement(_check_Payment); // if condition is false method clicks on check payment 
            }

        }
        public void UserClicksOnPlaceOrder()
        {
            Thread.Sleep(2000); // this suspends execution for 2 seconds 
            ClickOnElement((_btn_PlaceOrder));


        }
        //after comparing two order numbers this method logs user out of account 
        public void UserCompletesOrderAndReturnsToHomePage()
        {
            var orderNum1 = GetTextFromElement(_txt_OrderNum);
            Console.WriteLine("The order number is: " + orderNum1);// prints this message 
            ClickOnElement(_btn_MyAcc);
            ClickOnElement(_btn_Orders);
            GetTextFromElement(_txt_Final_OrderNum);
            var finalOrdeNum1 = GetTextFromElement(_txt_Final_OrderNum).Substring(1);// substring match and converts to double 
            Console.WriteLine("The final order number is: " +finalOrdeNum1);
            Assert.AreEqual(orderNum1, finalOrdeNum1, "Not Equal"); // compares two values 
            Console.WriteLine("The order numbers match");
            // reusable method used to click on logout button 
            ClickOnElement(_btn_LogOut);
            Console.WriteLine("Logged Out successfully");


        }



    }

}