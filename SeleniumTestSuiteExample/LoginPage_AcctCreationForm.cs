using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestSuiteExample
{
    partial class LoginPage
    {
        public const string EMPTY_FIRST_NAME_MESSAGE = "firstname is required.";
        public const string EMPTY_LAST_NAME_MESSAGE = "lastname is required.";
        public const string EMPTY_ACCT_CREATION_PASSWD_MESSAGE = "passwd is required.";
        public const string INVALID_PHONE_MESSAGE = "phone_mobile is invalid.";
        public const string INVALID_ZIP_MESSAGE = "The Zip/Postal code you've entered is invalid. It must follow this format: 00000";

        public string AcctCreationFormErrorMessage
        {
            get
            {
                return driver.FindElement(By.CssSelector(".alert.alert-danger"))
                       .FindElement(By.TagName("li")).Text;
            }
        }

        public bool IsShowingAccountCreationForm()
        {
            
            try
            {
                _ = accountCreationForm;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        
        /// <summary>
        /// Registers an account with the passed in info. 
        /// For parameters left null, the corresponding field will be left alone.
        /// </summary>
        public void RegisterAccount(
            AcctCreationFormInfo info
        )
        {
            personalInfo_EmailField.ClearAndPopulateIfNotNull(info.Email);
            personalInfo_FirstNameField.ClearAndPopulateIfNotNull(info.PersonalInfo_firstName);
            personalInfo_LastNameField.ClearAndPopulateIfNotNull(info.PersonalInfo_lastName);
            personalInfo_PasswdField.ClearAndPopulateIfNotNull(info.Password);
            addressForm_FirstNameField.ClearAndPopulateIfNotNull(info.Addr_firstName);
            addressForm_LastNameField.ClearAndPopulateIfNotNull(info.Addr_lastName);
            address1Field.ClearAndPopulateIfNotNull(info.AddressLine1);
            address2Field.ClearAndPopulateIfNotNull(info.AddressLine2);
            cityField.ClearAndPopulateIfNotNull(info.City);
            statePicker.SelectByText(info.State);
            zipField.ClearAndPopulateIfNotNull(info.ZipCode);
            countryPicker.SelectByText(info.Country);
            mobilePhoneField.ClearAndPopulateIfNotNull(info.MobilePhone);
            aliasField.ClearAndPopulateIfNotNull(info.Alias);

            registerAcctButton.Click();
        }

        private IWebElement accountCreationForm => driver.FindElement(By.Id("account-creation_form"));

        #region personal info form fields
        public IWebElement personalInfo_EmailField => accountCreationForm.FindElement(By.Id("email"));
        public IWebElement personalInfo_FirstNameField => driver.FindElement(By.Id("customer_firstname"));
        private IWebElement personalInfo_LastNameField => driver.FindElement(By.Id("customer_lastname"));
        private IWebElement personalInfo_PasswdField => accountCreationForm.FindElement(By.Id("passwd"));
        #endregion

        #region address form fields
        public IWebElement addressForm_FirstNameField => driver.FindElement(By.Id("firstname"));
        private IWebElement addressForm_LastNameField => driver.FindElement(By.Id("lastname"));
        private IWebElement address1Field => driver.FindElement(By.Id("address1"));
        private IWebElement address2Field => driver.FindElement(By.Id("address2"));
        private IWebElement cityField => driver.FindElement(By.Id("city"));
        private IWebElement zipField => driver.FindElement(By.Id("postcode"));
        private IWebElement mobilePhoneField => driver.FindElement(By.Id("phone_mobile"));
        private IWebElement aliasField => driver.FindElement(By.Id("alias"));
        private SelectElement statePicker => new SelectElement(driver.FindElement(By.Id("id_state")));
        private SelectElement countryPicker => new SelectElement(driver.FindElement(By.Id("id_country")));
        #endregion

        private IWebElement registerAcctButton => driver.FindElement(By.Id("submitAccount"));

    }
}
