using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SeedEquity.Services.Email
{
    public class SmtpEmailService : EmailService
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPassword { get; set; }

        public override void SendMail(System.Net.Mail.MailMessage msg)
        {
            using (SmtpClient client = new SmtpClient(SmtpServer, SmtpPort))
            {
                client.Credentials = new System.Net.NetworkCredential(SmtpUser, SmtpPassword);
                client.Send(msg);
            }
        }
    }
}
