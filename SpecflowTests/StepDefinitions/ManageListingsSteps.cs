using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages.Helpers;
using System;
using TechTalk.SpecFlow;
using static SpecflowPages.Helpers.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class ManageListingsSteps
    {
        [Given(@"I naviagte to profile page and click on Manage Listing")]
        public void GivenINaviagteToProfilePageAndClickOnManageListing()
        {
            LoginPage loginObj = new LoginPage();
            loginObj.LoginStep();
            CommonMethods.waitUntilClickable(Driver.driver, 1000, "(//a[contains(text(),'Manage Listings')])", "XPath");
            Driver.driver.FindElement(By.XPath("//a[contains(text(),'Manage Listings')]")).Click();
        }

        [When(@"I click Edit listing")]
        public void WhenIClickEditListing()
        {
            SkillShare ValidatedSkill = new SkillShare();
            ValidatedSkill.UpdateSkill();
        }
        [Then(@"skill should be updated")]
        public void ThenSkillShouldBeUpdated()
        {
            CommonMethods.ExtentReports();
            CommonMethods.Test = CommonMethods.Extent.StartTest("update a Skill");
            CommonMethods.Test.Log(LogStatus.Pass, "Test Passed, updated a Skill successfully");
            SaveScreenShotClass.SaveScreenshot(Driver.driver, "Skill Updated");
        }
        [Given(@"I navigate to profile page and click on Manage Listing")]
        public void GivenINavigateToProfilePageAndClickOnManageListing()
        {
            LoginPage loginObj = new LoginPage();
            loginObj.LoginStep();
            CommonMethods.waitUntilClickable(Driver.driver, 1000, "(//a[contains(text(),'Manage Listings')])", "XPath");
            Driver.driver.FindElement(By.XPath("//a[contains(text(),'Manage Listings')]")).Click();
        }

        [When(@"I click delete listing")]
        public void WhenIClickDeleteListing()
        {
            SkillShare deleteSkill = new SkillShare();
            deleteSkill.DeleteSkill();
        }

        [Then(@"skill should be deleted")]
        public void ThenSkillShouldBeDeleted()
        {
            CommonMethods.ExtentReports();
            CommonMethods.Test = CommonMethods.Extent.StartTest("Deleet a Skill");
            CommonMethods.Test.Log(LogStatus.Pass, "Test Passed, Delete a Skill successfully");
            SaveScreenShotClass.SaveScreenshot(Driver.driver, "Skill Updated");
        }

            }
}
