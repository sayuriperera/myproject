using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace library.Model
{
    public class Employee
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        public int Rank { get; set; }
        
        public double Score { get; set; }
    }
}