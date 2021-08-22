using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnitLite;

namespace SeleniumTestSuiteExample
{
    class EntryPoint
    {
        static int Main(string[] args)
        {
            InputArguments.ProcessArgs(args);
            return new AutoRun().Execute(new string[0]);
        }

        
    }
}
