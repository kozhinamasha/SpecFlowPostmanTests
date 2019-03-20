using SpecFlowPostmanTests.Pages;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowPostmanTests.StepDefinitions
{
    [Binding]
    public class BaseSteps
    {
        private readonly HomePostmanPage _homePage;
        private readonly SignInPage _signInPage;

        public BaseSteps(HomePostmanPage homePage, SignInPage signInPage)
        {
            _homePage = homePage;
            _signInPage = signInPage;
        }

        [StepDefinition("I visit the page (.*)")]
        public void IVisitThePage(string url)
        {
            _homePage.Visit(url);
            Thread.Sleep(5000);
        }

        [Given("I am logged in user")]
        public void GivenIAmLoggedInUser()
        {
            _homePage.Visit("https://identity.getpostman.com/login");
            _signInPage.EnterCredentials("globallogic", "globallogic");
            _signInPage.SubmitForm();
            Thread.Sleep(9000);
        }
    }
}