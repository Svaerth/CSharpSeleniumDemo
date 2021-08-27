using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace SeleniumTestSuiteExample
{
    partial class CartPage
    {

        public void RemoveTopItemFromCart()
        {
            trashCanButton.Click();
        }

        private IWebElement trashCanButton => driver.FindElement(By.ClassName("cart_quantity_delete"));
        private IWebElement summaryProceedBtn => driver.FindElement(By.CssSelector(".cart_navigation > [title=\"Proceed to checkout\"]"));

    }
}
