using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitParam
{
    public class SimpleStrataTests : Hooks
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "https://www.katalon.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheSimpleStrataLoginTest()
        {
            driver.Navigate().GoToUrl("http://ss-qa.azurewebsites.net/");
            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.Id("input_0")).Clear();
            driver.FindElement(By.Id("input_0")).SendKeys("ihabha@exceedgulf.com");
            driver.FindElement(By.Id("input_1")).Clear();
            driver.FindElement(By.Id("input_1")).SendKeys("ihab1@Hope");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();

            System.Threading.Thread.Sleep(10000);

            //Assert.IsTrue(driver.FindElement(By.XPath("(//button[@type='button'])[6]")).Displayed);
            System.Threading.Thread.Sleep(5000);
            Assert.That(Driver.PageSource.Contains("Ahmad Chayati"), Is.EqualTo(true),
                                            "The text Ahmad Chayati doest not exist");
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
