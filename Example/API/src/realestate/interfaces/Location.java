package realestate.interfaces;

/**
 * @author Michael Hinterdorfer
 */
public enum Location {
    Linz, Waldhausen;
    
    public static Location convertFromString(String name) {
	if(name.equals(Linz.name())) {
	    return Linz;
	}else if(name.equals(Waldhausen.name())) {
	    return Waldhausen;
	}
	return null;
    }
}