namespace LibraProFinalAPI.dto
{
    public class FineDto
    {
        public int FineId { get; set; }

        public decimal FineAmount { get; set; }

        public DateTime FineDate { get; set; }

        public string Status { get; set; } = null!;

        public int UserId { get; set; }

        public int CheckOutId { get; set; }
    }
}
