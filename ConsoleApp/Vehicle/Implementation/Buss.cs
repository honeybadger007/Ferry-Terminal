using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class Buss : VehicleBase, IVehiclePeople
    {
        public int Passengers { get; set; }

        public Buss(int id) : base(id)
        {
            base.Type = VehicleType.Buss;
        }
    }
}
