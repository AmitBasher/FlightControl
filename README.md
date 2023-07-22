# FlightControl
FlightControl is a my final project from sela, this project is about replacing a tower control in airport to handle flights takeoff and landing.
This project Uses .Net Core, Angular and MSSQL Server.
### Main Use
Simulator is a console project that connect to the api and send a new flight every few seconds,
The api map the incoming flight and send it to TowerControl, which is a Singleton service to handle all flights event,
and there we have:
- StageControl - which have all the stages and is responsible for sending the stages the currect flight.
- TowerControlDbService - which resposible for DB Changes and Hub Updates.
- Events - which is resposible for letting the TowerControl know when a flight is started,changed and finished.


## Features
- **Scalability** - This project is scalable, We could add more stages and it will be handled automatic, Stages definition are made in one place (StagesConfiguration.cs).
- **Thread Safe** - this project is using SemaphoreSlim and Channels to handle multithreading environment.
- **SignalR** - in order to see every change happens in the project the api connected to client side throw signalR.
- **AutoMapper** - this project is using a AutoMapper to map the new flights and to send out stages.

# How To Use The Project
**1st** - pull the repository.
**2nd** (option 1)- (on cmd) - open FlightControl.api in cmd directory, Then use the command "dotnet run".
          (option 2) - (in vs) - open the project in Visual Studio and run the FlightControl.api project.
**3rd** - open FlightControl.Client in cmd directory and use "npm install", Then "ng serve", and open the page.
**4th** - open FlightControl.Simulator in cmd directory and use "dotnet run".
