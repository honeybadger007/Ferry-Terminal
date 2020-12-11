using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region SIMULATE AUTO GENERATED DATABASE iD
            int terminalId,
                dockId,
                ferryId,
                employeeId,
                // vehicleId, this generated in VhicleFactory
                parcelId,
                documentId,
                invoiceId;
            terminalId = dockId = ferryId = employeeId = parcelId = documentId = invoiceId = 0;
            #endregion

            var terminals = new List<FerryTerminal>();
            var docks = new List<Dock>();
            var documents = new List<TerminalDocument>();
            var ferrys = new List<Ferry>();
            var parcels = new List<Parcel>();
            var invoices = new List<Invoice>();
            var employees = new List<IEmployee>();
            var vehicles = new List<IVehicle>();

            #region CREATE TERMINAL INFRASTRUCTURE AND PERSONELL
            // Create ferry terminal
            var ferryTerminal = new FerryTerminal(terminalId++);
            terminals.Add(ferryTerminal);

            // Create Dock
            var smallDock = new Dock(dockId++);
            var largeDock = new Dock(dockId++);
            docks.Add(smallDock);
            docks.Add(largeDock);

            // Get Dock reference inside ferry terminal
            ferryTerminal.DocksId.Add(smallDock.Id);
            ferryTerminal.DocksId.Add(largeDock.Id);

            // Create first two ferrys
            Ferry smallFerry = new Ferry(ferryId++, FerrySize.Small);
            Ferry largeFerry = new Ferry(ferryId++, FerrySize.Large);
            ferrys.Add(smallFerry);
            ferrys.Add(largeFerry);

            // Assign them to the docks
            smallDock.FerrysIds.Add(smallFerry.Id);
            largeDock.FerrysIds.Add(largeFerry.Id);

            // Create dock employee
            var dockEmloyee = new DockEmployee { Id = employeeId++ };
            employees.Add(dockEmloyee);
            #endregion

            #region Create vehicle factory
            var vehicleFactory = new VehicleFactory();
            var rnd = new Random();
            
            #endregion

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("********************************** Ferry Terimnal simulation Started **********************************");
            Console.WriteLine("*******************************************************************************************************\n\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 1000; i++)
            {
                // Create Vehicle
                var rndVehicleType = rnd.Next(1, 5);
                var vehType = (VehicleType)rndVehicleType;
                var currentVehicle = vehicleFactory.CreateVehicle(vehType);
                vehicles.Add(currentVehicle);
                currentVehicle.FuelLevel = rnd.Next(0, 101);

                #region Chose parcel size
                var parcelSize = ParcelSize.Small;
                switch (currentVehicle.Type)
                {
                    case VehicleType.Undefinde:
                        parcelSize = ParcelSize.Small;
                        break;
                    case VehicleType.Car:
                        parcelSize = ParcelSize.Small;
                        break;
                    case VehicleType.Van:
                        parcelSize = ParcelSize.Small;
                        break;
                    case VehicleType.Buss:
                        parcelSize = ParcelSize.Large;
                        break;
                    case VehicleType.Truck:
                        parcelSize = ParcelSize.Large;
                        break;
                }
                 #endregion

                // Create Parcel
                var currentParcel = new Parcel { Id = parcelId++, Content = currentVehicle.Id, Location = Location.UnSet, Size = parcelSize  };
                parcels.Add(currentParcel);

                // Create terminal document
                var currentDoc = new TerminalDocument { DocumentId = documentId++ };
                documents.Add(currentDoc);

                ferryTerminal.DocumentsIds.Add(currentDoc.DocumentId);
                currentDoc.ParcelsIds.Add(currentParcel.Id);
                currentParcel.Location = Location.Arrival;

                //// logistic
                // Charge transport fee
                var transportFee = 0;

                switch (currentVehicle.Type)
                {
                    case VehicleType.Car:
                        transportFee = 3;
                        break;
                    case VehicleType.Van:
                        transportFee = 4;
                        break;
                    case VehicleType.Buss:
                        transportFee = 5;
                        break;
                    case VehicleType.Truck:
                        transportFee = 6;
                        break;
                    default:
                        break;
                }

                var invoice = new Invoice { Id = invoiceId++, EmployeId = dockEmloyee.Id, ServiceType = ServiceType.TransportFee, Amount = transportFee };
                invoices.Add(invoice);

                _grossIncome += invoice.Amount;
                Console.WriteLine($"Transport fee of {transportFee} for a vehicle of a type {currentVehicle.Type.ToString()} has been charged.");
                currentDoc.InvoicesIds.Add(invoice.Id);

                // Check Gass status
                Console.WriteLine($"Fuel level is at {currentVehicle.FuelLevel} percent.");
                if (currentVehicle.FuelLevel < 10)
                {
                    currentParcel.Location = Location.GassStation;
                    currentVehicle.FuelLevel = 100;
                    Console.WriteLine($"Fuel level is at {currentVehicle.FuelLevel} percent.");
                }

                // Check If customs is needed
                if (currentVehicle is IVehicleCargo cargoVehicle)
                {
                    currentParcel.Location = Location.Customs;
                    // Open cargo door for inspection
                    Console.WriteLine($"Cargo doors are closed");
                    cargoVehicle.CargoDoor = DoorStatus.Opened;
                    Console.WriteLine($"Cargo doors are open");
                    cargoVehicle.CargoDoor = DoorStatus.Closed;
                    Console.WriteLine($"Cargo doors are closed");
                }

                // Create ferry when it is full 
                if(smallFerry.CurrentCargo.Count == smallFerry.FerryCapapcity )
                {
                    smallFerry = new Ferry(ferryId++, FerrySize.Small);
                    ferrys.Add(smallFerry);
                    smallDock.FerrysIds.Add(smallFerry.Id);
                }

                if (largeFerry.CurrentCargo.Count == largeFerry.FerryCapapcity )
                {
                    largeFerry = new Ferry(ferryId++, FerrySize.Large);
                    ferrys.Add(largeFerry);

                    largeDock.FerrysIds.Add(largeFerry.Id);
                }

                // Park car on ferry
                // Create Ferry if needed
                if (currentVehicle is Car || currentVehicle is Van)
                {
                    // Park small vehicle on ferry for small vehicles
                    smallFerry.LoadParcel(parcelId, ParcelSize.Small);
                    currentParcel.Location = Location.SmallFerry;
                }
                else
                {
                    // Park large vehicle on ferry for large vehicles
                    largeFerry.LoadParcel(parcelId, ParcelSize.Large);
                    currentParcel.Location = Location.LargeFerry;

                }


                // Park vehicle
                // take commission
                invoice.EmployeeCommission = dockEmloyee.CalcCommission(invoice.Amount);
                _employeeCommison += invoice.EmployeeCommission;
                Console.WriteLine("Commission for parking {0} for employe with Id #{1} is {2:f2}", currentVehicle.Type.ToString(), dockEmloyee.Id, invoice.EmployeeCommission );
                Console.WriteLine($"Summary: Gross income for terminal is: {_grossIncome}. Commission for employe: {dockEmloyee.Id} is {_employeeCommison.ToString("f2")}");
                Console.WriteLine("|*****************************************************************************************************\n|");
            }


                Console.WriteLine("Hello World!");
        }
        private static double _employeeCommison;

        private static double _grossIncome;
    }

    
}
