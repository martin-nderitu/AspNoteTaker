namespace NoteTaker.Models;

public class NoteViewModel
{
    public Note? Note { get; set; }
    public string Action { get; set; } = "Note Details";
    public bool HasDeleteButton { get; set; }
}

