using OpenQA.Selenium;
using SpecflowPages.Helpers;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowTests
{
    [Binding]
    public class SignInSteps
    {
        [Given(@"I have navigated to application")]
        public void GivenIHaveNavigatedToApplication()
        {
            Driver.driver.FindElement(By.XPath("//a[@class='item']")).Click();
        }
        [Given(@"I entered username and password")]
        public void GivenIEnteredUsernameAndPassword()
        {
            // Enter Username
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Email address']")).SendKeys("minty80@gmail.com");
            //Enter password
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("123123");
        }
        [Given(@"I click login")]
        public void GivenIClickLogin()
        {
            //Click on Login Button
            Driver.driver.FindElement(By.XPath("//button[contains(text(), 'Login')]")).Click();
        }

        [Then(@"I should be at the home page")]
        public void ThenIShouldBeAtTheHomePage()
        {
            //Start the Reports
            CommonMethods.ExtentReports();
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            CommonMethods.Test = CommonMethods.Extent.StartTest("Login");
            var text = Driver.driver.FindElement(By.XPath("//a[contains(text(),'Mars Logo')]")).Text;
            Console.WriteLine(text);
            Thread.Sleep(1000);

            if (text == "Mars Logo")
            {
                CommonMethods.Test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Login Successful");
            }
            else
            {
                CommonMethods.Test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Login Unsuccessful");

            }
        }
    }
}
