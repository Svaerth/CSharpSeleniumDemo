using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumTestSuiteExample
{
    class ProductListPage : WebPage
    {
        public bool LoadingGraphicIsShowing => LoadingGraphic != null;
        public bool QuickViewIsShowing => QuickViewIFrame != null;
        public bool ProductAddedPopupIsShowing => ProductAddedPopup != null;
        public int ItemsInCart => Int32.Parse(CartQuantityLabel.Text);

        public void AddFilterToSearchResults()
        {
            SmallSizeCheckbox.Click();
        }

        public void SelectFirstResult()
        {
            driver.ScrollToAndClick(FirstProductResult);
        }

        public void ClickQuickViewOnFirstResult()
        {
            new Actions(driver).MoveToElement(FirstProductResult).Perform();
            driver.ScrollToAndClick(FirstProductQuickViewButton);
        }

        public void AddFirstResultToCart()
        {
            new Actions(driver).MoveToElement(FirstProductResult).Perform();
            driver.ScrollToAndClick(FirstAddToCartButton);
        }

        public void GoToCart()
        {
            ViewMyCartLink.Click();
        }

        const int DEFAULT_PRODUCT_CATEGORY = 11;
        const string DEFAULT_CATEGORY_NAME = "Summer Dresses";
        const string URL_PREFIX = "http://automationpractice.com/index.php?id_category=";
        const string URL_SUFFIX = "&controller=category";
        protected override string URL => URL_PREFIX + DEFAULT_PRODUCT_CATEGORY + URL_SUFFIX;
        protected override string PageTitle => DEFAULT_CATEGORY_NAME + " - My Store";
        protected override void EnsurePageIsCorrect()
        {
            if (!driver.Url.StartsWith(URL_PREFIX) || !driver.Url.EndsWith(URL_SUFFIX))
            {
                throw new UnexpectedPageException("URL: " + driver.Url + ", doesn't match patter: " + URL_PREFIX + "<category id>" + URL_SUFFIX);
            }
        }

        private IWebElement SmallSizeCheckbox => driver.FindElement(By.Id("layered_id_attribute_group_1"));
        private IWebElement LoadingGraphic => driver.TryFindElement(By.CssSelector("#center_column [src=\"http://automationpractice.com/img/loader.gif\"]"));
        private IWebElement FirstProductResult => driver.FindElement(By.CssSelector(".product_list.grid.row > li .product_img_link"));
        private IWebElement FirstProductQuickViewButton => driver.FindElement(By.CssSelector(".product_list.grid.row > li .quick-view"));
        private IWebElement QuickViewIFrame => driver.TryFindElement(By.ClassName("fancybox-iframe"));
        private IWebElement FirstAddToCartButton => driver.FindElement(By.CssSelector("[title=\"Add to cart\"]"));
        private IWebElement ProductAddedPopup => driver.TryFindElement(By.ClassName("layer_cart_product"));
        private IWebElement CartQuantityLabel => driver.FindElement(By.CssSelector(".ajax_cart_quantity.unvisible"));
        private IWebElement ViewMyCartLink => driver.FindElement(By.CssSelector("[title=\"View my shopping cart\"]"));
    }
}
