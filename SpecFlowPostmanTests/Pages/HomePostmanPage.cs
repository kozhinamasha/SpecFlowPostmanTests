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

        public bool GetPage(string page)
        {
            _driver.Navigate().GoToUrl(page);
            bool logo = _driver.FindElement(Logo).Displayed;
            return logo;
        }

        public void ConfirmCookie()
        {
            _driver.FindElement(CookieButton).Click();
        }

        public SignInPage GoToSignIn()
        {
            _driver.FindElement(SignInButton).Click();
            return new SignInPage(_driver);
        }
    }
}
