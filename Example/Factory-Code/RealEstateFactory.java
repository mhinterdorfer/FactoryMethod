package realestate.interfaces;

import realestate.factories.LinzRealEstateFactory;
import realestate.factories.WaldhausenRealEstateFactory;

/**
 * @author Michael Hinterdorfer
 */
public abstract class RealEstateFactory {

    /**
     * Default constructor
     */
    public RealEstateFactory() {
    }

    private static RealEstateFactory waldhausenFactory = new WaldhausenRealEstateFactory();
    private static RealEstateFactory linzFactory = new LinzRealEstateFactory();

    /**
     * @param type
     * @param sqmeters
     * @param rooms
     * @param garden_sqmeters
     * @param num_of_parkingslots
     * @return
     */
    protected abstract RealEstate createRealEstate(RealEstateType type, double sqmeters, int rooms,
	    double garden_sqmeters, int num_of_parkingslots);

    /**
     * @param location
     * @param type
     * @param sqmeters
     * @param rooms
     * @param garden_sqmeters
     * @param num_of_parkingslots
     * @return
     */
    public static RealEstate addRealEstate(Location location, RealEstateType type, double sqmeters, int rooms,
	    double garden_sqmeters, int num_of_parkingslots) {
	if (location.equals(Location.Waldhausen)) {
	    return waldhausenFactory.createRealEstate(type, sqmeters, rooms, garden_sqmeters, num_of_parkingslots);
	} else if (location.equals(Location.Linz)) {
	    return linzFactory.createRealEstate(type, sqmeters, rooms, garden_sqmeters, num_of_parkingslots);
	}
	return null;
    }

}