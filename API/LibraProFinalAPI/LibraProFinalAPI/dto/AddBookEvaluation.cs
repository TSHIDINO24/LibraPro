namespace LibraProFinalAPI.dto
{
    public class AddBookEvaluation
    {
        public int BookId { get; set; }
        public string BookAuthor { get; set; } = null!;
        public string BookTitle { get; set; } = null!;
        public int ConditionId { get; set; }
        public string ConditionType { get; set; } = null!;
        public int UserId { get; set; }

    }
}
