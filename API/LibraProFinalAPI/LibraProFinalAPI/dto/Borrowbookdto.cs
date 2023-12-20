namespace LibraProFinalAPI.dto
{
    public class Borrowbookdto
    {

        //public DateTime BorrowDate { get; set; }

        //public DateTime BorrowReturnedDate { get; set; }

        //public string BorrowCode { get; set; } = null!;

        //public int UserId { get; set; }

        public string BookTitle { get; set; } = null!;

        public string BookAuthor { get; set; } = null!;

        public string BookImage { get; set; } = null!;

        public int BagId { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

    }
}
