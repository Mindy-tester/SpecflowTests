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
    public class ShareSkillFeatureSteps
    {
        [Given(@"I navigate to profile page and click on Share skil button")]
        public void GivenINavigateToProfilePageAndClickOnShareSkilButton()
        {
            LoginPage loginObj = new LoginPage();
            loginObj.LoginStep();
            //Explicit wait for Skill share button
            CommonMethods.waitUntilClickable(Driver.driver, 1000, "(//a[contains(text(), 'Share Skill')])", "XPath");
            Driver.driver.FindElement(By.XPath("//a[contains(text(), 'Share Skill')]")).Click();
        }

        [When(@"I fill the all the mandotory details")]
        public void WhenIFillTheAllTheMandotoryDetails()
        {
            SkillShare skill = new SkillShare();
            skill.AddSkill();
        }
        [Then(@"skill should be added in my listing")]
        public void ThenSkillShouldBeAddedInMyListing()
        {

            SkillShare skill = new SkillShare();
            skill.ValidateTheSkillAdded();
        }
    }
}
