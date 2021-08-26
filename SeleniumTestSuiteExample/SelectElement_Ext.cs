using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestSuiteExample
{
    static class SelectElement_Ext
    {
        public static int GetSelectedIndex(this SelectElement selectElement)
        {
            for(int i = 0; i < selectElement.Options.Count; i++)
            {
                if (selectElement.Options[i].Equals(selectElement.SelectedOption))
                {
                    return i;
                }
            }
            throw new Exception("Selected Element not found in Options!");
        }

        public static void ChangeToRandomSelection(this SelectElement selectElement)
        {
            int selectedIndex = selectElement.GetSelectedIndex();
            List<int> unselectedIndices = new List<int>();
            for(int i = 0; i < selectElement.Options.Count; i++)
            {
                if (i != selectedIndex)
                {
                    unselectedIndices.Add(i);
                }
            }
            int randomSelection = new Random().Next(unselectedIndices.Count);
            selectElement.SelectByIndex(unselectedIndices[randomSelection]);
        }
    }
}
