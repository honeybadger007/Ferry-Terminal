using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class Truck : VehicleBase, IVehicleCargo
    {
        public DoorStatus CargoDoor { get; set; } = DoorStatus.Closed;

        public Truck(int id): base(id)
        {
            base.Type = VehicleType.Truck;

        }
    }
}
