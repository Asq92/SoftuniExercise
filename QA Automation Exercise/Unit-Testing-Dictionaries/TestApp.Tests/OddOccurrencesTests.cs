using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class OddOccurrencesTests
{
    [Test]
    public void Test_FindOdd_WithEmptyArray_ShouldReturnEmptyString()
    {
        //Arrange

        string[] input = Array.Empty<string>();
        string expected = string.Empty;

        //Act

        string result = OddOccurrences.FindOdd(input);

        //Assert

        Assert.AreEqual(expected, result);
    }

    
    [Test]
    public void Test_FindOdd_WithNoOddOccurrences_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = new string[] { "hello", "hello", "softuni", "softuni" };
        string expected = string.Empty;

        // Act
        string result = OddOccurrences.FindOdd(input);

        // Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindOdd_WithSingleOddOccurrence_ShouldReturnTheOddWord()
    {
        // Arrange
        string[] input = new string[] { "Sun", "Sun", "Sun" };
        string expected = "sun";

        // Act
        string result = OddOccurrences.FindOdd(input);

        // Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindOdd_WithMultipleOddOccurrences_ShouldReturnAllOddWords()
    {
        // Arrange
        string[] input = new string[] { "Hello", "Hello", "Hello", "Ivan"};
        string expected = "hello ivan";

        // Act
        string result = OddOccurrences.FindOdd(input);

        // Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindOdd_WithMixedCaseWords_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] input = new string[] { "hello", "HELLO", "HEllo", "sun", "SUN", "Sun", "Student" };
        string expected = "hello sun student";

        // Act
        string result = OddOccurrences.FindOdd(input);

        // Assert

        Assert.AreEqual(expected, result);
    }
}
