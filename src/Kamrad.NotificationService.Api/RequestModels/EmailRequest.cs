namespace Kamrad.NotificationService.Api.RequestModels
{
    public class EmailRequest
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public EmailRequest()
        {
            
        }

        public EmailRequest(
            string @from,
            string to,
            string subject,
            string body
            )
        {
            From = @from;
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}