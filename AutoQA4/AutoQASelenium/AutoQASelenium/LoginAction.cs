using OpenQA.Selenium;

namespace AutoQASelenium
{
    public class LoginAction
    {
        public string DoLoginNegative(IWebDriver _driver, string login, string password)
        {
            var loginPage = new LoginPage(_driver);
            TryToLogin(loginPage, login, password);
            return loginPage.PossibleError.Text;
        }

        public string DoLoginPositive(IWebDriver _driver, string login, string password)
        {
            var loginPage = new LoginPage(_driver);
            TryToLogin(loginPage, login, password);
            var homePage = new HomePage(_driver);
            return _driver.Title;
        }

        private void TryToLogin(LoginPage _loginPage, string _login, string _password)
        {
            _loginPage.LoginField.SendKeys(_login);
            _loginPage.PasswordField.SendKeys(_password);
            _loginPage.SubmitButton.Click();
        }
    }
}
