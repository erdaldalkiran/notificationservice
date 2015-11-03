using System;
using Kamrad.NotificationService.Business.Ports.Aggregates;
using paramore.brighter.commandprocessor;

namespace Kamrad.NotificationService.Business.Ports.Commands
{
    public class CreateAnEmailCommand : IRequest
    {
        public Guid Id { get; set; }

        public Email Email { get; private set; }

        public CreateAnEmailCommand(Email email)
        {
            Id = Guid.NewGuid();
            Email = email;
        }
    }
}