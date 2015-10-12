using OpenQA.Selenium;

namespace AutoQASelenium
{
    public class LoginAction
    {
        public string DoLoginNegative(IWebDriver _driver, string login, string password)
        {
            var loginPage = new LoginPage(_driver);
            loginPage.LoginField.SendKeys(login);
            loginPage.PasswordField.SendKeys(password);
            loginPage.SubmitButton.Click();
            return loginPage.PossibleError.Text;
        }
    }
}
