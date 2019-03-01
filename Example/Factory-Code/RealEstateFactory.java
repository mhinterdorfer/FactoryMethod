
import java.util.*;

/**
 * @author Michael Hinterdorfer
 */
public abstract class RealEstateFactory {

	/**
	 * Default constructor
	 */
	public RealEstateFactory() {
	}

	/**
	 * 
	 */
	private int price_per_m2;



	/**
	 * @param type 
	 * @param sqmeters 
	 * @param rooms 
	 * @param garden_sqmeters 
	 * @param num_of_parkingslots 
	 * @return
	 */
	protected abstract RealEstate createRealEstate(RealEstateType type, double sqmeters, int rooms, double garden_sqmeters, int num_of_parkingslots);

	/**
	 * @param location 
	 * @param type 
	 * @param sqmeters 
	 * @param rooms 
	 * @param garden_sqmeters 
	 * @param num_of_parkingslots 
	 * @return
	 */
	public RealEstate addRealEstate(Location location, RealEstateType type, double sqmeters, int rooms, double garden_sqmeters, int num_of_parkingslots) {
		// TODO implement here
		return null;
	}

}