using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndToEndTestEdgewordsTraining_Bhawana.Utilities
{
    public class Helpers
    {

        // Reusable method to mimic clicking an element
        public static void ClickOnElement(By by, IWebDriver Driver)
        {
            Driver.FindElement(by).Click();
        }

        // Reusable method to type texts in textbox
        public static void TypeText(By by, String text, IWebDriver Driver)
        {
            Driver.FindElement(by).SendKeys(text);
        }

        // Reusable method to direct webdriver to wait for 5 seconds 
        public static void WaitForTimeInSec(int timeoutInSeconds, IWebDriver Driver)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutInSeconds);
        }

        // Reusable method to read  and write using TextContext variables
        public static string ReadValuesFromFile(string text, IWebDriver Driver)

        {
            return TestContext.Parameters[text];
        }

        public static string GetTextFromElement(By by, IWebDriver Driver)
        {
            return Driver.FindElement(by).Text;
        }
        // Reusable method for general webdriverwait 
        public static void WaitForElementToBeVisible(IWebDriver driver, By by, int timeoutInSeconds, IWebDriver Driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(drv => drv.FindElement(by).Displayed);
        }

        public static IWebElement GetElement(By by, IWebDriver Driver)
        {
            return Driver.FindElement(by);
        }
    }
}