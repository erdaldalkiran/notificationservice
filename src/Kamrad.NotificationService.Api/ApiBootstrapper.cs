using System;
using Autofac;
using Common.Logging;
using Kamrad.NotificationService.Business.Ports.Commands;
using Kamrad.NotificationService.Business.Ports.Handlers;
using Kamrad.NotificationService.Business.Ports.Persistance;
using Nancy.Bootstrappers.Autofac;
using paramore.brighter.commandprocessor;
using ILog = paramore.brighter.commandprocessor.Logging.ILog;

namespace Kamrad.NotificationService.Api
{
    public class ApiBootstrapper : AutofacNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
        {
            base.ConfigureApplicationContainer(existingContainer);

            RegisterLoggers(existingContainer);
            RegisterCommandProcessor(existingContainer);
            RegisterRepossitories(existingContainer);
        }

        private void RegisterLoggers(ILifetimeScope container)
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(LogManager.GetLogger<Program>()).As<Common.Logging.ILog>();

            builder.RegisterType<ParamoreLogger>()
                .AsImplementedInterfaces();

            builder.Update(container.ComponentRegistry);
        }

        private void RegisterCommandProcessor(ILifetimeScope container)
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterType<CreateAnEmailCommandHandler>()
                .AsSelf();


            IAmASubscriberRegistry subscriberRegistry = new SubscriberRegistry();
            subscriberRegistry.Register<CreateAnEmailCommand, CreateAnEmailCommandHandler>();

            IAmAHandlerFactory handlerFactory = new InMemoryHandlerFactory(container);
            var handlerConfiguration = new HandlerConfiguration(subscriberRegistry, handlerFactory);
            IAmARequestContextFactory requestContextFactory = new InMemoryRequestContextFactory();

            var commnadProcessor = CommandProcessorBuilder
                .With()
                .Handlers(handlerConfiguration)
                .DefaultPolicy()
                .Logger(container.Resolve<ILog>())
                .NoTaskQueues()
                .RequestContextFactory(requestContextFactory)
                .Build();

            builder.Register(context => commnadProcessor)
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.Update(container.ComponentRegistry);
        }

        private void RegisterRepossitories(ILifetimeScope container)
        {
            var builder = new ContainerBuilder();

            builder.RegisterGeneric(typeof (Repository<>))
                .AsImplementedInterfaces();

            builder.Update(container.ComponentRegistry);
        }
    }

    internal class Repository<T> : IRepository<T>
    {
        public void Add(T aggregate)
        {
        }
    }

    public class InMemoryHandlerFactory : IAmAHandlerFactory
    {
        private readonly IComponentContext context;

        public InMemoryHandlerFactory(IComponentContext context)
        {
            this.context = context;
        }

        public IHandleRequests Create(Type handlerType)
        {
            return context.Resolve(handlerType) as IHandleRequests;
        }

        public void Release(IHandleRequests handler)
        {
        }
    }
}