using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;


namespace SpecflowPages.Helpers
{
    public class LoginPage
    {
        public void LoginStep()
        {
            //click on signIn
            Driver.driver.FindElement(By.XPath("//a[@class='item']")).Click();
            //Enter Username
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Email address']")).SendKeys("minty80@gmail.com");
            //Enter password
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("121212");
            CommonMethods.waitUntilClickable(Driver.driver, 1000, "(//button[contains(text(), 'Login')])", "XPath");
            //Click on Login Button
            Driver.driver.FindElement(By.XPath("//button[contains(text(), 'Login')]")).Click();


        }

    }
}
