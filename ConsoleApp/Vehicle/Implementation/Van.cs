using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class Van : VehicleBase, IVehicleCargo
    {
        public DoorStatus CargoDoor { get; set; } = DoorStatus.Closed;

        public Van(int id) : base(id)
        {
            base.Type = VehicleType.Van;
        }
    }
}
