using ShoppingCard.API.Dtos;

namespace ShoppingCard.API.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
