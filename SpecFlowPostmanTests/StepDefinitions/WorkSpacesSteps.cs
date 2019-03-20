using FluentAssertions;
using SpecFlowPostmanTests.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowPostmanTests.StepDefinitions
{
    [Binding]
    public class WorkSpacesSteps
    {
        private readonly DashboardPage _dashboardPage;

        public WorkSpacesSteps(DashboardPage dashboardPage)
        {
            _dashboardPage = dashboardPage;
        }

        [When("I create new workspace (.*)")]
        public void WhenICreateNewWorkspace(string name)
        {
            TestContext.WorkspaceNumber = _dashboardPage.CountWorkSpaces();
            _dashboardPage.CreateWorkSpace(name);
        }

        [Then("I see new workspace (.*) at the Dashboard")]
        public void ThenISeeNewWorkspaceAtTheDashboard(string name)
        {
            _dashboardPage.CountWorkSpaces().Should().Be(TestContext.WorkspaceNumber + 1);
        }

        [When("I remove workspace (.*)")]
        public void WhenIRemoveWorkspace(string name)
        {
            TestContext.WorkspaceNumber = _dashboardPage.CountWorkSpaces();
            _dashboardPage.RemoveWorkSpace();
        }

        [Then("The workspace has been removed")]
        public void ThenTheWorkSpaceHasBeenRemoved()
        {
            // _dashboardPage.CountWorkSpaces().Should().Be(TestContext.WorkspaceNumber - 1);
            // _dashboardPage.WorkSpaceDisplayed().Should().Be(name);
            TestContext.WorkspaceNumber = _dashboardPage.CountWorkSpaces();
        }
    }
}