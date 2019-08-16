using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages.Helpers;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.Helpers.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class ChangePasswordSteps : Utils.Start
    {
        [Given(@"I navigate to Account Setting page")]
        public void GivenINavigateToAccountSettingPage()
        {
            LoginPage loginObj = new LoginPage();
            loginObj.LoginStep();
            CommonMethods.WaitForElement(Driver.driver, By.XPath("//span[text() = 'Hi ']"), 10);
            Driver.driver.FindElement(By.XPath("//span[text() = 'Hi ']")).Click();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("//a[contains(text(),'Account Settings')]")).Click();

        }

        [Given(@"I click on password edit icon")]
        public void GivenIClickOnPasswordEditIcon()
        {
            CommonMethods.WaitForElement(Driver.driver, By.XPath("//input[@id='Password']"), 10);
            Driver.driver.FindElement(By.XPath("//input[@id='Password']")).Click();
        }

        [Given(@"I enter (.*)")]
        public void GivenIEnter(int Currentpassword)
        {
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Current Password']")).SendKeys(Currentpassword.ToString());
        }

        [Given(@"I enter (.*) and (.*)")]
        public void GivenIEnterAnd(int Newpassword, int Confirmpassword)
        {
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("//input[@placeholder='New Password']")).SendKeys(Newpassword.ToString());
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Confirm Password']")).SendKeys(Confirmpassword.ToString());
        }

        [When(@"I click Save button")]
        public void WhenIClickSaveButton()
        {
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("//button[text() = 'Save']")).Click();

        }

        [Then(@"I should see the confirmation message")]
        public void ThenIShouldSeeTheConfirmationMessage()
        {
            //Start the Reports
            CommonMethods.ExtentReports();
            CommonMethods.Wait(10);
            CommonMethods.Test = CommonMethods.Extent.StartTest("Change Password");
            Thread.Sleep(1000);
            string expectedValue = "Password Changed Successfully";
            string message = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-box-inner')]")).Text;
            Thread.Sleep(1000);
            if (expectedValue == message)
            {
                CommonMethods.Test.Log(LogStatus.Pass, "Test Passed, Password Changed Successfully");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Password Changed");

            }

       }
    }
}
