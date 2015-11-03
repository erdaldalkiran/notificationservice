using System;

namespace Kamrad.NotificationService.Business.Ports.Aggregates
{
    public class Email
    {
        public Guid  Id { get; private set; }

        public string From { get; private set; }

        public string To { get; private set; }

        public string Subject { get; private set; }

        public string Body { get; private set; }

        public Email(
            Guid id,
            string @from,
            string to,
            string subject,
            string body)
        {
            Id = id;
            From = @from;
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}