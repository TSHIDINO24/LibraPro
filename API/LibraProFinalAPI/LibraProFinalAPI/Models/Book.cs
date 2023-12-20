using System;
using System.Collections.Generic;

namespace LibraProFinalAPI.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string BookTitle { get; set; } = null!;

    public string BookAuthor { get; set; } = null!;

    public string BookStatus { get; set; } = null!;

    public int BookQuantity { get; set; }

    public string BookImage { get; set; } = null!;

    public string BookDescription { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual ICollection<Bag> Bags { get; set; } = new List<Bag>();

    public virtual Category Category { get; set; } = null!;
}
