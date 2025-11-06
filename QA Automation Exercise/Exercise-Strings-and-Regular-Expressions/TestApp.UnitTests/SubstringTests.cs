using NUnit.Framework;

namespace TestApp.UnitTests;

public class SubstringTests
{
    
    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromMiddle()
    {
        // Arrange
        string toRemove = "fox";
        string input = "The quick brown fox jumps over the lazy dog";
        string expected = "The quick brown jumps over the lazy dog";


        // Act
        string result = Substring.RemoveOccurrences(toRemove, input);

        // Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromStart()
    {
        // Arrange
        string toRemove = "Brown";
        string input =  "Brown fox jumps over the lazy dog";
        string expected = "fox jumps over the lazy dog";


        // Act
        string result = Substring.RemoveOccurrences(toRemove, input);

        // Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromEnd()
    {
        // Arrange
        string toRemove = "dog";
        string input = "The quick brown fox jumps over the lazy dog";
        string expected = "The quick brown fox jumps over the lazy";


        // Act
        string result = Substring.RemoveOccurrences(toRemove, input);

        // Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesAllOccurrences()
    {
        // Arrange
        string toRemove = "THE";
        string input = "The quick brown fox jumps over the lazy dog";
        string expected = "quick brown fox jumps over lazy dog";


        // Act
        string result = Substring.RemoveOccurrences(toRemove, input);

        // Assert

        Assert.AreEqual(expected, result);
    }
}
