using Kamrad.NotificationService.Business.Ports.Aggregates;
using Kamrad.NotificationService.Business.Ports.Commands;
using Kamrad.NotificationService.Business.Ports.Persistance;
using paramore.brighter.commandprocessor;
using paramore.brighter.commandprocessor.Logging;

namespace Kamrad.NotificationService.Business.Ports.Handlers
{
    public class CreateAnEmailCommandHandler : RequestHandler<CreateAnEmailCommand>
    {
        private readonly IRepository<Email> repository;

        public CreateAnEmailCommandHandler(
            IRepository<Email> repository,
            ILog logger)
            : base(logger)
        {
            this.repository = repository;
        }


        public override CreateAnEmailCommand Handle(CreateAnEmailCommand command)
        {
            repository.Add(command.Email);
            return base.Handle(command);
        }
    }
}