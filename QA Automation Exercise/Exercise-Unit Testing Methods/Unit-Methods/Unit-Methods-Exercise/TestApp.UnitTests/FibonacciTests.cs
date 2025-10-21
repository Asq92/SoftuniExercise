using NUnit.Framework;

namespace TestApp.UnitTests;

public class FibonacciTests
{
    [Test]
    public void Test_CalculateFibonacci_ZeroInput()
    {
        //Arrange

        int number = 0;
        int expected = 0;

        //Act

        int result = Fibonacci.CalculateFibonacci(number);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_CalculateFibonacci_PositiveInput()
    {
        //Arrange

        int number = 17;
        int expected = 1597;

        //Act

        int result = Fibonacci.CalculateFibonacci(number);

        //Assert

        Assert.That(result, Is.EqualTo(expected));



    }
}