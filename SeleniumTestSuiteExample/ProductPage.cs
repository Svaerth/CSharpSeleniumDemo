using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace SeleniumTestSuiteExample
{
    class ProductPage : WebPage
    {
        public string DemoImageSrc => demoImage.GetAttribute("src");
        public bool ProductAddedPopupIsShowing => ProductAddedPopup != null;
        public int ItemsInCart => Int32.Parse(CartQuantityLabel.Text);

        public void ChangeColor()
        {
            firstUnselectedColorButton.Click();
        }

        public void AddToCart()
        {
            AddToCartBtn.Click();
        }

        const int DEFAULT_PRODUCT_ID = 5;
        const string DEFAULT_PRODUCT_NAME = "Printed Summer Dress";
        const string URL_PREFIX = "http://automationpractice.com/index.php?id_product=";
        const string URL_SUFFIX = "&controller=product";
        protected override string URL => URL_PREFIX + DEFAULT_PRODUCT_ID + URL_SUFFIX;
        protected override string PageTitle => DEFAULT_PRODUCT_NAME + " - My Store";
        protected override void EnsurePageIsCorrect()
        {
            if (!driver.Url.StartsWith(URL_PREFIX) || !driver.Url.EndsWith(URL_SUFFIX))
            {
                 throw new UnexpectedPageException("URL: " + driver.Url + ", doesn't match patter: " + URL_PREFIX + "<product id>" + URL_SUFFIX);
            }
        }

        private IWebElement firstUnselectedColorButton
        {
            get
            {
                foreach(var colorBtn in driver.FindElements(By.CssSelector("#color_to_pick_list > li ")))
                {
                    if (colorBtn.GetAttribute("class") != "selected")
                    {
                        return colorBtn;
                    }
                }
                return null;
            }
        }
        private IWebElement demoImage => driver.FindElement(By.Id("bigpic"));
        private IWebElement AddToCartBtn => driver.FindElement(By.CssSelector("[name=\"Submit\"]"));
        private IWebElement CartQuantityLabel => driver.FindElement(By.CssSelector("[title=\"View my shopping cart\"] > .ajax_cart_quantity"));
        private IWebElement ProductAddedPopup => driver.TryFindElement(By.ClassName("layer_cart_product"));

    }
}
