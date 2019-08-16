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
    public class AddEducationSteps
    {
        [Given(@"I navigate the Education tab under Profile page")]
        public void GivenINavigateTheEducationTabUnderProfilePage()
        {
            LoginPage loginObj = new LoginPage();
            loginObj.LoginStep();
            //click on Education 
            CommonMethods.waitUntilClickable(Driver.driver, 1000, "(//a[text() = 'Education'])", "XPath");
            Driver.driver.FindElement(By.XPath("//a[text() = 'Education']")).Click();
        }
        [When(@"I clicked on AddNew button under education")]
        public void WhenIClickedOnAddNewButtonUnderEducation()
        {
            Driver.driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][contains(text(),'Add New')]")).Click();
        }
        [When(@"I enetered College/University name, Country of university/College, Title, Degree and year of graduation")]
        public void WhenIEneteredCollegeUniversityNameCountryOfUniversityCollegeTitleDegreeAndYearOfGraduation()
        {

            //Enter the University
            Driver.driver.FindElement(By.XPath("//input[@placeholder='College/University Name']")).SendKeys("CGC");
            //Choose Country
            Driver.driver.FindElement(By.XPath("//select[@name='country']")).Click();
            Driver.driver.FindElement(By.XPath("//option[contains(text(),'Algeria')]")).Click();
            CommonMethods.Wait(10);
            //Choose Title
            Driver.driver.FindElement(By.XPath("//select[@name='title']")).Click();
            Driver.driver.FindElement(By.XPath("//option[contains(text(),'B.Tech')]")).Click();
            //Enter Degree
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Degree']")).SendKeys("Master");
            //Year of Graduation
            Driver.driver.FindElement(By.XPath("//select[@name='yearOfGraduation']")).Click();
            CommonMethods.Wait(10);
            Driver.driver.FindElement(By.XPath("//select[@name='yearOfGraduation']//option[contains(text(),'2016')]")).Click();
            //click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value = 'Add']")).Click();
            CommonMethods.Wait(10);
        }

        [Then(@"the new education should be added")]
        public void ThenTheNewEducationShouldBeAdded()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                CommonMethods.Wait(10);
                CommonMethods.Test = CommonMethods.Extent.StartTest("Add a Education");
                Thread.Sleep(1000);
                string expectedValue = "CGC";
                var actualValue = Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']//preceding-sibling::td")).Text;
                Thread.Sleep(1000);


                if (expectedValue == actualValue)
                {
                    CommonMethods.Test.Log(LogStatus.Pass, "Test Passed, Added a Education Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Education Added");

                }

            }
            catch (Exception e)
            {
                CommonMethods.Test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}
