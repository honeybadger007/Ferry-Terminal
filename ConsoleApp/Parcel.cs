namespace ConsoleApp
{
    public class Parcel
    {
        public int Id { get; set; }
        public Location Location { get; set; }

        public ParcelSize Size { get; set; }

        public int Content { get; set; }
    }
}