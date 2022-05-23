using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NoteTaker.Models;

public class Note : BaseEntity
{
    public Guid NoteId { get; set; }
    
    [Required(ErrorMessage = "Please enter a note title")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Note title must contain 3-50 characters")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Please enter the note body")]
    [StringLength(250, MinimumLength = 5, ErrorMessage = "Note body must contain 5-250 characters")]
    public string Body { get; set; } = string.Empty;
}