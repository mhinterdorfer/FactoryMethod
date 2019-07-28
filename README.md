# Factory Method Design Pattern

> Define a class interface to create an object, but let subclasses decide which class to instantiate. Factory methods allow a class to delegate the creation of objects to subclasses. 

![uml diagram](https://github.com/mhinterdorfer/FactoryMethod/blob/master/uml%20diagram.png?raw=true)

## Example

This example is for managing real estate. There are three types of real estate: Apartment, House and Villa. Each place (Factory) creates the real estate according to the current prices. New places can easily be added where the factory class is derived.

![uml diagram example](https://github.com/mhinterdorfer/FactoryMethod/blob/master/uml%20diagram%20example.png?raw=true)

The backend in the form of a REST interface was realized with Java. This manages the properties that are necessary to create the RealEstates. The following graphic shows the data model:

![data model](https://github.com/mhinterdorfer/FactoryMethod/blob/master/data%20model.png?raw=true)

The admin application was created with WPF. It provides the ability to dynamically create RealEstate objects and store them in the database through the REST interface.

![admin application](https://github.com/mhinterdorfer/FactoryMethod/blob/master/admin%20application%201.png?raw=true)

![admin application](https://github.com/mhinterdorfer/FactoryMethod/blob/master/admin%20application%202.png?raw=true)

The created objects can be checked in a list view. It is also possible to change or delete the data records. When clicking on an entry details can be displayed. When the detail page is called, the RealEstate object is created again using the factory method and the price is calculated. 

![admin application](https://github.com/mhinterdorfer/FactoryMethod/blob/master/admin%20application%203.png?raw=true)

![admin application](https://github.com/mhinterdorfer/FactoryMethod/blob/master/admin%20application%204.png?raw=true)

The client application is based on an Angular application that loads the records from the database and displays the RealEstate objects on a Website. At the same time, the application does not know which specific products it is dealing with.

![client application](https://github.com/mhinterdorfer/FactoryMethod/blob/master/client%20application.png?raw=true)

