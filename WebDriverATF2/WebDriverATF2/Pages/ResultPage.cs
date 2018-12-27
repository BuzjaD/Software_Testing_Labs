using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebDriverATF2.Pages
{
    class ResultPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        [FindsBy(How = How.ClassName, Using = "rec_submit")]
        private IList<IWebElement> chooseBtn;

        [FindsBy(How = How.Id, Using = "offers_table")]
        private IWebElement offers;
        

        public ResultPage(IWebDriver Driver, WebDriverWait Wait)
        {
            driver = Driver;
            wait = Wait;
            PageFactory.InitElements(Driver, this);
        }

        public void FirstResult()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(offers));//first result
            chooseBtn[0].Click();
        }
    }
}
