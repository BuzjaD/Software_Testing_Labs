using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverATF2.Tests
{
    [TestFixture]
    class Tests
    {
        private Steps.Steps steps = new Steps.Steps();

        [SetUp]
        public void SetupTest()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void TeardownTest()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void CheckAutocomplete()
        {
            Assert.AreEqual(steps.setFromInput("Минск"), "MSQ");
        }

        [Test]
        public void CheckCorrectEmail()
        {
            steps.SetMainData("Минск", "Лондон", "0", "9");
            steps.getFirstResult();
            Assert.AreEqual(steps.SetPersonData("aabbaa","1232422211","m",
                "Bukov","Ashot","10","01","1996", "Казахстан", "MK2321222",
                "11","11","2024"), "Пожалуйста, введите корректный адрес электронной почты");
        }

        [Test]
        public void EmptyCityName()
        {
            steps.SetMainData("", "Лондон", "0", "9");
            Assert.AreEqual(steps.getMainFromPageError(), "Это поле необходимо заполнить");
        }

        [Test]
        public void InfantsCountAfterManyTaps()
        {
            int count = 5;
            Assert.AreEqual(steps.getInfantsCount(count), "1");
        }

        [Test]
        public void CheckCorrectPhoneNumber()
        {
            steps.SetMainData("Минск", "Лондон", "0", "9");
            steps.getFirstResult();
            Assert.AreEqual(steps.SetPersonData("my@mail.ru", "2529214", "m",
               "Bukov", "Ashot", "10", "01", "1996", "Казахстан", "MK2321222",
               "11", "11", "2024"), "Пожалуйста, введите корректный номер телефона");//uncorrect for KZ
        }

        [Test]
        public void CheckEmptyPassengerInfoField()
        {
            steps.SetMainData("Минск", "Лондон", "0", "9");
            steps.getFirstResult();
            Assert.AreEqual(steps.SetPersonData("my@mail.ru", "1232422211", "m",
               "", "Ashot", "10", "01", "1996", "Казахстан", "MK2321222",
               "11", "11", "2024"), "Это поле необходимо заполнить");
        }

        [Test]
        public void CheckCorrectPassportData()
        {
            steps.SetMainData("Минск", "Лондон", "0", "9");
            steps.getFirstResult();
            Assert.AreEqual(steps.SetPersonData("my@mail.ru", "1232422211", "m",
               "Bukov", "Ashot", "10", "01", "1996", "Казахстан", "11111111",
               "11", "11", "2024"), "Формат введенных данных неверный");
        }

        [Test]
        public void CheckExpirePassportDate()
        {
            steps.SetMainData("Минск", "Лондон", "0", "9");
            steps.getFirstResult();
            Assert.AreEqual(steps.SetPersonData("my@mail.ru", "1232422211", "m",
               "Bukov", "Ashot", "10", "01", "1996", "Казахстан", "MK2321222",
               "11", "11", "2016"), "Укажите действительную дату в формате ДД.MM.ГГГГ или Д.M.ГГГГ");
        }

        [Test]
        public void ToYoungToFlySingly()
        {
            const string attentionMsg = "Внимание! При заказе билета для несовершеннолетнего, пожалуйста, свяжитесь с авиакомпанией или нашей Службой заботы о клиентах и уточните, необходим ли заказ услуги сопровождения.";
            steps.SetMainData("Минск", "Лондон", "0", "9");
            steps.getFirstResult();
            steps.SetCorrectPersonData("my@mail.ru", "1232422211", "m",
               "Bukov", "Ashot", "10", "01", "2010", "Казахстан", "MK2321222",
               "11", "11", "2024");
            Assert.AreEqual(steps.getAttention(), attentionMsg);
        }

        [Test]
        public void MinskToMinsk()
        {
            steps.SetMainData("Минск", "Минск", "0", "9");
            Assert.AreEqual(steps.getAlertData(), "Не найдены варианты перелёта, соответствующие вашим критериям");
        }
    }
}
