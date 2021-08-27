using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestSuiteExample
{
    partial class CartPage
    {
        public string DeliveryAddrLine1 => deliveryaddrLine1Label.Text;

        public void ChangeAddress()
        {
            chooseAddrDropdown.ChangeToRandomSelection();
        }

        private SelectElement chooseAddrDropdown => new SelectElement(driver.FindElement(By.Id("id_address_delivery")));
        private IWebElement deliveryaddrLine1Label => driver.FindElement(By.CssSelector("#address_delivery .address_address1"));
        private IWebElement addressProceedBtn => driver.FindElement(By.CssSelector("[name=\"processAddress\"]"));
    }
}
