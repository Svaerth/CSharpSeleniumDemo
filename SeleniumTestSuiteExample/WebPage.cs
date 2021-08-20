using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace SeleniumTestSuiteExample
{
    abstract class WebPage
    {
        protected abstract string URL { get; }

        protected IWebDriver driver;

        protected abstract string PageTitle { get; }

        /// <param name="driver">The webdriver used in this session.</param>
        /// <param name="shouldNavigateManually">
        /// whether or not the webdriver should navigate to this page's url upon instantiation of this WebPage.
        /// should be true if the webdriver has not already navigated to this webpage.
        /// </param>
        public WebPage(IWebDriver driver, bool shouldNavigateManually = false)
        {
            this.driver = driver;
            if (shouldNavigateManually)
            {
                driver.Navigate().GoToUrl(URL);
            }
            EnsurePageIsCorrect();
        }

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
