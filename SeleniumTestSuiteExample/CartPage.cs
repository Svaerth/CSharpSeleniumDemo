using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace SeleniumTestSuiteExample
{
    class CartPage : WebPage
    {

        public enum Step : int
        {
            Summary,
            SignIn,
            Address,
            Shipping,
            Payment
        }
        static Step[] stepOrder = new Step[] { Step.Summary, Step.SignIn, Step.Address, Step.Shipping, Step.Payment };

        public int ItemsInCart => cartItems.Count;
        public string DeliveryAddrLine1 => deliveryaddrLine1Label.Text;
        public bool TOSErrorPromptIsShowing => TOSErrorPrompt != null;

        public void RemoveTopItemFromCart()
        {
            trashCanButton.Click();
        }

        public void PressProceedBtn()
        {
            switch (currentStep)
            {
                case Step.Summary:
                    summaryProceedBtn.Click();
                    break;
                case Step.Address:
                    addressProceedBtn.Click();
                    break;
                case Step.Shipping:
                    shippingProceedBtn.Click();
                    break;
                default:
                    throw new Exception("The current step, " + (Step)currentStep + ", doesn't have a proceed button!");
            }
        }

        public void GoToStep(Step desiredStep)
        {
            if (OrderOfStep(desiredStep) < OrderOfStep(currentStep))
            {
                throw new Exception("Attempted to go from step " + currentStep + " to step " + desiredStep + ". Going backwards is unsupported!");
            }

            while (IsOnStep(desiredStep) == false)
            {
                AdvanceToNextStep();
            }
        }

        public Step GetStepAfter(Step step)
        {
            int nextStep = OrderOfStep(step) + 1;
            if (stepOrder.Length - 1 < nextStep)
            {
                throw new Exception("There is no step after " + step + "!");
            }
            return stepOrder[nextStep];
        }

        public bool IsOnStep(Step step)
        {
            switch(step)
            {
                case Step.Summary:
                    return currentStepDescription == "Your shopping cart";
                case Step.SignIn:
                    return WebPage.IsOnWebPage<LoginPage>(driver);
                case Step.Address:
                    return currentStepDescription == "Addresses";
                case Step.Shipping:
                    return currentStepDescription == "Shipping";
                case Step.Payment:
                    return currentStepDescription == "Your payment method";
                default:
                    throw new Exception("Invalid step: " + step);
            }
        }

        public bool IsOnStepAfter(Step step)
        {
            Step nextStep = GetStepAfter(step);
            return IsOnStep(nextStep);
        }

        public void AgreeToTOS()
        {
            TOSCheckbox.Click();
        }

        public void ChangeAddress()
        {
            chooseAddrDropdown.ChangeToRandomSelection();
        }

        public void PayByBankWire()
        {
            payByBankwireBtn.Click();
        }

        void AdvanceToNextStep()
        {
            switch (currentStep)
            {
                case Step.Summary:
                    PressProceedBtn();
                    break;
                case Step.SignIn:
                    if (WebPage.IsOnWebPage<LoginPage>(driver))
                    {
                        WebPage.Create<LoginPage>(driver).Login(TestUser.Email, TestUser.Password);
                    }
                    break;
                case Step.Address:
                    PressProceedBtn();
                    break;
                case Step.Shipping:
                    AgreeToTOS();
                    PressProceedBtn();
                    break;
                case Step.Payment:
                    throw new Exception("Attempted to advance to next step when already at final step!");
            }
        }

        int OrderOfStep(Step step)
        {
            
            for(int i = 0; i < stepOrder.Length; i++)
            {
                if (step == stepOrder[i])
                {
                    return i;
                }
            }
            throw new Exception("Step " + step + " not found in step order!");
        }

        protected override string URL => "http://automationpractice.com/index.php?controller=order";
        protected override string PageTitle => "Order - My Store";
        private Step currentStep 
        {
            get
            {
                foreach(var step in stepOrder)
                {
                    if (IsOnStep(step))
                    {
                        return step;
                    }
                }
                throw new Exception("current step could not be identified!");
            }
        }
        private ReadOnlyCollection<IWebElement> cartItems => driver.FindElements(By.ClassName("cart_item"));
        private IWebElement stepDescriptionLabel => driver.FindElement(By.ClassName("navigation_page"));
        private string currentStepDescription => stepDescriptionLabel.Text.Trim();
        
        private IWebElement trashCanButton => driver.FindElement(By.ClassName("cart_quantity_delete"));
        private IWebElement summaryProceedBtn => driver.FindElement(By.CssSelector(".cart_navigation > [title=\"Proceed to checkout\"]"));

        private SelectElement chooseAddrDropdown => new SelectElement(driver.FindElement(By.Id("id_address_delivery")));
        private IWebElement deliveryaddrLine1Label => driver.FindElement(By.CssSelector("#address_delivery .address_address1"));
        private IWebElement addressProceedBtn => driver.FindElement(By.CssSelector("[name=\"processAddress\"]"));
       
        private IWebElement shippingProceedBtn => driver.FindElement(By.CssSelector("[name=\"processCarrier\"]"));
        private IWebElement TOSCheckbox => driver.FindElement(By.Id("cgv"));
        private IWebElement TOSErrorPrompt => driver.TryFindElement(By.CssSelector(".fancybox-overlay.fancybox-overlay-fixed"));

        private IWebElement payByBankwireBtn => driver.FindElement(By.ClassName("bankwire"));
        private IWebElement payByCheckBtn => driver.FindElement(By.ClassName("cheque"));
    }
}
