using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Mail;
using CLPClasses;

namespace CLPActions
{
    public class EmailAction // : IAction
    {
        private MailMessage _mail;
        private readonly SmtpClient _client = new SmtpClient();
        private readonly string _mailFrom = "EDIRulesEngine@xpo.com"; //"noreply@xpo.com"

        public string MailTo { get; set; }
        public string MailBody { get; set; }
        public string MailSubject { get; set; }

        public void Map(ExpandoObject propertyObject)
        {
            PropertyUtils.MapProperties(propertyObject, this);
        }

        public void Execute()
        {
            SetupEmail();
            _client.Send(_mail);
        }

        public void Execute(IDictionary<string, object> src, ref List<ExpandoObject> dest)
        {
            throw new NotImplementedException();
        }

        public void SetupEmail()
        {
            _client.Port = 25;
            _client.DeliveryMethod = SmtpDeliveryMethod.Network;
            _client.UseDefaultCredentials = false;
            _client.Host = "xpoemail2.xpo.pvt";
            if (string.IsNullOrWhiteSpace(MailTo))
                MailTo = "Christopher.Pelphrey@xpo.com";
            _mail = new MailMessage(_mailFrom, MailTo);
            if (string.IsNullOrWhiteSpace(MailSubject))
                _mail.Subject = "this is a test email.";
            else
                _mail.Subject = MailSubject;
            if (string.IsNullOrWhiteSpace(MailBody))
                _mail.Body = "this is my test email body";
            else
                _mail.Body = MailBody;
            _mail.Body += "\nDo not reply to this email. This is an automated email and the inbox is not monitored.";
        }
    }
}