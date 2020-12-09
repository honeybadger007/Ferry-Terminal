using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class VehicleBase : IVehicle
    {

        public int Id { get; set; }
        public int FuelLevel { get; set; }
        public int Weight { get; set; }
        public VehicleType Type { get; set; }

        public VehicleBase(int vehicleId)
        {
            Id = vehicleId;

        }
    }
}
