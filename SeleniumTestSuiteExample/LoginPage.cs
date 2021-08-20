using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace SeleniumTestSuiteExample
{
    class LoginPage : WebPage
    {
        protected override string URL => "http://automationpractice.com/index.php?controller=authentication";
        protected override string PageTitle => "Login - My Store";

        public LoginPage(IWebDriver driver, bool shouldNavigateManually) : base(driver, shouldNavigateManually)
        { }
    }
}
