namespace Business.Responses
{
    public class BlacklistResponse
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public string Reason { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
