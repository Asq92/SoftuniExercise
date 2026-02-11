using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class ListRemover_RemoveLessThanOrEqualToTests
{
    [Test]
    public void Test_RemoveElementsLessThanOrEqualTo_EmptyListParameter_ReturnsEmtyList()
    {
        //Arrange
        List<int> emptyList = new List<int>();
        int threshold = 5;

        //Act

        List<int> result = ListRemover.RemoveElementsLessThanOrEqualTo(emptyList, threshold);

        //Assert

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_RemoveElementsLessThanOrEqualTo_ListWithLessThanOrEqualToThresholdElements_ReturnsEmtyList()
    {
        //Arrange
        List<int> input = new List<int> { 2, 3, 4 };
        int threshold = 5;

        //Act

        List<int> result = ListRemover.RemoveElementsLessThanOrEqualTo(input, threshold);

        //Assert

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_RemoveElementsLessThanOrEqualTo_ListWithOnlyGreaterThanThresholdElements_ReturnsSameList()
    {
        //Arrange
        List<int> input = new List<int> { 6, 7, 8};
        int threshold = 5;

        //Act

        List<int> result = ListRemover.RemoveElementsLessThanOrEqualTo(input, threshold);

        //Assert

        Assert.AreEqual(input, result);
    }

    [Test]
    public void Test_RemoveElementsLessThanOrEqualTo_ListWithLessThanEqualAndGreaterThanThresholdElements_ReturnsOnlyGreaterThanThreshold()
    {
        //Arrange
        List<int> input = new List<int> { 2, 3, 4, 7, 5, 8, 9 };
        int threshold = 5;
        List<int> expected = new List<int> { 7,  8, 9 };

        //Act

        List<int> result = ListRemover.RemoveElementsLessThanOrEqualTo(input, threshold);

        //Assert

        Assert.AreEqual(expected, result);
    }
}
