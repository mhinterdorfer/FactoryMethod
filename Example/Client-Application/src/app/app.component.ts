import { Component } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { RealEstateFactory } from "src/factory/RealEstateFactory";
import { RealEstate } from "src/factory/RealEstate";
import { Location1 } from "src/factory/Location";
import { RealEstateType } from "src/factory/RealEstateType";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent {
  realestates: RealEstate[] = [];

  constructor(private http: HttpClient) {
    http
      .get<IRealEstate[]>(
        "http://localhost:8080/RealEstateAPI/rest/realestates"
      )
      .forEach(model => {
        model.forEach(element => {
          this.realestates.push(
            RealEstateFactory.addRealEstate(
              Location1[element.location],
              RealEstateType[element.type],
              element.squaremeter,
              element.rooms,
              element.gardenSquaremeter,
              element.numOfParkinglots
            )
          );
        });
      });
    console.log(this.realestates);
  }
}
