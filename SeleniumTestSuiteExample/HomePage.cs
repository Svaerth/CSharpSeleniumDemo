using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace SeleniumTestSuiteExample
{
    class HomePage : WebPage
    {

        protected override string URL => "http://automationpractice.com/index.php";
        protected override string PageTitle => "My Store";
        public HomePage(IWebDriver driver, bool shouldNavigateManually) : base(driver, shouldNavigateManually)
        { }

    }
}
