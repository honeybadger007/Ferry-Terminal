using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class Ferry
    {
        public int Id { get; private set; }
        public FerrySize Size { get; set; }
        public int FerryCapapcity { get; private set; }
        public List<int> CurrentCargo { get; private set; }

        #region CTOR
        private Ferry()
        {
        }

        public Ferry( int id, FerrySize size )
        {
            Id = id;
            switch (size)
            {
                case FerrySize.Small:
                    FerryCapapcity = 8;
                    break;
                case FerrySize.Large:
                    FerryCapapcity = 6;
                    break;
                default:
                    FerryCapapcity = 8;
                    break;
            }
            CurrentCargo = new List<int>();
        }
        #endregion

        public void LoadParcel (int parcelId, ParcelSize parcelSize)
        {
            switch (parcelSize)
            {
                case ParcelSize.Unkonwn:
                    Console.WriteLine("Enter the right size of your parcel");
                    break;
                case ParcelSize.Small:
                    if (parcelSize == ParcelSize.Small && CurrentCargo.Count < FerryCapapcity +1)
                    {
                        CurrentCargo.Add(parcelId);
                    }
                    break;

                case ParcelSize.Large:
                    if (parcelSize == ParcelSize.Large && CurrentCargo.Count < FerryCapapcity +1 )
                    {
                        CurrentCargo.Add(parcelId);
                    }
                    break;
                default:
                    Console.WriteLine("Enter the right size of your parcel");
                    break;
            }
            
        }
    }
}
