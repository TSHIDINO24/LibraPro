namespace LibraProFinalAPI.Model
{
    public class BookCondition
    {
        public int BookConditionId { get; set; }
        public int ConditionId { get; set; }
        public string ConditionType { get; set; } = null!;
        public string ConditionDescription { get; set; } = null!;
        public virtual Condition Condition { get; set; } = null!;


    }
}
