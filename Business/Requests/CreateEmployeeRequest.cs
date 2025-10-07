using System;

namespace Business.Requests
{
    public class CreateEmployeeRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalityIdentity { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string Password { get; set; } 
    }
}
