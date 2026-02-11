using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class TextFilterTests
{
    
    [Test]
    public void Test_Filter_WhenNoBannedWords_ShouldReturnOriginalText()
    {
        // Arrange
        string[] bannedWords = new string[] { "Ana", "Ivan" };
        string input = "Sun, Time";
        string expected = "Sun, Time";

        // Act
        string result = TextFilter.Filter(bannedWords, input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Filter_WhenBannedWordExists_ShouldReplaceBannedWordWithAsterisks()
    {
        // Arrange
        string[] bannedWords = new string[] { "ugly" };
        string input = "You are ugly person";
        string expected = "You are **** person";

        // Act
        string result = TextFilter.Filter(bannedWords, input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Filter_WhenBannedWordsAreEmpty_ShouldReturnOriginalText()
    {

        // Arrange
        string[] bannedWords = Array.Empty<string>();
        string input = "Sun, Time";
        string expected = "Sun, Time";

        // Act
        string result = TextFilter.Filter(bannedWords, input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Filter_WhenBannedWordsContainWhitespace_ShouldReplaceBannedWord()
    {
        // Arrange
        string[] bannedWords = new string[] { "ugly and bad" };
        string input = "You are ugly and bad person";
        string expected = "You are ************ person";

        // Act
        string result = TextFilter.Filter(bannedWords, input);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
