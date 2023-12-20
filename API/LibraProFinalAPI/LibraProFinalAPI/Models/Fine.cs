using System;
using System.Collections.Generic;

namespace LibraProFinalAPI.Models;

public partial class Fine
{
    public int FineId { get; set; }

    public decimal FineAmount { get; set; }

    public DateTime FineDate { get; set; }

    public int BorrowId { get; set; }

    public virtual Borrow Borrow { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
