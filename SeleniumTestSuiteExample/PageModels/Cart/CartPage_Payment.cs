using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace SeleniumTestSuiteExample
{
    partial class CartPage
    {
        public void PayByBankWire()
        {
            payByBankwireBtn.Click();
        }

        private IWebElement payByBankwireBtn => driver.FindElement(By.ClassName("bankwire"));
        private IWebElement payByCheckBtn => driver.FindElement(By.ClassName("cheque"));
    }
}
