using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Test
{
    //mock class using for testing
    public class MockConsoleWrapper : IConsoleWrapper
    {
        //variables to imitate user input
        string _input1;
        string _input2;
        string _input3;
        string _input4;

        Queue<string> userInputs = new Queue<string>();//Queue to store the inputs
        public List<string> messageList { get; set; } = new List<string>();//list to store redirected outputs


        //constructor with mocking user inputs
        public MockConsoleWrapper(string input1, string input2, string input3, string input4)
        {
            _input1 = input1;
            _input2 = input2;
            _input3 = input3;
            _input4 = input4;
        }
        //mocking Readline for tets
        public string ReadLine()
        {
            userInputs.Enqueue(_input1);
            userInputs.Enqueue(_input2);
            userInputs.Enqueue(_input3);
            userInputs.Enqueue(_input4);

            return userInputs.Dequeue();
        }

        //Mocking WriteLine for tests
        public void WriteLine(string anyString)
        {
                StringWriter stringWriter = new StringWriter();//stringWriter to store an output
                Console.SetOut(stringWriter);//redirect output to the stringWriter
                Console.WriteLine(anyString);//write a message
                messageList.Add(stringWriter.ToString());//add the stored in the stringWriter into the list
               
            
        }

        //same logic as in WriteLine
        public void Write(string anyString)
        {
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.Write(anyString);
            messageList.Add(stringWriter.ToString());
            
        }
    }
}

