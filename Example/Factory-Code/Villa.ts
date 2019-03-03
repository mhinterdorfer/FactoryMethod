import { RealEstate } from "./RealEstate";
import { Location1 } from "./Location";

/**
 * @author Michael Hinterdorfer
 */
export class Villa implements RealEstate {
  /**
   * Default constructor
   */
  constructor() {}

  /**
   *
   */
  price: number;

  /**
   *
   */
  squaremeter: number;

  /**
   *
   */
  rooms: number;

  /**
   *
   */
  garden_squaremeter: number;

  /**
   *
   */
  num_of_parkinglots: number;

  /**
   *
   */
  location: Location1;
}
