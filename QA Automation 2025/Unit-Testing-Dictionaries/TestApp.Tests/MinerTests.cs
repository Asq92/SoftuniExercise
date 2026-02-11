using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class MinerTests
{
    [Test]
    public void Test_Mine_WithEmptyInput_ShouldReturnEmptyString()
    {
       //Arrange
        string[] input = Array.Empty<string>();
        string expected = string.Empty;

        //Act

        string result = Miner.Mine(input);

        //Assert
        Assert.AreEqual(expected, result);
    }

    
    [Test]
    public void Test_Mine_WithMixedCaseResources_ShouldBeCaseInsensitive()
    {
        // Arrange

        string[] input = new string[] { "GOLD 2", "silver 5", "gold 10", "SILVER 23", "CoPper 12" };
        string expected = "gold -> 12" + Environment.NewLine + "silver -> 28" + Environment.NewLine + "copper -> 12";
        // Act
        string result = Miner.Mine(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Mine_WithDifferentResources_ShouldReturnResourceCounts()
    {
        // Arrange

        string[] input = new string[] { "gold 2", "silver 5", "gold 10", "silver 23", "copper 12" };
        string expected = "gold -> 12" + Environment.NewLine + "silver -> 28" + Environment.NewLine + "copper -> 12";
        // Act
        string result = Miner.Mine(input);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
