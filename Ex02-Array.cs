using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessments
{
    class Ex02_Array
    {
        static void Main(string[] args)
        {
            DisplayArray(createArray());
        }


        public static Array createArray()
        {
            string datattype = Utilities.GetString("Enter the datatype: ");
            Type type = Type.GetType(datattype);
            int size = Utilities.GetInteger("Enter the size of array: ");
            Array arr = Array.CreateInstance(typeof(string), size);
            for (int i = 0; i < size; i++)
            {
                if (arr.GetValue(i) == null)
                {
                    Console.WriteLine($"Enter the {i+1} value: ");
                    var value = Console.ReadLine();
                    arr.SetValue(value, i);
                }
            }
            return arr;
        }

        public static void DisplayArray(Array arr)
        {
            Console.WriteLine();
            foreach(var item in arr)
                Console.WriteLine(item);
        }
    }
}
