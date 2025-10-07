namespace Business.Requests
{
    public class CreateBlacklistRequest
    {
        public int ApplicantId { get; set; }
        public string Reason { get; set; }
    }
}
