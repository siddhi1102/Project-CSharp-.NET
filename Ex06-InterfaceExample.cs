using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessments
{
    interface IExample
    {
        void getData(string name, int rollNO);
        void setData();
    }

    class Example : IExample
    {
        public void getData(string name, int rollNo)
        {
            Console.WriteLine($"Roll No. of {name} is {rollNo}");
        }

        public void setData()
        {
            string name = Utilities.GetString("Enter the name: ");
            int rollNo = Utilities.GetInteger("Enter the roll no: ");
            getData(name, rollNo);
        }
    }

    class Ex06_InterfaceExample
    {
        static void Main(string[] args)
        {
            Example ex = new Example();
            ex.setData();
        }
    }

    
}
