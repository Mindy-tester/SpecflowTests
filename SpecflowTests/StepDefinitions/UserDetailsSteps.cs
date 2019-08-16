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
    public class UserDetailsSteps
    {
        [Given(@"I add my avalibity")]
        public void GivenIAddMyAvalibity()
        {
            //click on Availability
            Driver.driver.FindElement(By.XPath("//span[contains(text(),'Part Time')]//i[@class='right floated outline small write icon']")).Click();
            Driver.driver.FindElement(By.XPath("//select[@name='availabiltyType']")).Click();
            CommonMethods.Wait(10);
            Driver.driver.FindElement(By.XPath("//option[contains(text(),'Part Time')]")).Click();
        }

        [Given(@"I add hours available")]
        public void GivenIAddHoursAvailable()
        {
            CommonMethods.Wait(10);
            Driver.driver.FindElement(By.XPath("//div[@class='extra content']//div[3]//div[1]//span//i")).Click();
            CommonMethods.Wait(10);
            Driver.driver.FindElement(By.XPath("//select[@name='availabiltyHour']")).Click();
            CommonMethods.Wait(10);
            Driver.driver.FindElement(By.XPath("//option[contains(text(),'More than 30hours a week')]")).Click();
        }
        [Given(@"I add earn target")]
        public void GivenIAddEarnTarget()
        {
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("//div[@class='four wide column']//div[4]//div[1]//span//i")).Click();
            CommonMethods.Wait(10);
            Driver.driver.FindElement(By.XPath("//select[@name='availabiltyTarget']")).Click();
            CommonMethods.Wait(10);
            Driver.driver.FindElement(By.XPath("//select[@name='availabiltyTarget']//option[3]")).Click();
        }

        [Then(@"all details should be added")]
        public void ThenAllDetailsShouldBeAdded()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                CommonMethods.Wait(10);
                CommonMethods.Test = CommonMethods.Extent.StartTest("User Details added");
                Thread.Sleep(1000);
                string expectedValue = "Availability updated";
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
