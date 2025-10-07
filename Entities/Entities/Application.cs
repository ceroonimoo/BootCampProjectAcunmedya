using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        public int BootcampId { get; set; }
        public Bootcamp Bootcamp { get; set; }
        public ApplicationState ApplicationState { get; set; }
    }
}
