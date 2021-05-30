using System;
using System.IO;
using Xunit;
using System.Collections.Generic;

namespace Calculator.Test
{
    public class CalculatorTests
    {
        //test operations of the maCalculator class
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
        //test operations of the myCalculator with wrong inputs
        [Fact]
        public void ShouldReturnNaN()
        {
            double num1 = 1;
            double num2 = 0;
            Assert.Equal(double.NaN, MyCalculator.DoOperation(num1, num2, "d"));
            Assert.Equal(double.NaN, MyCalculator.DoOperation(num1, num2, "c"));
        }

        //test user input by the help of MockConsoleWriter
        [Fact]
        public void ShouldReceiveUserInput()
        {
            IConsoleWrapper consoleWrapper = new MockConsoleWrapper("5", "2", "m", "n");
            string userInput1 = consoleWrapper.ReadLine();
            Assert.Equal("5", userInput1);
            string userInput2 = consoleWrapper.ReadLine();
            Assert.Equal("2", userInput2);
            string userInput3 = consoleWrapper.ReadLine();
            Assert.Equal("m", userInput3);
            string userInput4 = consoleWrapper.ReadLine();
            Assert.Equal("n", userInput4);

        }

        //test wrong number input by the help of MockConsoleWriter
        [Fact]
        public void ShouldOutputFailureMessage()
        {
            MockConsoleWrapper mockConsoleWrapper = new MockConsoleWrapper("a", "2", "m", "n");
            Program.RunCalculator(mockConsoleWrapper);
            string programOutput1 = mockConsoleWrapper.messageList[0];
            Assert.Equal("This is not valid input. Please enter an integer value: ", programOutput1);
            
        }

        //test result(output) of the program by the help of MockConsoleWriter
        [Fact]
        public void ShoulMultiplyFiveAndTwo()
        {
           
            MockConsoleWrapper mockConsoleWrapper = new MockConsoleWrapper("5","2", "m", "n");
            double result = Program.RunCalculator(mockConsoleWrapper);
            Assert.Equal(10, result);
      
        }
        //test result(output) with a wrong operation sign input of the program by the help of MockConsoleWriter
        [Fact]
        public void ShoudReturnNaN()
        {
 
            MockConsoleWrapper mockConsoleWrapper = new MockConsoleWrapper("5", "2", "b", "n");
            double result = Program.RunCalculator(mockConsoleWrapper);
            Assert.Equal(double.NaN, result);

        }
    }
}