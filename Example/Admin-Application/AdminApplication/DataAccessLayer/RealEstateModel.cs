namespace AdminApplication
{
    internal class RealEstateModel
    {
        public RealEstateModel(string type, string location, int rooms, double squaremeter, double gardenSquaremeter, int numOfParkinglots)
        {
            Type = type;
            Location = location;
            Rooms = rooms;
            Squaremeter = squaremeter;
            GardenSquaremeter = gardenSquaremeter;
            NumOfParkinglots = numOfParkinglots;
        }

        public int IdRealEsate { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public int Rooms { get; set; }
        public double Squaremeter { get; set; }
        public double GardenSquaremeter { get; set; }
        public int NumOfParkinglots { get; set; }
    }
}