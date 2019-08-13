using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages.Helpers;
using System;
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
            Driver.driver.FindElement(By.XPath("//div[@class='extra content']//div[3]//div[1]")).Click();
            Driver.driver.FindElement(By.XPath("//select[@name='availabiltyHour']")).Click();
            CommonMethods.Wait(10);
            Driver.driver.FindElement(By.XPath("//option[contains(text(),'More than 30hours a week')]")).Click();
        }
        [Given(@"I add earn target")]
        public void GivenIAddEarnTarget()
        {
            Driver.driver.FindElement(By.XPath("//div[@class='four wide column']//div[4]//div[1]")).Click();
            Driver.driver.FindElement(By.XPath("//select[@name='availabiltyTarget']")).Click();
            CommonMethods.Wait(10);
            Driver.driver.FindElement(By.XPath("//select[@name='availabiltyTarget']//option[3]")).Click();
        }

        [Then(@"all details should be added")]
        public void ThenAllDetailsShouldBeAdded()
        {
            CommonMethods.ExtentReports();
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            CommonMethods.Test = CommonMethods.Extent.StartTest("Add User Detail");
            CommonMethods.Test.Log(LogStatus.Pass, "Test Passed, Added user detail successfully");
            SaveScreenShotClass.SaveScreenshot(Driver.driver, "User Detail Added");
        }
    }
}
