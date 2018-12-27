using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverATF2.Driver
{
    class Driver
    {
         private static IWebDriver driver;
        private static WebDriverWait wait;

        private Driver() { }
        
        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
                driver.Manage().Window.Maximize();
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
            }
            return driver;
        }

        public static WebDriverWait GetWait()
        {
            return wait;
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
    }
}
