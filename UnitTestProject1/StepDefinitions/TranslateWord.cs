using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using UnitTestProject1.Pages;

namespace UnitTestProject1.StepDefinitions
{
    [Binding]
    public sealed class TranslateWord
    {
        private TranslatorPage _page;
        private SeleniumContext _seleniumContext;

        public TranslateWord(TranslatorPage page,SeleniumContext seleniumContext)
        {
            _seleniumContext = seleniumContext;
            _page = new TranslatorPage(_seleniumContext);
        }

        [Given(@"I have opened translator page")]
        public void GivenIHaveOpenedTranslatorPage()
        {
            _seleniumContext.WebDriver.Navigate().GoToUrl("https://translate.google.com");
        }

        [When(@"I select language (.*) for original text")]
        public void WhenISelectLanguageForOriginalText(string lang)
        {
            _page.SelectOriginalLanguage(lang);
        }

        [When(@"I select language (.*) for translate")]
        public void WhenISelectLanguageForTranslate(string lang)
        {
            _page.SelectTranslateLanguage(lang);
        }

        [When(@"I enter the word (.*)")]
        public void WhenIEnterTheWord(string word)
        {
            _page.EnterWord(word);
        }

        [Then(@"The word has been translated on (.*)")]
        public void ThenTheWordHasBeenTranslatedOnPadres(string word)
        {
            string test = _page.BackWord();
            test.Should().Be(word);
        }
    }
}
