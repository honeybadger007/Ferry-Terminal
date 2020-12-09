using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class VehicleFactory
    {
        private int _vehicleId;
        public IVehicle CreateVehicle(VehicleType vehicleType)
        {
            switch (vehicleType)
            {
                case VehicleType.Car:
                    return new Car(_vehicleId++);

                case VehicleType.Van:
                    return new Van(_vehicleId++);
                   
                case VehicleType.Buss:
                    return new Buss(_vehicleId++);
                    
                case VehicleType.Truck:
                    return new Truck(_vehicleId++);
                    
                default:
                    return new Car(_vehicleId++);
            }
        }
    }
}
