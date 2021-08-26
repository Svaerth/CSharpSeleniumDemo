using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace SeleniumTestSuiteExample
{
    [TestFixture]
    class CartPageTests
    {
        [Test]
        public void EnsureItemsAddedElsewhereShowUp()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                ProductPage productPage = WebPage.NavigateToPage<ProductPage>(driver);
                productPage.AddToCart();
                CartPage cartPage = WebPage.NavigateToPage<CartPage>(driver);
                Assert.AreEqual(1, cartPage.ItemsInCart);
            }
        }

        [Test]
        public void RemoveItem()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                ProductPage productPage = WebPage.NavigateToPage<ProductPage>(driver);
                productPage.AddToCart();
                CartPage cartPage = WebPage.NavigateToPage<CartPage>(driver);
                cartPage.RemoveTopItemFromCart();
                Assert.AreEqual(0, cartPage.ItemsInCart);
            }
        }

        [Test]
        public void ProceedPastSummary()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                ProductPage productPage = WebPage.NavigateToPage<ProductPage>(driver);
                productPage.AddToCart();
                CartPage cartPage = WebPage.NavigateToPage<CartPage>(driver);
                cartPage.PressProceedBtn();
                Assert.IsTrue(cartPage.IsOnStepAfter(CartPage.Step.Summary));
            }
        }

        [Test]
        public void ChangeAddresses()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                ProductPage productPage = WebPage.NavigateToPage<ProductPage>(driver);
                productPage.AddToCart();
                CartPage cartPage = WebPage.NavigateToPage<CartPage>(driver);
                cartPage.GoToStep(CartPage.Step.Address);
                string addrBefore = cartPage.DeliveryAddrLine1;
                cartPage.ChangeAddress();
                Assert.AreNotEqual(addrBefore, cartPage.DeliveryAddrLine1);
            }
        }

        [Test]
        public void ProceedPastAddress()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                ProductPage productPage = WebPage.NavigateToPage<ProductPage>(driver);
                productPage.AddToCart();
                CartPage cartPage = WebPage.NavigateToPage<CartPage>(driver);
                cartPage.GoToStep(CartPage.Step.Address);
                cartPage.PressProceedBtn();
                Assert.IsTrue(cartPage.IsOnStepAfter(CartPage.Step.Address));
            }
        }

        [Test]
        public void ProceedPastShippingWithoutTOS()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                ProductPage productPage = WebPage.NavigateToPage<ProductPage>(driver);
                productPage.AddToCart();
                CartPage cartPage = WebPage.NavigateToPage<CartPage>(driver);
                cartPage.GoToStep(CartPage.Step.Shipping);
                cartPage.PressProceedBtn();
                Assert.IsTrue(cartPage.TOSErrorPromptIsShowing);
            }
        }

        [Test]
        public void ProceedPastShipping()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                ProductPage productPage = WebPage.NavigateToPage<ProductPage>(driver);
                productPage.AddToCart();
                CartPage cartPage = WebPage.NavigateToPage<CartPage>(driver);
                cartPage.GoToStep(CartPage.Step.Shipping);
                cartPage.AgreeToTOS();
                cartPage.PressProceedBtn();
                Assert.IsTrue(cartPage.IsOnStepAfter(CartPage.Step.Shipping));
            }
        }

        [Test]
        public void PayByBankWire()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                ProductPage productPage = WebPage.NavigateToPage<ProductPage>(driver);
                productPage.AddToCart();
                CartPage cartPage = WebPage.NavigateToPage<CartPage>(driver);
                cartPage.GoToStep(CartPage.Step.Payment);
                cartPage.PayByBankWire();
                WebPage.AssertIsOnWebPage<ConfirmOrderPage>(driver);
            }
        }

    }
}
