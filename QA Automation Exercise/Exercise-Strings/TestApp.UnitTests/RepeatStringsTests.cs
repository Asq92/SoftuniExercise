using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class RepeatStringsTests
{
    [Test]
    public void Test_Repeat_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act
        string result = RepeatStrings.Repeat(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Repeat_SingleInputString_ReturnsRepeatedString()
    {
        // Arrange
        string[] input = new string[] { "Ana" };
        string expected = "AnaAnaAna";

        // Act
        string result = RepeatStrings.Repeat(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Repeat_MultipleInputStrings_ReturnsConcatenatedRepeatedStrings()
    {
        // Arrange
        string[] input = new string[] { "Ana", "Ivan" };
        string expected = "AnaAnaAnaIvanIvanIvanIvan";

        // Act
        string result = RepeatStrings.Repeat(input);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
