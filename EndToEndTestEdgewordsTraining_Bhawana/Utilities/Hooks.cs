using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndToEndTestEdgewordsTraining_Bhawana.Utilities
{
    [Binding]// provides binding between step definition and scenario steps 
    public class Hooks : BasePage
    {

        [Before] // this will run before every test case 
        public void SetUp()
        {

            string browserName = TestContext.Parameters["BrowserName"];


            if (browserName == "Chrome") // condition 
            {
                // if condition is true instantiate ChromeDriver driver 
                driver = new ChromeDriver();

            }
            // if condition is true instantiate EdgeDriver driver 
            else if (browserName == "Edge")
            {
                driver = new EdgeDriver();
            }
            else
            {

                // if condition is false instantiate FireforDriver driver 
                driver = new FirefoxDriver();

            }
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(TestContext.Parameters["Url"]);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5); //waits for page to load 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


        }



        [After] // this executes after every testruns 
        public void TakeScreenshot()
        {


            ITakesScreenshot? ssdriver = driver as ITakesScreenshot;

            //This code block takes a screenshot when a test case fails
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                string dateToday = DateTime.Now.ToString("ddMMyyyyHHmmss");
                Screenshot screenshot = ssdriver.GetScreenshot();
                screenshot.SaveAsFile("C:/Users/BhawanaSatyal/DocumentsScreenshot/myscreenshot" + dateToday + ".png", ScreenshotImageFormat.Png);// path to a file to save screenshot 
                TestContext.AddTestAttachment("C:/Users/BhawanaSatyal/Documents/Screenshot/myscreenshot" + dateToday + ".png");

            }
        }
        [After] // this is executed after every Test Runs 
        public void EmptyCart()
        {
            string checkCart = driver.FindElement(By.CssSelector("a > .amount.woocommerce-Price-amount")).Text.Substring(1);
            var convertCheckCart = double.Parse(checkCart);
            Console.WriteLine("The cart value is :" + convertCheckCart);
            if (convertCheckCart > 0.00)
            {
                driver.FindElement(By.CssSelector("a > .amount.woocommerce-Price-amount")).Click();
                driver.FindElement(By.CssSelector(".remove")).Click();
            }
            else
            {
                Console.WriteLine("The cart is empty");
            }

            driver.FindElement(By.LinkText("My account")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        [After]
        public void TearDown()
        {
            driver.Close();
            driver.Quit(); // close browser
        }

    }
}

