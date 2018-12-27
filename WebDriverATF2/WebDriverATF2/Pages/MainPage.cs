using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverATF2.Pages
{
    class MainPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private string BabyCount;
        private readonly string url = "https://tickets.kz/";

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

        [FindsBy(How = How.XPath, Using = "//samp[@class='error']")]
        private IWebElement error;

        [FindsBy(How = How.ClassName, Using = "airp_code")]
        private IWebElement cityCode;

        [FindsBy(How = How.ClassName, Using = "swap")]
        private IWebElement swapBtn;
        
        [FindsBy(How = How.ClassName, Using = "js-infants-plus")]
        private IWebElement infantsPlus;
        
        [FindsBy(How = How.ClassName, Using = "infants")]
        private IWebElement infantsValue;

        [FindsBy(How = How.ClassName, Using = "preson_quant")]
        private IWebElement personSelect;

        [FindsBy(How = How.XPath, Using = "//div[@class='allert-block']/p")]
        private IWebElement alertMsg;

        public MainPage(IWebDriver Driver, WebDriverWait Wait)
        {
            this.driver = Driver;
            wait = Wait;
            PageFactory.InitElements(Driver, this);
        }

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
            if(From != "" && To != "")
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(hotels));
                hotels.Click();
            }
           
            searchBtn.Click();
        }

        public string getErrorMsg()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(error));
            return error.Text;
        }

        public string checkFromInputData(string From)
        {
            driver.Navigate().GoToUrl(this.url);
            wait.Until(ExpectedConditions.ElementToBeClickable(from));
            from.SendKeys(From);
            wait.Until(ExpectedConditions.ElementToBeClickable(dropDownFrom));
            from.SendKeys(Keys.Enter);
            swapBtn.Click();//check data after swap two times
            swapBtn.Click();
            return cityCode.Text;
        }

        public string infantsCount(int count)
        {
            driver.Navigate().GoToUrl(this.url);
            wait.Until(ExpectedConditions.ElementToBeClickable(personSelect));
            personSelect.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(infantsPlus));
            for (int i =0; i < count; i++)
            {
                infantsPlus.Click();
            }
            return infantsValue.GetAttribute("value");
        }

        public string getAlertMsg()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(alertMsg));
            return alertMsg.Text;
        }

    }
}
