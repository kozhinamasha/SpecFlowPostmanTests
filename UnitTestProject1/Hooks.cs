using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace UnitTestProject1
{
    [Binding]
    public sealed class Hooks
    {
        //private IWebDriver _driver;
        private readonly IObjectContainer _objectContainer;
        private static SeleniumContext _seleniumContext;

        public Hooks(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [BeforeTestRun]
        public static void BeforeRun()
        {
            _seleniumContext = new SeleniumContext();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //_driver = new ChromeDriver();
            //_driver.Manage().Window.Maximize();
            //ScenarioContext.Current.Add("currentDriver", _driver);
            _objectContainer.RegisterInstanceAs(_seleniumContext);
            _seleniumContext.WebDriver.Manage().Window.Maximize();
        }

        //[AfterScenario]
        //public void AfterScenario()
        //{
        //    _seleniumContext.WebDriver?.Quit();
        //}
    }
}
