using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class ListAnalyzerTests
{
    [Test]
    public void Test_Analyze_EmptyList_ShouldReturnNoElementsMsg()
    {
        //Arrange
        List<int> numbers = new List<int>();
        string expected = "No elements!";
        //Act
        string result = ListAnalyzer.Analyze(numbers);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Analyze_OneElement_ShouldReturnSameValueForMinMaxAvg()
    {
        //Assert
        List<int> numbers = new List<int> { 6 };
        string expected = "Element count: 1, Min value: 6, Max value: 6, Avg: 6.00.";
        //Act
        string result = ListAnalyzer.Analyze(numbers);

        //Assert
        Assert.AreEqual(expected, result);
    }
        

    [Test]
    public void Test_Analyze_OnlySameValueElements_ShouldReturnSameValueForMinMaxAvg()
    {
        //Assert
        List<int> numbers = new List<int> { 6, 6, 6 };
        string expected = "Element count: 3, Min value: 6, Max value: 6, Avg: 6.00.";
        //Act
        string result = ListAnalyzer.Analyze(numbers);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Analyze_DiffrentValues_ShouldReturnCorrectValues()
    {
        //Assert
        List<int> numbers = new List<int> { 2, 4, 6  };
        string expected = "Element count: 3, Min value: 2, Max value: 6, Avg: 4.00."; // накрая се пише средното число
        //Act
        string result = ListAnalyzer.Analyze(numbers);

        //Assert
        Assert.AreEqual(expected, result);
    }
}
