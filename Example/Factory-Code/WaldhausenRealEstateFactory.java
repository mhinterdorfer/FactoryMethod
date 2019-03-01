
import java.util.*;

/**
 * @author Michael Hinterdorfer
 */
public class WaldhausenRealEstateFactory extends RealEstateFactory {

	/**
	 * Default constructor
	 */
	public WaldhausenRealEstateFactory() {
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
	protected RealEstate createRealEstate(RealEstateType type, double sqmeters, int rooms, double garden_sqmeters, int num_of_parkingslots) {
		// TODO implement here
		return null;
	}

	/**
	 * @param type 
	 * @param sqmeters 
	 * @param rooms 
	 * @param garden_sqmeters 
	 * @param num_of_parkingslots 
	 * @return
	 */
	protected abstract RealEstate createRealEstate(RealEstateType type, double sqmeters, int rooms, double garden_sqmeters, int num_of_parkingslots);

}