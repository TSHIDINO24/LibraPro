using System;
using System.Collections.Generic;

namespace LibraProFinalAPI.Models;

public partial class Borrow
{
    public int BorrowId { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime BorrowReturnedDate { get; set; }

    public string BorrowCode { get; set; } = null!;

    public int UserId { get; set; }

    public string BookTitle { get; set; } = null!;

    public string BookAuthor { get; set; } = null!;

    public string BookImage { get; set; } = null!;

    public int BagId { get; set; }

    public virtual Bag Bag { get; set; } = null!;

    public virtual ICollection<Fine> Fines { get; set; } = new List<Fine>();

    public virtual User User { get; set; } = null!;
}
