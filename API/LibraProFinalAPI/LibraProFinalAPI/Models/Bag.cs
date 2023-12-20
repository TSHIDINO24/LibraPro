using System;
using System.Collections.Generic;

namespace LibraProFinalAPI.Models;

public partial class Bag
{
    public int BagId { get; set; }

    public int BookId { get; set; }

    public int UserId { get; set; }

    public string BookTitle { get; set; } = null!;

    public string BookAuthor { get; set; } = null!;

    public string BookImage { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;

    public virtual ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();

    public virtual User User { get; set; } = null!;

}
