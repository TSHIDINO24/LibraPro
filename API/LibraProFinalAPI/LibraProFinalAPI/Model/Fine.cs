using System;
using System.Collections.Generic;

namespace LibraProFinalAPI.Model;

public partial class Fine
{
    public int FineId { get; set; }

    public decimal FineAmount { get; set; }

    public DateTime FineDate { get; set; }

    public string Status { get; set; } = null!;

    public int UserId { get; set; }

    public int CheckOutId { get; set; }

    public virtual User user { get; set; } = null!;
    public virtual Checkout Checkout { get; set; } = null!;
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

}
