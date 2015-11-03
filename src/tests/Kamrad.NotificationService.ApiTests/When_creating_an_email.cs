using System;
using System.Net;
using System.Net.Http;
using System.Text;
using FluentAssertions;
using Kamrad.NotificationService.Api.RequestModels;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Kamrad.NotificationService.ApiTests
{
    [TestFixture]
    public class When_creating_an_email
    {
        [Test]
        public void status_code_should_be_Created()
        {
            var emailRequest = new EmailRequest(
                @from: "hede@hede.com",
                to: "test@gmail.com",
                subject: "subject",
                body: "body"
                );

            using (var client = new HttpClient())
            {
                var result = client.PostAsync(
                    new Uri("http://localhost:7000/emails"),
                    new StringContent(
                        JsonConvert.SerializeObject(emailRequest),
                        Encoding.UTF8,
                        "application/json"))
                    .Result;

                result.StatusCode.Should().Be(HttpStatusCode.Created);
            }
        }
    }
}