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

        //Test validation, when user try to pick uncorrect date
        [Test]
        public void Test()
        {
            driver.Url = "https://belavia.by/";

            IWebElement searchForm = driver.FindElement(By.Id("ibe"));
            IWebElement from = searchForm.FindElement(By.Id("OriginLocation_Combobox"));
            IWebElement to = searchForm.FindElement(By.Id("DestinationLocation_Combobox"));
            IWebElement oneSide = searchForm.FindElement(By.XPath("//label[@for='JourneySpan_Ow']"));
            IWebElement dateInput = searchForm.FindElement(By.ClassName("ui-date-input"));
            IWebElement dateField = searchForm.FindElement(By.Id("DepartureDate_Datepicker"));
    
            from.Clear();
            from.SendKeys("Минск");
            to.Clear();
            to.SendKeys("Лондон");
            oneSide.Click();
            dateInput.Click();
            SetDate("9","9");//old date 9.10.2018
            searchForm.FindElement(By.Id("DestinationLocation_Combobox")).SendKeys(Keys.Enter);
            Assert.IsTrue(dateField.GetAttribute("class").Contains("input-validation-error"));
        }
    }
}
