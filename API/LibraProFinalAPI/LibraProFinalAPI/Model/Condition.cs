namespace LibraProFinalAPI.Model
{
    public class Condition
    {
       public  int ConditionId { get; set; }
        public string ConditionType { get; set; } = null!;

        public virtual ICollection<BookEvaluation> BookEvaluations { get; set; } = new List<BookEvaluation>();
        public virtual ICollection<BookCondition> BookConditions { get; set; } = new List<BookCondition>();


    }
}
