using FluentAssertions;
using OpenQA.Selenium;
using SpecFlowPostmanTests.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowPostmanTests.StepDefinitions
{
    [Binding]
    public class PostmanLoginSteps
    {
        private readonly HomePostmanPage _postmanPage;
        private readonly SignInPage _signInPage;
        private readonly DashboardPage _dashboardPage;

        public PostmanLoginSteps(IWebDriver driver, HomePostmanPage postmanPage, DashboardPage dashboardPage, SignInPage signInPage)
        {
            _postmanPage = postmanPage;
            _signInPage = signInPage;
            _dashboardPage = dashboardPage;
        }

        [Given(@"I have opened page (.*)")]
        public void GivenIHaveOpenedPage(string page)
        {
            _postmanPage.GetPage(page).Should().Be(true);
        }

        [Given(@"I confirmed Cookies policy")]
        public void GivenIConfirmedCookiesPolicy()
        {
            _postmanPage.ConfirmCookie();
        }

        [When(@"Enter Login (.*) and Password (.*)")]
        public void WhenEnterLoginAndPassword(string email, string password)
        {
            _postmanPage.GoToSignIn();
            _signInPage.EnterCredentials(email, password);
            _signInPage.SubmitForm();
        }

        [Then(@"The login is successful")]
        public void ThenTheLoginIsSuccessful()
        {
            _dashboardPage.GetPageTitle().Should().Be("Postman Dashboard");
        }
    }
}
