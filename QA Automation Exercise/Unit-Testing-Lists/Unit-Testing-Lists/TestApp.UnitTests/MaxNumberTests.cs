using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class MaxNumberTests
{

    [Test]
    public void Test_FindMax_InputHasOneElement_ShouldReturnTheElement()
    {
        //Arrange
        List<int> numbers = new List<int> { 5 };
        int expected = 5;


        //Act
        int result = MaxNumber.FindMax(numbers);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindMax_InputHasPositiveIntegers_ShouldReturnMaximum()
    {
        //Arrange
        List<int> numbers = new List<int> { 2, 4, 6 };
        int expected = 6;


        //Act
        int result = MaxNumber.FindMax(numbers);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindMax_InputHasNegativeIntegers_ShouldReturnMaximum()
    {
        //Arrange
        List<int> numbers = new List<int> { -2, -3, -5 };
        int expected = -2; // При отрицателни числа винаги най-малкото е първо число и се води най-голямо


        //Act
        int result = MaxNumber.FindMax(numbers);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindMax_InputHasMixedIntegers_ShouldReturnMaximum()
    {
        //Arrange
        List<int> numbers = new List<int> { 2, 4, 6, -3, -2 };
        int expected = 6;


        //Act
        int result = MaxNumber.FindMax(numbers);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindMax_InputHasDuplicateMaxValue_ShouldReturnMaximum()
    {
        //Arrange
        List<int> numbers = new List<int> { 2, 4, 6, 6 };
        int expected = 6;


        //Act
        int result = MaxNumber.FindMax(numbers);

        //Assert

        Assert.AreEqual(expected, result);
    }
}
