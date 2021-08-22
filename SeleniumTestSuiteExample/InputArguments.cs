using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTestSuiteExample
{
    static class InputArguments
    {

        public static bool ShouldRunHeadless { get; private set; }

        public static void ProcessArgs(string[] args)
        {
            foreach (var arg in args)
            {
                switch(arg)
                {
                    case "-headless":
                    case "-h":
                        ShouldRunHeadless = true;
                        break;
                    default:
                        Console.WriteLine("Invalid arg found: " + arg + ". Ignoring.");
                        break;
                }
            }
        }

    }
}
