using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace SeleniumTestSuiteExample
{
    partial class CartPage : WebPage
    {
        public int ItemsInCart => cartItems.Count;

        protected override string URL => "http://automationpractice.com/index.php?controller=order";
        protected override string PageTitle => "Order - My Store";
        
        private ReadOnlyCollection<IWebElement> cartItems => driver.FindElements(By.ClassName("cart_item"));
    }
}
