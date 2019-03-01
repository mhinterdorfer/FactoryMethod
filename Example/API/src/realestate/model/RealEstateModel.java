package realestate.model;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the RealEstates database table.
 * 
 */
@Entity
@Table(name="RealEstates")
@NamedQuery(name="RealEstateModel.findAll", query="SELECT r FROM RealEstateModel r")
public class RealEstateModel implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="id_real_esate")
	private int idRealEsate;

	@Column(name="garden_squaremeter")
	private double gardenSquaremeter;

	private String location;

	@Column(name="num_of_parkinglots")
	private int numOfParkinglots;

	private int rooms;

	private double squaremeter;

	private String type;

	public RealEstateModel() {
	}

	public int getIdRealEsate() {
		return this.idRealEsate;
	}

	public void setIdRealEsate(int idRealEsate) {
		this.idRealEsate = idRealEsate;
	}

	public double getGardenSquaremeter() {
		return this.gardenSquaremeter;
	}

	public void setGardenSquaremeter(double gardenSquaremeter) {
		this.gardenSquaremeter = gardenSquaremeter;
	}

	public String getLocation() {
		return this.location;
	}

	public void setLocation(String location) {
		this.location = location;
	}

	public int getNumOfParkinglots() {
		return this.numOfParkinglots;
	}

	public void setNumOfParkinglots(int numOfParkinglots) {
		this.numOfParkinglots = numOfParkinglots;
	}

	public int getRooms() {
		return this.rooms;
	}

	public void setRooms(int rooms) {
		this.rooms = rooms;
	}

	public double getSquaremeter() {
		return this.squaremeter;
	}

	public void setSquaremeter(double squaremeter) {
		this.squaremeter = squaremeter;
	}

	public String getType() {
		return this.type;
	}

	public void setType(String type) {
		this.type = type;
	}

}