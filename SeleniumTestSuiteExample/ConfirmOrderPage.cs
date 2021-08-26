using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace SeleniumTestSuiteExample
{
    class ConfirmOrderPage : WebPage
    {

        public void ConfirmOrder()
        {
            confirmButton.Click();
        }

        enum PaymentType
        {
            bankwire,
            check
        }

        const string URLPrefix = "http://automationpractice.com/index.php?fc=module&module=";
        const string URLSuffix = "&controller=payment";
        const PaymentType defaultPaymentType = PaymentType.bankwire;
        protected override string URL => URLPrefix + GetStringForPaymentType(defaultPaymentType) + URLSuffix;
        protected override string PageTitle => "My Store";

        private IWebElement confirmButton => driver.FindElement(By.CssSelector("#cart_navigation button"));

        protected override void EnsurePageIsCorrect()
        {
            if (!driver.Url.StartsWith(URLPrefix) || !driver.Url.EndsWith(URLSuffix))
            {
                throw new UnexpectedPageException("invalid url: " + driver.Url + ", expected format: " + URLPrefix + "<payment type>" + URLSuffix);
            }
        }

        string GetStringForPaymentType(PaymentType type)
        {
            switch(type)
            {
                case PaymentType.bankwire:
                    return "bankwire";
                case PaymentType.check:
                    return "check";
                default:
                    throw new Exception("Unsupported payment type: " + type);
            }
        }
    }
}
