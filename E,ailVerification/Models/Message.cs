using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailVerification.Models
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { set; get; }
        public string Content { set; get; }
        public Message(IEnumerable<string> to , string subject, string content) 
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(i=> new MailboxAddress("email" , i)));
            Subject = subject;
            Content = content;
        }



    }
}
