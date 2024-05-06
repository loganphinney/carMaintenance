namespace CarMaintenance;
public class Vehicle(string make, string model, int year, string vin, string oilType, double oilQuantity)
{
    private MaintenanceList _records = new();
    private NotesList _notes = new();

    public string Make
    { get => make; set => make = value ?? throw new ArgumentNullException(nameof(value)); }

    public string Model
    { get => model; set => model = value ?? throw new ArgumentNullException(nameof(value)); }

    public int Year
    { get => year; set => year = value; }

    public string Vin
    { get => vin; set => vin = value ?? throw new ArgumentNullException(nameof(value)); }

    public string OilType
    { get => oilType; set => oilType = value ?? throw new ArgumentNullException(nameof(value)); }

    public double OilQuantity
    { get => oilQuantity; set => oilQuantity = value; }

    public MaintenanceList Records
    { get => _records; set => _records = value ?? throw new ArgumentNullException(nameof(value)); }

    public NotesList Notes
    { get => _notes; set => _notes = value ?? throw new ArgumentNullException(nameof(value)); }

    public override string ToString()
    { return "Make: " + make + "\nModel: " + model + "\nYear: " + year + "\nVIN: " + vin + "\nOil Type: " + oilType + "\nOil Quantity: " + oilQuantity; }

    public void AddNote(DateOnly date, string description)
    { _notes.AddNote(date, description); }

    public void AddMaintenanceEvent(DateOnly date, string description, string partNumber)
    { _records.AddRecord(date, description, partNumber); }

    public void DisplayRecords()
    {
        Console.WriteLine(" Records:");
        _records.PrintRecords();
    }

    public void DisplayNotes()
    {
        Console.WriteLine(" Notes:");
        _notes.PrintNotes();
    }
}