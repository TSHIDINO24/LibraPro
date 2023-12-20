namespace LibraProFinalAPI.dto
{
    public class AddBookdto
    {
        public string BookTitle { get; set; } = null!;

        public string BookAuthor { get; set; } = null!;

        public string BookDescription { get; set; } = null!;

        public int BookQuantity { get; set; }

        public string BookImage { get; set; } = null!;

        public string ISBN { get; set; } = null!;

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

    }
}
