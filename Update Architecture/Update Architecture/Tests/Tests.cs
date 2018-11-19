using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Update_Architecture.Tests
{
    [TestFixture]
    class Tests
    {
        private Steps.Steps steps = new Steps.Steps();

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void CheckCorrectActivePrice()
        {
            Assert.IsTrue(steps.checkActiveTabPrice("Минск", "Лондон", "10", "23"));
        }

        [Test]
        public void checkPassengerBirthDate()
        {
            steps.checkBirthDate("Минск", "Лондон", "10", "23","08.08.2200");
        }
    }
}
