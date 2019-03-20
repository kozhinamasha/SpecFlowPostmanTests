using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace SpecFlowPostmanTests
{
    [Binding]
    public sealed class Hooks
    {
        private IWebDriver _driver;
        private readonly IObjectContainer _objectContainer;

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
                // Local machine
                string browser = ConfigurationManager.AppSettings["browser"];
                switch (browser)
                {
                    case "Chrome":
                        _driver = new ChromeDriver();
                        _objectContainer.RegisterInstanceAs(_driver);
                        _driver.Manage().Window.Maximize();
                        break;
                    case "FireFox":
                        _driver = new FirefoxDriver();
                        _objectContainer.RegisterInstanceAs(_driver);
                        _driver.Manage().Window.Maximize();
                        break;
                    case "IE":
                        var options = new InternetExplorerOptions
                        {
                            IgnoreZoomLevel = true
                        };
                        _driver = new InternetExplorerDriver(options);
                        _objectContainer.RegisterInstanceAs(_driver);
                        _driver.Manage().Window.Maximize();
                        break;
                }
            }
            else
            {
                // Selenium Grid
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