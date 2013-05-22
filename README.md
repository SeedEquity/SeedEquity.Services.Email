SeedEquity.Services.Email
============

A DI oriented utility lib to switch between a debug email service and SMTP Email service

The idea here is that in dev environments, you can dump emails to the debug console.  This is nicer than the "pickup directory" option in web.config which takes you out of VS.


In Production, you would use System.Net web.config

Also, a Ninject Binding exists:

        private static void RegisterServices(IKernel kernel)
        {

          #if DEBUG
                      kernel.Load(EmailModule.DebugService());
          #else
          
                      kernel.Load(EmailModule.SmtpService());
          #endif 
        }

##Nuget

`Install-Package SeedEquity.Services.Email.Ninject`
