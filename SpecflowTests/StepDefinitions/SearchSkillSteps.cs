using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages.Helpers;
using System;
using TechTalk.SpecFlow;
using static SpecflowPages.Helpers.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class SearchSkillSteps
    {
        [Given(@"I navigate to home page")]
        public void GivenINavigateToHomePage()
        {
            LoginPage loginObj = new LoginPage();
            loginObj.LoginStep();
        }

        [Given(@"I enter skill in search box")]
        public void GivenIEnterSkillInSearchBox()
        {
            //wait for skill searchbox
            CommonMethods.WaitForElement(Driver.driver, By.XPath("//input[@placeholder='Search skills']"), 10);
            //Enter skill in skill search
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Search skills']")).SendKeys("Testing");
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Search skills']")).SendKeys(Keys.Enter);
        }

        [Given(@"I select categories")]
        public void GivenISelectCategories()
        {
            // wait for All categories
            CommonMethods.waitUntilClickable(Driver.driver, 1000, "(//b[contains(text(),'All Categories')])", "XPath");
            //click on all category
            Driver.driver.FindElement(By.XPath("//b[contains(text(),'All Categories')]")).Click();
            //wait for category
            CommonMethods.WaitForElement(Driver.driver, By.XPath("//a[@role = 'listitem' and text() ='Graphics & Design']"), 10);
            //click on category
            Driver.driver.FindElement(By.XPath("//a[@role = 'listitem' and text() ='Graphics & Design']")).Click();

        }
        [Then(@"selected categories skill should open")]
        public void ThenSelectedCategoriesSkillShouldOpen()
        {
            CommonMethods.ExtentReports();
            CommonMethods.Test = CommonMethods.Extent.StartTest("Searck skill by category");
            CommonMethods.Test.Log(LogStatus.Pass, "Searck skill by category successfully");
            SaveScreenShotClass.SaveScreenshot(Driver.driver, "Searck skill by category");
        }

        [When(@"I select categories")]
        public void WhenISelectCategories()
        {
            // wait for All categories
            CommonMethods.waitUntilClickable(Driver.driver, 1000, "(//b[contains(text(),'All Categories')])", "XPath");
            //click on all category
            Driver.driver.FindElement(By.XPath("//b[contains(text(),'All Categories')]")).Click();
            //wait for category
            CommonMethods.WaitForElement(Driver.driver, By.XPath("//a[@role = 'listitem' and text() ='Graphics & Design']"), 10);
            //click on category
            Driver.driver.FindElement(By.XPath("//a[@role = 'listitem' and text() ='Graphics & Design']")).Click();
        }

        [When(@"I select subcategories")]
        public void WhenISelectSubcategories()
        {
            CommonMethods.WaitForElement(Driver.driver, By.XPath("//a[@role = 'listitem' and text() = 'Logo Design']"), 10);
            //click on sub category
            Driver.driver.FindElement(By.XPath("//a[@role = 'listitem' and text() = 'Logo Design']")).Click();
        }
               
        [Then(@"selected sub categories skill should open")]
        public void ThenSelectedSubCategoriesSkillShouldOpen()
        {
            CommonMethods.ExtentReports();
            CommonMethods.Test = CommonMethods.Extent.StartTest("Searck skill by sub category");
            CommonMethods.Test.Log(LogStatus.Pass, "Searck skill by sub category successfully");
            SaveScreenShotClass.SaveScreenshot(Driver.driver, "Searck skill by sub category");
        }
    }
}
