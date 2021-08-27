using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumTestSuiteExample
{
    [TestFixture]
    class ConfirmOrderPageTest
    {

        [Test]
        public void ConfirmOrder()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                WebPage.NavigateToPage<LoginPage>(driver).Login(TestUser.Email, TestUser.Password);
                WebPage.NavigateToPage<ProductPage>(driver).AddToCart();
                WebPage.NavigateToPage<ConfirmOrderPage>(driver).ConfirmOrder();
                WebPage.AssertIsOnWebPage<OrderConfirmationPage>(driver);
            }
        }

    }
}
