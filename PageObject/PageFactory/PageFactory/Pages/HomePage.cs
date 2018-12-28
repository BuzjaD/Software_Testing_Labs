using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PageFactoryProject.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        private readonly string url = "https://tickets.kz/";
        private readonly WebDriverWait wait;

        [FindsBy(How = How.XPath, Using = "//label[@for='oneway']")]
        private IWebElement oneSide;

        [FindsBy(How = How.XPath, Using = "//label[@for='hotels-new-tab']")]
        private IWebElement hotels;

        [FindsBy(How = How.Id, Using = "from_name")]
        private IWebElement from;

        [FindsBy(How = How.Id, Using = "to_name")]
        private IWebElement to;

        [FindsBy(How = How.Id, Using = "departure_date")]
        private IWebElement datePicker;

        [FindsBy(How = How.Id, Using = "ui-datepicker-div")]
        private IWebElement calendar;

        [FindsBy(How = How.ClassName, Using = "search_button")]
        private IWebElement searchBtn;

        [FindsBy(How = How.Id, Using = "ui-id-1")]
        private IWebElement dropDownFrom;

        [FindsBy(How = How.Id, Using = "ui-id-2")]
        private IWebElement dropDownTo;

        public HomePage(IWebDriver driver, WebDriverWait Wait)
        {
            this.driver = driver;
            wait = Wait;
            PageFactory.InitElements(driver, this);
        }
  
        [FindsBy(How = How.XPath, Using = "//div[@class='allert-block']/p")]
        private IWebElement alertMsg;

        public void SetDate(string month, string date)
        {
            string resultStr = "//td[@data-month='" + month + "']";
            var weeks = calendar.FindElements(By.XPath(resultStr));

            foreach (var el in weeks)
            {
                if (el.Text == date)
                {
                    el.Click();
                    break;
                }
            }
        }

        public string getAlertMsg()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(alertMsg));
            return alertMsg.Text;
        }

        public void NewMainPageData(string From, string To, string month, string day)
        {
            driver.Navigate().GoToUrl(this.url);
            wait.Until(ExpectedConditions.ElementToBeClickable(oneSide));
            oneSide.Click();
            from.Clear();
            if (From != "")
            {
                from.SendKeys(From);
                wait.Until(ExpectedConditions.ElementToBeClickable(dropDownFrom));
                from.SendKeys(Keys.Enter);
            }
            to.Clear();
            if (To != "")
            {
                to.SendKeys(To);
                wait.Until(ExpectedConditions.ElementToBeClickable(dropDownTo));
                to.SendKeys(Keys.Enter);
            }
            datePicker.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(calendar));
            SetDate(month, day);
            if (From != "" && To != "")
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(hotels));
                hotels.Click();
            }

            searchBtn.Click();
        }
    }
}
