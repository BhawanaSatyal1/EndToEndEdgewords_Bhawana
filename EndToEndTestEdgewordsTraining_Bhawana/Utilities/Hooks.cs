using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndToEndTestEdgewordsTraining_Bhawana.Utilities
{
    [Binding]
    public class Hooks
    {
        public static IWebDriver driver ; //declare the webdriver

        [Before] // this will run before every test case 
        public static void SetUp()
        {
            string browserName = Environment.GetEnvironmentVariable("Browser", EnvironmentVariableTarget.Process);



            if (browserName == "FireFox") // condition 
            {
                driver = new FirefoxDriver(); // if condition is true instantiate FireforDriver driver 

            }
            else
            {

                driver = new ChromeDriver();// if condition is false instantiate ChromeDriver driver 


            }

            driver.Manage().Window.Maximize(); 
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5); //waits for page to load 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }



        [After] // this executes after every test case
        public void TakeScreenshot()
        {
            

            ITakesScreenshot ssdriver = driver as ITakesScreenshot;

            //This code block takes a screenshot when a test case fails
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {


                Screenshot screenshot = ssdriver.GetScreenshot();
                screenshot.SaveAsFile("C:/Users/BhawanaSatyal/Documents/Screenshot/myscreenshot.png", ScreenshotImageFormat.Png);// path to a file
                TestContext.AddTestAttachment("C:/Users/BhawanaSatyal/Documents/Screenshot/myscreenshot.png");

            }
        }
        [AfterTestRun] // this is executed after every Test Runs 
        public static void TearDown()
        {
            //  driver.Quit();
        }
    }
}
