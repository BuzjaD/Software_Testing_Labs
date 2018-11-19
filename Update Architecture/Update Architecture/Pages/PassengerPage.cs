using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

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

        [FindsBy(How = How.ClassName, Using = "field-validation-error")]
        private IList<IWebElement> validationFields;        

        public bool CheckBirthDate(string date)
        {
            string executeStr = "document.getElementById('p_0_dateOfBirth').value = '" + date + "'";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            Thread.Sleep(2000);
            dateOfBirthField.SendKeys(date);
            js.ExecuteScript(executeStr);
            Thread.Sleep(2000);
            dateOfBirthField.SendKeys(Keys.Enter);
            Thread.Sleep(5000);
            return (validationFields[3].Text.Length != 0);
        }
    }
}
