using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace SeleniumTestSuiteExample
{
    static class IWebElement_Ext
    {
        /// <summary>
        /// Clears and populates webelement if passed in value isn't null.
        /// </summary>
        public static void ClearAndPopulateIfNotNull(this IWebElement element, string value)
        {
            if (value != null)
            {
                element.Clear();
                element.SendKeys(value);
            }
        }
    }
}
