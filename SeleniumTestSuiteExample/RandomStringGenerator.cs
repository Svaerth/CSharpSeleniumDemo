using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTestSuiteExample
{
    class RandomStringGenerator
    {

        const byte minASCIIChar = 97;
        const byte maxASCIIChar = 122;
        static byte ASCIICharRange => maxASCIIChar - minASCIIChar;

        public static string Generate(int length)
        {
            Random rng = new Random();
            byte[] randomBytes = new byte[length];
            
            for(int i = 0; i < length; i++)
            {
                randomBytes[i] = (byte)(minASCIIChar + rng.Next(ASCIICharRange));
            }

            return ASCIIEncoding.ASCII.GetString(randomBytes);
        }
    }
}
