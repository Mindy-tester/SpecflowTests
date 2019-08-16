using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages.Helpers;
using System;
using System.Collections.Generic;
using System.Threading;
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
            CommonMethods.WaitForElement(Driver.driver, By.XPath("//h2[contains(text(),'Manage Listings')]"), 10);
            IList<IWebElement> noOfPages = Driver.driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));
            //Start the Reports
            CommonMethods.ExtentReports();
            Thread.Sleep(1000);

            CommonMethods.Test = CommonMethods.Extent.StartTest("Update skill");
            while (true)
            {

                for (int j = 1; j <= 5; j++)

                {
                    var titleObj = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;

                    Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                    if (titleObj == "Testing1")
                    {
                        CommonMethods.Test.Log(LogStatus.Pass, "Update Skill Successfully");
                        return;
                    }

                }
                //click next page
                Driver.driver.FindElement(By.XPath("//button[contains(text(),'>')]")).Click();
            }
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
            SkillShare deleteSkill = new SkillShare();
            deleteSkill.ValidateSkillDeleted();
        }

            }
}
