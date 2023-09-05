using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
//using System.

namespace Assessments
{
    enum weekDays
    {
        SUNDAY, MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY, SATURDAY
    }
    class Ex05_WeekDays
    {
        public static void createEnum()
        {
            //Dictionary<string, int> enumDict = new Dictionary<string, int>();
            //int size = Utilities.GetInteger("Enter the size of enum: ");
            //for (int i = 0; i < size; i++)
            //{
            //    string constant = Utilities.GetString("Enter the constant for enum: ");
            //    int value = Utilities.GetInteger("Enter the value: ");
            //    if (enumDict.ContainsKey(constant))
            //    {
            //        Console.WriteLine("Constant already defined!");
            //        i--;
            //    }
            //    else
            //        enumDict.Add(constant, value);
            //}

            //foreach(var item in enumDict)
            //    Console.WriteLine(item.Key + " , " + item.Value);


            string constant = Utilities.GetString("Enter the day of week: ").ToUpper();
            weekDays value = (weekDays)Enum.Parse(typeof(weekDays), constant);
            //Console.WriteLine("The value for the entered constant: " + Enum.GetValues(typeof(weekDays)));

            //foreach(var item in Enum.GetValues(typeof(weekDays)))
            //{
            //    if(item == constant)
            //        Console.WriteLine((int)item);
            //}
            //int value1 = Utilities.GetInteger("Enter the number: ");
            //Console.WriteLine(Enum.GetName(typeof(weekDays), value1));

        }

        static void Main()
        {
            createEnum();
        }
    }
}
