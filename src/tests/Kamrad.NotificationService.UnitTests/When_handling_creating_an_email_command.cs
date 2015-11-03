using System;
using Kamrad.NotificationService.Business.Ports.Aggregates;
using Kamrad.NotificationService.Business.Ports.Commands;
using Kamrad.NotificationService.Business.Ports.Handlers;
using Kamrad.NotificationService.Business.Ports.Persistance;
using Moq;
using NUnit.Framework;
using paramore.brighter.commandprocessor.Logging;

namespace Kamrad.NotificationService.UnitTests
{
    [TestFixture]
    public class When_handling_creating_an_email_command
    {
        [Test]
        public void should_add_email_to_repository()
        {
            var command = new CreateAnEmailCommand(
                email: new Email(
                    id: Guid.NewGuid(),
                    @from: "hede@hede.com",
                    to: "test@gmail.com",
                    subject: "subject",
                    body: "body"));

            var logger = new Mock<ILog>();
            var repository = new Mock<IRepository<Email>>();

            var handler = new CreateAnEmailCommandHandler(
                repository.Object,
                logger.Object);
            handler.Handle(command);

            repository.Verify(repo =>
            repo.Add(
                It.Is<Email>(
                    email =>
                        email.Id == command.Email.Id
                        && email.From == command.Email.From
                        && email.To == command.Email.To
                        && email.Subject == command.Email.Subject
                        && email.Body == command.Email.Body
                    )));
        }
    }
}