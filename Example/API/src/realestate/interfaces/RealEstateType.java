package realestate.interfaces;

/**
 * @author Michael Hinterdorfer
 */
public enum RealEstateType {
    Apartment, Villa, House;
    
    public static RealEstateType convertFromString(String name) {
	if(name.equals(Apartment.name())) {
	    return Apartment;
	}else if(name.equals(Villa.name())) {
	    return Villa;
	}else if(name.equals(House.name())) {
	    return House;
	}
	return null;
    }
}