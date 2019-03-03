import { WaldhausenRealEstateFactory } from "./WaldhausenRealEstateFactory";

import { LinzRealEstateFactory } from "./LinzRealEstateFactory";

import { RealEstate } from "./RealEstate";
import { IRealEstateFactory } from "./IRealEstateFactory";
import { Location1 } from "./Location";
import { RealEstateType } from "./RealEstateType";

/**
 * @author Michael Hinterdorfer
 */
export class RealEstateFactory {
  private static waldhausenFactory: IRealEstateFactory = new WaldhausenRealEstateFactory();
  private static linzFactory: IRealEstateFactory = new LinzRealEstateFactory();

  /**
   * @param location
   * @param type
   * @param sqmeters
   * @param rooms
   * @param garden_sqmeters
   * @param num_of_parkingslots
   * @return
   */
  static addRealEstate(
    location: Location1,
    type: RealEstateType,
    sqmeters: number,
    rooms: number,
    garden_sqmeters: number,
    num_of_parkingslots: number
  ): RealEstate {
    console.log(type);
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
