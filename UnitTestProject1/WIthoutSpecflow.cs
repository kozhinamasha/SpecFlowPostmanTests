using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using UnitTestProject1.Pages;

namespace UnitTestProject1
{
    [TestClass]
    public class CheckTranslator
    {
        [BeforeScenario]
        public void SetUp()
        {
        }

        [TestMethod]
        public void CheckWordTranslation()
        {
            //IWebDriver driver = new ChromeDriver();
            //TranslatorPage page = new TranslatorPage(driver);
            //driver.Navigate().GoToUrl("https://translate.google.com");
            //page.SelectOriginalLanguage("English");
            //page.SelectTranslateLanguage("Spanish");
            //page.EnterWord("parents");

            //string test = page.BackWord();
            //test.Should().Be("madres");
            //driver.Quit();
        }

        [AfterScenario]
        public void TearDown()
        {
        }
    }
}
