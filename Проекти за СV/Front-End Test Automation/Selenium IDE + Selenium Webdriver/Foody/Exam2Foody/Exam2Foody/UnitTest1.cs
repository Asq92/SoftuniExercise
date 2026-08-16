using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;



namespace ExamPrep2
{
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private readonly string BaseUrl = "http://144.91.123.158:81/";
        private Random random;
        private string lastCreatedFoodName;

        [OneTimeSetUp]
        public void Setup()
        {

            driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            random = new Random();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Login to the system
            driver.Navigate().GoToUrl(BaseUrl + "User/Login");
            driver.FindElement(By.CssSelector("#username")).SendKeys("softuni92");
            driver.FindElement(By.CssSelector("#password")).SendKeys("zvezda666");

            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        }

        [Test, Order(1)]
        public void AddFoddWithInvalidData_Test()
        {
            //Arrange
            driver.Navigate().GoToUrl(BaseUrl + "Food/Add");

            string foodName = "";
            string foodDescription = "";

            //Act
            driver.FindElement(By.CssSelector("#name")).SendKeys(foodName);
            driver.FindElement(By.CssSelector("#description")).SendKeys(foodDescription);
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            //Assert
            var errorMessage = driver.FindElement(By.CssSelector("div.validation-summary-errors li")).Text;

            Assert.That(errorMessage, Is.EqualTo("Unable to add this food revue!"));


        }

        [Test, Order(2)]
        public void AddFoodWithValidData_Test()
        {
            //Arrange
            driver.Navigate().GoToUrl(BaseUrl + "Food/Add");

            lastCreatedFoodName = "Title_" + random.Next(999, 99999).ToString();
            string lastCreatedFoodDescription = "Description_" + random.Next(999, 99999).ToString();

            //Act
            driver.FindElement(By.CssSelector("#name")).SendKeys(lastCreatedFoodName);
            driver.FindElement(By.CssSelector("#description")).SendKeys(lastCreatedFoodDescription);
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            // Assert
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            wait.Until(d =>
                d.FindElement(By.CssSelector("h1"))
            );

            Assert.That(driver.Url, Is.EqualTo(BaseUrl));
            Assert.That(driver.Title, Is.EqualTo("Home Page - Foody.WebApp"));

            var lastCreatedFood = driver.FindElements(By.CssSelector("div.row.gx-5.align-items-center h2")).Last();

            Assert.That(lastCreatedFood.Text, Is.EqualTo(lastCreatedFoodName));
        }

        [Test, Order(3)]
        public void EditLastAddedFood_Test()
        {
            //Arrange
            driver.Navigate().GoToUrl(BaseUrl);
            string editedName = "Edited";

            var lastFoodEditButton = driver.FindElement(By.XPath("(//div[@class='row gx-5 align-items-center'])[last()]//a[text()='Edit']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", lastFoodEditButton);

            Thread.Sleep(200);
            lastFoodEditButton.Click();

            //Act
            
            
            var nameField = driver.FindElement(By.CssSelector("#name"));

            nameField.Clear();
            nameField.SendKeys("New Food Name");

            driver.FindElement(By.CssSelector("button.btn-primary")).Click();

            //Assert
            var lastFoodName = driver.FindElements(By.CssSelector("div.row.gx-5.align-items-center h2")).Last().Text;
            Assert.That(lastFoodName, Is.EqualTo(lastCreatedFoodName));
        }

        [Test, Order(4)]
        public void SearchForFoodTitle_Test()
        {
            //Arrange
            driver.FindElement(By.CssSelector("a.navbar-brand")).Click();

            //Act
            driver.FindElement(By.CssSelector("[name='keyword']")).SendKeys(lastCreatedFoodName);
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            //Assert

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            wait.Until(d =>
                d.FindElements(By.CssSelector("div.row.gx-5.align-items-center")).Count > 0
            );

            var allFoodContainers = driver.FindElements(By.CssSelector("div.row.gx-5.align-items-center"));

            Assert.That(allFoodContainers.Count, Is.EqualTo(1));

            var searchResultFoodName = driver.FindElement(By.CssSelector("div.row.gx-5.align-items-center h2")).Text;

            Assert.That(searchResultFoodName, Is.EqualTo(lastCreatedFoodName));


        }

        [Test, Order(5)]
        public void DeleteLastAddedFood_Test()
        {
            // Arrange
            driver.FindElement(By.CssSelector("a.navbar-brand")).Click();

            var initialFoodCount = driver
                .FindElements(By.CssSelector("div.row.gx-5.align-items-center"))
                .Count;

            var lastFoodContainer = driver.FindElement(
                By.XPath("(//div[@class='row gx-5 align-items-center'])[last()]")
            );

            // Act
            var deleteButton = lastFoodContainer.FindElement(
                By.CssSelector("a[href*='/Food/Delete']")
            );

            ((IJavaScriptExecutor)driver).ExecuteScript(
                "arguments[0].scrollIntoView({block: 'center'});",
                deleteButton
            );

            Thread.Sleep(500);

            deleteButton.Click();

            // Assert
            var countAfterDeletion = driver
                .FindElements(By.CssSelector("div.row.gx-5.align-items-center"))
                .Count;

            Assert.That(countAfterDeletion, Is.EqualTo(initialFoodCount - 1));
        }

        [Test, Order(6)]
        public void SearchForDeletedFood_Test()
        {
            //Arrange
            driver.FindElement(By.CssSelector("a.navbar-brand")).Click();

            //Act
            driver.FindElement(By.CssSelector("[name='keyword']")).SendKeys(lastCreatedFoodName);
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            //Assert

            var noFoodsMessage = driver.FindElement(By.CssSelector("h2.display-4"));

            Assert.That(noFoodsMessage.Text, Is.EqualTo("There are no foods :("));

            var addFoodButton = driver.FindElement(By.CssSelector("a[href='/Food/Add']"));

            Assert.That(addFoodButton.Text, Is.EqualTo("ADD FOOD"));

        }









        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}