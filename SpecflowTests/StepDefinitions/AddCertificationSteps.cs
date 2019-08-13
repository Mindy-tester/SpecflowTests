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
    public class AddCertificationSteps
    {

        [Given(@"I navigate the Certifications tab under Profile page")]
        public void GivenINavigateTheCertificationsTabUnderProfilePage()
        {
            LoginPage loginObj = new LoginPage();
            loginObj.LoginStep();
            CommonMethods.waitUntilClickable(Driver.driver, 1000, "(//a[text() = 'Certifications'])", "XPath");
            Driver.driver.FindElement(By.XPath("//a[text() = 'Certifications']")).Click();
        }

        [When(@"I clicked on AddNew button")]
        public void WhenIClickedOnAddNewButton()
        {
            //click on AddNew button
            Driver.driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][contains(text(),'Add New')]")).Click();
        }
        [When(@"I enetered Certification, Certified from and Year of certification")]
        public void WhenIEneteredCertificationCertifiedFromAndYearOfCertification()
        {
            //Enter Certificate Name
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']")).SendKeys("ISTQB");
            //Enter Certified from
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Certified From (e.g. Adobe)']")).SendKeys("ANZTB");
            //Enter the Year
            Driver.driver.FindElement(By.XPath("//select[@name='certificationYear']")).Click();
            CommonMethods.Wait(10);
            Driver.driver.FindElement(By.XPath("//option[contains(text(),'2014')]")).Click();
            //click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value = 'Add']")).Click();
            CommonMethods.Wait(10);
        }
        [Then(@"new certicifation should be added")]
        public void ThenNewCerticifationShouldBeAdded()
        {
            CommonMethods.ExtentReports();
            CommonMethods.Test = CommonMethods.Extent.StartTest("Add a Certification");
            CommonMethods.Test.Log(LogStatus.Pass, "Test Passed, Added a certification successfully");
            SaveScreenShotClass.SaveScreenshot(Driver.driver, "Certification Added");
        }

    }
}
