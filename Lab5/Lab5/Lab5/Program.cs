using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    [TestFixture]
    class Tests
    {
        

        IWebDriver driver;

        public void SetDate(String month, String date)
        {
            IWebElement calendar = driver.FindElement(By.Id("calendar"));
            var weeks = calendar.FindElements(By.TagName("td"));
            foreach (var el in weeks)
            {
                if (el.GetAttribute("data-month") == month)
                {
                    IWebElement link = el.FindElement(By.ClassName("ui-state-default"));
                    if (link.Text == date)
                    {

                        link.Click();
                        break;
                    }
                }
            }
        }

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void cleanup()
        {
            driver.Quit();
        }

        [Test]
        public void Test()
        {
            driver.Url = "https://belavia.by/";

            IWebElement searchForm = driver.FindElement(By.Id("ibe"));
            IWebElement from = searchForm.FindElement(By.Id("OriginLocation_Combobox"));
            from.Clear();
            from.SendKeys("Минск");
            Thread.Sleep(1000);
            from.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            IWebElement to = searchForm.FindElement(By.Id("DestinationLocation_Combobox"));
            to.Clear();
            to.SendKeys("Минск");
            Thread.Sleep(1000);
            to.SendKeys(Keys.Enter);

            searchForm.FindElement(By.ClassName("ui-date-input")).Click();
            Thread.Sleep(1000);
            SetDate("10","20");
            Thread.Sleep(1000);
            SetDate("10", "30");
            Thread.Sleep(1000);
            searchForm.FindElement(By.Id("DestinationLocation_Combobox")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
        }
    }
}
