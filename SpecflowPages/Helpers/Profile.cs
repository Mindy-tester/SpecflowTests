using OpenQA.Selenium;
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
    public class Profile
    {

        //Update a language
        public void UpdateLanguage()
        {

            //populate the data from Excel sheet
            ExcelData.PopulateInCollection(@"C:\Users\minty\OneDrive\Documents\Standard\SpecflowTests\SpecflowTests\ExcelData\TestData.xlsx", "Language");
            //to iterate within each language on the page

            for (int i = 1; i <= 4; i++)
            {
                var codeText = Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[" + i + "]/tr[1]/td[1]")).Text;
                Console.WriteLine(codeText);
                if (codeText == "French")
                {
                    //click on pencil icon
                    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i")).Click();
                    //clear existing language
                    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input")).Clear();
                    //update new language
                    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input")).SendKeys(ExcelData.ReadData(5, "Language"));
                    //wait
                    Thread.Sleep(1000);
                    //click on update button
                    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/span/input[1]")).Click();
                    return;

                }
            }
        }

        //valiadte the updated language
        public void ValidateTheUpdateLang()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);

                CommonMethods.Test = CommonMethods.Extent.StartTest("Update a Language");

                Thread.Sleep(1000);
                string ExpectedValue = ExcelData.ReadData(5, "Language");
                for (int j = 1; j <= 4; j++)
                {
                    var actualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + j + "]/tr/td[1]")).Text;
                    if (actualValue == ExpectedValue)
                    {
                        CommonMethods.Test.Log(LogStatus.Pass, "Test Passed, Updated a Language Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageUpdated");
                        Thread.Sleep(500);
                        return;
                    }


                }
            }
            catch (Exception e)
            {
                CommonMethods.Test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }
        //Delete a language
        public void DelLanguage()
        {
            //Populate data from excel
            ExcelData.PopulateInCollection(@"C:\Users\minty\OneDrive\Documents\Standard\SpecflowTests\SpecflowTests\ExcelData\TestData.xlsx", "Language");
            for (int i = 1; i <= 4; i++)
            {
                var deleteText = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                Console.WriteLine(deleteText);
                if (deleteText == ExcelData.ReadData(5, "Language"))
                {
                    //click on delete icon
                    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[2]/i")).Click();

                    return;

                }

            }
        }

        //valiadted the deletd language
        public void ValidateTheDeletedLanguage()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.Test = CommonMethods.Extent.StartTest("Delete a Language");

                Thread.Sleep(1000);
                string notexpectedValue = ExcelData.ReadData(5, "Language");
                for (int j = 1; j <= 4; j++)
                {
                    var actualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + j + "]/tr/td[1]")).Text;
                    if (actualValue != notexpectedValue)
                    {
                        CommonMethods.Test.Log(LogStatus.Pass, "Test Passed, Deleted a Language Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageDeleted");
                        Thread.Sleep(500);
                        return;
                    }

                }

            }
            catch (Exception e)
            {
                CommonMethods.Test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }
    }
}
