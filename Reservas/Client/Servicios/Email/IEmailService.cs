using Reservas.Shared;

namespace Reservas.Client.Servicios.Email
{
    public interface IEmailService
    {

        void SendEmail(EmailDTO request);
        
    }
}
