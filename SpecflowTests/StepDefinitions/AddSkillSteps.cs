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
    public class AddSkillSteps
    {
        [Given(@"I navigate to skills tab under profile page")]
        public void GivenINavigateToSkillsTabUnderProfilePage()
        {
            LoginPage loginObj = new LoginPage();
            loginObj.LoginStep();
            CommonMethods.waitUntilClickable(Driver.driver, 1000, "(//a[contains(text(),'Skills')]", "XPath");
            Driver.driver.FindElement(By.XPath("//a[contains(text(),'Skills')]")).Click();
        }

        [When(@"I add new skills")]
        public void WhenIAddNewSkills()
        {
            //Click on AddNew
            Driver.driver.FindElement(By.XPath("//div[@class='ui teal button' and text() = 'Add New']")).Click();
            //Enter the skill 
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Skill']")).SendKeys("Postman");
            //Click the skill dropdown
            Driver.driver.FindElement(By.XPath("//select[@name='level']")).Click();
            CommonMethods.Wait(10);
            //Select skill level
            Driver.driver.FindElement(By.XPath("//option[contains(text(),'Beginner')]")).Click();
            //Click on Add
            Driver.driver.FindElement(By.XPath("//span[@class='buttons-wrapper']//input[contains(@class,'ui teal button')]")).Click();
            CommonMethods.Wait(10);
        }
        [Then(@"the skills should be added")]
        public void ThenTheSkillsShouldBeAdded()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                CommonMethods.Wait(10);
                CommonMethods.Test = CommonMethods.Extent.StartTest("Add a Skill");
                Thread.Sleep(1000);
                string expectedValue = "Postman";
                var actualValue = Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']//preceding-sibling::td")).Text;
                Thread.Sleep(1000);


                if (expectedValue == actualValue)
                {
                    CommonMethods.Test.Log(LogStatus.Pass, "Test Passed, Added a Skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Skill added");

                }

            }
            catch (Exception e)
            {
                CommonMethods.Test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}
