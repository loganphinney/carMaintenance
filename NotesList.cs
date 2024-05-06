namespace CarMaintenance;
public class NotesList
{
    private List<Note> _notes = new();

    public List<Note> Notes
    { get => _notes; set => _notes = value ?? throw new ArgumentNullException(nameof(value)); }

    public void AddNote(DateOnly date, string description)
    {
        _notes.Add(new Note(date, description));
        _notes.Sort();
    }
    
    public void PrintNotes()
    {
        foreach (var t in _notes)
            Console.WriteLine(t+"\n");
    }
}

public class Note(DateOnly date, string description) : IComparable<Note>
{
    private DateOnly _date = date;

    public DateOnly Date
    { get => _date; set => _date = value; }
    
    public string Description
    { get => description; set => description = value ?? throw new ArgumentNullException(nameof(value)); }
    
    public override string ToString()
    { return "  Date: " + _date + "\n  Description: " + description; }
    
    public int CompareTo(Note? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return _date.CompareTo(other._date);
    }
}