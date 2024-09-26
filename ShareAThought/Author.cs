using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ShareAThought;

public partial class Author
{
    public int AuthorId { get; set; }
    [MaxLength(50)]
    public string? Username { get; set; }
    [MaxLength(255)]
    public string? Password { get; set; }
}
