namespace LibraProFinalAPI.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; } = null!;
        public List<Book> listofBooks { get; set; } = null!;
    }
}
