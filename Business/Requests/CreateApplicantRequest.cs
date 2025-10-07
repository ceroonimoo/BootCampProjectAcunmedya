namespace Business.Requests
{
    public class CreateApplicantRequest
    {
        public int StudentId { get; set; }
        public string NationalityIdentity { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool Status {  get; set; }
    }
}
