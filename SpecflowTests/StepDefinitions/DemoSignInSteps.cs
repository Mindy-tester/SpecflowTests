using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowPages.Helpers;
using System;
using System.Threading;
using TechTalk.SpecFlow;


namespace SpecflowTests.StepDefinitions
{
    [Binding]
    public class DemoSignInSteps
    {
        IWebDriver driver = new ChromeDriver();
        [Given(@"I have navigated to  skill swap website")]
        public void GivenIHaveNavigatedToSkillSwapWebsite()
        {
            
            driver.Navigate().GoToUrl("http://www.skillswap.pro/");
            Thread.Sleep(1000);
            driver.Manage().Window.Maximize();
               }
        
        [Given(@"I have clicked on SignIn")]
        public void GivenIHaveClickedOnSignIn()
        {
            IWebElement signIn = driver.FindElement(By.XPath("//a[@class='item']"));
            signIn.Click();

        }
        
        [When(@"I have entered username ""(.*)"" and password ""(.*)""")]
        public void WhenIHaveEnteredUsernameAndPassword(string UserName, string Password)
        {
            driver.FindElement(By.XPath("//input[@placeholder='Email address']")).SendKeys(UserName);
            driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys(Password);


        }
        
        [When(@"I have clicke on Login button")]
        public void WhenIHaveClickeOnLoginButton()
        {
            driver.FindElement(By.XPath("")).Click();
        }
        
        [Then(@"I should be on home page")]
        public void ThenIShouldBeOnHomePage()
        {
            CommonMethods.ExtentReports();
            CommonMethods.Test = CommonMethods.Extent.StartTest("Login");
            try
            {
                IWebElement text = driver.FindElement(By.XPath("//span[@class='item ui dropdown link active visible']"));

                if(text.Text == "Hi Minty")
                {
                    CommonMethods.Test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Login Successful");
                   
                }

            }
            catch(Exception e)
            {
                CommonMethods.Test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, e.Message);
            }
        }
    }
}
