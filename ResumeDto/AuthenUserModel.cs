using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeDto
{
    public class AuthenUserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string NotiToken { get; set; }
        public string Language { get; set; }
        public string BusinessId { get; set; }
        public string BearerToken { get; set; }
    }
}
