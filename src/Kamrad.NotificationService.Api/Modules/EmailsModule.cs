using System;
using Kamrad.NotificationService.Api.RequestModels;
using Kamrad.NotificationService.Business.Ports.Aggregates;
using Kamrad.NotificationService.Business.Ports.Commands;
using Nancy;
using Nancy.ModelBinding;
using paramore.brighter.commandprocessor;

namespace Kamrad.NotificationService.Api.Modules
{
    public class EmailsModule : NancyModule
    {
        public EmailsModule(IAmACommandProcessor commandProcessor) : base("/emails")
        {
            Post["/"] = _ =>
            {
                var request = this.Bind<EmailRequest>();

                commandProcessor.Send( new CreateAnEmailCommand(
                    email: new Email(
                        id: Guid.NewGuid(),
                        from: request.From,
                        to: request.To,
                        subject: request.Subject,
                        body: request.Body)));
                return HttpStatusCode.OK;
            };
        }
    }
}