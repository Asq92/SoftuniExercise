using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class AdjacentEqualTests
{
    [Test]
    public void Test_Sum_InputIsEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<int> emptyList = new();
        string expected = "";

        // Act
        string result = AdjacentEqual.Sum(emptyList);

        // Assert
        Assert.AreEqual(expected, result);
    }

    
    [Test]
    public void Test_Sum_NoAdjacentEqualNumbers_ShouldReturnOriginalList()
    {
        // Arrange

        List<int> numbers = new List<int> { 1, 2, 3, 4, 5};
        string expected = "1 2 3 4 5";
       

        // Act
        string result = AdjacentEqual.Sum(numbers);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersExist_ShouldReturnSummedList()
    {
        //Arrange
        List<int> numbers = new List<int>{1, 2, 3, 3};
        string expected = "1 2 6";

        //Act
        string result = AdjacentEqual.Sum(numbers);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Sum_AllNumbersAreAdjacentEqual_ShouldReturnSingleSummedNumber()
    {
        //Arrange
        List<int> numbers = new List<int> { 3, 3, 3, 3 };
        string expected = "12";

        //Act
        string result = AdjacentEqual.Sum(numbers);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersAtBeginning_ShouldReturnSummedList()
    {
        //Arrange
        List<int> numbers = new List<int> { 3, 3, 2, 4 };
        string expected = "6 2 4";

        //Act
        string result = AdjacentEqual.Sum(numbers);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersAtEnd_ShouldReturnSummedList()
    {
        //Arrange
        List<int> numbers = new List<int> { 2, 4, 3, 3 };
        string expected = "2 4 6";

        //Act
        string result = AdjacentEqual.Sum(numbers);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersInMiddle_ShouldReturnSummedList()
    {
        //Arrange
        List<int> numbers = new List<int> { 2, 1, 3, 3, 4, 5 };
        string expected = "2 1 6 4 5";

        //Act
        string result = AdjacentEqual.Sum(numbers);

        //Assert
        Assert.AreEqual(expected, result);
    }
}
