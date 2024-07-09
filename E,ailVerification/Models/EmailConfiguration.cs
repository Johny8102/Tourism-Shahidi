using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailVerification.Models
{
    public class EmailConfiguration
    {
        public string From { set; get; } 
        public string SmtpServer { set; get; }
        public int Port { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }

    }
}
