using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumTestSuiteExample
{
    [TestFixture]
    class ContactPageTests
    {

        [Test]
        public void SelectCustomerServiceHeading()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                ContactPage contactPage = WebPage.NavigateToPage<ContactPage>(driver);
                contactPage.SelectSubjectHeading(ContactPage.SubjectHeading.CustomerService);
                Assert.IsTrue(contactPage.IsShowingCustomerServiceComment);
            }
        }

        [Test]
        public void SelectWebmasterHeading()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                ContactPage contactPage = WebPage.NavigateToPage<ContactPage>(driver);
                contactPage.SelectSubjectHeading(ContactPage.SubjectHeading.Webmaster);
                Assert.IsTrue(contactPage.IsShowingWebmasterComment);
            }
        }

        [Test]
        public void SelectOrderReference()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                WebPage.NavigateToPage<LoginPage>(driver).Login(TestUser.Email, TestUser.Password);
                ContactPage contactPage = WebPage.NavigateToPage<ContactPage>(driver);
                contactPage.SelectOrderReference();
                Assert.IsTrue(contactPage.AProductPickerIsShowing);
            }
        }

        [Test]
        public void AttemptSendWithInvalidEmail()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                WebPage.NavigateToPage<LoginPage>(driver).Login(TestUser.Email, TestUser.Password);
                ContactPage contactPage = WebPage.NavigateToPage<ContactPage>(driver);
                contactPage.SelectSubjectHeading(ContactPage.SubjectHeading.CustomerService);
                contactPage.enterEmail("invalid email");
                contactPage.pressSendButton();
                Assert.IsTrue(contactPage.ErrorMesage == ContactPage.INVALID_EMAIL_ERROR);
            }
        }

        [Test]
        public void AttemptSendWithEmptyMessage()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                WebPage.NavigateToPage<LoginPage>(driver).Login(TestUser.Email, TestUser.Password);
                ContactPage contactPage = WebPage.NavigateToPage<ContactPage>(driver);
                contactPage.SelectSubjectHeading(ContactPage.SubjectHeading.CustomerService);
                contactPage.pressSendButton();
                Assert.IsTrue(contactPage.ErrorMesage == ContactPage.EMPTY_MESSAGE_ERROR);
            }
        }

        [Test]
        public void SuccessfulMessage()
        {
            using (var driver = WebDriverFactory.CreateWebDriver())
            {
                WebPage.NavigateToPage<LoginPage>(driver).Login(TestUser.Email, TestUser.Password);
                ContactPage contactPage = WebPage.NavigateToPage<ContactPage>(driver);
                contactPage.SelectSubjectHeading(ContactPage.SubjectHeading.CustomerService);
                contactPage.enterMessage("test message");
                contactPage.pressSendButton();
                Assert.IsTrue(contactPage.IsShowingSuccessPrompt);
            }
        }

    }
}
