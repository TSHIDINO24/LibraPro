using System;
using System.Collections.Generic;

namespace LibraProFinalAPI.Model;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserSurname { get; set; } = null!;

    public string UserIdnumber { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserAddress { get; set; } = null!;

    public string UserPhone { get; set; } = null!;

    public string UserType { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string UserStatus { get; set; } = null!;

    public DateTime UserCreatedDate { get; set; }

    public virtual ICollection<Bag> Bags { get; set; } = new List<Bag>();

    public virtual ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();

    public virtual ICollection<Checkout> Checkouts { get; set; } = new List<Checkout>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual ICollection<Fine> Fines { get; set; } = new List<Fine>();

    public virtual ICollection<BookEvaluation> BookEvaluations { get; set; } = new List<BookEvaluation>();
}
