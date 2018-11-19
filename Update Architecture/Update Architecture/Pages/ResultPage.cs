using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace Update_Architecture.Pages
{
    public class ResultPage
    {
        private IWebDriver driver;

        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".change-dates li.active > .day .price")]
        private IWebElement activeTabPrice;

        [FindsBy(How = How.CssSelector, Using = ".economy-price .price")]
        private IList<IWebElement> prices;

        [FindsBy(How = How.CssSelector, Using = ".economy-price")]
        private IList<IWebElement> economPrices;
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Найти')]")]
        private IWebElement submitBtn;

        public PassengerPage getEconomTicket()
        {
            economPrices[0].Click();
            IWebElement firstEl = driver.FindElement(By.CssSelector(".brand.er"));
            firstEl.Click();
            IWebElement nextButton = driver.FindElement(By.XPath("//button[contains(text(),'Далее')]"));
            nextButton.Click();
            Thread.Sleep(1000);
            return new PassengerPage(driver);
        }

        public bool checkMinPrice()
        {
            double minPrice = Convert.ToDouble(activeTabPrice.Text.Split('\n')[1].Split(' ')[0]);
            double min = Convert.ToDouble(prices[0].Text.Split(' ')[0]);

            foreach (var el in prices)
            {
                double price = Convert.ToDouble(el.Text.Split(' ')[0]);
                if (price < min)
                {
                    min = price;
                }
            }

            return (min == minPrice);
        }
    }
}