using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string BookName { get; set; } = null!;

    public string Author { get; set; } = null!;
}
