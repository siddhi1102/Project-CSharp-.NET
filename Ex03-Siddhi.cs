using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessments
{
    class FunctionExample
    {
        public static void funcInput()
        {
            string name = Utilities.GetString("Enter the name: ");
            string password = Utilities.GetString("Enter the password: ");
            funcDisplay(name, password);
        }
        public static void funcDisplay(string name, string password)
        {
            Console.WriteLine($"Name:- {name}");
            Console.WriteLine($"Password:- {password}");
        }
    }


    class Ex03_Siddhi
    {
        static void Main(string[] args)
        {
            FunctionExample.funcInput();
        }
    }
}
