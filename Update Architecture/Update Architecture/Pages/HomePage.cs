﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace Update_Architecture.Pages
{
    public class HomePage
    {
        private IWebDriver driver;

        private const string BASE_URL = "https://belavia.by/";

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "OriginLocation_Combobox")]
        private IWebElement fromCombobox;

        [FindsBy(How = How.Id, Using = "DestinationLocation_Combobox")]
        private IWebElement toCombobox;

        [FindsBy(How = How.ClassName, Using = "ui-date-input")]
        private IWebElement datePicker;

        [FindsBy(How = How.Id, Using = "calendar")]
        private IWebElement calendar;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Найти')]")]
        private IWebElement submitBtn;

        [FindsBy(How = How.XPath, Using = "//label[@for='JourneySpan_Ow']")]
        private IWebElement oneSide;

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
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


        public ResultPage GoToResultPage(string fromStr, string toStr, string month, string date)
        {
            fromCombobox.Clear();
            fromCombobox.SendKeys(fromStr);
            toCombobox.Clear();
            toCombobox.SendKeys(toStr);
            oneSide.Click();
            datePicker.Click();
            SetDate(month, date);
            Thread.Sleep(1000);
            submitBtn.Submit();
            driver.Navigate().GoToUrl("https://ibe.belavia.by/select/MSQLON/2018-11-23/adults-1/children-0/infants-0?culture=ru");
            Thread.Sleep(1000);
            return new ResultPage(driver);
        }
    }
}