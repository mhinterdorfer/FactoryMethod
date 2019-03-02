/**
 * @author Michael Hinterdorfer
 */
class WaldhausenRealEstateFactory extends RealEstateFactory {
  /**
   * Default constructor
   */
  constructor() {
    super();
  }

  /**
   *
   */
  private price_per_m2: number = 6.5;
  private location: Location1 = Location1.Waldhausen;

  /**
   * @param type
   * @param sqmeters
   * @param rooms
   * @param garden_sqmeters
   * @param num_of_parkingslots
   * @return
   */
  createRealEstate(
    type: RealEstateType,
    sqmeters: number,
    rooms: number,
    garden_sqmeters: number,
    num_of_parkingslots: number
  ): RealEstate {
    let price: number = 0;
    price += sqmeters * this.price_per_m2;
    price += garden_sqmeters * this.price_per_m2;

    if (type == RealEstateType.Apartment) {
      let apartment: Apartment = new Apartment();
      apartment.garden_squaremeter = garden_sqmeters;
      apartment.location = this.location;
      apartment.num_of_parkinglots = num_of_parkingslots;
      apartment.rooms = rooms;
      apartment.squaremeter = sqmeters;
      apartment.price = price;
      return apartment;
    } else if (type == RealEstateType.House) {
      let house: House = new House();
      house.garden_squaremeter = garden_sqmeters;
      house.location = this.location;
      house.num_of_parkinglots = num_of_parkingslots;
      house.rooms = rooms;
      house.squaremeter = sqmeters;
      house.price = price;
      return house;
    }
    return null;
  }
}
