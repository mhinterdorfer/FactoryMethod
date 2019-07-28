# Factory Method Design Pattern

> Define a class interface to create an object, but let subclasses decide which class to instantiate. Factory methods allow a class to delegate the creation of objects to subclasses. 

![1564325702094](C:\Users\mhinterdorfer\AppData\Roaming\Typora\typora-user-images\1564325702094.png)

## Example

This example is for managing real estate. There are three types of real estate: Apartment, House and Villa. Each place (Factory) creates the real estate according to the current prices. New places can easily be added where the factory class is derived.

![1564325756668](C:\Users\mhinterdorfer\AppData\Roaming\Typora\typora-user-images\1564325756668.png)

The backend in the form of a REST interface was realized with Java. This manages the properties that are necessary to create the RealEstates. The following graphic shows the data model:

![1564325819534](C:\Users\mhinterdorfer\AppData\Roaming\Typora\typora-user-images\1564325819534.png)

The admin application was created with WPF. It provides the ability to dynamically create RealEstate objects and store them in the database through the REST interface.

![1564325851907](C:\Users\mhinterdorfer\AppData\Roaming\Typora\typora-user-images\1564325851907.png) ![1564325857223](C:\Users\mhinterdorfer\AppData\Roaming\Typora\typora-user-images\1564325857223.png)

The created objects can be checked in a list view. It is also possible to change or delete the data records. When clicking on an entry details can be displayed. When the detail page is called, the RealEstate object is created again using the factory method and the price is calculated. 

![1564325885775](C:\Users\mhinterdorfer\AppData\Roaming\Typora\typora-user-images\1564325885775.png)

![1564325893061](C:\Users\mhinterdorfer\AppData\Roaming\Typora\typora-user-images\1564325893061.png)

The client application is based on an Angular application that loads the records from the database and displays the RealEstate objects on a Web site. At the same time, the application does not know which specific products it is dealing with.

![1564325913839](C:\Users\mhinterdorfer\AppData\Roaming\Typora\typora-user-images\1564325913839.png)

