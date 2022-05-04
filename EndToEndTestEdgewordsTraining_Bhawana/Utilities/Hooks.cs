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
    [Binding]// provides binding between step definition and scenario steps 
    public class Hooks
    {
        public static IWebDriver driver ; //declare the webdriver

        [Before] // this will run before every test case 
        public static void SetUp()
        {
            string browserName = "Chrome"; 



            if (browserName == "Chrome") // condition 
            {
                // if condition is true instantiate ChromeDriver driver 
                driver = new ChromeDriver();

            }
            else
            {

                // if condition is false instantiate FireforDriver driver 
                driver = new FirefoxDriver();

            }

            driver.Manage().Window.Maximize(); 
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5); //waits for page to load 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }



        [AfterScenario] // this executes after every scenario
        public void TakeScreenshot()
        {
            

            ITakesScreenshot? ssdriver = driver as ITakesScreenshot;

          
            //This code block takes a screenshot when a test case fails
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {

                Screenshot screenshot = ssdriver.GetScreenshot();

                screenshot.SaveAsFile("C:/Users/BhawanaSatyal/Documents/Screenshot/myscreenshot.png", ScreenshotImageFormat.Png);// path to a file to save screenshot 
                TestContext.AddTestAttachment("C:/Users/BhawanaSatyal/Documents/Screenshot/myscreenshot.png");

            }
        }
        [After] // this is executed after every Test Runs 
        public static void TearDown()
        {        
            driver.Quit();
        }
    }
}
