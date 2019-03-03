/// <summary>
/// @author Michael Hinterdorfer
/// </summary>
public abstract class RealEstate
{

    public RealEstate()
    {
    }

    private double price;

    private double squaremeter;

    private int rooms;

    private double garden_squaremeter;

    private int num_of_parkinglots;

    private Location location;


    public double getPrice()
    {
        return price;
    }

    public void setPrice(double price)
    {
        this.price = price;
    }

    public double getSquaremeter()
    {
        return squaremeter;
    }

    public void setSquaremeter(double squaremeter)
    {
        this.squaremeter = squaremeter;
    }

    public int getRooms()
    {
        return rooms;
    }

    public void setRooms(int rooms)
    {
        this.rooms = rooms;
    }

    public double getGarden_squaremeter()
    {
        return garden_squaremeter;
    }

    public void setGarden_squaremeter(double garden_squaremeter)
    {
        this.garden_squaremeter = garden_squaremeter;
    }

    public int getNum_of_parkinglots()
    {
        return num_of_parkinglots;
    }

    public void setNum_of_parkinglots(int num_of_parkinglots)
    {
        this.num_of_parkinglots = num_of_parkinglots;
    }

    public Location getLocation()
    {
        return location;
    }

    public void setLocation(Location location)
    {
        this.location = location;
    }

    public override string ToString()
    {
        string realestate = "";
        realestate += "Price: " + getPrice() + "\n";
        realestate += "Squaremeter: " + getSquaremeter() + "\n";
        realestate += "Garden Squaremeter: " + getGarden_squaremeter() + "\n";
        realestate += "Location: " + getLocation() + "\n";
        realestate += "Num of parkinglots: " + getNum_of_parkinglots() + "\n";
        realestate += "Rooms: " + getRooms() + "\n";
        realestate += "Type: " + GetType() + "\n";
        return realestate;
    }

}