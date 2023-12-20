namespace LibraProFinalAPI.dto
{
    public class SendNotification
    {
        public string NotificationDetails { get; set; } = null!;

        public DateTime NotificationDate { get; set; }

        public int UserId { get; set; }
    }
}
