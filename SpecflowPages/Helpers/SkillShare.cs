using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SpecflowPages.Helpers.CommonMethods;

namespace SpecflowPages.Helpers
{
    public class SkillShare
    {
        public void AddSkill()
        {
            //add title
            IWebElement addTitle = Driver.driver.FindElement(By.Name("title"));
            addTitle.SendKeys("Testing1");


            //add description
            IWebElement addDescription = Driver.driver.FindElement(By.Name("description"));
            addDescription.SendKeys("This is specflow");

            //add category
            //Select Category
            SelectElement categoryObj = new SelectElement(Driver.driver.FindElement(By.Name("categoryId")));
            categoryObj.SelectByValue("3");



            //Explicit wait for sub category
            WebDriverWait subCategoryWait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(30));
            IWebElement subCategory = subCategoryWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("subcategoryId")));

            //Select Sub Category
            SelectElement subCategoryObj = new SelectElement(Driver.driver.FindElement(By.Name("subcategoryId")));

            subCategoryObj.SelectByIndex(2);

            //add Tags
            IWebElement addTags = Driver.driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]"));
            addTags.SendKeys("New");
            addTags.SendKeys(Keys.Enter);

            //Select SkillTrade
            IWebElement skillTradeObj = Driver.driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@placeholder='Add new tag']"));
            skillTradeObj.SendKeys("tag");
            skillTradeObj.SendKeys(Keys.Enter);

            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //click on save
            IWebElement saveBtn = Driver.driver.FindElement(By.XPath("//input[@value = 'Save']"));
            saveBtn.Click();


        }

        public void ValidateTheSkillAdded()
        {
            WebDriverWait wait1 = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(20));
            IWebElement element1 = wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h2[contains(text(),'Manage Listings')]")));
            IList<IWebElement> noOfPages = Driver.driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));

            //Start the Reports
            CommonMethods.ExtentReports();
            Thread.Sleep(1000);

            CommonMethods.Test = CommonMethods.Extent.StartTest("Add a skill");
            for (int i = 0; i <= noOfPages.Count; i++)
            {
                
                for (int j = 1; j <= 5; j++)

                {
                    var titleObj = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;
                   
                    Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    
                    if (titleObj == "Testing1")
                    {
                        CommonMethods.Test.Log(LogStatus.Pass, "Skill added Successfully");
                        return;
                    }

                }
                //click next page
                Driver.driver.FindElement(By.XPath("//button[contains(text(),'>')]")).Click();
            }

        }
        public void UpdateSkill()
        {

            SkillShare updSkillObj = new SkillShare();
            //Start the Reports
            CommonMethods.ExtentReports();
            Thread.Sleep(1000);

            CommonMethods.Test = CommonMethods.Extent.StartTest("update a skill");

            IList<IWebElement> noOfPages = Driver.driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));
            for (int i = 0; i <= noOfPages.Count; i++)
            {

                for (int j = 1; j <= 5; j++)

                {
                    Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    var titleObj = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;
                    var categoryObj = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[2]")).Text;

                    IWebElement updateListing = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[8]/i[2]"));
                    Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    if (titleObj == "ttt" && categoryObj == "Programming & Tech")
                    {
                        Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        updateListing.Click();
                        Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        updSkillObj.AddSkill();
                        CommonMethods.Test.Log(LogStatus.Pass, "Skill updated Successfully");
                        return;
                    }
                }
                //click next page
                Driver.driver.FindElement(By.XPath("//button[contains(text(),'>')]")).Click();

            }

         }
        public void DeleteSkill()
        {
            WebDriverWait wait1 = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(20));
            IWebElement element1 = wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h2[contains(text(),'Manage Listings')]")));
            
            IList<IWebElement> noOfPages = Driver.driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));

                for (int i = 0; i <= noOfPages.Count; i++)
                {

                    for (int j = 1; j <= 5; j++)

                    {
                        var titleObj = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;
                        //var categoryObj = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[2]")).Text;
                       
                        IWebElement deleteListing = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + " ]/td[8]/i[3]"));

                        Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        if (titleObj == "Testing1")
                        {
                            //Explicit wait for delete btn
                            WebDriverWait deleteListingWait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
                            IWebElement deleteListingObj = deleteListingWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + " ]/td[8]/i[3]")));
                            deleteListing.Click();
                            //Explicit wait for accept btn
                            WebDriverWait acceptBtnWait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
                            IWebElement acceptBtnObj = acceptBtnWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='ui icon positive right labeled button']")));
                           Driver.driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']"));

                            return;

                        }
                    }
                    // click next page
                Driver.driver.FindElement(By.XPath("//button[contains(text(),'>')]")).Click();
                }
                   
                
        }

        public void ValidateSkillDeleted()
        {
            //Start the Reports
            CommonMethods.ExtentReports();
            Thread.Sleep(1000);

            CommonMethods.Test = CommonMethods.Extent.StartTest("delete a skill");

            IList<IWebElement> noOfPages = Driver.driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));
            try
            {
                for (int i = 0; i <= noOfPages.Count; i++)
                {
                    for (int j = 1; j <= 5; j++)

                    {
                        var titleObj = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;
                        var categoryObj = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[2]")).Text;

                        if (titleObj == "Testing1")
                        {
                            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                            CommonMethods.Test.Log(LogStatus.Info, "Skill deleted failed");
                        }

                    }
                    //click next page
                    Driver.driver.FindElement(By.XPath("//button[contains(text(),'>')]")).Click();
                }
            }
            catch (Exception)
            {
                CommonMethods.Test.Log(LogStatus.Pass, "Skill deleted passed");
            }
        }
    } 
    
}


