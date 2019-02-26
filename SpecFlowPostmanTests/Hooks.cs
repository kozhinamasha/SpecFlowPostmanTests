using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace SpecFlowPostmanTests
{
    [Binding]
    public sealed class Hooks
    {
        private IWebDriver _driver;
        private IObjectContainer _objectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]

        public void BeforeScenario()
        {
            var localExecution = ConfigurationManager.AppSettings["localExecution"];

            if (localExecution == "true")
            {
                //Local machine
                _driver = new ChromeDriver();
                _objectContainer.RegisterInstanceAs(_driver);
                _driver.Manage().Window.Maximize();
            }
            else
            {
                //Selenium Grid
                ChromeOptions options = new ChromeOptions();
                _driver = new RemoteWebDriver(new Uri("http://localhost:4447/wd/hub"), options);
                _objectContainer.RegisterInstanceAs(_driver);
            }
            }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }
        }
}
