using System.Text.Json;

namespace CarMaintenance;
public class Program
{
    private static List<Vehicle> _vehicleList = new();

    public static void Main(string[] args)
    {
        OnLoadReadTxtFile();
        var mainMenu = true;
        while (mainMenu)
        {
            Console.WriteLine("――――――――――――――――――――――――――――――"); //30length
            Console.WriteLine("1) Vehicle List");
            Console.WriteLine("2) View Records and Notes");
            Console.WriteLine("3) Add Maintenance Event");
            Console.WriteLine("4) Add Note");
            Console.WriteLine("5) Save and Exit Application");
            switch (Console.ReadLine()?.Trim())
            {
                case "1":
                    Console.WriteLine("――――――――――――――――――――――――――――――"); //30length
                    DisplayVehicleListFull();
                    Console.WriteLine("1) Add Vehicle");
                    Console.WriteLine("2) Delete Vehicle");
                    Console.WriteLine("3) Edit Vehicle Information");
                    switch (Console.ReadLine()?.Trim())
                    {
                        case "1":
                            CreateNewVehicle();
                            break;
                        case "2":
                            DeleteVehicle();
                            break;
                        case "3":
                            EditVehicleInformation();
                            break;
                        default:
                            Console.WriteLine("ENTER A NUMBER IN RANGE TO MAKE A SELECTION.");
                            break;
                    }
                    break;
                case "2":
                    ViewVehicleInformation();
                    break;
                case "3":
                    CreateMaintenanceEvent();
                    break;
                case "4":
                    CreateNote();
                    break;
                case "5":
                    ExportVehicleList();
                    mainMenu = false;
                    break;
                case "debug1":
                    Console.WriteLine("WARNING! Are you sure you want to reset the vehicle directory and populate it with predefined data? [Y] or [N]");
                    if (Console.ReadLine()?.Trim().ToUpper() == "Y")
                        DebugReset();
                    break;
                default:
                    Console.WriteLine("ENTER A NUMBER IN RANGE TO MAKE A SELECTION.");
                    break;
            }
        }
    }

    private static void DisplayVehicleListFull()
    {
        Console.Clear();
        for (int i = 0; i < _vehicleList.Count; i++)
        {
            Console.WriteLine("Index: " + i);
            Console.WriteLine(_vehicleList[i].ToString());
            Console.WriteLine();
        }
    }

    private static void DisplayVehicleListShort()
    {
        Console.Clear();
        for (int i = 0; i < _vehicleList.Count; i++)
        {
            Console.WriteLine("Index: " + i);
            Console.WriteLine(" " + _vehicleList[i].Year + " " + _vehicleList[i].Make + " " + _vehicleList[i].Model);
        }
        Console.WriteLine();
    }
    private static void CreateNewVehicle()
    {
        Console.WriteLine("――――――――――――――――――――――――――――――"); //30length
        Console.WriteLine("Enter make: ");
        string tempMake = Console.ReadLine() ?? throw new InvalidOperationException();
        Console.WriteLine("Enter model: ");
        string tempModel = Console.ReadLine() ?? throw new InvalidOperationException();
        Console.WriteLine("Enter model year: ");
        int tempYear = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter VIN: ");
        string tempVin = Console.ReadLine() ?? throw new InvalidOperationException();
        Console.WriteLine("Enter oil type: ");
        string tempOilType = Console.ReadLine() ?? throw new InvalidOperationException();
        Console.WriteLine("Enter oil capacity: ");
        double tempOilCapacity = Convert.ToDouble(Console.ReadLine());
        _vehicleList.Add(new Vehicle(tempMake, tempModel, tempYear, tempVin, tempOilType, tempOilCapacity));
        Console.Clear();
    }
    private static void DeleteVehicle()
    {
        Console.WriteLine("――――――――――――――――――――――――――――――"); //30length
        DisplayVehicleListShort();
        Console.WriteLine("Enter index of vehicle to remove:");
        if (int.TryParse(Console.ReadLine(), out int selector))
        {
            Console.WriteLine("WARNING! ARE YOU SURE YOU WANT TO REMOVE THE [" + _vehicleList[selector].Model + "]? [Y] or [N]");
            if (Console.ReadLine()?.Trim().ToUpper() == "Y")
                _vehicleList.RemoveAt(selector);
        }
        Console.Clear();
    }

    private static void ViewVehicleInformation()
    {
        Console.WriteLine("――――――――――――――――――――――――――――――"); //30length
        DisplayVehicleListShort();
        Console.WriteLine("Enter index of vehicle to view:");
        int indexOf = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        Console.WriteLine(_vehicleList[indexOf].Year + " " + _vehicleList[indexOf].Make + " " + _vehicleList[indexOf].Model);
        _vehicleList[indexOf].DisplayNotes();
        _vehicleList[indexOf].DisplayRecords();
    }

