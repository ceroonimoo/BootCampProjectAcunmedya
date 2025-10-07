using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses
{
    public class LoggedInUserResponse
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
