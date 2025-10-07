using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses
{
    public class CreatedApplicationResponse
    {
        public int Id { get; set; }
        public string BootcampName { get; set; }
        public string ApplicantName { get; set; }
        public ApplicationState ApplicationState { get; set; }
    }
}
