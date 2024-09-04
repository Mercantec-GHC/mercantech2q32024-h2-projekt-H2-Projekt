using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Blazor.Services
{
    public class MailServices
    {
        private readonly string GuestEmail = "trinityHotelGuest@outlook.com";
        private readonly string GuestEmailPW = "TrinityGuest!";
        private readonly string BookingEmail = "trinityHotelEmployee@outlook.com";
        private readonly string BookingEmailPW = "TrinityBooking!";
        public async Task SendEmail(string subject, string message, string FromEmail)
        {
            Console.WriteLine("Test");

            string ToEmail = "";
            string EmailPW = "";

            if (FromEmail == GuestEmail)
            {
                ToEmail = BookingEmail;
                EmailPW = GuestEmailPW;
            }
            else if (FromEmail == BookingEmail)
            {
                ToEmail = GuestEmail;
                EmailPW = BookingEmailPW;
            }
            else
            {
                Console.WriteLine("Failed to create email");
            }

            SmtpClient client = new SmtpClient("smpt-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(FromEmail, EmailPW)
            };

            try
            {
                await client.SendMailAsync(new MailMessage(FromEmail, ToEmail, subject, message));
            }
            catch
            {
                Console.WriteLine("Failed to send Email");
            }
        }
    }
}