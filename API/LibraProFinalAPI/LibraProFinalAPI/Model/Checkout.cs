using System;
using System.Collections.Generic;

namespace LibraProFinalAPI.Model;

public partial class Checkout
{
    public int CheckOutId { get; set; }

    public int UserId { get; set; }

    public int BookId { get; set; }

    public int BorrowId { get; set; }

    public string BorrowCode { get; set; } = null!;

    public DateTime BorrowDate { get; set; }

    public DateTime BorrowReturnedDate { get; set; }

    public string BookTitle { get; set; } = null!;

    public string BookImage { get; set; } = null!;

    public string BookAuthor { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;

    public virtual Borrow Borrow { get; set; } = null!;
    
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Fine> Fines { get; set; } = new List<Fine>();

    public virtual User User { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
}
