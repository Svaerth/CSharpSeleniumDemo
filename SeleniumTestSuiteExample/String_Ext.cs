using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTestSuiteExample
{
    static class String_Ext
    {
        public static string RemoveWhiteSpace(this string str)
        {
            string strWithoutWhitespace = "";
            foreach(var letter in str)
            {
                if (Char.IsWhiteSpace(letter) == false)
                {
                    strWithoutWhitespace += letter;
                }
            }
            return strWithoutWhitespace;
        }
    }
}
