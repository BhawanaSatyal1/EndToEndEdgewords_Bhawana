using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndToEndTestEdgewordsTraining_Bhawana.Utilities
{
    public class Helpers : Hooks
    {

        // Reusable method to mimic clicking an element
        public void ClickOnElement(By by)
        {
            driver.FindElement(by).Click();
        }

        // Reusable method to type texts in textbox
        public void TypeText(By by, String text) 
        { 
            driver.FindElement(by).SendKeys(text); 
        }

        // Reusable method to direct webdriver to wait for 5 seconds 
        public void ImpWait05Secs()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        
        // Reusable method to read  and write using TextContext variables
        public string ReadValuesFromFile(string text)

        {
              return TestContext.Parameters[text];



        }

        public string GetTextFromElement(By by)
        {
            return driver.FindElement(by).Text; 
        }
        
    }
}