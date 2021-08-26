using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace SeleniumTestSuiteExample
{
    class ContactPage : WebPage
    {

        public enum SubjectHeading
        {
            CustomerService,
            Webmaster
        }

        public string ErrorMesage => errorMessageLabel.Text;
        public const string INVALID_EMAIL_ERROR = "Invalid email address.";
        public const string EMPTY_MESSAGE_ERROR = "The message cannot be blank.";

        public bool IsShowingCustomerServiceComment => customerServiceCommentLabel.Displayed;
        public bool IsShowingWebmasterComment => webmasterCommentLabel.Displayed;
        public bool IsShowingSuccessPrompt => successPrompt != null;
        public bool AProductPickerIsShowing 
        {
            get
            {
                foreach(var picker in productPickers)
                {
                    if (picker.DisplayStyleIsNone() == false)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void SelectSubjectHeading(SubjectHeading heading)
        {
            SubjectHeadingPicker.SelectByIndex(GetIndexForHeading(heading));
        }

        public void SelectOrderReference()
        {
            OrderReferencePicker.SelectByIndex(1);
        }

        public void enterEmail(string email)
        {
            emailField.Clear();
            emailField.SendKeys(email);
        }

        public void enterMessage(string message)
        {
            messageField.Clear();
            messageField.SendKeys(message);
        }

        public void pressSendButton()
        {
            sendBtn.Click();
        }

        protected override string URL => "http://automationpractice.com/index.php?controller=contact";
        protected override string PageTitle => "Contact us - My Store";
        private SelectElement SubjectHeadingPicker => new SelectElement(driver.FindElement(By.Id("id_contact")));
        private SelectElement OrderReferencePicker => new SelectElement(driver.FindElement(By.CssSelector("[name=\"id_order\"]")));
        private IWebElement customerServiceCommentLabel => driver.FindElement(By.Id("desc_contact2"));
        private IWebElement webmasterCommentLabel => driver.FindElement(By.Id("desc_contact1"));
        private ReadOnlyCollection<IWebElement> productPickers => driver.FindElements(By.CssSelector(".unvisible.product_select.form-control"));
        private IWebElement emailField => driver.FindElement(By.Id("email"));
        private IWebElement messageField => driver.FindElement(By.Id("message"));
        private IWebElement sendBtn => driver.FindElement(By.CssSelector("[name=\"submitMessage\"]"));
        private IWebElement errorMessageLabel => driver.FindElement(By.CssSelector(".alert.alert-danger li"));
        private IWebElement successPrompt => driver.TryFindElement(By.CssSelector(".alert.alert-success"));

        int GetIndexForHeading(SubjectHeading heading)
        {
            switch(heading)
            {
                case SubjectHeading.CustomerService:
                    return 1;
                case SubjectHeading.Webmaster:
                    return 2;
                default:
                    throw new Exception("Unsupported subject heading type: " + heading);
            }
        }
    }
}
