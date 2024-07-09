using EmailVerification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailVerification.Services
{
    public interface IEmailServices
    {
        void SendEmail(Message message);
    }
}
