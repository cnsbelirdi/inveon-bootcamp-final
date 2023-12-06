using FluentEmail.Core;
using FluentEmail.Core.Models;
using FluentEmail.Razor;
using FluentEmail.SendGrid;
using ShoppingCard.API.Dtos;

namespace ShoppingCard.API.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(EmailDto request)
        {

            string apiKey = _config.GetSection("APIKey").Value;

            IFluentEmail fluentEmail = Email
                .From("omerfaruksahiin@gmail.com")
                .To(request.To)
                .Subject("Ödeme Özeti")
                .Tag("test")
                .Body(request.Body);

            SendGridSender sendGridSender = new SendGridSender(apiKey);
            SendResponse response = sendGridSender.Send(fluentEmail);

            if (response.Successful)
            {
                Console.WriteLine("The email was sent successfully");
            }
            else
            {
                Console.WriteLine("The email could not be sent. Check the errors: ");
                foreach (string error in response.ErrorMessages)    
                {
                    Console.WriteLine(error);
                }
            }
        }
    }
}
