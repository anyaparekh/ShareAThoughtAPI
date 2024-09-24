using System;
using System.Collections.Generic;

namespace ShareAThought;

public partial class Note
{
    public int NoteId { get; set; }

    public int AuthorId { get; set; }

    public string Title { get; set; } = null!;

    public string Body { get; set; } = null!;

    public virtual Author Author { get; set; } = null!;
}
