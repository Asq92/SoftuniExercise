using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class NumberProcessorTests
{
    [Test]
    public void Test_ProcessNumbers_SquareEvenNumbers()
    {
        // Arrange
        List<int> input = new() { 2, 4, 6 };
        List<double> expected = new() { 4, 16, 36 };

        // Act
        List<double> actual = NumberProcessor.ProcessNumbers(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    
    [Test]
    public void Test_ProcessNumbers_SquareRootOddNumbers()
    {
        // Arrange
        List<int> input = new List<int> { 9, 49, 81 };
        List<double> expected = new List<double> { 3, 7, 9 };

        // Act
        List<double> result = NumberProcessor.ProcessNumbers(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    
    [Test]
    public void Test_ProcessNumbers_HandleZero()
    {
        // Arrange
        List<int> input = new List<int> { 0 };
        List<double> expected = new List<double> { 0 };

        // Act
        List<double> result = NumberProcessor.ProcessNumbers(input);

        // Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_ProcessNumbers_EmptyInput()
    {
        //Arrange

        List<int> input = new List<int>();

        //Act

        List<double> result = NumberProcessor.ProcessNumbers(input);

        //Assert

        Assert.That(result, Is.Empty);
    }
}
