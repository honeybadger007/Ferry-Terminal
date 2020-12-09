using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class Car : VehicleBase, IVehiclePeople
    {
        public Car(int id) : base(id)
        {
            base.Type = VehicleType.Car;
        }
        public int Passengers { get; set; }
    }
}
