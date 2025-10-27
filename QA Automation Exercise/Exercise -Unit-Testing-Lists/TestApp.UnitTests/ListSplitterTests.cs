using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class ListSplitterTests
{
    [Test]
    public void Test_SplitEvenAndOdd_EmptyListParameter_ReturnsEmptyEvenAndOddLists()
    {
        //Arrange
        List<int> emptyList = new List<int>();


        //Act
        (List<int> evens, List<int> odds) result = ListSplitter.SplitEvenAndOdd(emptyList);

        //Assert

        Assert.That(result.evens, Is.Empty);
        Assert.That(result.odds, Is.Empty);
            
    }

    [Test]
    public void Test_SplitEvenAndOdd_OnlyEvenValues_ReturnsEmptyOddList()
    {
        //Arrange
        List<int> input = new List<int> { 2, 4, 6, 8 };


        //Act
        (List<int> evens, List<int> odds) result = ListSplitter.SplitEvenAndOdd(input);

        //Assert

        Assert.That(result.evens, Is.EqualTo(input));
        Assert.That(result.odds, Is.Empty);
    }

    [Test]
    public void Test_SplitEvenAndOdd_OnlyOddValues_ReturnsEmptyEvenList()
    {
        //Arrange
        List<int> input = new List<int> { 3, 7, 11, 9 };


        //Act
        (List<int> evens, List<int> odds) result = ListSplitter.SplitEvenAndOdd(input);

        //Assert

        Assert.That(result.evens, Is.Empty);
        Assert.That(result.odds, Is.EqualTo(input));
    }

    [Test]
    public void Test_SplitEvenAndOdd_EvenAndOddValues_ReturnsListWithCorrectValues()
    {
        //Arrange
        List<int> input = new List<int> { 2, 4, 6, 8, 3, 7, 11, 9 };
        List<int> expectedEvens = new List<int> { 2, 4, 6, 8 };
        List<int> expectedOdds = new List<int> { 3, 7, 11, 9 };

        //Act
        (List<int> evens, List<int> odds) result = ListSplitter.SplitEvenAndOdd(input);

        //Assert

        Assert.That(result.evens, Is.EqualTo(expectedEvens));
        Assert.That(result.odds, Is.EqualTo(expectedOdds));
    }
}
