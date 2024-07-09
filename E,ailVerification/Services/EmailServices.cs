using EmailVerification.Models;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailVerification.Services
{
    public class EmailServices:IEmailServices
    {
        private readonly EmailConfiguration _emailConfiguration;
        public EmailServices(EmailConfiguration emailConfiguration) => _emailConfiguration = emailConfiguration;


        public void SendEmail(Message message) 
        {
            var emailmess = CreateEmailMessage(message);
            Send(emailmess);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfiguration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }

        private void Send(MimeMessage mailmessage)
        {
            //using (var client = new MailKit.Net.Smtp.SmtpClient())
            //{
            //    client.Connect("smtp.mailserver.com", 587, false); // You need to specify the SMTP server and port here
            //    client.Authenticate("username", "password"); // If your SMTP server requires authentication
            //    client.Send(message);
            //    client.Disconnect(true);
            //}

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfiguration.UserName , _emailConfiguration.Password);

                    client.Send(mailmessage);
                }
                catch (Exception ex)
                {
                    //_logger.Information(JsonConvert.SerializeObject(ex));
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }



        }


    }
}
