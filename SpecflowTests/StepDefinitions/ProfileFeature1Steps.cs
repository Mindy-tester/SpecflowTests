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
    public class SpecFlowFeature1Steps : Utils.Start
    {
        [Given(@"I clicked on the Languages tab under Profile page")]
        public void GivenIClickedOnTheLanguagesTabUnderProfilePage()
        {
            //wait for language 
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

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
            IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[2];
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

                Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
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
            languageObj = new Profile();
            languageObj.ValidateTheUpdateLang();

        }
        [When(@"I clicked on delete icon")]
        public void WhenIClickedOnDeleteIcon()
        {
            languageObj = new Profile();
            languageObj.ValidateTheDeletedLanguage();
        }


        [Then(@"the deleted language should not display on my listings")]
        public void ThenTheDeletedLanguageShouldNotDisplayOnMyListings()
        {
            languageObj = new Profile();
            languageObj.ValidateTheDeletedLanguage();
        }
        

        //Share Skill
        [Given(@"User is on profile page")]
        public void GivenUserIsOnProfilePage()
        {
            //Explicit wait for Skill share button
            WebDriverWait skillSharewait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(20));
            IWebElement skillShareObj = skillSharewait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(), 'Share Skill')]")));
           Driver.driver.FindElement(By.XPath("//a[contains(text(), 'Share Skill')]")).Click();
        }

        [When(@"user click on share skill and add skill")]
        public void WhenUserClickOnShareSkillAndAddSkill()
        {
            SkillShare skill = new SkillShare();
            skill.AddSkill();
        }
        SkillShare validatedSkill;
        [Then(@"skill should display in Manage listings")]
        
        public void ThenSkillShouldDisplayInManageListings()
        {
            validatedSkill = new SkillShare();
            validatedSkill.ValidateTheSkillAdded();
        }

        [When(@"user click on manage listings and click on edit listing")]
        public void WhenUserClickOnManageListingsAndClickOnEditListing()
        {
            // Explicit wait for Manage Listings tab
 
             WebDriverWait skillSharewait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(20));
            IWebElement skillShareObj = skillSharewait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Manage Listings')]")));
            Driver.driver.FindElement(By.XPath("//a[contains(text(),'Manage Listings')]")).Click();
        }

        [Then(@"skill should display with new updates")]
        public void ThenSkillShouldDisplayWithNewUpdates()
        {
            validatedSkill = new SkillShare();
            validatedSkill.UpdateSkill();
        }
        SkillShare delSkill;
        [When(@"user click on manage listings and click on delete listing")]
        public void WhenUserClickOnManageListingsAndClickOnDeleteListing()
        {
            // Explicit wait for Manage Listings tab
            WebDriverWait skillSharewait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(20));
            IWebElement skillShareObj = skillSharewait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Manage Listings')]")));
            Driver.driver.FindElement(By.XPath("//a[contains(text(),'Manage Listings')]")).Click();

            delSkill = new SkillShare();
            delSkill.DeleteSkill();
        }

        [Then(@"skill should not display in listings")]
        public void ThenSkillShouldNotDisplayInListings()
        {
            delSkill = new SkillShare();
            delSkill.ValidateSkillDeleted();
        }

    }
}
