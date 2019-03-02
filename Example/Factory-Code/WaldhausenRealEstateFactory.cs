/// <summary>
/// @author Michael Hinterdorfer
/// </summary>
public class WaldhausenRealEstateFactory : RealEstateFactory
{

    public WaldhausenRealEstateFactory()
    {
    }

    private readonly int price_per_m2;
    private static readonly Location location = Location.Waldhausen;

    protected override RealEstate createRealEstate(RealEstateType type, double sqmeters, int rooms, double garden_sqmeters, int num_of_parkingslots)
    {
        double price = 0;
        price += sqmeters * price_per_m2;
        price += garden_sqmeters * price_per_m2;

        if (type == RealEstateType.Apartment)
        {
            Apartment apartment = new Apartment();

            apartment.setGarden_squaremeter(garden_sqmeters);
            apartment.setLocation(location);
            apartment.setNum_of_parkinglots(num_of_parkingslots);
            apartment.setRooms(rooms);
            apartment.setSquaremeter(sqmeters);
            apartment.setPrice(price);

            return apartment;
        }
        else if (type == RealEstateType.House)
        {
            House house = new House();

            house.setGarden_squaremeter(garden_sqmeters);
            house.setLocation(location);
            house.setNum_of_parkinglots(num_of_parkingslots);
            house.setRooms(rooms);
            house.setSquaremeter(sqmeters);
            house.setPrice(price);

            return house;
        }
        return null;
    }
}