﻿using OpenQA.Selenium;

namespace AutoQASelenium
{
    public class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
