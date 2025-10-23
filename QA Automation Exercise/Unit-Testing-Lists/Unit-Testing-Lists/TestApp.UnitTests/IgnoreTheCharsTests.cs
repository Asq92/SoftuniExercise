using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class IgnoreTheCharsTests
{
    [Test]
    public void Test_IgnoreChars_EmptyStringSentence_ReturnsEmptyString()
    {
        //Arrange
        List<char> ignoreChars = new List<char> { 'a', 'c' };
        string sentence = "";
        string expected = "";

        //Act
        string result = IgnoreTheChars.IgnoreChars(sentence, ignoreChars);

        //Assert
        Assert.AreEqual(expected, result);
        
    }

    [Test]
    public void Test_IgnoreChars_EmptyList_ReturnsSameSentence()
    {
        //Arrange
        List<char> emptyList = new List<char>();
        string sentence = "Sunday";
        string expected = "Sunday";

        //Act
        string result = IgnoreTheChars.IgnoreChars(sentence, emptyList);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_IgnoreChars_OneCharSentenceAndSameCharsForIgnoring_ReturnsEmptyString()
    {
        //Arrange
        List<char> ignoredChars = new List<char> { 's'};
        string sentence = "s";
        string expected = "";

        //Act
        string result = IgnoreTheChars.IgnoreChars(sentence,ignoredChars);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_IgnoreChars_WholeSentenceAndFewCharsToIgnore_ReturnsCorrectString()
    {
        //Arrange
        List<char> ignoredChars = new List<char> { 'o', 'a' };
        string sentence = "Today is Sunday";
        string expected = "Tdy is Sundy";

        //Act
        string result = IgnoreTheChars.IgnoreChars(sentence, ignoredChars);

        //Assert
        Assert.AreEqual(expected, result);
    }
}
