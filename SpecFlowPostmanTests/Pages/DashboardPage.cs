using System.Threading;
using OpenQA.Selenium;

namespace SpecFlowPostmanTests.Pages
{
    public class DashboardPage
    {
        private IWebDriver _driver;
        public DashboardPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetPageTitle()
        {
            Thread.Sleep(5000);
            string title = _driver.Title;
            return title;

        }
    }
}
