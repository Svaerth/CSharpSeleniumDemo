using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTestSuiteExample
{
    class UnexpectedPageException : Exception
    {
        
        public UnexpectedPageException(string message) : base(message)
        {}

    }
}
