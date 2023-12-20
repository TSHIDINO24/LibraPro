using System;
using System.Collections.Generic;

namespace LibraProFinalAPI.Model;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public DateTime TransactionDate { get; set; }

    public string TransactionStatus { get; set; } = null!;

    public int FineId { get; set; }

    public int UserId { get; set; }

    public virtual Fine Fine { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
