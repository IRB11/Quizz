﻿namespace Quizz.Common.Configuration
{
    public class MailConfiguration
    {
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SiteUrl { get; set; }

    }
}
