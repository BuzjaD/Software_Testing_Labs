using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using PageFactoryProject.Pages;

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
        private const string url = @"https://belavia.by/";
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Url = url;
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }

        [Test]
        public void CheckCorrectActivePrice()
        {
            HomePage homePage = new HomePage(driver);
            ResultPage resultPage = homePage.GoToResultPage("Минск", "Лондон", "0", "9");
            Assert.IsTrue(resultPage.checkMinPrice());
        }
    }
}
