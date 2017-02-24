# _My Little Hair Salon_

#### _Hair Salon client and stylist database webpage, 2.24.17_

#### By _**Katy Daviscourt**_

## Description

_This webpage allows the user to manage their list of stylists and stylists through a database that keeps track of which clients see which stylists. It also allows the user to delete clients or change their name._

## Setup/Installation Requirements

* Clone the git from the repository at https://github.com/katyisgreaty/hair-salon.git .
* In Powershell, navigate to the git's location
* In SQLCMD:
    * > CREATE DATABASE hair_salon;
    * > GO
    * > USE hair_salon;
    * > GO
    * > CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255), stylist_id INT);
    * > CREATE TABLE tasks (id INT IDENTITY(1,1), name VARCHAR(255), specialty VARCHAR(255), experience INT);
    * > GO
* Backup and restore database, naming the restored database hair_salon_test
* Type "dnx kestrel" into Powershell
* In the browser, to go "localhost:5004" to view webpage


## Specifications

* The get all method will return an empty list if the list of stylists is empty in the beginning
    * input: nothing/null
    * output: empty string

* The equals method will return true if there are two stylists that are the same
    * input: Alex, Alex
    * output: true

* The get all method will return the stylist if the stylist was saved in the database
    * input: Stephanie
    * output: Stephanie

* The save method will assign a new id to a new instance of the stylist class
    * Input: Ramon, 0
    * Output: Ramon, non zero

* The get all method will return a list of all stylists
    * input: Samantha, Hallie, Teela, Geoffery
    * output: Samantha, Hallie, Teela, Geoffery

* The find method will return the stylist in the database.
    * input: Teela
    * output: Teela

* The get name, get specialty, and get experience methods will return a stylist's details when a user clicks on that stylist
    * input: Hallie
    * output: Hallie, curly hair, 3 years

* The get all method will return an empty list if the list of clients is empty in the beginning
    * input: nothing/null
    * output: empty string

* The equals method will return true if there are two clients that are the same
    * input: Bill, Bill
    * output: true

* The save and get all methods will return true if the client was saved in the database
    * input: Bob
    * output: true

* The get all method will return true if the id for the first client has an id of 1.
    input: Becky
    output: 1

* The get all method will return a list of all clients
    * input: Sandra, Shelley, Tom, Kendra
    * output: Sandra, Shelley, Tom, Kendra

* The find method will return the client in the database by id.
    * input: Hannah
    * output: Hannah

* The find method will return the client in the database by name.
    * input: Hannah
    * output: Hannah

* When the user updates the name of a client, the update method will return the updated info
    * input: Big T replacing Tom
    * output: Big T

* When the user deletes a client, the delete method will return an updated list without the deleted client
    * input: DELETE Big T
    * output: Sandra, Shelley, Kendra

* The get all method can sort clients by stylist
    * input: Teela
    * output: Shelley, Sandra


## Ice Box Specifications

* When the user updates the name of a stylist, the update method will return the updated name
    * input: Sam replacing Samantha
    * output: Sam

* When the user deletes a stylist, the delete method will return an updated list without the deleted stylist
    * input: DELETE Geoffery
    * output: Sam, Hallie, Teela

* The search method can search for stylists by name
    * input: Hallie
    * output: Hallie

* The search method can search for stylists by name
    * input: Hallie
    * output: Hallie

* The get details method will return a client's details when a user clicks on that client
    * input: Sandra
    * output: Sandra, short hair, prefers Paul Mitchell Shampoo


## Known Bugs

_None at this time_

## Support and contact details

_For questions or comments please contact Katy at katy.daviscourt@gmail.com_

## Technologies Used

_C#, MSSQL_

### License

*Available under an MIT License*

Copyright (c) 2017 **_Katy Daviscourt_**
