using System;

namespace Kamrad.NotificationService.Api
{
    class Program
    {
        private static NancySelfHost host = new NancySelfHost();

        static void Main(string[] args)
        {
            host.Start();

            Console.ReadKey();

            host.Stop();
        }
    }
}
