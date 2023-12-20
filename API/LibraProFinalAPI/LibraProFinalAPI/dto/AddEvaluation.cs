namespace LibraProFinalAPI.dto
{
    public class AddEvaluation
    {
        public int DamagedBookId { get; set; }

        public int BookId { get; set; }

        public string BookTitle { get; set; } = null!;

        public string BookAuthor { get; set; } = null!;

        public string Status { get; set; } = null!;

        public string DamageType { get; set; } = null!;

        public decimal RepairPrice { get; set; }

        public decimal ReplacePrice { get; set; }

    }
}
