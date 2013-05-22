using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SeedEquity.Services.Email
{
    public class DebugEmailService : EmailService
    {
        public override void SendMail(MailMessage msg)
        {
            System.Diagnostics.Debug.WriteLine("From:{0}, To:{1}, Subject:{2}, Body:{3}", msg.To.ToString(), msg.From.ToString(), msg.Subject, msg.Body);
        }
    }
}
