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
    public class Start : Driver
    {
        [Before]
        public void SetUp()
        {
            //Launch the browser
            Initialize();
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            //Call the Login Class            
            LoginPage.LoginStep();         
                      
        }

        [After]
        public static void TearDown()
        {
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            // Screenshot
            string img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");
            Test.Log(LogStatus.Info, "Snapshot below: " + Test.AddScreenCapture(img));

            // end test. (Reports)
            CommonMethods.Extent.EndTest(Test);

            // calling Flush writes everything to the log file (Reports)
            CommonMethods.Extent.Flush();

            //Close the browser
            Driver.driver.Quit();
        }

    }
}
