using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebDriverATF2.Steps
{
    class Steps
    {
        IWebDriver driver;
        WebDriverWait wait;
        Pages.MainPage mainPage;
        Pages.ResultPage resultPage;
        Pages.PassengerPage passengerPage;

        public void InitBrowser()
        {
            driver = Driver.Driver.GetInstance();
            wait = Driver.Driver.GetWait();
        }

        public void CloseBrowser()
        {
            Driver.Driver.CloseBrowser();
        }

        public string SetPersonData(string email, string phone, string gender, string lastname,
            string firstname, string d, string m, string y, string citizen, string docNum,
            string dd, string dm, string dy)
        {
            passengerPage = new Pages.PassengerPage(this.driver, this.wait);
            return passengerPage.dataValidation(email, phone, gender, lastname, firstname, d, m, y, citizen, docNum, dd, dm, dy);
        }

        public void SetMainData(string CityFrom, string CityTo, string DateFrom, string DateTo)
        {
            mainPage = new Pages.MainPage(this.driver, this.wait);
            mainPage.NewMainPageData(CityFrom, CityTo, DateFrom, DateTo);
        }

        public string setFromInput(string CityFrom)
        {
            mainPage = new Pages.MainPage(this.driver, this.wait);
           return mainPage.checkFromInputData(CityFrom);
        }

        public string getMainFromPageError()
        {
            return mainPage.getErrorMsg();
        }

        public void getFirstResult()
        {
            resultPage = new Pages.ResultPage(this.driver, this.wait);
            resultPage.FirstResult();
        }

        public string getInfantsCount(int count)
        {
            mainPage = new Pages.MainPage(this.driver, this.wait);
            return mainPage.infantsCount(count);
        }

        public void SetCorrectPersonData(string email, string phone, string gender, string lastname,
            string firstname, string d, string m, string y, string citizen, string docNum,
            string dd, string dm, string dy)
        {
            passengerPage = new Pages.PassengerPage(this.driver, this.wait);
            passengerPage.setPassengerData(email, phone, gender, lastname, firstname, d, m, y, citizen, docNum, dd, dm, dy);
        }

        public string getAttention()
        {
            return passengerPage.getAttentionMsg();
        }

        public string getAlertData()
        {
            return mainPage.getAlertMsg();
        }
        
    }
}
