using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace library.Model
{
    public class BestEmployeeHeader
    {
        public string SupervisorID { get; set; }
        public string SupervisorName { get; set; }
        public string Department { get; set; }
        public int Year { get; set; }

        public string Month { get; set; }
    }
}