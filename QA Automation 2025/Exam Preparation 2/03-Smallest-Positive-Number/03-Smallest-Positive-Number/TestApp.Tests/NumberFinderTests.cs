using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;

namespace TestApp.Tests;

public class NumberFinderTests
{
    [Test]
    public void Test_FindSmallestPositive_ShouldReturnError_WhenListIsNull()
    {
        //Arrange
        List<int> numbers = null;
        string expected = "List cannot be empty.";

        //Act

        string result = NumberFinder.FindSmallestPositive(numbers);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindSmallestPositive_ShouldReturnError_WhenListIsEmpty()
    {
        //Arrange
        List<int> emptyList = new List<int>();
        string expected = "List cannot be empty.";

        //Act

        string result = NumberFinder.FindSmallestPositive(emptyList);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindSmallestPositive_ShouldReturnSmallest_WhenListHasPositiveNumbers()
    {
        //Arrange
        List<int> numbers = new List<int> { 2, 4, 6 };
        string expected = $"Smallest positive number is: 2";

        //Act

        string result = NumberFinder.FindSmallestPositive(numbers);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindSmallestPositive_ShouldReturnSmallest_WhenListHasMixedNumbers()
    {
        //Arrange
        List<int> numbers = new List<int> { 2, 4, 6, -3, -9,  };
        string expected = $"Smallest positive number is: 2";

        //Act

        string result = NumberFinder.FindSmallestPositive(numbers);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindSmallestPositive_ShouldReturnNotFoundMessage_WhenAllNumbersAreNegativeOrZero()
    {
        //Arrange
        List<int> numbers = new List<int> { 0, -2, -5};
        string expected = "No positive numbers found.";

        //Act

        string result = NumberFinder.FindSmallestPositive(numbers);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindSmallestPositive_ShouldHandleDuplicates_Correctly()
    {
        //Arrange
        List<int> numbers = new List<int> { 2, 10, 2, 8};
        string expected = $"Smallest positive number is: 2";

        //Act

        string result = NumberFinder.FindSmallestPositive(numbers);

        //Assert

        Assert.AreEqual(expected, result);
    }
}
