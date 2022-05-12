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
    public class Hooks
    {
        private readonly DriverHelper _driverHelper;
        public Hooks(DriverHelper driverHelper) => _driverHelper = driverHelper;


        [Before] // this will run before every test case 
        public void SetUp()
        {

            string browserName = TestContext.Parameters["BrowserName"];


            if (browserName == "Chrome") // condition 
            {
                // if condition is true instantiate ChromeDriver driver 
                _driverHelper.Driver = new ChromeDriver();

            }
            // if condition is true instantiate EdgeDriver driver 
            else if (browserName == "Edge")
            {
                _driverHelper.Driver = new EdgeDriver();
            }
            else
            {

                // if condition is false instantiate FirefoDriver driver 
                _driverHelper.Driver = new FirefoxDriver();

            }
            _driverHelper.Driver.Manage().Window.Maximize();
            _driverHelper.Driver.Navigate().GoToUrl(TestContext.Parameters["Url"]);
            _driverHelper.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5); //waits for page to load 
            _driverHelper.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


        }

        [After] // this executes after every testruns 
        public void TearDown()
        {
            TakeScreenshot();
            EmptyCart();
            CloseBrowser();

        }
        public void TakeScreenshot()
        {


            ITakesScreenshot? ssdriver = _driverHelper.Driver as ITakesScreenshot;

            //This code block takes a screenshot when a test case fails
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                string dateToday = DateTime.Now.ToString("ddMMyyyyHHmmss");
                Screenshot screenshot = ssdriver.GetScreenshot();
                screenshot.SaveAsFile("C:/Users/BhawanaSatyal/Documents/Screenshot/myscreenshot" + dateToday + ".png", ScreenshotImageFormat.Png);// path to a file to save screenshot 
                TestContext.AddTestAttachment("C:/Users/BhawanaSatyal/Documents/Screenshot/myscreenshot" + dateToday + ".png");

            }
        }
        // this is executed after every Test Runs 
        public void EmptyCart()
        {
            string checkCart = _driverHelper.Driver.FindElement(By.CssSelector("a > .amount.woocommerce-Price-amount")).Text.Substring(1);
            var convertCheckCart = double.Parse(checkCart);
            Console.WriteLine("The cart value is :" + convertCheckCart);
            if (convertCheckCart > 0.00)
            {
                _driverHelper.Driver.FindElement(By.CssSelector("a > .amount.woocommerce-Price-amount")).Click();
                _driverHelper.Driver.FindElement(By.CssSelector(".remove")).Click();
            }
            else
            {
                Console.WriteLine("The cart is empty");
            }

            _driverHelper.Driver.FindElement(By.LinkText("My account")).Click();
            _driverHelper.Driver.FindElement(By.PartialLinkText("Logout")).Click();
        }

        public void CloseBrowser()
        {
            _driverHelper.Driver.Close();
            _driverHelper.Driver.Quit(); // close browser
        }

    }
}

