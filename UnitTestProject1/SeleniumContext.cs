using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject1
{
    public class SeleniumContext
    {
        public SeleniumContext()
        {
            WebDriver = new ChromeDriver();
        }
        public IWebDriver WebDriver { get; private set; }
    }
}
