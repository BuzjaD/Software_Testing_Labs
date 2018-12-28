using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using PageFactoryProject.Pages;
using System;

namespace PageFactoryProject
{
    class Program
    {

        static void Main(string[] args)
        {
         
        }
    }

    [TestFixture]
    class Test
    {
        private const string url = "https://tickets.kz/";
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Url = url;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }

        [Test]
        public void MinskToMinsk()
        {
            HomePage homePage = new HomePage(this.driver,this.wait);
            homePage.NewMainPageData("Минск", "Минск", "0", "9");
            Assert.AreEqual(homePage.getAlertMsg(), "Не найдены варианты перелёта, соответствующие вашим критериям");
        }
    }
}
