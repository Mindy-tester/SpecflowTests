using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages.Helpers;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static SpecflowPages.Helpers.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class RegistrationSteps
    {
        [Given(@"I have navigated to registration page")]
        public void GivenIHaveNavigatedToRegistrationPage()
        {
            Driver.driver.FindElement(By.XPath("//button[text() = 'Join']")).Click();
        }
        [Given(@"I enter all the following details")]
        public void GivenIEnterAllTheFollowingDetails(Table table)
        {
            dynamic tableDetail = table.CreateDynamicInstance();
            Driver.driver.FindElement(By.XPath("//input[@placeholder='First name']")).SendKeys(tableDetail.Fisrtname);
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Last name']")).SendKeys(tableDetail.Lastname);
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Email address']")).SendKeys(tableDetail.Emailaddress);
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys(tableDetail.Password);
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Confirm Password']")).SendKeys(tableDetail.ConfirmPassword);
        }

        [Given(@"I Select the terms and conditions checkbox")]
        public void GivenISelectTheTermsAndConditionsCheckbox()
        {
            Driver.driver.FindElement(By.XPath("//input[@name='terms']")).Click();
        }
        [Then(@"I click on Join button")]
        public void ThenIClickOnJoinButton()
        {
            Driver.driver.FindElement(By.XPath("//div[@id='submit-btn']")).Click();
        }
        [Then(@"I should be registered")]
        public void ThenIShouldBeRegistered()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                CommonMethods.Wait(10);
                CommonMethods.Test = CommonMethods.Extent.StartTest("Add new user");
                Thread.Sleep(1000);
                string expectedValue = "Registration Successfully, Please verify your email!";
                string actualValue = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-box-inner')]")).Text;
                Thread.Sleep(1000);

                if (expectedValue == actualValue)
                {
                    CommonMethods.Test.Log(LogStatus.Pass, "Test Passed, Added User details Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "User Details Added");

                }

            }
            catch (Exception e)
            {
                CommonMethods.Test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

    }
}
