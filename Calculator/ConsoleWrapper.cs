using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    //an interface for ConsoleWrapper
    //that has ReadLine and WriteLine Methods for mocking  and using
    //input and output of the program
    public interface IConsoleWrapper
    {
        string ReadLine();
        void WriteLine(string anyString);
        
        void Write(string anyString);
    }
    //ConsoleWrapper implements the inteface using usuall Console.ReadLine, WriteLine and Write
    //they are used in the program to replace nedded Console.ReadLine, WriteLine and Write
    public class ConsoleWrapper: IConsoleWrapper
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string anyString)
        {
            Console.WriteLine(anyString);
        }

        public void Write(string anyString)
        {
            Console.Write(anyString);
        }
    }
}
