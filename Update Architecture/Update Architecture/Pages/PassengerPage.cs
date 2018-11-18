using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;

namespace Update_Architecture.Pages
{
    public class PassengerPage
    {
        private IWebDriver driver;

        public PassengerPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "p_0_dateOfBirth")]
        private IWebElement dateOfBirthField;

        [FindsBy(How = How.CssSelector, Using = "#p_0_dateOfBirth + .field-validation-error")]
        private IWebElement validationField;        

        private string errMessage = "Дата больше ограничения по возврасту пассажира";

        public bool CheckBirthDate(string date)
        {
            dateOfBirthField.SendKeys(date);
            dateOfBirthField.SendKeys(Keys.Enter);
            return (validationField.Text == errMessage);
        }
    }
}
