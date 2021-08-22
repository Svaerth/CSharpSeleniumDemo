using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumTestSuiteExample
{
    class WebDriverFactory
    {

        public static IWebDriver CreateWebDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            if (InputArguments.ShouldRunHeadless)
            {
                options.AddArgument("--headless");
            }
            options.LogLevel = FirefoxDriverLogLevel.Fatal;
            return new FirefoxDriver(options);
        }

    }
}
