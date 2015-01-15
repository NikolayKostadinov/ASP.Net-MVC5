namespace SportStore.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EmailSettings
    {
            public string MailToAddress = "Nikolay.Kostadinov@bmsys.eu";
            public string MailFromAddress = "sportsstore@bmsys.eu";
            public bool UseSsl = false;
            public string Username = "Nikolay.Kostadinov@bmsys.eu";
            public string Password = "Manhattan1";
            public string ServerName = "mail.bmsys.eu";
            public int ServerPort = 25;
            public bool WriteAsFile = false;
            public string FileLocation = @"d:\temp\sports_store_emails";
    }
}
