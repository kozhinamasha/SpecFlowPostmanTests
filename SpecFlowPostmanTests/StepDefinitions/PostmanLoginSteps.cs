using FluentAssertions;
using SpecFlowPostmanTests.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowPostmanTests.StepDefinitions
{
    [Binding]
    public class PostmanLoginSteps
    {
        private readonly HomePostmanPage _homePage;
        private readonly SignInPage _signInPage;
        private readonly DashboardPage _dashboardPage;

        public PostmanLoginSteps(HomePostmanPage homePage, DashboardPage dashboardPage, SignInPage signInPage)
        {
            _homePage = homePage;
            _signInPage = signInPage;
            _dashboardPage = dashboardPage;
        }

        [Given(@"I confirmed Cookies policy")]
        public void GivenIConfirmedCookiesPolicy()
        {
            _homePage.ConfirmCookie();
        }

        [When(@"Enter Login (.*) and Password (.*)")]
        public void WhenEnterLoginAndPassword(string email, string password)
        {
            _homePage.GoToSignIn();
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
