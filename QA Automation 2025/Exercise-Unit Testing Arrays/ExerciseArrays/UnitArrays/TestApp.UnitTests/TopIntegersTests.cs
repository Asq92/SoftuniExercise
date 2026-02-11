using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class TopIntegersTests
{
    [Test]
    public void Test_FindTopIntegers_EmptyArrayParameter_ReturnEmptyString()
    {
        //Arrange

        int[] emptyArray = Array.Empty<int>();

        //Act

        TopIntegers topInt = new TopIntegers();
        string result = topInt.FindTopIntegers(emptyArray);


        //Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_FindTopIntegers_AllElementsAreTopIntegers_ReturnStringWithAllElements()
    {
        // Arrange

        int[] inputArray = new int[] { 4, 3, 2 };
        string expected = "4 3 2";

        //Act

        TopIntegers topInt = new TopIntegers();
        string result = topInt.FindTopIntegers(inputArray);

        //Assert

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindTopIntegers_OnlyOneElementArray_ReturnStringWithOneInteger()
    {
        // Arrange

        int[] inputArray = new int[] { 42 };
        string expected = "42";

        //Act

        TopIntegers topInt = new TopIntegers();
        string result = topInt.FindTopIntegers(inputArray);

        //Assert

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindTopIntegers_OnlySomeElementsAreTopIntegers_ReturnStringWithOnlyTopIntegers()
    {
        // Arrange

        int[] inputArray = new int[] { 14, 24, 3, 19, 15, 17 };
        string expected = "24 19 17";

        //Act

        TopIntegers topInt = new TopIntegers();
        string result = topInt.FindTopIntegers(inputArray);

        //Assert

        Assert.That(result, Is.EqualTo(expected));
    }
}

