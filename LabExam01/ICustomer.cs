using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessments.LabExam01
{
    interface Customer
    {
        void InsertCust();
        void DeleteCust();
        void UpdateCust();
        void FindCust();
        void FindProd();
        void GetAllCust ();
        void GetAllProd ();
        void InsertBill ();
        void DisplayBill();
        void DisplayCustBill();
    }
}
