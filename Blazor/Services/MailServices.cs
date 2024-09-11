using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Blazor.Services
{
    public class MailServices
    {
        // The emails We use depending on what the services is used for.
        private readonly string GuestEmail = "trinityHotelGuest@outlook.com";
        private readonly string GuestEmailPW = "TrinityGuest!";
        private readonly string BookingEmail = "trinityHotelEmployee@outlook.com";
        private readonly string BookingEmailPW = "TrinityBooking!";
        public async Task SendEmail(string FromEmail, string subject, string message)
        {
            string ToEmail = "";
            string EmailPW = "";

            /* This can be changed so it can be send to from a guest email, but you should be aware that you would need the users password for their email.
             You would also need the receiving email.*/

            // Tjeks which Email, you are using.
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

            // Create SmtpClient with a email.
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(FromEmail, EmailPW)
            };

            // Sends the email.
            try
            {
                await client.SendMailAsync(new MailMessage(FromEmail, ToEmail, subject, message));
				Console.WriteLine("Mail sent successfully.");
			}
            catch 
            {
                Console.WriteLine("Failed to send Email");
            }
        }
    }
}