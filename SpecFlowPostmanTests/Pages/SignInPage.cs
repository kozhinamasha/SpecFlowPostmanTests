using OpenQA.Selenium;
using System.Threading;

namespace SpecFlowPostmanTests.Pages
{
    public class SignInPage
    {
        IWebDriver _driver;
        public SignInPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private By Email => By.Id("username");
        private By Password => By.Id("password");
        private By Submit => By.Id("sign-in-btn");
        private By Title => By.ClassName("pm-h1");

        public void EnterCredentials(string email, string password)
        {
            Thread.Sleep(5000);
            _driver.FindElement(Email).SendKeys(email);
            _driver.FindElement(Password).SendKeys(password);
        }

        public DashboardPage SubmitForm()
        {
            _driver.FindElement(Submit).Submit();
            return new DashboardPage(_driver);
        }
    }
}
