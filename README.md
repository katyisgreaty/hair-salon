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
* Backup and restore database with the restored database named hair_salon_test
* Type "dnx kestrel" into Powershell
* In the browser, to go "localhost:5004" to view webpage


## Known Bugs

_{Are there issues that have not yet been resolved that you want to let users know you know?  Outline any issues that would impact use of your application.  Share any workarounds that are in place. }_

## Support and contact details

_{Let people know what to do if they run into any issues or have questions, ideas or concerns.  Encourage them to contact you or make a contribution to the code.}_

## Technologies Used

_{Tell me about the languages and tools you used to create this app. Assume that I know you probably used HTML and CSS. If you did something really cool using only HTML, point that out.}_

### License

*{Determine the license under which this application can be used.  See below for more details on licensing.}*

Copyright (c) 2016 **_{List of contributors or company name}_**
