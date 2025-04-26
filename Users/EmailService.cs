using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGuiTietKiem
{
    public class EmailService
    {
        public static void SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("giahanthcstmt@gmail.com", "jqwegjdsksjiaeaa"),
                    EnableSsl = true,
                };

                mail.From = new MailAddress("giahanthcstmt@gmail.com");
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;

                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi gửi email: " + ex.Message);
            }
        }

        public static string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString(); 
        }
    }
}
