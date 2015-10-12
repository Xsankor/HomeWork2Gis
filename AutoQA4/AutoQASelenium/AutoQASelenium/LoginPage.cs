using OpenQA.Selenium;

namespace AutoQASelenium
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement LoginField
        {
            get
            {
                return _driver.FindElement(By.Id("login"));
            }
        }

        public IWebElement PasswordField
        {
            get
            {
                return _driver.FindElement(By.Id("password"));
            }
        }

        public IWebElement SubmitButton
        {
            get
            {
                return _driver.FindElement(By.XPath("//*[@id=\"loginform\"]/input[3]"));
            }
        }

        public IWebElement PossibleError
        {
            get
            {
                return _driver.FindElement(By.XPath("/html/body/p/span"));
            }
        }
    }
}
