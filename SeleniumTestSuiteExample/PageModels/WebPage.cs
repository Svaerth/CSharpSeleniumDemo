using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace SeleniumTestSuiteExample
{
    abstract class WebPage
    {

        /// <summary>
        /// Attempts to create a WebPage model of type T from the passed in driver.
        /// If the driver is not currently on the webpage that matches type T, 
        /// an exception will be thrown.
        /// </summary>
        /// <typeparam name="T">The WebPage type that you would like to obtain a model of.</typeparam>
        /// <param name="driver">The IWebDriver that is being used in the current session.</param>
        /// <returns>A WebPage of type T that models the webpage that the driver is currently navigated to.</returns>
        public static T Create<T>(IWebDriver driver) where T : WebPage, new()
        {
            T webPage = new T();
            webPage.driver = driver;
            webPage.EnsurePageIsCorrect();
            return webPage;
        }

        /// <summary>
        /// Navigated the passed in webdriver to the WebPage specified by Type T.
        /// </summary>
        /// <typeparam name="T">The WebPage you wish to navigate to</typeparam>
        /// <param name="driver">The IWebDriver being used in the current session.</param>
        /// <returns>A model of the webpage that was navigated to.</returns>
        public static T NavigateToPage<T>(IWebDriver driver) where T : WebPage, new()
        {
            T webPage = new T();
            webPage.driver = driver;
            driver.Navigate().GoToUrl(webPage.URL);
            webPage.EnsurePageIsCorrect();
            return webPage;
        }

        /// <summary>
        /// Throws an exception if the passed in webdriver isn't currently navigated to the
        /// webpage of type T.
        /// </summary>
        /// <typeparam name="T">The webpage that you expect the webdriver to be navigated to.</typeparam>
        /// <param name="driver">The webdriver being used in the current session</param>
        public static void AssertIsOnWebPage<T>(IWebDriver driver) where T: WebPage, new()
        {
            //Create() naturally throws an exception if the driver is not currently navigated
            //to the expected webpage.
            Create<T>(driver);
        }

        public static bool IsOnWebPage<T>(IWebDriver driver) where T : WebPage, new()
        {
            //Create() naturally throws an exception if the driver is not currently navigated
            //to the expected webpage.
            try
            {
                Create<T>(driver);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        protected abstract string URL { get; }

        protected IWebDriver driver;

        protected abstract string PageTitle { get; }

        protected WebPage() { }

        protected virtual void EnsurePageIsCorrect()
        {
            if (driver.Title != PageTitle)
            {
                throw new UnexpectedPageException("Expected page with title: " + PageTitle + 
                                                  ", instead, found page with title: " + driver.Title);
            }
        }

    }
}
