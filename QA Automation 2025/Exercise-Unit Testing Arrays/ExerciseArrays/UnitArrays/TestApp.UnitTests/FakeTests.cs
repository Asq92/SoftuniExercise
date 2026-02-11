using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class FakeTests
{
    [Test]
    public void Test_RemoveStringNumbers_RemovesDigitsFromCharArray()
    {
        //Arrange

        char[] inputArray = new char[] { 'a', 'T', '6' };
        char[] expectedArray = new char[] { 'a', 'T', };

        //Act
        char[] result = Fake.RemoveStringNumbers(inputArray);

        // Assert

        Assert.That(result, Is.EqualTo(expectedArray));
    }

    [Test]
    public void Test_RemoveStringNumbers_NoDigitsInInput_ReturnsSameArray()
    {
        //Arrange

        char[] inputArray = new char[] { 'a', 'T' };
        char[] expectedArray = new char[] { 'a', 'T' };

        //Act
        char[] result = Fake.RemoveStringNumbers(inputArray);

        // Assert

        Assert.That(result, Is.EqualTo(inputArray));
    }

    [Test]
    public void Test_RemoveStringNumbers_EmptyArray_ReturnsEmptyArray()
    {
        //Arrange

        char[] emptytArray = Array.Empty<char>();


        //Act
        char[] result = Fake.RemoveStringNumbers(emptytArray);

        // Assert

        Assert.That(result, Is.Empty);
    }
}
