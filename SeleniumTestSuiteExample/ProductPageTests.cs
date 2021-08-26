using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace SeleniumTestSuiteExample
{
    [TestFixture]
    class ProductPageTests
    {
        [Test]
        public void ChangeColors()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                ProductPage productPage = WebPage.NavigateToPage<ProductPage>(driver);
                string originalDemoImgSrc = productPage.DemoImageSrc;
                productPage.ChangeColor();
                Assert.AreNotEqual(originalDemoImgSrc, productPage.DemoImageSrc);
            }
        }

        [Test]
        public void AddToCart()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                ProductPage productPage = WebPage.NavigateToPage<ProductPage>(driver);
                productPage.AddToCart();
                Assert.IsTrue(productPage.ProductAddedPopupIsShowing);
            }
        }

        [Test]
        public void EnsureCartUpdatesAfterAdd()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                ProductPage productPage = WebPage.NavigateToPage<ProductPage>(driver);
                productPage.AddToCart();
                Assert.AreEqual(1, productPage.ItemsInCart);
            }
        }
    }
}
