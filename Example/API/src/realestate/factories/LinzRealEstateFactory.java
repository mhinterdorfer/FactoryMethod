package realestate.factories;

import realestate.interfaces.Location;
import realestate.interfaces.RealEstate;
import realestate.interfaces.RealEstateFactory;
import realestate.interfaces.RealEstateType;
import realestate.products.Apartment;
import realestate.products.House;
import realestate.products.Villa;

/**
 * @author Michael Hinterdorfer
 */
public class LinzRealEstateFactory extends RealEstateFactory {

    /**
     * Default constructor
     */
    public LinzRealEstateFactory() {
    }

    /**
     * 
     */
    private double price_per_m2 = 9.9;
    private double price_per_parkinglot = 100;
    private static Location location = Location.Linz;

    /**
     * @param type
     * @param sqmeters
     * @param rooms
     * @param garden_sqmeters
     * @param num_of_parkingslots
     * @return
     */
    protected RealEstate createRealEstate(RealEstateType type, double sqmeters, int rooms, double garden_sqmeters,
	    int num_of_parkingslots) {

	double price = 0;
	price += sqmeters * price_per_m2;
	price += garden_sqmeters * price_per_m2;
	price += num_of_parkingslots * price_per_parkinglot;

	if (type.equals(RealEstateType.Apartment)) {
	    Apartment apartment = new Apartment();

	    apartment.setGarden_squaremeter(garden_sqmeters);
	    apartment.setLocation(location);
	    apartment.setNum_of_parkinglots(num_of_parkingslots);
	    apartment.setRooms(rooms);
	    apartment.setSquaremeter(sqmeters);
	    apartment.setPrice(price);

	    return apartment;
	} else if (type.equals(RealEstateType.House)) {
	    House house = new House();

	    house.setGarden_squaremeter(garden_sqmeters);
	    house.setLocation(location);
	    house.setNum_of_parkinglots(num_of_parkingslots);
	    house.setRooms(rooms);
	    house.setSquaremeter(sqmeters);
	    house.setPrice(price);

	    return house;
	} else if (type.equals(RealEstateType.Villa)) {
	    Villa villa = new Villa();

	    villa.setGarden_squaremeter(garden_sqmeters);
	    villa.setLocation(location);
	    villa.setNum_of_parkinglots(num_of_parkingslots);
	    villa.setRooms(rooms);
	    villa.setSquaremeter(sqmeters);
	    villa.setPrice(price);

	    return villa;
	}
	return null;
    }
}