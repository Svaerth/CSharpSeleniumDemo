using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace SeleniumTestSuiteExample
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initiating Test Suite For automationpractice.com");

            using (var driver = CreateWebDriver())
            {
                Console.WriteLine("web driver instantiated.");




            }

        }

        static IWebDriver CreateWebDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--headless");
            options.LogLevel = FirefoxDriverLogLevel.Fatal;
            return new FirefoxDriver(options);
        }
    }
}
