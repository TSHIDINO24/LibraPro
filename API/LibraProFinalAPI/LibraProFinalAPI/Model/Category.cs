using System;
using System.Collections.Generic;

namespace LibraProFinalAPI.Model;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();

    public virtual ICollection<Bag> Bags { get; set; } = new List<Bag>();
}
