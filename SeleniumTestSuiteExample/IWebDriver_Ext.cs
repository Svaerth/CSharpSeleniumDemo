using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace SeleniumTestSuiteExample
{
    static class IWebDriver_Ext
    {
        public static void ScrollToAndClick(this IWebDriver driver, IWebElement element)
        {
            string jsToRun = "" +
                "arguments[0].scrollIntoView();" +
                "arguments[0].click();";
            ((IJavaScriptExecutor)driver).ExecuteScript(jsToRun, element);
        }

        public static IWebElement TryFindElement(this IWebDriver driver, By by)
        {
            try{
                return driver.FindElement(by);
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
