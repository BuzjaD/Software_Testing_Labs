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
    class PassengerPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement emailInput;

        [FindsBy(How = How.Id, Using = "user_form")]
        private IWebElement userForm;

        [FindsBy(How = How.XPath, Using = "//samp[contains(@class,'error')]")]
        private IWebElement error;

        [FindsBy(How = How.XPath, Using = "//input[@data-uil='to_pay']")]
        private IWebElement submitBtn;

        [FindsBy(How = How.Id, Using = "phone_number")]
        private IWebElement phoneInput;

        [FindsBy(How = How.Id, Using = "passengers_gender_0_chosen")]
        private IWebElement genderSelect;

        [FindsBy(How = How.XPath, Using = "//ul[@class='chosen-results']/li[2]")]
        private IWebElement genderM;

        [FindsBy(How = How.XPath, Using = "//ul[@class='chosen-results']/li[3]")]
        private IWebElement genderW;

        [FindsBy(How = How.Id, Using = "lastname_0")]
        private IWebElement lastname;

        [FindsBy(How = How.Id, Using = "firstname_0")]
        private IWebElement firstname;

        [FindsBy(How = How.Id, Using = "birthday_day_0")]
        private IWebElement bDay;

        [FindsBy(How = How.Id, Using = "birthday_month_0")]
        private IWebElement bMonth;

        [FindsBy(How = How.Id, Using = "birthday_year_0")]
        private IWebElement bYear;

        [FindsBy(How = How.Id, Using = "citizenship_name_0_chosen")]
        private IWebElement citizen;

        [FindsBy(How = How.Id, Using = "docnum_0")]
        private IWebElement docnum;

        [FindsBy(How = How.Id, Using = "doc_expire_date_day_0")]
        private IWebElement docDay;

        [FindsBy(How = How.Id, Using = "doc_expire_date_month_0")]
        private IWebElement docMonth;

        [FindsBy(How = How.Id, Using = "doc_expire_date_year_0")]
        private IWebElement docYear;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'attention_just_children_v3')]")]
        private IWebElement attentionSection;
        

        public PassengerPage(IWebDriver Driver, WebDriverWait Wait)
        {
            driver = Driver;
            wait = Wait;
            PageFactory.InitElements(Driver, this);
        }

        public void setPassengerData(string email, string phone, string gender, string Lastname,
            string Firstname, string d, string m, string y, string Citizen, string docNum,
            string dd, string dm, string dy)
        {
            driver.Navigate().GoToUrl("https://tickets.kz/avia/m/search/pre_booking?session_id=6c6c685c95aacafabbf18787b34b56c5&recommendation_id=36f3825910cf7a0a53d68041221e30a6_611%5E%5E0&route=MSQLON&vs=B2");
            wait.Until(ExpectedConditions.ElementToBeClickable(userForm));
            emailInput.SendKeys(email);
            phoneInput.SendKeys(phone);
            if (gender == "m")
            {
                genderSelect.Click();
                genderM.Click();
            }
            else if (gender == "w")
            {
                genderSelect.Click();
                genderW.Click();
            }
            lastname.SendKeys(Lastname);
            firstname.SendKeys(Firstname);
            bDay.SendKeys(d);
            bMonth.SendKeys(m);
            bYear.SendKeys(y);
            docnum.SendKeys(docNum);
            docDay.SendKeys(dd);
            docMonth.SendKeys(dm);
            docYear.SendKeys(dy);
            submitBtn.Submit();
        }

        public string dataValidation(string email,string phone, string gender, string Lastname,
            string Firstname, string d, string m, string y,string Citizen,string docNum,
            string dd, string dm, string dy)
        {
            setPassengerData(email, phone, gender, Lastname, Firstname, d, m, y, Citizen, docNum, dd, dm, dy);
            wait.Until(ExpectedConditions.ElementToBeClickable(error));
            return error.Text;
        }

        public string getAttentionMsg()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(attentionSection));
            return attentionSection.Text;
        }
    }
}
