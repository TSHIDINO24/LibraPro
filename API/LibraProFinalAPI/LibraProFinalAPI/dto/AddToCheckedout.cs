
namespace LibraProFinalAPI.dto
{
    public class AddToCheckedout
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

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;
    }
}
