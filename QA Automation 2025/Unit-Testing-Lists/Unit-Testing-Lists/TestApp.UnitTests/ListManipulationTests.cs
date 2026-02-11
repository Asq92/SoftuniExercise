using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class ListManipulationTests
{
    [Test]
    public void Test_RemoveNegativesAndReverse_EmptyListInput_ReturnEmptyList()
    {
        //Arrange

        List<int> numbers = new List<int>();

        //Act

        List<int> result = ListManipulation.RemoveNegativesAndReverse(numbers);

        //Assert

        CollectionAssert.IsEmpty(result);
    }

    [Test]
    public void Test_RemoveNegativesAndReverse_OnlyNegativeNumbers_ReturnEmptyList()
    {
        //Arrange

        List<int> numbers = new List<int> { -4, -3, -2, -1 };

        //Act

        List<int> result = ListManipulation.RemoveNegativesAndReverse(numbers);

        //Assert

        CollectionAssert.IsEmpty(result);
    }

    [Test]
    public void Test_RemoveNegativesAndReverse_OnlyOnePositiveNumber_ReturnSameCollection()
    {
        //Arrange

        List<int> numbers = new List<int> { 6 };


        //Act

        List<int> result = ListManipulation.RemoveNegativesAndReverse(numbers);

        //Assert

        CollectionAssert.AreEqual(numbers, result);
    }

    [Test]
    public void Test_RemoveNegativesAndReverse_OnlyPositiveNumbers_ReturnRevursedList()
    {
        //Arrange

        List<int> numbers = new List<int> { 6, 9, 12 };
        List<int> expected = new List<int> { 12, 9, 6 };


        //Act

        List<int> result = ListManipulation.RemoveNegativesAndReverse(numbers);

        //Assert

        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_RemoveNegativesAndReverse_PostiveAndNegativeElements_ReturnPositiveNumbersInReversedOrder()
    {
        //Arrange

        List<int> numbers = new List<int> { 6, 9, 12, -2, -3, -4 };
        List<int> expected = new List<int> { 12, 9, 6 };

        //Act

        List<int> result = ListManipulation.RemoveNegativesAndReverse(numbers);

        //Assert

        CollectionAssert.AreEqual(expected, result);
    }
}
