using System;
using System.Collections.Generic;
using System.Linq;
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

        private By CreateButton => By.CssSelector("#app-mount-point > main > div > div.workspace-list__actions > button");
        private By WorkSpaceName => By.Id("ws-name");
        private By Summary => By.CssSelector("#app-mount-point > main > div > div > div.pm-text-area.workspace-edit__summary > div > textarea");
        private By Type => By.CssSelector("#app-mount-point > main > div > div > div.pm-toggle.workspace-edit__type > div > span");
        private By ButtonCreate => By.CssSelector("#app-mount-point > main > div > div > div.pm-actions.workspace-edit__actions > button.pm-btn.pm-btn-primary.pm-btn-md.pm-btn-content.pm-actions__confirm");
        private By WorkSpace => By.ClassName("workspace-table__title");
        private By ButtonMore => By.XPath("//*[@id='app-mount-point']/main/div/div[2]/div/div[1]/div[2]/div[2]/div/div[2]/div/div/div/button/i");
                                          //*[@id="app-mount-point"]/main/div/div[2]/div/div[1]/div[2]/div/div/div[2]/div/div/div/button/i
        private By ButtonConfirmDelete =>
            By.CssSelector(
                "body > div.ReactModalPortal > div > div > div > div > div.pm-modal-confirm__actions > button.pm-btn.pm-btn-error.pm-btn-md.pm-btn-block.pm-btn-content.pm-modal-confirm__confirm");
        
        public string GetPageTitle()
        {
            Thread.Sleep(5000);
            string title = _driver.Title;
            return title;
        }

        public int CountWorkSpaces()
        {
            int number = _driver.FindElements(WorkSpace).Count;
            return number;
        }

        public void CreateWorkSpace(string name)
        {
            _driver.FindElement(CreateButton).Click();
            _driver.FindElement(WorkSpaceName).SendKeys(name);
            _driver.FindElement(Summary).SendKeys("summary");
            bool type = _driver.FindElement(Type).Selected;
            if (type ==true) {
                _driver.FindElement(Type).Click();
                }
            else
            {
            }
            _driver.FindElement(ButtonCreate).Click();     
        }

        public string GetWorkSpaceName()
        {
            string newWorkplace = _driver.FindElement(WorkSpace).Text;
            return newWorkplace;
        }

        public void RemoveWorkSpace()
        {
            List<IWebElement> elements = _driver.FindElements(WorkSpace).ToList();

            foreach (var item in elements)
            {
                string workspaceName = item.Text;
                    if (workspaceName == "TestWorkSpace\r\ngloballogic")
                    {
                        var removeButton = _driver.FindElement(ButtonMore);
                        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                        js.ExecuteScript("arguments[0].style.border='3px solid red'", removeButton);
                        Thread.Sleep(9000);

                    _driver.FindElement(ButtonMore).Click();;
                    Thread.Sleep(9000);
                    _driver.FindElement(By.CssSelector("div.menu>div:nth-of-type(6)")).Click();
                        _driver.SwitchTo().Window(_driver.WindowHandles.Last());
                        _driver.FindElement(ButtonConfirmDelete).Click();
                    }
                    else
                    {
                        Console.WriteLine("There is no TestWorkspace at the list");
                    }
                }
            }
        }
}
