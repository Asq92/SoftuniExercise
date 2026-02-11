using NUnit.Framework;
using System;
using TestApp;

namespace TestApp.UnitTests
{
    public class ArticleTests
    {
        private Article _article;

        [SetUp]
        public void SetUp()
        {
            _article = new Article();
        }

        [Test]
        public void Test_AddArticles_ReturnsArticleWithCorrectData()
        {
            // Arrange
            string[] articles = new string[]
            {
                "Ivan_Ivanov Instagram... Anastasiq_Arsova",
                "Soft_uni Link... Mariq_Spasova",
                "Title3 Content3 Author3"
            };

            // Act
            Article result = _article.AddArticles(articles);

            // Assert
            Assert.That(result.ArticleList, Has.Count.EqualTo(3));
            Assert.That(result.ArticleList[0].Title, Is.EqualTo("Ivan_Ivanov"));
            Assert.That(result.ArticleList[0].Content, Is.EqualTo("Instagram..."));
            Assert.That(result.ArticleList[0].Author, Is.EqualTo("Anastasiq_Arsova"));

            Assert.That(result.ArticleList[1].Title, Is.EqualTo("Soft_uni"));
            Assert.That(result.ArticleList[1].Content, Is.EqualTo("Link..."));
            Assert.That(result.ArticleList[1].Author, Is.EqualTo("Mariq_Spasova"));

            Assert.That(result.ArticleList[2].Title, Is.EqualTo("Title3"));
            Assert.That(result.ArticleList[2].Content, Is.EqualTo("Content3"));
            Assert.That(result.ArticleList[2].Author, Is.EqualTo("Author3"));
        }

        [Test]
        public void Test_GetArticleList_SortsArticlesByTitle()
        {
            // Arrange
            string[] articles = new string[]
            {
                "Title3 Content3 Author3",
                "Ivan_Ivanov Instagram... Anastasiq_Arsova",
                "Soft_uni Link... Mariq_Spasova"
            };
            Article result = _article.AddArticles(articles);

            string expected =
                "Ivan_Ivanov - Instagram...: Anastasiq_Arsova" + Environment.NewLine +
                "Soft_uni - Link...: Mariq_Spasova" + Environment.NewLine +
                "Title3 - Content3: Author3";

            // Act
            string actual = result.GetArticleList(result, "title");

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_GetArticleList_SortsArticlesByContent()
        {
            // Arrange
            string[] articles = new string[]
            {
                "Title3 Content3 Author3",
                "Ivan_Ivanov Instagram... Anastasiq_Arsova",
                "Soft_uni Link... Mariq_Spasova"
            };
            Article result = _article.AddArticles(articles);

            string expected =
                "Title3 - Content3: Author3" + Environment.NewLine +
                "Ivan_Ivanov - Instagram...: Anastasiq_Arsova" + Environment.NewLine +
                "Soft_uni - Link...: Mariq_Spasova";

            // Act
            string actual = result.GetArticleList(result, "content");

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
        {
            // Arrange
            string[] articles = new string[]
            {
                "Title3 Content3 Author3",
                "Ivan_Ivanov Instagram... Anastasiq_Arsova",
                "Soft_uni Link... Mariq_Spasova"
            };
            Article result = _article.AddArticles(articles);

            // Act
            string actual = result.GetArticleList(result, "invalidCriteria");

            // Assert
            Assert.That(actual, Is.Empty);
        }
    }
}

