using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Firefox;



namespace IdeaCenter
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private Random random;
        private readonly string BaseUrl = "http://144.91.123.158:82/";
        private static string testTitle;



        [OneTimeSetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            random = new Random();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Login to the system
            driver.Navigate().GoToUrl(BaseUrl + "Users/Login");
            driver.FindElement(By.CssSelector("[name='Email']")).SendKeys("zvezda666@gmail.com");
            driver.FindElement(By.CssSelector("[name='Password']")).SendKeys("zvezda666");

            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        }



        [Test, Order(1)]
        public void CreateIdeaWithInvalidData_Test()
        {
            //Arrange
            driver.Navigate().GoToUrl(BaseUrl + "Ideas/Create");
            string testTitle = "";
            string testDescription = "";

            //Act
            driver.FindElement(By.CssSelector("[name='Title']")).SendKeys(testTitle);
            driver.FindElement(By.CssSelector("[name='Description']")).SendKeys(testDescription);
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            //Assert
            Assert.That(driver.Url, Is.EqualTo(BaseUrl + "Ideas/Create"));


            var errorMessage = driver.FindElement(By.XPath("//li[text()='Unable to create new Idea!']")).Text;

            Assert.That(errorMessage, Is.EqualTo("Unable to create new Idea!"));






        }

        [Test, Order(2)]
        public void CreateIdeaWithValidData_Test()
        {
            //Arrange
            driver.Navigate().GoToUrl(BaseUrl + "Ideas/Create");
            testTitle = "Title_" + random.Next(999, 99999).ToString();
            string testDescription = "Description_" + random.Next(999, 99999).ToString();

            //Act
            driver.FindElement(By.CssSelector("[name='Title']")).SendKeys(testTitle);
            driver.FindElement(By.CssSelector("[name='Description']")).SendKeys(testDescription);
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            //Assert
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(d =>
                d.FindElement(By.CssSelector("p.card-text"))
            );
            Assert.That(driver.Url, Is.EqualTo(BaseUrl + "Ideas/MyIdeas"));


            var lastIdea = driver.FindElements(By.CssSelector("p.card-text")).Last();

            Assert.That(lastIdea.Text, Is.EqualTo(testDescription));

        }

        [Test, Order(3)]
        public void ViewLastCreatedIdea_Test()
        {
            //Arrange
            driver.Navigate().GoToUrl(BaseUrl + "Ideas/MyIdeas");

            //Act

            driver.FindElement(By.XPath("(//div[@class='card mb-4 box-shadow'])[last()]//a[text()='View']")).Click();




            var ideaTitle = driver.FindElement(By.CssSelector("h1.mb-0.h4")).Text;

            //Assert

            Assert.That(ideaTitle, Is.EqualTo(testTitle));

        }

        [Test, Order(4)]
        public void EditLastCreatedIdeaTitle_Test()
        {
            //Arrange
            driver.Navigate().GoToUrl(BaseUrl + "Ideas/MyIdeas");
            var editedName = "Edited";

            var lastIdea = driver.FindElements(By.CssSelector("p.card-text")).Last();

            //Act

            driver.FindElement(By.XPath("(//div[@class='card mb-4 box-shadow'])[last()]//a[text()='Edit']")).Click();
            driver.FindElement(By.CssSelector("[name='Title']")).Clear();
            driver.FindElement(By.CssSelector("[name='Title']")).SendKeys(editedName);
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();


            driver.FindElement(By.XPath("(//div[@class='card mb-4 box-shadow'])[last()]//a[text()='View']")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var ideaTitle = wait.Until(d =>
                d.FindElement(By.CssSelector("h1.mb-0.h4"))
            ).Text;

            //Assert

            Assert.That(ideaTitle, Is.EqualTo(editedName));

        }

        [Test, Order(5)]
        public void EditCreatedIdeaDescription_Test()
        {
            //Arrange
            driver.Navigate().GoToUrl(BaseUrl + "Ideas/MyIdeas");
            var editedDescription = "Edited Description";

            var lastIdea = driver.FindElements(By.CssSelector("p.card-text")).Last();

            //Act

            driver.FindElement(By.XPath("(//div[@class='card mb-4 box-shadow'])[last()]//a[text()='Edit']")).Click();
            driver.FindElement(By.CssSelector("[name='Description']")).Clear();
            driver.FindElement(By.CssSelector("[name='Description']")).SendKeys(editedDescription);
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();


            driver.FindElement(By.XPath("(//div[@class='card mb-4 box-shadow'])[last()]//a[text()='View']")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var ideaDescription = wait.Until(d =>
                d.FindElement(By.CssSelector("p.offset-lg-3.col-lg-6"))).Text;

            //Assert

            Assert.That(ideaDescription, Is.EqualTo(editedDescription));
        }

        [Test, Order(6)]
        public void DeleteLastCreatedIdea_Test()
        {
            //Arrange
            driver.Navigate().GoToUrl(BaseUrl + "Ideas/MyIdeas");
            var lastIdea = driver.FindElements(By.CssSelector("p.card-text")).Last();

            //Act

            driver.FindElement(By.XPath("(//div[@class='card mb-4 box-shadow'])[last()]//a[text()='Delete']")).Click();

            //Assert

            var message = driver.FindElement(By.CssSelector("span.col-12.text-muted")).Text;

            Assert.That(message, Is.EqualTo("No Ideas yet!"));
        }






        [OneTimeTearDown]
            public void TearDown()
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
