using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests
{
    public class UpdateApplicationRequest
    {
        public int Id { get; set; }
        public ApplicationState ApplicationState { get; set; }
    }
}
