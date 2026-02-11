using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class GaussTrickTests
{
    [Test]
    public void Test_SumPairs_InputIsEmptyList_ShouldReturnEmptyList()
    {
        // Arrange
        List<int> emptyList = new();

        // Act
        List<int> result = GaussTrick.SumPairs(emptyList);

        // Assert
        CollectionAssert.AreEqual(emptyList, result);
    }


    [Test]
    public void Test_SumPairs_InputHasSingleElement_ShouldReturnSameElement()
    {
        // Arrange
        List<int> element = new List<int> { 3 };

        // Act
        List<int> result = GaussTrick.SumPairs(element);

        // Assert
        CollectionAssert.AreEqual(element, result);
    }

    
    [Test]
    public void Test_SumPairs_InputHasEvenCountElements_ShouldReturnSumPairs()
    {
        // Arrange
        List<int> element = new List<int> { 2, 4, 6, 8 }; // събират се двойките числа => 2+8 и 4+6 (първото с последнотор второто с предпоследното)
        List<int> expected = new List<int> { 10, 10 };

        // Act
        List<int> result = GaussTrick.SumPairs(element);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_SumPairs_InputHasOddCountElements_ShouldReturnWithMiddleElement()
    {
        //Arrange
        List<int> element = new List<int> { 1, 2, 3, 4, 5, 6, 7 };// събират се двойките числа => 1+7; 2+6; 3+5; 4 (първото с последнотор второто с предпоследното)
        List<int> expected = new List<int> { 8, 8, 8, 4 }; // средното число от редицата

        //Act
        List<int> result = GaussTrick.SumPairs(element);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_SumPairs_InputHasLargeEvenCountElements_ShouldReturnSumPairs()
    {
        //Arrange
        List<int> element = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };// събират се двойките числа => 1+7; 2+6; 3+5; .... (първото с последнотор второто с предпоследното)
        List<int> expected = new List<int> { 11, 11, 11, 11, 11 }; 

        //Act
        List<int> result = GaussTrick.SumPairs(element);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_SumPairs_InputHasLargeOddCountElements_ShouldReturnWithMiddleElement()
    {
        //Arrange
        List<int> element = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };// събират се двойките числа => 1+7; 2+6; 3+5; 4 (първото с последнотор второто с предпоследното)
        List<int> expected = new List<int> { 12, 12, 12, 12, 12, 6 }; // средното число от редицата

        //Act
        List<int> result = GaussTrick.SumPairs(element);

        //Assert
        Assert.AreEqual(expected, result);
    }
}
