using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace SeleniumTestSuiteExample
{
    partial class CartPage
    {
        public bool TOSErrorPromptIsShowing => TOSErrorPrompt != null;

        public void AgreeToTOS()
        {
            TOSCheckbox.Click();
        }

        private IWebElement shippingProceedBtn => driver.FindElement(By.CssSelector("[name=\"processCarrier\"]"));
        private IWebElement TOSCheckbox => driver.FindElement(By.Id("cgv"));
        private IWebElement TOSErrorPrompt => driver.TryFindElement(By.CssSelector(".fancybox-overlay.fancybox-overlay-fixed"));
    }
}
