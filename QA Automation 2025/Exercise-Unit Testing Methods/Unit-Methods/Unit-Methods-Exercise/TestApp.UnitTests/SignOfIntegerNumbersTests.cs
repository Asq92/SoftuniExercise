using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestApp.UnitTests;

public class SignOfIntegerNumbersTests
{
    [Test]
    public void Test_CheckSign_NotAnIntegerValue_ReturnErrorMessage()
    {
        //Arrange

        string input = "5a";
        string expected = "The input is not an integer!";

        //Act

        string result = SignOfIntegerNumbers.CheckSign(input);

        //Assert

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CheckSign_ZeroValueInput_ReturnMessageForZero()
    {
        //Arrange

        string input = "0";
        string expected = $"The number {input} is zero.";

        //Act

        string result = SignOfIntegerNumbers.CheckSign(input);

        //Assert

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CheckSign_NegativeValueInput_ReturnMessageForNegativeInteger()
    {
        //Arrange

        string input = "-5";
        string expected = $"The number {input} is negative.";

        //Act

        string result = SignOfIntegerNumbers.CheckSign(input);

        //Assert

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CheckSign_PositiveValueInput_ReturnMessageForPositiveInteger()
    {
        //Arrange

        string input = "5";
        string expected = $"The number {input} is positive.";

        //Act

        string result = SignOfIntegerNumbers.CheckSign(input);

        //Assert

        Assert.That(result, Is.EqualTo(expected));
    }
}
