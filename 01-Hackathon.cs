using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessments
{
    class Hackathon
    {
        const string content = "the quick and brown fox jumps over the lazy dog";
        static void Main(string[] args)
        {
            string input = Utilities.GetString("Enter the input: ");
            Encoded(input.ToLower());
        }

        public static void Encoded(string input)
        {
            string result = string.Empty;
            if (input == null) throw new NullReferenceException();
            if (input == "") throw new ArgumentException("The entered string is empty!!");
            for(int i = 0; i < input.Length; i++)
            {
                result += getCode(input[i]);
                if (result.EndsWith(",-"))
                {
                    result = result.Substring(0, result.Length - 2) + "-";
                }
            }

            Console.WriteLine(result.Substring(0, result.Length-1));
            
        }

        public static string getCode(char ch)
        {
            string result = string.Empty;
            Array words = content.Split();
            List<string> list = new List<string>();
            foreach (var item in words)
                list.Add(item.ToString());
            for (int i = 0; i < words.Length; i++)
            {
                if (list[i].Contains(ch))
                {
                    result += list.IndexOf(list[i]);
                    result += list[i].IndexOf(ch);
                    return result + ",";
                }
            }
            return "-";
        }
    }
}
