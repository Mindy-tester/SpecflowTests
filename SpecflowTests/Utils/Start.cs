using RelevantCodes.ExtentReports;
using SpecflowPages;
using SpecflowPages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static SpecflowPages.Helpers.CommonMethods;

namespace SpecflowTests.Utils
{
    public class Start: Driver
    {
        [BeforeScenario]
        public void SetUp()
        {
            //Launch the browser
            Initialize();
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Driver.NavigateUrl();
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Call the Login Class            
            //LoginPage.LoginStep();         

        }

        [AfterScenario]
        public void TearDown()
        {
            CommonMethods.Wait(10);
            // Screenshot
            string img = SaveScreenShotClass.SaveScreenshot(driver, "Report");
            Test.Log(LogStatus.Info, "Snapshot below: " + Test.AddScreenCapture(img));

            // end test. (Reports)
            //CommonMethods.Extent.EndTest(Test);
            Extent.EndTest(Test);

            // calling Flush writes everything to the log file (Reports)
           // CommonMethods.Extent.Flush();
            Extent.Flush();

            //Close the browser
            driver.Close();
        }

    }
}
