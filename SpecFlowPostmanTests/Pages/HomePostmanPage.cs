using OpenQA.Selenium;

namespace SpecFlowPostmanTests.Pages
{
    public class HomePostmanPage
    {

        private IWebDriver _driver;

        public HomePostmanPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private By Logo => By.ClassName("header__logo");
        private By CookieButton => By.CssSelector("div.cc-compliance>a");
        private By SignInButton => By.XPath("//*[@id='siteNav']/nav[2]/a[2]");

        public void ConfirmCookie()
        {
            _driver.FindElement(CookieButton).Click();
        }

        public SignInPage GoToSignIn()
        {
            _driver.FindElement(SignInButton).Click();
            return new SignInPage(_driver);
        }

        public void Visit(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
    }
}
