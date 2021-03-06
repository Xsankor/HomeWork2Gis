﻿using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutoQASelenium
{
    public class TestClass
    {
        protected IWebDriver Driver { get; set; }

        [TestFixtureSetUp]
        public void BeforeClass()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://planeta.2gis.ru/");
        }

        [Test]
        public void LoginNegativeTest()
        {
            var errorMessage = new LoginAction().DoLoginNegative(Driver, "test", "123qwe!");

            var expectedErrorMessage = "Что-то не так! Вероятно, неправильно указан логин или пароль.";
            Assert.IsNotEmpty(
                errorMessage,
                "Незарегистрированному пользователю удалось авторизоваться под логином {0}",
                "test");
            Assert.AreEqual(
                expectedErrorMessage,
                errorMessage,
                "Текст ошибки {0} не совпал с ожидаемым {1}",
                errorMessage,
                expectedErrorMessage);
        }

        [Test]
        public void LoginPositveTest()
        {
            // Данный тест будет проходить только под авторизованным пользователем (под пользователем test будет падать)
            var pageTitle = new LoginAction().DoLoginPositive(Driver, "test", "123qwe!");

            var expectedPageTitle = "Планета 2ГИС";

            Assert.AreEqual(
                expectedPageTitle,
                pageTitle,
                "В ходе авторизации не удалось перейти на страницу {0}",
                expectedPageTitle);
        }

        [TestFixtureTearDown]
        public void AfterClass()
        {
            Driver.Quit();
        }
    }
}
