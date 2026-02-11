using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Security;

namespace TestApp.Tests;
public class PalindromeFinderTests
{
    [Test]
    public void Test_GetPalindromes_NullWordsList_ReturnsEmptyString()
    {
        //Arrange
        List<string> nullList = null;
        string expected = string.Empty;

        //Act

        string result = PalindromeFinder.GetPalindromes(nullList);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetPalindromes_EmptyWordsList_ReturnsEmptyString()
    {
        //Arrange
        List<string> emptyList = new List<string>();
        string expected = string.Empty;

        //Act

        string result = PalindromeFinder.GetPalindromes(emptyList);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetPalindromes_ListWithWords_ReturnsOnlyPalidromeWords()
    {
        //Arrange
        List<string> input = new List<string> { "town", "madam", "country" };
        string expected = "madam";

        //Act

        string result = PalindromeFinder.GetPalindromes(input);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetPalindromes_ListWithoutPalindromeWords_ReturnsEmptyString()
    {
        //Arrange
        List<string> input = new List<string> { "town", "country", "city", "sun" };
        string expected = string.Empty;

        //Act

        string result = PalindromeFinder.GetPalindromes(input);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetPalindromes_ListOnlyWithPalidromeWords_ReturnsStringWithAllWords()
    {
        //Arrange
        List<string> input = new List<string> { "level", "madam", "rotator", "mom" };
        string expected = "level madam rotator mom";

        // Act
        string result = PalindromeFinder.GetPalindromes(input);

        // Assert
        Assert.AreEqual(expected, result);
    }
}

