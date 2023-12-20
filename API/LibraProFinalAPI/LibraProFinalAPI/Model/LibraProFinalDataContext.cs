using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibraProFinalAPI.Model;

public partial class LibraProFinalDataContext : DbContext
{
    public LibraProFinalDataContext()
    {
    }

    public LibraProFinalDataContext(DbContextOptions<LibraProFinalDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bag> Bags { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Borrow> Borrows { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Checkout> Checkouts { get; set; }

    public virtual DbSet<Fine> Fines { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Condition> Conditions { get; set; }

    public virtual DbSet<BookCondition> BookConditions { get; set; }

    public virtual DbSet<BookEvaluation> BookEvaluations { get; set; }

    public virtual DbSet<DamagedBook> DamagedBooks { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=TSHIDINO-MOKONO\\SQLEXPRESS; Database=LibraProFinalData;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bag>(entity =>
        {
            entity.ToTable("Bag");

            entity.Property(e => e.BagId).HasColumnName("Bag_ID");
            entity.Property(e => e.BookAuthor).IsUnicode(false);
            entity.Property(e => e.BookId).HasColumnName("Book_ID");
            entity.Property(e => e.BookImage).IsUnicode(false);
            entity.Property(e => e.BookTitle).IsUnicode(false);
            entity.Property(e => e.Status).IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.CategoryName).HasColumnName("Category_Name");

            entity.HasOne(d => d.Book).WithMany(p => p.Bags)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bag_Book");

            entity.HasOne(d => d.User).WithMany(p => p.Bags)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bag_User");

            
            entity.HasOne(d => d.Category).WithMany(p => p.Bags)
               .HasForeignKey(d => d.CategoryId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Book_Category");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");

            entity.Property(e => e.BookId).HasColumnName("Book_ID");
            entity.Property(e => e.BookAuthor)
                .IsUnicode(false)
                .HasColumnName("Book_Author");
            entity.Property(e => e.BookDescription)
                .IsUnicode(false)
                .HasColumnName("Book_Description");
            entity.Property(e => e.BookImage)
                .IsUnicode(false)
                .HasColumnName("Book_Image");
            entity.Property(e => e.BookQuantity).HasColumnName("Book_Quantity");
            entity.Property(e => e.BookStatus)
                .IsUnicode(false)
                .HasColumnName("Book_Status");
            entity.Property(e => e.BookTitle)
                .IsUnicode(false)
                .HasColumnName("Book_Title");
            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.CategoryName).HasColumnName("Category_Name");

            entity.Property(e => e.Isbn)
                .HasMaxLength(13)
                .IsFixedLength()
                .HasColumnName("ISBN");

            entity.HasOne(d => d.Category).WithMany(p => p.Books)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book_Category");
        });

               modelBuilder.Entity<BookCondition>(entity =>
        {
            entity.ToTable("BookCondition");
            entity.Property(e => e.BookConditionId).HasColumnName("BookCondition_ID");
            entity.HasKey(e => e.BookConditionId);

            entity.Property(e => e.ConditionId).HasColumnName("Condition_ID");
            entity.Property(e => e.ConditionType)
          .IsUnicode(false)
          .HasColumnName("Condition_Type");
            entity.Property(e => e.ConditionDescription)
              .IsUnicode(false)
              .HasColumnName("Condition_Description");

            entity.HasOne(d => d.Condition).WithMany(p => p.BookConditions)
            .HasForeignKey(d => d.ConditionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookCondition_Condition");

        });

             modelBuilder.Entity<BookEvaluation>(entity =>
        {
            entity.ToTable("BookEvaluation");

            entity.Property(e => e.BookEvaluationId).HasColumnName("BookEvaluation_ID");
            entity.HasKey(e => e.BookEvaluationId);

            entity.Property(e => e.ConditionId).HasColumnName("Condition_ID");
            entity.Property(e => e.ConditionType)
          .IsUnicode(false)
          .HasColumnName("Condition_Type");
            entity.Property(e => e.BookId)
                .IsUnicode(false)
                .HasColumnName("Book_ID");
            entity.Property(e => e.BookAuthor)
                .IsUnicode(false)
                .HasColumnName("Book_Author");
            entity.Property(e => e.BookTitle)
                .IsUnicode(false)
                .HasColumnName("Book_Title");

            entity.Property(e => e.Status)
              .IsUnicode(false)
              .HasColumnName("Status");

            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.EvaluationDate).HasColumnName("Evaluation_Date");


            entity.HasOne(d => d.Condition).WithMany(p => p.BookEvaluations)            
            .HasForeignKey(d => d.ConditionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookEvaluation_Condition");

            entity.HasOne(d => d.Book).WithMany(p => p.BookEvaluations)
              .HasForeignKey(d => d.BookId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_BookEvaluation_Book");

            entity.HasOne(d => d.User).WithMany(p => p.BookEvaluations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookEvaluation_User");

        });


        modelBuilder.Entity<Borrow>(entity =>
        {
            entity.ToTable("Borrow");

            entity.Property(e => e.BorrowId).HasColumnName("Borrow_ID");
            entity.Property(e => e.BagId).HasColumnName("Bag_ID");
            entity.Property(e => e.BookAuthor).IsUnicode(false);
            entity.Property(e => e.BookId).HasColumnName("Book_ID");
            entity.Property(e => e.BookImage).IsUnicode(false);
            entity.Property(e => e.BookTitle).IsUnicode(false);
            entity.Property(e => e.BorrowCode)
                .IsUnicode(false)
                .HasColumnName("Borrow_Code");
            entity.Property(e => e.BorrowDate)
                .HasColumnType("datetime")
                .HasColumnName("Borrow_Date");
            entity.Property(e => e.BorrowReturnedDate)
                .HasColumnType("datetime")
                .HasColumnName("Borrow_ReturnedDate");
            entity.Property(e => e.Status).IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.CategoryName).HasColumnName("Category_Name");

            entity.HasOne(d => d.Bag).WithMany(p => p.Borrows)
                .HasForeignKey(d => d.BagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Borrow_Bag");

            entity.HasOne(d => d.Book).WithMany(p => p.Borrows)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Borrow_Book");

            entity.HasOne(d => d.User).WithMany(p => p.Borrows)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Borrow_User");

             entity.HasOne(d => d.Category).WithMany(p => p.Borrows)
               .HasForeignKey(d => d.CategoryId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Book_Category");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.CategoryName)
                .IsUnicode(false)
                .HasColumnName("Category_Name");
        });

        modelBuilder.Entity<Condition>(entity =>
        {
            entity.ToTable("Condition");   

            entity.Property(e => e.ConditionId).HasColumnName("Condition_ID");
            entity.HasKey(e => e.ConditionId);

            entity.Property(e => e.ConditionType)
                .IsUnicode(false)
                .HasColumnName("Condition_Type");
        });

        modelBuilder.Entity<Checkout>(entity =>
        {
            entity.ToTable("Checkout");

            entity.Property(e => e.CheckOutId).HasColumnName("CheckOut_ID");
            entity.Property(e => e.BookAuthor)
                .IsUnicode(false)
                .HasColumnName("Book_Author");
            entity.Property(e => e.BookId).HasColumnName("Book_ID");
            entity.Property(e => e.BookImage)
                .IsUnicode(false)
                .HasColumnName("Book_Image");
            entity.Property(e => e.BookTitle)
                .IsUnicode(false)
                .HasColumnName("Book_Title");
            entity.Property(e => e.BorrowCode)
                .IsUnicode(false)
                .HasColumnName("Borrow_Code");
            entity.Property(e => e.BorrowDate)
                 .HasColumnType("datetime")
                 .HasColumnName("Borrow_Date");
            entity.Property(e => e.BorrowId).HasColumnName("Borrow_ID");
            entity.Property(e => e.BorrowReturnedDate)
               .HasColumnType("datetime")
               .HasColumnName("Borrow_ReturnedDate");
            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.CategoryName).HasColumnName("Category_Name");

            entity.HasOne(d => d.Book).WithMany(p => p.Checkouts)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Checkout_Book");

            entity.HasOne(d => d.Borrow).WithMany(p => p.Checkouts)
                .HasForeignKey(d => d.BorrowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Checkout_Borrow");

            entity.HasOne(d => d.User).WithMany(p => p.Checkouts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Checkout_User");

           
        });

        modelBuilder.Entity<DamagedBook>(entity =>
        {
            entity.ToTable("DamagedBook");

            entity.Property(e => e.DamagedBookId).HasColumnName("DamagedBook_ID");
            entity.HasKey(e => e.DamagedBookId);

            entity.Property(e => e.BookId).HasColumnName("Book_ID");

            entity.Property(e => e.BookAuthor)
                .IsUnicode(false)
                .HasColumnName("Book_Author");

            entity.Property(e => e.BookTitle)
                .IsUnicode(false)
                .HasColumnName("Book_Title");


            entity.Property(e => e.Status)
                .IsUnicode(false)
                .HasColumnName("Status");


            entity.Property(e => e.DamageType)
                .IsUnicode(false)
                .HasColumnName("DamageType");


            entity.Property(e => e.RepairPrice)
                 .HasColumnType("money")
                .HasColumnName("RepairPrice");


            entity.Property(e => e.ReplacePrice)
                 .HasColumnType("money")
                .HasColumnName("ReplacePrice");

            entity.Property(e => e.EvaluationDate).HasColumnName("EvaluationDate");

            entity.HasOne(d => d.Book).WithMany(p => p.DamagedBooks)
              .HasForeignKey(d => d.BookId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_DamagedBook_Book");

        });

        modelBuilder.Entity<Fine>(entity =>
        {
            entity.ToTable("Fine");

            entity.Property(e => e.FineId).HasColumnName("Fine_ID");
            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.FineAmount)
                .HasColumnType("money")
                .HasColumnName("Fine_Amount");
            entity.Property(e => e.FineDate)
                .HasColumnType("datetime")
                .HasColumnName("Fine_Date");

            entity.HasOne(d => d.user).WithMany(p => p.Fines)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fine_User");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification");

            entity.Property(e => e.NotificationId).HasColumnName("Notification_ID");
            entity.Property(e => e.NotificationDate)
                .HasColumnType("datetime")
                .HasColumnName("Notification_Date");
            entity.Property(e => e.NotificationDetails)
                .IsUnicode(false)
                .HasColumnName("Notification_Details");
            entity.Property(e => e.NotificationTitle)
                .IsUnicode(false)
                .HasColumnName("Notification_Title");
            entity.Property(e => e.Status)
               .IsUnicode(false)
               .HasColumnName("Status");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notification_User");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable("Transaction");

            entity.Property(e => e.TransactionId).HasColumnName("Transaction_ID");
            entity.Property(e => e.FineId).HasColumnName("FIne_ID");
            entity.Property(e => e.TransactionDate)
                .HasColumnType("datetime")
                .HasColumnName("Transaction_Date");
            entity.Property(e => e.TransactionStatus)
                .IsUnicode(false)
                .HasColumnName("Transaction_Status");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.Fine).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.FineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaction_Fine");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaction_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.UserAddress)
                .IsUnicode(false)
                .HasColumnName("User_Address");
            entity.Property(e => e.UserCreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("User_CreatedDate");
            entity.Property(e => e.UserEmail)
                .IsUnicode(false)
                .HasColumnName("User_Email");
            entity.Property(e => e.UserIdnumber)
                .HasMaxLength(13)
                .IsFixedLength()
                .HasColumnName("User_IDNumber");
            entity.Property(e => e.UserName)
                .IsUnicode(false)
                .HasColumnName("User_Name");
            entity.Property(e => e.UserPassword)
                .IsUnicode(false)
                .HasColumnName("User_Password");
            entity.Property(e => e.UserPhone)
                .IsUnicode(false)
                .HasColumnName("User_Phone");
            entity.Property(e => e.UserStatus)
                .IsUnicode(false)
                .HasColumnName("User_Status");
            entity.Property(e => e.UserSurname)
                .IsUnicode(false)
                .HasColumnName("User_Surname");
            entity.Property(e => e.UserType)
                .IsUnicode(false)
                .HasColumnName("User_Type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
