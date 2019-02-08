using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace UnitTestProject1.Pages
{
    public class TranslatorPage
    {
        private readonly SeleniumContext _seleniumContext;
        public TranslatorPage(SeleniumContext seleniumContext) => _seleniumContext = seleniumContext;
        //private readonly IWebDriver _driver;

        //public TranslatorPage(IWebDriver driver) => _driver = driver;
      
        private By LeftLangEng => By.CssSelector("div.sl-sugg div[value = 'en']");
        private By LeftLangSpain => By.CssSelector("div.sl-sugg div[value = 'es']");
        private By RightLangEng => By.CssSelector("divtll-sugg div[value = 'en']");
        private By RightLangSpain => By.CssSelector("div.tl-sugg div[value = 'es']");
        private By OriginField => By.Id("source");
        private By TranslatedField => By.ClassName("result tlid-copy-target");

        public void SelectOriginalLanguage(string lang)
        {
            switch (lang)
            {
                case "English":
                    _seleniumContext.WebDriver.FindElement(LeftLangEng).Click();
                    break;
                case "Spanish":
                    _seleniumContext.WebDriver.FindElement(LeftLangSpain).Click();
                    break;
            }
        }

        public void SelectTranslateLanguage(string lang)
        {
            switch (lang)
            {
                case "English":
                    _seleniumContext.WebDriver.FindElement(RightLangEng).Click();
                    break;
                case "Spanish":
                    _seleniumContext.WebDriver.FindElement(RightLangSpain).Click();
                    break;
            }
        }

        public void EnterWord(string word)
        {
            _seleniumContext.WebDriver.FindElement(OriginField).SendKeys(word);
        }

        public string BackWord()
        {
            return _seleniumContext.WebDriver.FindElement(TranslatedField).GetAttribute("value");
        }
    }
}
