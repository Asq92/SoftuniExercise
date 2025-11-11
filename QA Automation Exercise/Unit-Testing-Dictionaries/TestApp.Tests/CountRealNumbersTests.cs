using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class CountRealNumbersTests
{
    
    [Test]
    public void Test_Count_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        int[] number = Array.Empty<int>();
        string expected = string.Empty;

        // Act
        string result = CountRealNumbers.Count(number);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Count_WithSingleNumber_ShouldReturnCountString()
    {
        // Arrange
        int[] number = new int[] { 2 };
        string expected = "2 -> 1";

        // Act
        string result = CountRealNumbers.Count(number);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Count_WithMultipleNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] number = new int[] { 2, 3, 4, 2, 4 };
        string expected = "2 -> 2" + Environment.NewLine + "3 -> 1" + Environment.NewLine + "4 -> 2";

        // Act
        string result = CountRealNumbers.Count(number);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Count_WithNegativeNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] number = new int[] { -3, -2, -2 };
        string expected = "-3 -> 1" + Environment.NewLine + "-2 -> 2";

        // Act
        string result = CountRealNumbers.Count(number);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Count_WithZero_ShouldReturnCountString()
    {
        // Arrange
        int[] number = new int[] { 0, 0, 0 };
        string expected = "0 -> 3";

        // Act
        string result = CountRealNumbers.Count(number);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
