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
    public class AddDescriptionSteps
    {
        [Given(@"I navigate to profile page")]
        public void GivenINavigateToProfilePage()
        {
            LoginPage loginObj = new LoginPage();
            loginObj.LoginStep();
        }
        [Given(@"I click on decription update icon")]
        public void GivenIClickOnDecriptionUpdateIcon()
        {
            CommonMethods.WaitForElement(Driver.driver, By.XPath("//h3[@class='ui dividing header']//i[@class='outline write icon']"), 10);
            Driver.driver.FindElement(By.XPath("//h3[@class='ui dividing header']//i[@class='outline write icon']")).Click();
        }
        [Given(@"I added description and click save")]
        public void GivenIAddedDescriptionAndClickSave()
        {

            //clear Description
            Driver.driver.FindElement(By.XPath("//textarea[@name = 'value']")).Clear();
            //Add Description
            Driver.driver.FindElement(By.XPath("//textarea[@name = 'value']")).SendKeys("Certified QA");
            CommonMethods.Wait(10);
            //Click save
            Driver.driver.FindElement(By.XPath("//div[@class='ui twelve wide column']//button[@class='ui teal button'][contains(text(),'Save')]")).Click();
        }
        [Then(@"Description should be added")]
        public void ThenDescriptionShouldBeAdded()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                CommonMethods.Wait(10);
                CommonMethods.Test = CommonMethods.Extent.StartTest("Add a Desription");
                Thread.Sleep(1000);
                string expectedValue = "Certified QA";
                string actualValue = Driver.driver.FindElement(By.XPath("//textarea[@name = 'value']")).Text;
                Thread.Sleep(1000);
                if (expectedValue == actualValue)
                {
                    CommonMethods.Test.Log(LogStatus.Pass, "Test Passed, Added a Description Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "DesriptionAdded");

                }
                else
                {
                    CommonMethods.Test.Log(LogStatus.Fail, "Test Failed");
                }
            }

            catch (Exception e)
            {
                CommonMethods.Test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}
