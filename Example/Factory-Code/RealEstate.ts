import { Location1 } from "./Location";

/**
 * @author Michael Hinterdorfer
 */
export interface RealEstate {
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
