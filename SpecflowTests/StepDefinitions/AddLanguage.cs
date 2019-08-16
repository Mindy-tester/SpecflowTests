using SpecflowPages.Helpers;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.Helpers.CommonMethods;
using OpenQA.Selenium.Support.UI;

namespace SpecflowTests.StepDefinitions
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"I clicked on the Languages tab under Profile page")]
        public void GivenIClickedOnTheLanguagesTabUnderProfilePage()
        {
            LoginPage loginObj = new LoginPage();
            loginObj.LoginStep();
            CommonMethods.waitUntilClickable(Driver.driver, 1000, "(//a[text() = 'Languages'])", "XPath");
            // Click on language tab
            Driver.driver.FindElement(By.XPath("//a[text() = 'Languages']")).Click();
        }

        [When(@"I clicked on add (.*)")]
        public void WhenIClickedOnAddLanguagesUnderProfilePage(string language)
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target']//div[contains(@class,'ui teal button')][contains(text(),'Add New')]")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']")).SendKeys(language);

            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//select[@name='level']")).Click();

            //Choose the language level
            IWebElement Lang = Driver.driver.FindElement(By.XPath("//option[contains(text(),'Basic')]"));
            Lang.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }

        [Then(@"the new (.*) should display on my listings")]
        public void ThenTheNewLanguageShouldDisplayOnMyListings(string language)
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                CommonMethods.Test = CommonMethods.Extent.StartTest("Add a Language");
                string expectedValue = language;
                for (var i = 1; i <= 4; i++)
                {
                    string actualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;

                    if (expectedValue == actualValue)
                    {
                        CommonMethods.Test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                CommonMethods.Test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }

        Profile languageObj;
        [When(@"I clicked on pencil icon and update language")]
        public void WhenIClickedOnPencilIconAndUpdateLanguage()
        {
            languageObj = new Profile();
            languageObj.UpdateLanguage();
        }

        [Then(@"the updated language should display on my listings")]
        public void ThenTheUpdatedLanguageShouldDisplayOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                CommonMethods.Wait(10);
                CommonMethods.Test = CommonMethods.Extent.StartTest("Update a Language");
                Thread.Sleep(1000);
                string expectedValue = "French";
                var actualValue = Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']//preceding-sibling::td")).Text;
                Thread.Sleep(1000);


                if (expectedValue == actualValue)
                {
                    CommonMethods.Test.Log(LogStatus.Pass, "Test Passed, updated a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Language updated");

                }

            }
            catch (Exception e)
            {
                CommonMethods.Test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }
        [When(@"I clicked on delete icon")]
        public void WhenIClickedOnDeleteIcon()
        {
            languageObj = new Profile();
            languageObj.DelLanguage();
        }

        [Then(@"the deleted language should not display on my listings")]
        public void ThenTheDeletedLanguageShouldNotDisplayOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                CommonMethods.Wait(10);
                CommonMethods.Test = CommonMethods.Extent.StartTest("delete a Language");
                Thread.Sleep(1000);
                string expectedValue = "Hindi";
                var actualValue = Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']//preceding-sibling::td")).Text;
                Thread.Sleep(1000);


                if (expectedValue == actualValue)
                {
                    CommonMethods.Test.Log(LogStatus.Pass, "Test Passed, delete a Language failed");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "deleted language");

                }

            }
            catch (Exception e)
            {
                CommonMethods.Test.Log(LogStatus.Fail, "Test passed", e.Message);
            }
        }



    }
}
