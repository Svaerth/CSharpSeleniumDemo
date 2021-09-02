using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTestSuiteExample
{
    static class InputArguments
    {

        public static bool ShouldRunHeadless { get; private set; }
        public static string TestUserPassword { get; private set; }
        public static string TestUserEmail { get; private set; }

        public static void ProcessArgs(string[] args)
        {
            for(int i = 0; i < args.Length; i++)
            {
                string arg = args[i];
                switch(arg)
                {
                    case "-headless":
                    case "-h":
                        ShouldRunHeadless = true;
                        break;
                    case "-password":
                    case "-p":
                        TestUserPassword = args[i + 1];
                        i++;
                        break;
                    case "-email":
                    case "-e":
                        TestUserEmail = args[i + 1];
                        i++;
                        break;
                    default:
                        Console.WriteLine("Invalid arg found: " + arg + ". Ignoring.");
                        break;
                }
            }

            CheckForRequiredArgs();
        }

        private static void CheckForRequiredArgs()
        {
            if (TestUserEmail == null)
            {
                throw new Exception("missing required argument: -email. this should contain the test user email that will be used in the test suite.");
            }
            if (TestUserPassword == null)
            {
                throw new Exception("missing required argument: -password. this should contain the test user email that will be used in the test suite.");
            }
        }

    }
}
