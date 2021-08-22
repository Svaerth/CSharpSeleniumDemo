using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumTestSuiteExample
{
    [TestFixture]
    class LoginTests
    {

        [Test]
        public void RightEmailWrongPass()
        {
            using (IWebDriver driver = WebDriverFactory.CreateWebDriver())
            {
                LoginPage loginPage = WebPage.NavigateToPage<LoginPage>(driver);
                loginPage.Login(TestUser.Email, "incorrect_password");
                Assert.AreEqual(LoginPage.AUTH_FAILED_MESSAGE, loginPage.loginErrorMessage);
            }
        }

        [Test]
        public void WrongEmailRightPass()
        {
            using (IWebDriver driver = WebDriverFactory.CreateWebDriver())
            {
                LoginPage loginPage = WebPage.NavigateToPage<LoginPage>(driver);
                loginPage.Login("wrong@email.com", TestUser.Password);
                Assert.AreEqual(LoginPage.AUTH_FAILED_MESSAGE, loginPage.loginErrorMessage);
            }
        }

        [Test]
        public void EmptyEmail()
        {
            using (IWebDriver driver = WebDriverFactory.CreateWebDriver())
            {
                LoginPage loginPage = WebPage.NavigateToPage<LoginPage>(driver);
                loginPage.Login("", TestUser.Password);
                Assert.AreEqual(LoginPage.EMPTY_LOGIN_EMAIL_MESSAGE, loginPage.loginErrorMessage);
            }
        }

        [Test]
        public void EmptyPassword()
        {
            using (IWebDriver driver = WebDriverFactory.CreateWebDriver())
            {
                LoginPage loginPage = WebPage.NavigateToPage<LoginPage>(driver);
                loginPage.Login(TestUser.Email, "");
                Assert.AreEqual(LoginPage.EMPTY_LOGIN_PASSWD_MESSAGE, loginPage.loginErrorMessage);
            }
        }

        [Test]
        public void SuccessfulLogin()
        {
            using (IWebDriver driver = WebDriverFactory.CreateWebDriver())
            {
                LoginPage loginPage = WebPage.NavigateToPage<LoginPage>(driver);
                loginPage.Login(TestUser.Email, TestUser.Password);
                WebPage.AssertIsOnWebPage<MyAccountPage>(driver);
            }
        }

    }
}
