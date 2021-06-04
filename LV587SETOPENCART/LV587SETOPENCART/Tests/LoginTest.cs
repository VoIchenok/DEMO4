﻿using LV587SETOPENCART.Pages;
using LV587SETOPENCART.BL;
using OpenQA.Selenium;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;


namespace LV587SETOPENCART.Tests
{
    [TestFixture]
    class LoginTest
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            //driver.Navigate().GoToUrl(@"http://localhost/");
            ClassWithDriver classWithDriver = new ClassWithDriver(driver);
            classWithDriver.NavigateToURL();
        }

        [Test]
        public void LoginPageTest()
        {
            HeaderComponent headerComponent = new HeaderComponent(driver);
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);

            LoginBL loginBL = new LoginBL(driver);
            //LoginPage loginPage = new LoginPage(driver);
            loginBL.Login("user1@gmail.com", "qwertyasdf12345");

            MyAccountPage myAccountPage = new MyAccountPage(driver); //crash
            Assert.AreEqual("My Account", myAccountPage.MyAccountText());

        }
    }
}
