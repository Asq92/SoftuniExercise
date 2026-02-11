using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.Tests;

public class CountCharactersTests
{
    [Test]
    public void Test_Count_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new();

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    
    [Test]
    public void Test_Count_WithNoCharacters_ShouldReturnEmptyString()
    {
        //Arrange
        List<string> input = new List<string> { "" };
        string expected = string.Empty;

        //Act
        string result = CountCharacters.Count(input);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Count_WithSingleCharacter_ShouldReturnCountString()
    {
        //Arrange
        List<string> input = new List<string> { "a" };
        string expected = "a -> 1";

        //Act
        string result = CountCharacters.Count(input);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Count_WithMultipleCharacters_ShouldReturnCountString()
    {
        //Arrange
        List<string> input = new List<string> { "ab", "bc", "cd"};
        string expected = "a -> 1" + Environment.NewLine + "b -> 2" + Environment.NewLine + "c -> 2" + Environment.NewLine + "d -> 1";

        //Act
        string result = CountCharacters.Count(input);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Count_WithSpecialCharacters_ShouldReturnCountString()
    {
        //Arrange
        List<string> input = new List<string> { "@b", "@bc", "%d" };
        string expected = "@ -> 2" + Environment.NewLine + "b -> 2" + Environment.NewLine + "c -> 1" + Environment.NewLine + "% -> 1" + Environment.NewLine + "d -> 1";

        //Act
        string result = CountCharacters.Count(input);

        //Assert
        Assert.AreEqual(expected, result);
    }
}
