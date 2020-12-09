using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public interface IVehicle
    {
        int Id { get; set; }
        int FuelLevel { get; set; }
        int Weight { get; set; }
        VehicleType Type { get; set; }
    }
}
