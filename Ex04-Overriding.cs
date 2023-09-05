using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessments
{
    class baseClass
    {
        public virtual void PaymentCurrency()
        {
            string curr = Utilities.GetString("Enter the currency you want to choose: ");
            Console.WriteLine($"The entered currency for use is: {curr}");
        }
    }

    class Rupees : baseClass
    {
        public override void PaymentCurrency()
        {
            Console.WriteLine("The entered currency is: Rupees!!");
        }
    }

    class Dollar : baseClass
    {
        public override void PaymentCurrency()
        {
            Console.WriteLine("The entered currency is: Dollar!!");
        }
    }

    class Ex04_Overriding
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("FOR RUPEES----------->PRESS R\nFOR DOLLAR----------->PRESS D\nFOR OTHERS----------->PRESS O\n------ - TO EXIT PRESS EXIT--------");
                string choice = Utilities.GetString("Enter the currency choice: ");
                switch (choice)
                {
                    case "R": var rup = new Rupees(); rup.PaymentCurrency(); break;
                    case "D": var dol = new Rupees(); dol.PaymentCurrency(); break;
                    case "EXIT": return;
                    default: var curr = new baseClass(); curr.PaymentCurrency(); break;

                }

            } while (true);
        }
        
    }
}
