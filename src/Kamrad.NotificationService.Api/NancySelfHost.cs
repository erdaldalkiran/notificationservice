using System;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Hosting.Self;

namespace Kamrad.NotificationService.Api
{
    public class NancySelfHost
    {
        private NancyHost nancyHost;

        public void Start()
        {
            INancyBootstrapper bootstrapper = new ApiBootstrapper();
            nancyHost = new NancyHost(
                bootstrapper,
                new HostConfiguration
                {
                    UrlReservations = new UrlReservations
                    {
                        CreateAutomatically = true
                    }
                },
                new Uri("http://localhost:7000"));
            nancyHost.Start();
        }

        public void Stop()
        {
            nancyHost.Stop();
        }
    }
}