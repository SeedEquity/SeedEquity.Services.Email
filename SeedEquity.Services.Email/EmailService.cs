using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SeedEquity.Services.Email
{
    public abstract class EmailService
    {
        public abstract void SendMail(MailMessage msg);
    }

}
