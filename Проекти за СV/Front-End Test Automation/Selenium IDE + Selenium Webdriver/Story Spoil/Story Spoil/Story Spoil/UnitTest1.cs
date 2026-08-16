using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;



namespace Story_Spoil
{
   
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private Random random;
        private readonly string BaseUrl = "http://144.91.123.158:100/";
        private static string storyTitle;
        private static string storyDescription;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            random = new Random();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Login to the system
            driver.Navigate().GoToUrl(BaseUrl + "User/Login");
            driver.FindElement(By.CssSelector("#username")).SendKeys("softunibg");
            driver.FindElement(By.CssSelector("#password")).SendKeys("zvezda666");

            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        }

        [Test, Order(1)]
        public void CreateStorySpoilerWithInvalidData_Test()
        {
            driver.Navigate().GoToUrl(BaseUrl + "Story/Add");
            string storyTitle = "";
            string storyDescription = "";

            driver.FindElement(By.CssSelector("#title")).SendKeys(storyTitle);
            driver.FindElement(By.CssSelector("#description")).SendKeys(storyDescription);
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            Assert.That(driver.Url, Is.EqualTo(BaseUrl + "Story/Add"));


            var errorMessage = driver.FindElement(By.CssSelector("div.text-info.validation-summary-errors li"));

            Assert.That(errorMessage.Text, Is.EqualTo("Unable to add this spoiler!"));

        }

        [Test, Order(2)]
        public void CreateStorySpoilerWithValidData_Test()
        {
            driver.Navigate().GoToUrl(BaseUrl + "Story/Add");
            storyTitle = "Test Story Title_" + random.Next(1000, 9999);
            storyDescription = "Test Story Description_" + random.Next(1000, 9999);

            driver.FindElement(By.CssSelector("#title")).SendKeys(storyTitle);
            driver.FindElement(By.CssSelector("#description")).SendKeys(storyDescription);
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            Assert.That(driver.Url, Is.EqualTo(BaseUrl));
            Assert.That(driver.Title, Is.EqualTo("Home Page - StorySpoil.WebApp"));
            var lastCreatedStory = driver.FindElements(By.CssSelector("div.row.gx-5.align-items-center h2")).Last();

            Assert.That(lastCreatedStory.Text, Is.EqualTo(storyTitle));

        }

        [Test, Order(3)]
        public void EditLastCreatedStorySpoilerTitle_Test()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            string editedName = "Edited";

            var lastStoryEditButton = driver.FindElement(By.XPath("(//div[@class='row gx-5 align-items-center'])[last()]//a[text()='Edit']"));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);",lastStoryEditButton);

            Thread.Sleep(200);

            lastStoryEditButton.Click();

            driver.FindElement(By.CssSelector("[name='Title']")).Clear();
            driver.FindElement(By.CssSelector("[name='Title']")).SendKeys(editedName);
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            Assert.That(driver.Url, Is.EqualTo(BaseUrl));
            var lastCreatedStory = driver.FindElements(By.CssSelector("div.row.gx-5.align-items-center h2")).Last();

            Assert.That(lastCreatedStory.Text, Is.EqualTo(editedName));

        }

        [Test, Order(4)]
        public void DeleteLastCreatedStorySpoiler_Test()
        {
            driver.Navigate().GoToUrl(BaseUrl);

            var initialStoryCount = driver.FindElements(By.CssSelector("div.row.gx-5.align-items-center")).Count;
            var lastStoryDeleteButton = driver.FindElement(By.XPath("(//div[@class='row gx-5 align-items-center'])[last()]//a[text()='Delete']"));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", lastStoryDeleteButton);

            Thread.Sleep(200);

            lastStoryDeleteButton.Click();

            var countAfterDeletion = driver.FindElements(By.CssSelector("div.row.gx-5.align-items-center")).Count;

            Assert.That(countAfterDeletion, Is.EqualTo(initialStoryCount - 1));

        }

        [Test, Order(5)]
        public void EditNonExistentStorySpoiler_Test()
        {
            
            driver.Navigate().GoToUrl(BaseUrl);


            driver.Navigate().GoToUrl(BaseUrl + "Story/Edit?storyId=6757f090-8396-4e42-4e2e-08dee70175d3");


            var errorMessage = driver.FindElement(By.CssSelector("pre"));

            Assert.That(errorMessage.Text, Does.Contain("No such spoiler!"));
        }

        [Test, Order(6)]
        public void DeleteNonExistentStorySpoiler_Test()
        {
            driver.Navigate().GoToUrl(BaseUrl);


            driver.Navigate().GoToUrl(BaseUrl + "Story/Delete?storyId=6757f090-8396-4e42-4e2e-08dee70175d3");

            
            var errorMessage = driver.FindElement(By.CssSelector("pre"));

            Assert.That(errorMessage.Text, Does.Contain("No such spoiler!"));
        }   


        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}