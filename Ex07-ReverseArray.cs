using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessments
{
    class Ex07_ReverseArray
    {
        static List<int> lst = new List<int>();

        private static void ReverseArray(List<int> input)
        {
            int backward = input.Count-1;
            for (int forward = 0; forward <= backward; forward++, backward--)
            {
                int temp = input[forward];
                input[forward] = input[backward];
                input[backward] = temp;
            }

            foreach(var item in input)
                Console.WriteLine(item);
        }

        public static List<int> InputArray()
        {
            int size = Utilities.GetInteger("Enter the size of array: ");
            List<int> input = new List<int>();
            for (int i = 0; i < size; i++)
                input.Add(Utilities.GetInteger("Enter the element: "));
            return input;
        }


        static void Main()
        {
            ReverseArray(InputArray());   
        }
    }
}
