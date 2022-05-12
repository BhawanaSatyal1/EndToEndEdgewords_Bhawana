using EndToEndTestEdgewordsTraining_Bhawana.Utilities;
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

    public class CompletePaymentPOM : Utilities.Helpers
    {
        // Locate element using By class
        By BtnProceed = (By.PartialLinkText("Proceed to checkout"));
        By TxtFirstName = By.Id("billing_first_name");
        By TxtLastName = (By.Id("billing_last_name"));
        By TxtHouseNumName = (By.Id("billing_address_1"));
        By TxtCity = (By.Id("billing_city"));
        By TxtPostcode = (By.Id("billing_postcode"));
        By TxtPhoneNum = (By.Id("billing_phone"));
        By BtnPlaceOrder = (By.Id("place_order"));
        By TxtBillingEmail = (By.Id("billing_email"));
        By BtnMyAcc = By.LinkText("My account");
        By BtnOrders = By.PartialLinkText("Orders");
        By BtnLogOut = By.PartialLinkText("Logout");
        By CheckPayment = By.CssSelector("#payment_method_cheque");
        By TxtFinalOrderNum = By.XPath("//div/table/tbody/tr[1]/td[@data-title='Order']");
        By TxtOrderNum = By.CssSelector(".order > strong");


        private IWebDriver Driver;
        public CompletePaymentPOM(IWebDriver driver)
        {
            Driver = driver;
        }


        // method clicks on checkout button 
        public void UserClickOnCheckOutButton()
        {
            ClickOnElement(BtnProceed, Driver);
        }

        public void UserFillsUpBillingInformation(Utilities.BillingDetails billingDetails)
        {
            // driver find lists of elements 
            IList<IWebElement> elements = Driver.FindElements(By.XPath("//div[@class='woocommerce-billing-fields__field-wrapper']/p/span/input"));
            // for loop used to perform iteration until the condition becomes false  
            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].Clear();

            }

            TypeText(TxtFirstName, billingDetails.FirstName, Driver);
            TypeText(TxtLastName, billingDetails.LastName, Driver);
            TypeText(TxtHouseNumName, billingDetails.HouseName, Driver);
            TypeText(TxtCity, billingDetails.City, Driver);
            TypeText(TxtPostcode, billingDetails.Postcode, Driver);
            TypeText(TxtPhoneNum, billingDetails.PhoneNum.ToString(), Driver);
            TypeText(TxtBillingEmail, billingDetails.Bil_Email, Driver);

            string CheckPayment = Driver.FindElement(By.CssSelector("#payment_method_cheque")).GetAttribute("checked");

            if (CheckPayment.Equals("true")) // checks for condition 
            {
                Console.WriteLine("Checkbox Selected"); // if condition is true this will get printed 

            }
            else
            {
                ClickOnElement(this.CheckPayment, Driver); // if condition is false method clicks on check payment 
            }

        }
        public void UserClicksOnPlaceOrder()
        {
            Thread.Sleep(2000); // this suspends execution for 2 seconds 
            ClickOnElement((BtnPlaceOrder), Driver);


        }
        //after comparing two order numbers this method logs user out of account 
        public void UserCompletesOrderAndReturnsToHomePage()
        {
            var orderNum1 = GetTextFromElement(TxtOrderNum, Driver);
            Console.WriteLine("The order number is: " + orderNum1);// prints this message 
            ClickOnElement(BtnMyAcc, Driver);
            ClickOnElement(BtnOrders, Driver);
            GetTextFromElement(TxtFinalOrderNum, Driver);
            var finalOrdeNum1 = GetTextFromElement(TxtFinalOrderNum, Driver).Substring(1);// substring match and converts to double 
            Console.WriteLine("The final order number is: " + finalOrdeNum1);
            Assert.AreEqual(orderNum1, finalOrdeNum1, "Not Equal"); // compares two values 
            Console.WriteLine("The order numbers match");

        }

    }

}