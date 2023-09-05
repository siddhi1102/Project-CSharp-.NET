using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessments
{
    class Utilities
    {
        public static int GetInteger(string s)
        {
            Console.WriteLine(s);
            return int.Parse(Console.ReadLine());
        }
        public static string GetString(string s)
        {
            Console.WriteLine(s);
            return Console.ReadLine();
        }
        public static double GetDouble(string s)
        {
            Console.WriteLine(s);
            return float.Parse(Console.ReadLine());
        }
    }
}
