using System;
using Xunit;

namespace Calculator.Test
{
    public class MyCalculatorTests
    {
   
        [Fact]
        public void ShouldDoOperations()
        {
            double num1 = 1;
            double num2 = 2;

            Assert.Equal(num1 + num2, MyCalculator.DoOperation(num1, num2, "a"));
            Assert.Equal(num1 - num2, MyCalculator.DoOperation(num1, num2, "s"));
            Assert.Equal(num1 / num2, MyCalculator.DoOperation(num1, num2, "d"));
            Assert.Equal(num1 * num2, MyCalculator.DoOperation(num1, num2, "m"));    
        }
        [Fact]
        public void ShouldReturnNaN()
        {
            double num1 = 1;
            double num2 = 0;
            Assert.Equal(double.NaN, MyCalculator.DoOperation(num1, num2, "d"));
            Assert.Equal(double.NaN, MyCalculator.DoOperation(num1, num2, "c"));
        }
    }
}
