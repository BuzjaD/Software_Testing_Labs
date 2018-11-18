using OpenQA.Selenium;

namespace Update_Architecture.Steps
{
    public class Steps
    {
        private IWebDriver driver;

        private const string BASE_URL = @"https://belavia.by/";

        public void InitBrowser()
        {
            driver = Driver.Driver.GetInstance();
            driver.Url = BASE_URL;
        }

        public void CloseBrowser()
        {
            Driver.Driver.CloseBrowser();
        }
        
        public void checkBirthDate(string fromStr, string toStr, string month, string date, string birthDate)
        {
            Pages.HomePage homePage = new Pages.HomePage(driver);
            homePage.OpenPage();
            Pages.ResultPage resultPage = homePage.GoToResultPage(fromStr, toStr, month, date);
            Pages.PassengerPage passengerPage = resultPage.getEconomTicket();
            passengerPage.CheckBirthDate(birthDate);
        }

        public bool checkActiveTabPrice(string fromStr, string toStr, string month, string date)
        {
            Pages.HomePage homePage = new Pages.HomePage(driver);
            homePage.OpenPage();
            Pages.ResultPage resultPage = homePage.GoToResultPage(fromStr, toStr, month, date);
            return resultPage.checkMinPrice();
        }
    }
}