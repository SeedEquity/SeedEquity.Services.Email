using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace SeedEquity.Services.Email.Ninject
{
    public class EmailModule : NinjectModule
    {
        public bool IsDebug { get; set; }

        public string Server { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public static EmailModule SmtpService()
        {
            var section = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;
            var host = section.Network.Host;
            return SmtpService(section.Network.Host, section.Network.Port, section.Network.UserName, section.Network.Password);
        }

        public static EmailModule SmtpService(string server, int port, string user, string password)
        {
            return new EmailModule { Server = server, Port = port, User = user, Password = password };
        }

        public static EmailModule DebugService()
        {
            return new EmailModule { IsDebug = true };
        }

        public override void Load()
        {
            if (IsDebug)
                Bind<EmailService>().To<DebugEmailService>();
            else
                Bind<EmailService>().To<SmtpEmailService>()
                    .WithPropertyValue("SmtpServer", this.Server)
                    .WithPropertyValue("SmtpPort", this.Port)
                    .WithPropertyValue("SmtpUser", this.User)
                    .WithPropertyValue("SmtpPassword", this.Password);
        }
    }
}
