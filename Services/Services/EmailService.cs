using System.Net;
using System.Net.Mail;

namespace Technics.com.Services
{
    public class EmailService
    {
        public void Send(string email, string code, string url, string body, string subject)
        {
            MailAddress from = new MailAddress("email");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Body = body + " https://localhost:5001/" + url + "?code=" + code;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("email", "password");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
