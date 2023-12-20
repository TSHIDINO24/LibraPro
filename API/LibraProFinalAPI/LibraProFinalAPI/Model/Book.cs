using System;
using System.Collections.Generic;

namespace LibraProFinalAPI.Model;

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
    public string CategoryName { get; set; } = null!;


    public string Isbn { get; set; } = null!;

    public virtual ICollection<Bag> Bags { get; set; } = new List<Bag>();

    public virtual ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();

    public virtual Category Category { get; set; } = null!;
  public virtual ICollection<BookEvaluation> BookEvaluations { get; set; } = new List<BookEvaluation>();
    public virtual ICollection<DamagedBook> DamagedBooks { get; set; } = new List<DamagedBook>();

    public virtual ICollection<Checkout> Checkouts { get; set; } = new List<Checkout>();
}
