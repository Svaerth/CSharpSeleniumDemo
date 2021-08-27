using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestSuiteExample
{
    [TestFixture]
    class AccountCreationTests
    {

        [Test]
        public void EmptyAcctCreationEmail()
        {
            using (IWebDriver driver = WebDriverFactory.CreateWebDriver())
            {
                LoginPage loginPage = WebPage.NavigateToPage<LoginPage>(driver);
                loginPage.BeginAccountCreation("");
                Assert.AreEqual(LoginPage.EMPTY_CREATE_ACCT_EMAIL_MESSAGE, loginPage.createAcctErrorMessage);
            }
        }

        [Test]
        public void InvalidAcctCreationEmail()
        {
            using (IWebDriver driver = WebDriverFactory.CreateWebDriver())
            {
                LoginPage loginPage = WebPage.NavigateToPage<LoginPage>(driver);
                loginPage.BeginAccountCreation("invalid email");
                Assert.AreEqual(LoginPage.INVALID_CREATE_ACCT_EMAIL_MESSAGE, loginPage.createAcctErrorMessage);
            }
        }

        [Test]
        public void ValidAcctCreationEmail()
        {
            using (IWebDriver driver = WebDriverFactory.CreateWebDriver())
            {
                LoginPage loginPage = WebPage.NavigateToPage<LoginPage>(driver);
                loginPage.BeginAccountCreation(RandomStringGenerator.Generate(10) + "@gmail.com");
                Assert.IsTrue(loginPage.IsShowingAccountCreationForm());
            }
        }

        [Test]
        public void BlankFirstName()
        {
            using (IWebDriver driver = WebDriverFactory.CreateWebDriver())
            {
                LoginPage loginPage = WebPage.NavigateToPage<LoginPage>(driver);
                AcctCreationFormInfo info = AcctCreationFormInfo.CreateWithRandomEmail();
                info.PersonalInfo_firstName = null;
                loginPage.BeginAccountCreation(info.Email);
                loginPage.RegisterAccount(info);
                Assert.AreEqual(LoginPage.EMPTY_FIRST_NAME_MESSAGE, loginPage.AcctCreationFormErrorMessage);
            }
        }

        [Test]
        public void BlankLastName()
        {
            using (IWebDriver driver = WebDriverFactory.CreateWebDriver())
            {
                LoginPage loginPage = WebPage.NavigateToPage<LoginPage>(driver);
                AcctCreationFormInfo info = AcctCreationFormInfo.CreateWithRandomEmail();
                info.PersonalInfo_lastName = null;
                loginPage.BeginAccountCreation(info.Email);
                loginPage.RegisterAccount(info);
                Assert.AreEqual(LoginPage.EMPTY_LAST_NAME_MESSAGE, loginPage.AcctCreationFormErrorMessage);
            }
        }

        [Test]
        public void BlankPassword()
        {
            using (IWebDriver driver = WebDriverFactory.CreateWebDriver())
            {
                LoginPage loginPage = WebPage.NavigateToPage<LoginPage>(driver);
                AcctCreationFormInfo info = AcctCreationFormInfo.CreateWithRandomEmail();
                info.Password = null;
                loginPage.BeginAccountCreation(info.Email);
                loginPage.RegisterAccount(info);
                Assert.AreEqual(LoginPage.EMPTY_ACCT_CREATION_PASSWD_MESSAGE, loginPage.AcctCreationFormErrorMessage);
            }
        }

        [Test]
        public void InvalidPhoneNum()
        {
            using (IWebDriver driver = WebDriverFactory.CreateWebDriver())
            {
                LoginPage loginPage = WebPage.NavigateToPage<LoginPage>(driver);
                AcctCreationFormInfo info = AcctCreationFormInfo.CreateWithRandomEmail();
                info.MobilePhone = "invalid phone #";
                loginPage.BeginAccountCreation(info.Email);
                loginPage.RegisterAccount(info);
                Assert.AreEqual(LoginPage.INVALID_PHONE_MESSAGE, loginPage.AcctCreationFormErrorMessage);
            }
        }

        [Test]
        public void InvalidZip()
        {
            using (IWebDriver driver = WebDriverFactory.CreateWebDriver())
            {
                LoginPage loginPage = WebPage.NavigateToPage<LoginPage>(driver);
                AcctCreationFormInfo info = AcctCreationFormInfo.CreateWithRandomEmail();
                info.ZipCode = "invalid zip";
                loginPage.BeginAccountCreation(info.Email);
                loginPage.RegisterAccount(info);
                Assert.AreEqual(LoginPage.INVALID_ZIP_MESSAGE, loginPage.AcctCreationFormErrorMessage);
            }
        }

        [Test]
        public void EnsureEmailIsPrepopulated()
        {
            using (IWebDriver driver = WebDriverFactory.CreateWebDriver())
            {
                LoginPage loginPage = WebPage.NavigateToPage<LoginPage>(driver);
                AcctCreationFormInfo info = AcctCreationFormInfo.CreateWithRandomEmail();
                loginPage.BeginAccountCreation(info.Email);
                Assert.AreEqual(info.Email, loginPage.personalInfo_EmailField.GetAttribute("value"));
            }
        }

        [Test]
        public void EnsureAddrFirstNameIsPrepopulated()
        {
            using (IWebDriver driver = WebDriverFactory.CreateWebDriver())
            {
                LoginPage loginPage = WebPage.NavigateToPage<LoginPage>(driver);
                AcctCreationFormInfo info = AcctCreationFormInfo.CreateWithRandomEmail();
                loginPage.BeginAccountCreation(info.Email);
                loginPage.personalInfo_FirstNameField.SendKeys(info.PersonalInfo_firstName);
                Assert.AreEqual(info.PersonalInfo_firstName, loginPage.addressForm_FirstNameField.GetAttribute("value"));
            }
        }

        [Test]
        public void SuccessfulRegistration()
        {
            using (IWebDriver driver = WebDriverFactory.CreateWebDriver())
            {
                LoginPage loginPage = WebPage.NavigateToPage<LoginPage>(driver);
                AcctCreationFormInfo info = AcctCreationFormInfo.CreateWithRandomEmail();
                loginPage.BeginAccountCreation(info.Email);
                loginPage.RegisterAccount(info);
                WebPage.AssertIsOnWebPage<MyAccountPage>(driver);
            }
        }

    }
}
