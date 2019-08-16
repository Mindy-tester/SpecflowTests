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
            CommonMethods.WaitForElement(Driver.driver, By.XPath("//h3[contains(text(),'Title')]"), 10);
            IWebElement addTitle = Driver.driver.FindElement(By.Name("title"));
            addTitle.SendKeys("Testing1");
            //add description
            IWebElement addDescription = Driver.driver.FindElement(By.Name("description"));
            addDescription.SendKeys("This is specflow");
            //Select Category
            CommonMethods.WaitForElement(Driver.driver, By.XPath("//h3[contains(text(),'Title')]"), 10);
            SelectElement categoryObj = new SelectElement(Driver.driver.FindElement(By.Name("categoryId")));
            categoryObj.SelectByValue("3");
            //Explicit wait for sub category
            CommonMethods.waitUntilClickable(Driver.driver, 1000, "(//select[@name='subcategoryId'])", "XPath");
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
            //click on save
            CommonMethods.waitUntilClickable(Driver.driver, 1000, "(//input[@value = 'Save'])", "XPath");
            IWebElement saveBtn = Driver.driver.FindElement(By.XPath("//input[@value = 'Save']"));
            saveBtn.Click();
        }

        public void ValidateTheSkillAdded()
        {
            CommonMethods.WaitForElement(Driver.driver, By.XPath("//h2[contains(text(),'Manage Listings')]"), 10);
            IList<IWebElement> noOfPages = Driver.driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));
            //Start the Reports
            CommonMethods.ExtentReports();
            Thread.Sleep(1000);

            CommonMethods.Test = CommonMethods.Extent.StartTest("Share skill");
            while (true)
            {

                for (int j = 1; j <= 5; j++)

                {
                    var titleObj = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;

                    Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                    if (titleObj == "Testing1")
                    {
                        CommonMethods.Test.Log(LogStatus.Pass, "Skill Shared Successfully");
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

            while (true)
            {

                for (int j = 1; j <= 5; j++)

                {
                    CommonMethods.WaitForElement(Driver.driver, By.XPath("//tr[1]//td[3]"), 10);
                    var categoryObj = Driver.driver.FindElement(By.XPath("//tr[" + j + "]//td[2]")).Text;
                    var titleObj = Driver.driver.FindElement(By.XPath("//tr[" + j + "]//td[3]")).Text;

                    IWebElement updateListing = Driver.driver.FindElement(By.XPath("//tr[" + j + "]//td[8]//i[2]"));
                    CommonMethods.Wait(10);
                    if (titleObj == "ttt" && categoryObj == "Programming & Tech")
                    {
                        //wait for update btn
                        CommonMethods.waitUntilClickable(Driver.driver, 1000, "(//tr[" + j + "]//td[8]//i[2])", "XPath");
                        updateListing.Click();
                        CommonMethods.Wait(10);
                        updSkillObj.AddSkill();
                        return;
                    }
                }
                //click next page
                Driver.driver.FindElement(By.XPath("//button[contains(text(),'>')]")).Click();

            }

        }
        public void DeleteSkill()
        {
            while (true)
            {

                for (int j = 1; j <= 5; j++)

                {
                    CommonMethods.WaitForElement(Driver.driver, By.XPath("//tr[1]//td[3]"), 10);
                    var categoryObj = Driver.driver.FindElement(By.XPath("//tr[" + j + "]//td[2]")).Text;
                    var titleObj = Driver.driver.FindElement(By.XPath("//tr[" + j + "]//td[3]")).Text;

                    Console.WriteLine(titleObj);
                    Console.WriteLine(categoryObj);
                    IWebElement deleteListing = Driver.driver.FindElement(By.XPath("//tr[" + j + "]//td[8]//i[3]"));

                    CommonMethods.Wait(10);
                    if (titleObj == "API")
                    {
                        //wait for delete btn
                        CommonMethods.waitUntilClickable(Driver.driver, 1000, "(//tr[" + j + "]//td[8]//i[3])", "XPath");

                        deleteListing.Click();
                        //wait for accept btn
                        CommonMethods.waitUntilClickable(Driver.driver, 1000, "(//button[@class='ui icon positive right labeled button'])", "XPath");
                        Driver.driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']")).Click();
                        return;
                    }
                }// click next page
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

                        if (titleObj == "API")
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


