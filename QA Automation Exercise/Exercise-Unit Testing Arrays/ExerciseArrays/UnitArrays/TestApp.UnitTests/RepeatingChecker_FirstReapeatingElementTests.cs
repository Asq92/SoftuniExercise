using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class RepeatingChecker_FirstReapeatingElementTests
{
    [Test]
    public void Test_FindFirstRepeatingElement_EmptyArray_ReturnsNegativeOne()
    {
        //Arrange

        int[] emptyArray = Array.Empty<int>();
        int expected = -1;

        //Act
        int result = RepeatingChecker.FindFirstRepeatingElement(emptyArray);

        //Assert

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindFirstRepeatingElement_ArrayWithOneInteger_ReturnsNegativeOne()
    {
        //Arrange

        int[] inputArray = new int[] { 7 };
        int expected = -1;

        //Act
        int result = RepeatingChecker.FindFirstRepeatingElement(inputArray);

        //Assert

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindFirstRepeatingElement_ArrayWithManyNonRepeatingValues_ReturnsNegativeOne()
    {
        //Arrange

        int[] inputArray = new int[] { 7, 42, 3, -5 };
        int expected = -1;

        //Act
        int result = RepeatingChecker.FindFirstRepeatingElement(inputArray);

        //Assert

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindFirstRepeatingElement_ArrayWithTwoReapeatingNegativeOneValue_ReturnsNegativeOne()
    {
        //Arrange

        int[] inputArray = new int[] { -1, 42, 3, -1 };
        int expected = -1;

        //Act
        int result = RepeatingChecker.FindFirstRepeatingElement(inputArray);

        //Assert

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindFirstRepeatingElement_ArrayWithManyIntegerWithSameValues_ReturnsTheIntegerValue()
    {
        //Arrange

        int[] inputArray = new int[] { 7, 7, 7, 7, 7 };
        int expected = 7;

        //Act
        int result = RepeatingChecker.FindFirstRepeatingElement(inputArray);

        //Assert

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindFirstRepeatingElement_ArrayWithAtLeastTwoReaptingValues_ReturnsTheRepeatingValue()
    {
        
        //Arrange
        int[] inputArray = new int[] { 7, 9, 13, 7, 5 };
        int expected = 7;

        //Act
        int result = RepeatingChecker.FindFirstRepeatingElement(inputArray);

        //Assert

        Assert.That(result, Is.EqualTo(expected));
    }
}
