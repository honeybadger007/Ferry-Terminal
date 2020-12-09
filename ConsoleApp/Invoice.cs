using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class Invoice
    {
        public int Id { get; set; }
        public int EmployeId { get; set; }
        public ServiceType ServiceType {  get; set; }
        public int Amount { get; set; }
        public double EmployeeCommission { get; set; }

    }
}
