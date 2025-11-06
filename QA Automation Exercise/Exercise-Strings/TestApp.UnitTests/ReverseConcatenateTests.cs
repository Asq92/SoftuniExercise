using NUnit.Framework;

using System;
using System.Linq;
using System.Text;

namespace TestApp.UnitTests;

public class ReverseConcatenateTests
{
    
    [Test]
    public void Test_ReverseAndConcatenateStrings_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();
        string expected = string.Empty;

        // Act
        string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    
    [Test]
    public void Test_ReverseAndConcatenateStrings_SingleString_ReturnsSameString()
    {
        // Arrange
        string[] input = new string[] { "Ana" };
        string expected = "Ana";

        // Act
        string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_MultipleStrings_ReturnsReversedConcatenatedString()
    {
        // Arrange
        string[] input = new string[] { "Ana", "Ivan", "Sun", "Blagoevgrad" };
        string expected = "BlagoevgradSunIvanAna";

        // Act
        string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_NullInput_ReturnsEmptyString()
    {
        // Arrange
        string[] input = null;
        string expected = string.Empty;

        // Act
        string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_WhitespaceInput_ReturnsConcatenatedString()
    {
        // Arrange
        string[] input = new string[] { "Ana", " and ", "Ivan" };
        string expected = "Ivan and Ana";

        // Act
        string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_LargeInput_ReturnsReversedConcatenatedString()
    {
        // Arrange
        string[] input = new string[1000];

        for (int i= 0; i <= 999; i++)
        {
            input[i] = i.ToString();
        }
        
        StringBuilder sb = new StringBuilder();

        for (int i = input.Length-1; i >= 0; i--)
        {
            sb.Append(i);
        }
        string expected = sb.ToString();

        // Act
        string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
