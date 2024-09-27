using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShareAThought;

public partial class Note
{
    public int NoteId { get; set; }
    [MaxLength(255)]
    public string? Title { get; set; }
    [MaxLength(255)]
    public string? Body { get; set; }
}
