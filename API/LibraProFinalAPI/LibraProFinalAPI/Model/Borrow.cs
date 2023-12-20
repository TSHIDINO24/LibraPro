using System;
using System.Collections.Generic;

namespace LibraProFinalAPI.Model;

public partial class Borrow
{
    public int BorrowId { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime BorrowReturnedDate { get; set; }

    public string BorrowCode { get; set; } = null!;

    public int UserId { get; set; }

    public int BookId { get; set; }

    public string BookTitle { get; set; } = null!;

    public string BookAuthor { get; set; } = null!;

    public string BookImage { get; set; } = null!;

    public int BagId { get; set; }

    public string Status { get; set; } = null!;

    public virtual Bag Bag { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;
    
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Checkout> Checkouts { get; set; } = new List<Checkout>();

    public virtual User User { get; set; } = null!;
    public virtual Category Category { get; set; } = null!;
}
