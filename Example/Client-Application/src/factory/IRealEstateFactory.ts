import { RealEstate } from "./RealEstate";
import { RealEstateType } from "./RealEstateType";

export interface IRealEstateFactory {
  createRealEstate(
    type: RealEstateType,
    sqmeters: number,
    rooms: number,
    garden_sqmeters: number,
    num_of_parkingslots: number
  ): RealEstate;
}
