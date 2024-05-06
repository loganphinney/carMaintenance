namespace CarMaintenance;
public class MaintenanceList
{
    private List<MaintenanceEvent> _records = new();

    public List<MaintenanceEvent> Records
    { get => _records; set => _records = value ?? throw new ArgumentNullException(nameof(value)); }

    public void AddRecord(DateOnly date, string description, string partNumber)
    {
        _records.Add(new MaintenanceEvent(date, description, partNumber));
        _records.Sort();
    }
    
    public void PrintRecords()
    {
        foreach (var t in _records)
            Console.WriteLine(t+"\n");
    }
}

public class MaintenanceEvent(DateOnly date, string description, string partNumber) : IComparable<MaintenanceEvent>
{
    private DateOnly _date = date;

    public DateOnly Date
    { get => _date; set => _date = value; }

    public string Description
    { get => description; set => description = value ?? throw new ArgumentNullException(nameof(value)); }

    public string PartNumber
    { get => partNumber; set => partNumber = value ?? throw new ArgumentNullException(nameof(value)); }
    
    public override string ToString()
    { return "  Date: " + _date + "\n  Description: " + description + "\n  Part: " + partNumber; }

    public int CompareTo(MaintenanceEvent? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return _date.CompareTo(other._date);
    }
}