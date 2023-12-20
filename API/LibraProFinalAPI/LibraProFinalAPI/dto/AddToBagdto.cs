namespace LibraProFinalAPI.dto
{
    public class AddToBagdto
    {

        public string BookAuthor { get; set; } = null!;

        public string BookImage { get; set; } = null!;

        public string BookTitle { get; set; } = null!;

        public int BookId { get; set; }

        public int BookQuantity { get; set; }
        
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

    }
}
