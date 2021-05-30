 using System;

    namespace Calculator
    {
        
        public class Program
        {

        public static void Main(string[] args)
            {

            RunCalculator(new ConsoleWrapper());//run the program
                
            }

        //function that constains the program
        //with iConsolWrapper as a parameter
        public static double RunCalculator(IConsoleWrapper iConsoleWrapper)
        {
            double result = 0;//create new variable to return a result of the programm

            bool endApp = false;
            // Display title as the C# console calculator app.
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Declare variables and set to empty.
                string numInput1 = "";
                string numInput2 = "";
                

                // Ask the user to type the first number.
                Console.Write("Type a number, and then press Enter: ");
                numInput1 = iConsoleWrapper.ReadLine();//here and further replace all Console.ReadLine() with iConsoleWrapper.ReadLine() for testing

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    //replace Console.Write with  iConsolWrapper.Write to test this cycle
                    iConsoleWrapper.Write("This is not valid input. Please enter an integer value: ");
                    numInput1 = iConsoleWrapper.ReadLine();
                }

                // Ask the user to type the second number.
                Console.Write("Type another number, and then press Enter: ");
                numInput2 = iConsoleWrapper.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    //replace Console.Write with  iConsolWrapper.Write to test this cycle
                    iConsoleWrapper.Write("This is not valid input. Please enter an integer value: ");
                    numInput2 = iConsoleWrapper.ReadLine();
                }

                // Ask the user to choose an operator.
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option? ");

                string op = iConsoleWrapper.ReadLine();

                try
                {
                    result = MyCalculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        iConsoleWrapper.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    //replace Console.Write with  iConsolWrapper.Write to test this cycle
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                //this block is uncovered, because I didn't know how to check exeption
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");
                

                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (iConsoleWrapper.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
            return result;//return string result to test program's output
        }
        }
    }

