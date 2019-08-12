using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.IO;



namespace SpecflowPages.Helpers
{
    //Screenshot
    public class CommonMethods
    {
        public class SaveScreenShotClass
        {
            public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
            {
                var folderLocation = (ConstantHelpers.ScreenshotPath);

                if (!System.IO.Directory.Exists(folderLocation))
                {
                    System.IO.Directory.CreateDirectory(folderLocation);
                }

                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = new StringBuilder(folderLocation);

                fileName.Append(ScreenShotFileName);
                fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
                //fileName.Append(DateTime.Now.ToString("dd-mm-yyyym_ss"));
                fileName.Append(".jpeg");
                screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
                return fileName.ToString();
            }
        }
        //ExtentReports
        #region reports
        public static ExtentTest Test;
        public static ExtentReports Extent;

        public static void ExtentReports()
        {
            Extent = new ExtentReports(ConstantHelpers.ReportsPath, false, DisplayOrder.NewestFirst);
            Extent.LoadConfig(ConstantHelpers.ReportXMLPath);
        }
        #endregion

        #region Wait for Element

        public static void Wait(int time)
        {
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);

        }
        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by)));
        }
        //wait for element to be clickable

        public static void waitUntilClickable(IWebDriver driver, int timeSeconds, string LocatorValue, string LocatorType)
        {
            if (LocatorType == "Xpath")
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSeconds));
                wait.Until(drv => drv.FindElement(By.XPath(LocatorValue)));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(LocatorValue)));
            }
        }

        #endregion
    }
}