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

        /// <summary>
        /// This is needed because on firefox the Displayed property will return false 
        /// if your display style is inline-block
        /// </summary>
        public static bool DisplayStyleIsNone(this IWebElement element)
        {
            string style = element.GetAttribute("style");
            if (style != null && 
               style.RemoveWhiteSpace().Contains("display:none",StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }
}
