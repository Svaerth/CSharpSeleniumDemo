using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Threading.Tasks;

namespace SeleniumTestSuiteExample
{
    partial class LoginPage : WebPage
    {

        #region login
        public string loginErrorMessage => loginErrorPrompt?.FindElement(By.CssSelector("li")).Text;
        public const string AUTH_FAILED_MESSAGE = "Authentication failed.";
        public const string EMPTY_LOGIN_EMAIL_MESSAGE = "An email address required.";
        public const string EMPTY_LOGIN_PASSWD_MESSAGE = "Password is required.";

        public void Login(string email, string password)
        {
            loginEmailField.SendKeys(email);
            passwordField.SendKeys(password);
            signInButton.Click();
        }

        private IWebElement loginEmailField => driver.FindElement(By.Id("email"));
        private IWebElement createAcctEmailField => driver.FindElement(By.Id("email_create"));
        private IWebElement passwordField => driver.FindElement(By.Id("passwd"));
        private IWebElement loginErrorPrompt => driver.FindElement(By.CssSelector(".alert.alert-danger"));
        #endregion

        #region create account
        public const string EMPTY_CREATE_ACCT_EMAIL_MESSAGE = "Invalid email address.";
        public const string INVALID_CREATE_ACCT_EMAIL_MESSAGE = "Invalid email address.";
        public string createAcctErrorMessage => createAcctErrorPrompt?.FindElement(By.CssSelector("li")).Text;

        public void BeginAccountCreation(string email)
        {
            createAcctEmailField.SendKeys(email);
            startAcctCreationButton.Click();
        }

        public void PressRegisterButton()
        {
            registerAcctButton.Click();
        }

        private IWebElement signInButton => driver.FindElement(By.Id("SubmitLogin"));
        private IWebElement startAcctCreationButton => driver.FindElement(By.Id("SubmitCreate"));
        private IWebElement createAcctErrorPrompt => driver.FindElement(By.Id("create_account_error"));
        #endregion

        protected override string URL => "http://automationpractice.com/index.php?controller=authentication";
        protected override string PageTitle => "Login - My Store";
    }
}
