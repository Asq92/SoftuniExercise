using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class RepeatingChecker_LastReapeatingElementTests
{
    [Test]
    public void Test_FindLastRepeatingElement_EmptyArray_ReturnsNegativeOne()
    {
        //Arrange

        int[] emptyArray = Array.Empty<int>();
        int expected = -1;

        //Act
        int result = RepeatingChecker.FindLastRepeatingElement(emptyArray);

        //Assert

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindLastRepeatingElement_ArrayWithOneInteger_ReturnsNegativeOne()
    {
        //Arrange

        int[] emptyArray = new int[] { 15 };
        int expected = -1;

        //Act
        int result = RepeatingChecker.FindLastRepeatingElement(emptyArray);

        //Assert

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindLastRepeatingElement_ArrayWithManyNonRepeatingValues_ReturnsNegativeOne()
    {
        //Arrange

        int[] emptyArray = new int[] { 15, 10, 8, 3 };
        int expected = -1;

        //Act
        int result = RepeatingChecker.FindLastRepeatingElement(emptyArray);

        //Assert

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindLastRepeatingElement_ArrayWithTwoReapeatingNegativeOneValue_ReturnsNegativeOne()
    {
        //Arrange

        int[] emptyArray = new int[] { -1, 10, 8, 3, -1 };
        int expected = -1;

        //Act
        int result = RepeatingChecker.FindLastRepeatingElement(emptyArray);

        //Assert

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindLastRepeatingElement_ArrayWithManyIntegerWithSameValues_ReturnsTheIntegerValue()
    {
        //Arrange

        int[] emptyArray = new int[] { 15, 15, 15, 15, 15 };
        int expected = 15;

        //Act
        int result = RepeatingChecker.FindLastRepeatingElement(emptyArray);

        //Assert

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindLastRepeatingElement_ArrayWithAtLeastTwoReaptingValues_ReturnsTheRepeatingValue()
    {
        //Arrange

        int[] emptyArray = new int[] { -1, 10, 8, 3, 3 };
        int expected = 3;

        //Act
        int result = RepeatingChecker.FindLastRepeatingElement(emptyArray);

        //Assert

        Assert.That(result, Is.EqualTo(expected));
    }
}
