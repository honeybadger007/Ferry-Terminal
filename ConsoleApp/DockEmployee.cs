using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class DockEmployee
    {
        public int Id { get; set; }
        public double CalcCommission(double price)
        {
            return price * 0.1;
        }

    }
}
