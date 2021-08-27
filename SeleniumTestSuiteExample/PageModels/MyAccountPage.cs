using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace SeleniumTestSuiteExample
{
    class MyAccountPage : WebPage
    {
        protected override string URL => "http://automationpractice.com/index.php?controller=my-account";

        protected override string PageTitle => "My account - My Store";
    }
}
