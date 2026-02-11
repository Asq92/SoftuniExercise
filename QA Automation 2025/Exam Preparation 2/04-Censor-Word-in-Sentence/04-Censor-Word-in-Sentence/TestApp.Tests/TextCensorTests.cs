using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

namespace TestApp.Tests;

public class TextCensorTests
{
    [Test]
    public void CensorWord_ShouldReturnError_WhenSentenceIsNull()
    {
        //Arrange

        string sentence = null;
        string wordToCensor = "bad";
       string expected = "Sentence cannot be empty.";

        //Act

        string result = TextCensor.CensorWord(sentence, wordToCensor);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CensorWord_ShouldReturnError_WhenSentenceIsWhitespace()
    {
        //Arrange

        string sentence = " ";
        string wordToCensor = " bad ";
        string expected = "Sentence cannot be empty.";

        //Act

        string result = TextCensor.CensorWord(sentence, wordToCensor);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CensorWord_ShouldReturnError_WhenWordIsNull()
    {
        //Arrange

        string sentence = "This girl is bad.";
        string wordToCensor = null;
        string expected = "Word to censor cannot be empty.";

        //Act

        string result = TextCensor.CensorWord(sentence, wordToCensor);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CensorWord_ShouldReturnError_WhenWordIsWhitespace()
    {
        //Arrange

        string sentence = "This girl is bad.";
        string wordToCensor = " ";
        string expected = "Word to censor cannot be empty.";

        //Act

        string result = TextCensor.CensorWord(sentence, wordToCensor);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CensorWord_ShouldReplaceSingleOccurrence()
    {
        //Arrange

        string sentence = "This is a bad word";
        string wordToCensor = "bad";
        string expected = "This is a *** word";

        //Act

        string result = TextCensor.CensorWord(sentence, wordToCensor);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CensorWord_ShouldReplaceMultipleOccurrences()
    {
        //Arrange

        string sentence = "bad habbits are bad";
        string wordToCensor = "bad";
        string expected = "*** habbits are ***";

        //Act

        string result = TextCensor.CensorWord(sentence, wordToCensor);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CensorWord_ShouldReturnOriginal_WhenWordNotFound()
    {
        //Arrange

        string sentence = "Bad girls are bad.";
        string wordToCensor = "ugly";
        string expected = "Bad girls are bad.";

        //Act

        string result = TextCensor.CensorWord(sentence, wordToCensor);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CensorWord_ShouldReplaceCaseInsensitive()
    {
        //Arrange

        string sentence = "Bad girls are bad and pretty";
        string wordToCensor = "Bad";
        string expected = "*** girls are *** and pretty";

        //Act

        string result = TextCensor.CensorWord(sentence, wordToCensor);

        //Assert

        Assert.AreEqual(expected, result);
    }
}

