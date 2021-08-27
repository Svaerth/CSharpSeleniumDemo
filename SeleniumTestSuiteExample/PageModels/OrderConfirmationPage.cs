using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTestSuiteExample
{
    class OrderConfirmationPage : WebPage
    {
        const string URLPrefix = "http://automationpractice.com/index.php?controller=order-confirmation";
        const string defaultURLParams = "&id_cart=3603162&id_module=3&id_order=353651&key=ab1f86c2787a45834b3f18bfb84f7de7";
        protected override string URL => URLPrefix + defaultURLParams;
        protected override string PageTitle => "Order confirmation - My Store";
    }
}