    private static void EditVehicleInformation()
    {
        Console.WriteLine("――――――――――――――――――――――――――――――"); //30length
        DisplayVehicleListFull();
        Console.WriteLine("Enter index of vehicle to edit:");
        int indexOf = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Information to Edit:");
        Console.WriteLine("1) Make");
        Console.WriteLine("2) Model");
        Console.WriteLine("3) Year");
        Console.WriteLine("4) VIN");
        Console.WriteLine("5) Oil Type");
        Console.WriteLine("6) Oil Capacity");
        switch (Console.ReadLine())
        {
            case "1":
                Console.WriteLine("Edit Make: ");
                _vehicleList[indexOf].Make = Console.ReadLine()?.Trim() ?? throw new InvalidOperationException();
                break;
            case "2":
                Console.WriteLine("Edit Model: ");
                _vehicleList[indexOf].Model = Console.ReadLine()?.Trim() ?? throw new InvalidOperationException();
                break;
            case "3":
                Console.WriteLine("Edit Year: ");
                _vehicleList[indexOf].Year = Convert.ToInt32(Console.ReadLine()?.Trim());
                break;
            case "4":
                Console.WriteLine("Edit VIN: ");
                _vehicleList[indexOf].Vin = Console.ReadLine()?.Trim() ?? throw new InvalidOperationException();
                break;
            case "5":
                Console.WriteLine("Edit Oil Type:");
                _vehicleList[indexOf].OilType = Console.ReadLine()?.Trim() ?? throw new InvalidOperationException();
                break;
            case "6":
                Console.WriteLine("Edit Oil Capacity:");
                _vehicleList[indexOf].OilQuantity = Convert.ToDouble(Console.ReadLine()?.Trim());
                break;
            default:
                Console.WriteLine("ENTER A NUMBER IN RANGE TO MAKE A SELECTION.");
                break;
        }
        Console.Clear();
    }

    private static void CreateMaintenanceEvent()
    {
        Console.WriteLine("――――――――――――――――――――――――――――――"); //30length
        DisplayVehicleListShort();
        Console.WriteLine("Index of vehicle to add maintenance event: ");
        int indexOf = Convert.ToInt32(Console.ReadLine()?.Trim());
        Console.WriteLine("Date (dd/mm/yyyy): ");
        DateOnly tempDate1 = DateOnly.Parse(Console.ReadLine()!);
        Console.WriteLine("Description:");
        string tempDescription1 = Console.ReadLine()!;
        Console.WriteLine("Part Number:");
        string tempPartNumber = Console.ReadLine()!;
        _vehicleList[indexOf].AddMaintenanceEvent(tempDate1, tempDescription1, tempPartNumber);
        Console.Clear();
    }

    private static void CreateNote()
    {
        Console.WriteLine("――――――――――――――――――――――――――――――"); //30length
        DisplayVehicleListShort();
        Console.WriteLine("Index of vehicle to add note: ");
        int indexOf = Convert.ToInt32(Console.ReadLine()?.Trim());
        Console.WriteLine("Date (dd/mm/yyyy): ");
        DateOnly tempDate2 = DateOnly.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        Console.WriteLine("Description:");
        string tempDescription2 = Console.ReadLine() ?? throw new InvalidOperationException();
        _vehicleList[indexOf].AddNote(tempDate2, tempDescription2);
        Console.Clear();
    }

    private static void ExportVehicleList()
    {
        File.Delete("vehicleList.json");
        for (int i = 0; i < _vehicleList.Count(); i++)
        {
            string json = JsonSerializer.Serialize(_vehicleList[i]);
            File.AppendAllLines("vehicleList.json", [json]);
        }
    }

    private static void OnLoadReadTxtFile()
    {
        try
        {
            string[] jsonFromFile = File.ReadAllLines("vehicleList.json");
            foreach (string line in jsonFromFile)
            {
                Vehicle? tempVehicle = JsonSerializer.Deserialize<Vehicle>(line);
                if (tempVehicle != null)
                {
                    _vehicleList.Add(tempVehicle);
                }
            }
            Console.WriteLine("SUCCESSFULLY LOADED [" + _vehicleList.Count + "] VEHICLES.");
            Console.WriteLine("All changes must be saved before closing the application.");
        }
        catch (Exception ex)
        { Console.WriteLine("An error occurred in reading the file: " + ex.Message); }

    }

    private static void DebugReset()
    {
        //ENTER "debug1" FROM THE MAIN MENU TO EXECUTE THIS FUNCTION 
        _vehicleList.Clear();
        _vehicleList.Add(new Vehicle("Lexus", "IS300", 2002, "JTHBD1921200*****", "5w30", 6));
        _vehicleList.Add(new Vehicle("Honda", "Accord", 2007, "BSKRB7624756*****", "5w20", 4.2));
        _vehicleList.Add(new Vehicle("Toyota", "Highlander", 2011, "TBVDG0175627*****", "0w15", 8.2));
        _vehicleList[0].AddNote(DateOnly.Parse("02/21/2015"), "Added power steering fluid to top level.");
        _vehicleList[0].AddNote(DateOnly.Parse("04/29/2011"), "Replaced 10a fuse for highbeam control.");
        _vehicleList[0].AddMaintenanceEvent(DateOnly.Parse("05/10/2015"), "Polyurethane Steering Rack Bushing", "HFJSK15073");
        _vehicleList[0].AddMaintenanceEvent(DateOnly.Parse("02/21/2017"), "Front Lower Control Arms", "GHT901724");
        _vehicleList[1].AddNote(DateOnly.Parse("08/30/2024"), "Lost air in one tire, had to patch it.");
        _vehicleList[1].AddNote(DateOnly.Parse("01/12/2022"), "35% ceramic window tint all around.");
        _vehicleList[1].AddMaintenanceEvent(DateOnly.Parse("10/12/2022"), "Replaced thermostat.", "HKLYIRS678");
        _vehicleList[2].AddNote(DateOnly.Parse("04/07/2016"), "Replaced subwoofer with junkyard replacement.");
        _vehicleList[2].AddNote(DateOnly.Parse("08/24/2017"), "5% tint on all rear windows and 35% on front two windows.");
        _vehicleList[2].AddMaintenanceEvent(DateOnly.Parse("06/29/2017"), "Replaced OEM sway bar end links", "THSL67985");
    }
}