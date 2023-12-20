using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraProFinalAPI.Model
{
    public class DamagedBook
    {
        public int DamagedBookId { get; set; }

        public int BookId { get; set; }

        public string BookTitle { get; set; } = null!;
        
        public string BookAuthor { get; set; } = null!;

        public string Status { get; set; } = null!;

        public string DamageType { get; set; } = null!;

        public decimal RepairPrice { get; set; }

        public decimal ReplacePrice { get; set; }

        public DateTime EvaluationDate { get; set; }

        public virtual Book Book { get; set; } = null!;
    }
}