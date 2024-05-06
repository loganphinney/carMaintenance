This is a C# application created with the JetBrains Rider IDE on MacOS. Although you may not need every single file in the repo, they are all included. The four main files necessary at a bare minimum to run this program are as follows:
	Program.cs (contains main method)
	Vehicle.cs
	MaintenanceList.cs
	NotesList.cs.

The application reads and writes vehicles data at the following location. 
carMaintenance/bin/debug/net8.0/vehicleList.json
If you wish to start the application with no vehicles already added you can safely delete this file. A new one will automatically be created. 

Data is only persistent as long as you exit the application through the main menu dialog.

If at any point you wish to revert the applications data to the default state, you can enter ‘debug1’ on the main menu. This will wipe the current vehicle data and replace it with a copy of the original data provided with the application.
