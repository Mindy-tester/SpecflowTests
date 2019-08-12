using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecflowPages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowPages.Pages
{
    public class SignUp
    {
        public SignUp()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Join 
        [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div/div[1]/div/button")]
        public IWebElement Join { get; set; }

        //Identify FirstName Textbox
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='First name']")]
        public IWebElement FirstName { get; set; }

        //Identify LastName Textbox
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Last name']")]
        public IWebElement LastName { get; set; }

        //Identify Email Textbox
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Email address']")]
        public IWebElement Email { get; set; }

        //Identify Password Textbox
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Password']")]
        public IWebElement Password { get; set; }

        //Identify Confirm Password Textbox
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Confirm Password']")]
        public IWebElement ConfirmPassword { get; set; }

        //Identify Term and Conditions Checkbox
        [FindsBy(How = How.XPath, Using = "//input[@name='terms']")]
        public IWebElement Checkbox { get; set; }

        //Identify join button
        [FindsBy(How = How.XPath, Using = "//*[@id='submit-btn']")]
        public IWebElement JoinBtn { get; set; }
        #endregion

        public void register()
        {

            //Click on Join button
            Join.Click();
        }
        public void EnterDetails()
        {
            //Enter FirstName
            FirstName.SendKeys("minty");

            //Enter LastName
            LastName.SendKeys("bansal");

            //Enter Email
            Email.SendKeys("abc1@gmail.com");

            //Enter Password
            Password.SendKeys("123123");

            //Enter Password again to confirm
            ConfirmPassword.SendKeys("123123");

        }

        public void SelectTC()
        {
            //Click on Checkbox
            Checkbox.Click();
        }

        public void ClickJoin()
        {

            //Click on join button to Sign Up
            JoinBtn.Click();

        }
    }
}



