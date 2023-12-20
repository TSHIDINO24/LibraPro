namespace LibraProFinalAPI.dto
{
    public class Bookupdatedto
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; } = null!;

        public string BookAuthor { get; set; } = null!;

        public string BookDescription { get; set; } = null!;

        public string BookStatus { get; set; } = null!;

        public int BookQuantity { get; set; }

    }
}
