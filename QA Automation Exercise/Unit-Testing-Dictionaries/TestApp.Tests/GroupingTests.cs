using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.Tests;

public class GroupingTests
{
     
    [Test]
    public void Test_GroupNumbers_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<int> numbers = new List<int>();
        string expected = string.Empty;

        // Act
        string result = Grouping.GroupNumbers(numbers);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GroupNumbers_WithEvenAndOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6,};
        string expected = "Odd numbers: 1, 3, 5" + Environment.NewLine + "Even numbers: 2, 4, 6";

        // Act
        string result = Grouping.GroupNumbers(numbers);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GroupNumbers_WithOnlyEvenNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> numbers = new List<int>() { 2, 4, 6, 8 };
        string expected =  "Even numbers: 2, 4, 6, 8";

        // Act
        string result = Grouping.GroupNumbers(numbers);

        // Assert
        Assert.AreEqual(expected, result);

    }

    [Test]
    public void Test_GroupNumbers_WithOnlyOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> numbers = new List<int>() { 1, 3, 5,  };
        string expected = "Odd numbers: 1, 3, 5";

        // Act
        string result = Grouping.GroupNumbers(numbers);

        // Assert
        Assert.AreEqual(expected, result);

    }

    [Test]
    public void Test_GroupNumbers_WithNegativeNumbers_ShouldReturnGroupedString()
    {

        // Arrange
        List<int> numbers = new List<int>() { -1, -2, -3, -4, -5, -6 };
        string expected = "Odd numbers: -1, -3, -5" + Environment.NewLine + "Even numbers: -2, -4, -6";

        // Act
        string result = Grouping.GroupNumbers(numbers);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
