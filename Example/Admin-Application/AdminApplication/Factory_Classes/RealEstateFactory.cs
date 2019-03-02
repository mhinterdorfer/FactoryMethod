/// <summary>
/// @author Michael Hinterdorfer
/// </summary>
public abstract class RealEstateFactory
{

    public RealEstateFactory()
    {
    }

    private static RealEstateFactory waldhausenFactory = new WaldhausenRealEstateFactory();
    private static RealEstateFactory linzFactory = new LinzRealEstateFactory();



    /// <summary>
    /// @param type 
    /// @param sqmeters 
    /// @param rooms 
    /// @param garden_sqmeters 
    /// @param num_of_parkingslots 
    /// @return
    /// </summary>
    protected abstract RealEstate createRealEstate(RealEstateType type, double sqmeters, int rooms, double garden_sqmeters, int num_of_parkingslots);

    /// <summary>
    /// @param location 
    /// @param type 
    /// @param sqmeters 
    /// @param rooms 
    /// @param garden_sqmeters 
    /// @param num_of_parkingslots 
    /// @return
    /// </summary>
    public static RealEstate addRealEstate(Location location, RealEstateType type, double sqmeters, int rooms,
        double garden_sqmeters, int num_of_parkingslots)
    {
        if (location == Location.Waldhausen)
        {
            return waldhausenFactory.createRealEstate(type, sqmeters, rooms, garden_sqmeters, num_of_parkingslots);
        }
        else if (location == Location.Linz)
        {
            return linzFactory.createRealEstate(type, sqmeters, rooms, garden_sqmeters, num_of_parkingslots);
        }
        return null;
    }

}