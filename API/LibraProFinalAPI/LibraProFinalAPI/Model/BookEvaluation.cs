namespace LibraProFinalAPI.Model
{
    public class BookEvaluation
    {
        public int BookEvaluationId { get; set; }

        public int BookId { get; set; }
        public string BookAuthor { get; set; } = null!;
        public string BookTitle { get; set; } = null!;
        public int ConditionId { get; set; }
        public string ConditionType { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime EvaluationDate { get; set; }   

        public int UserId { get; set; } 
        public virtual Condition Condition { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual Book Book { get; set; } = null!;


    }
}
