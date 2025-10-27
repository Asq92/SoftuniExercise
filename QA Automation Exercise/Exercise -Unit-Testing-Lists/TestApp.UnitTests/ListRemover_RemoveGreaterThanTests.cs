using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class ListRemover_RemoveGreaterThanTests
{
    [Test]
    public void Test_RemoveElementsGreaterThan_EmptyListParameter_ReturnsEmtyList()
    {
        //Arrange
        List<int> emptyList = new List<int>();
        int threshold = 5;

        //Act

        List<int> result = ListRemover.RemoveElementsGreaterThan(emptyList, threshold);


        //Assert

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_RemoveElementsGreaterThan_ListWithGreaterThanThresholdElements_ReturnsEmtyList()
    {
        //Arrange
        List<int> emptyList = new List<int> { 7, 12, 9, 20 };
        int threshold = 5;

        //Act

        List<int> result = ListRemover.RemoveElementsGreaterThan(emptyList, threshold);


        //Assert

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_RemoveElementsGreaterThan_ListWithLessThanOrEqualToThresholdElements_ReturnsSameList()
    {
        //Arrange
        List<int> emptyList = new List<int> { 7, 8, 9 };
        int threshold = 10;

        //Act

        List<int> result = ListRemover.RemoveElementsGreaterThan(emptyList, threshold);


        //Assert

        Assert.AreEqual(emptyList, result);
    }

    [Test]
    public void Test_RemoveElementsGreaterThan_ListWithLessThanEqualAndGreaterThanThresholdElements_ReturnsOnlyLessThanOrEqualToThreshold()
    {
        //Arrange
        List<int> emptyList = new List<int> { 7, 12, 9, 20, 10, 6 };
        int threshold = 10;
        List<int> expected = new List<int> { 7, 9, 10, 6 };

        //Act

        List<int> result = ListRemover.RemoveElementsGreaterThan(emptyList, threshold);


        //Assert

        Assert.AreEqual(expected, result);
    }
}
