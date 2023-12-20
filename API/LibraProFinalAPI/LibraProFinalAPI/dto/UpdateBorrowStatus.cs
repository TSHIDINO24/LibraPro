namespace LibraProFinalAPI.dto
{
    public class UpdateBorrowStatus
    {
        public int BorrowId { get; set; }

        public string Status { get; set; } = null!;
    }
}
