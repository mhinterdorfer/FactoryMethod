/**
 * @author Michael Hinterdorfer
 */
abstract class RealEstateFactory {
  /**
   * Default constructor
   */
  constructor() {}

  private static waldhausenFactory: RealEstateFactory = new WaldhausenRealEstateFactory();
  private static linzFactory: RealEstateFactory = new LinzRealEstateFactory();

  /**
   * @param type
   * @param sqmeters
   * @param rooms
   * @param garden_sqmeters
   * @param num_of_parkingslots
   * @return
   */
  abstract createRealEstate(
    type: RealEstateType,
    sqmeters: number,
    rooms: number,
    garden_sqmeters: number,
    num_of_parkingslots: number
  ): RealEstate;

  /**
   * @param location
   * @param type
   * @param sqmeters
   * @param rooms
   * @param garden_sqmeters
   * @param num_of_parkingslots
   * @return
   */
  addRealEstate(
    location: Location1,
    type: RealEstateType,
    sqmeters: number,
    rooms: number,
    garden_sqmeters: number,
    num_of_parkingslots: number
  ): RealEstate {
    if (location == Location1.Waldhausen) {
      return RealEstateFactory.waldhausenFactory.createRealEstate(
        type,
        sqmeters,
        rooms,
        garden_sqmeters,
        num_of_parkingslots
      );
    } else if (location == Location1.Linz) {
      return RealEstateFactory.linzFactory.createRealEstate(
        type,
        sqmeters,
        rooms,
        garden_sqmeters,
        num_of_parkingslots
      );
    }
    return null;
  }
}
