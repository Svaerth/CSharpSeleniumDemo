using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace SeleniumTestSuiteExample
{
    [TestFixture]
    class ProductListPageTests
    {
        [Test]
        public void EnsureLoadingAppearsOnCriteriaChange()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                ProductListPage productList = WebPage.NavigateToPage<ProductListPage>(driver);
                productList.AddFilterToSearchResults();
                Assert.IsTrue(productList.LoadingGraphicIsShowing);
            }
        }

        [Test]
        public void SelectAProduct()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                ProductListPage productList = WebPage.NavigateToPage<ProductListPage>(driver);
                productList.SelectFirstResult();
                WebPage.AssertIsOnWebPage<ProductPage>(driver);
            }
        }

        [Test]
        public void ShowQuickView()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                ProductListPage productList = WebPage.NavigateToPage<ProductListPage>(driver);
                productList.ClickQuickViewOnFirstResult();
                Assert.IsTrue(productList.QuickViewIsShowing);
            }
        }

        [Test]
        public void AddToCart()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                ProductListPage productList = WebPage.NavigateToPage<ProductListPage>(driver);
                productList.AddFirstResultToCart();
                Assert.IsTrue(productList.ProductAddedPopupIsShowing);
            }
        }

        [Test]
        public void EnsureCartUpdatesAfterAdd()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                ProductListPage productList = WebPage.NavigateToPage<ProductListPage>(driver);
                productList.AddFirstResultToCart();
                Assert.AreEqual(1, productList.ItemsInCart);
            }
        }

        [Test]
        public void NavigateToCartFromProductList()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                ProductListPage productList = WebPage.NavigateToPage<ProductListPage>(driver);
                productList.GoToCart();
                WebPage.AssertIsOnWebPage<CartPage>(driver);
            }
        }

    }
}
