using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace BussinessLayer
{
    public interface IEmailRepository
    {
        public void SendEmail(string fromAddress, string password, string toAddress, string Subject, string body);
    }
    public class EmailRepository: IEmailRepository
    {
        
       

       
        public void SendEmail(string fromAddress,string password,string toAddress,string Subject ,string body)
        {
            using SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "Smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(fromAddress, password)
            };
            Console.WriteLine(fromAddress);
            string subject = "Good Morning";

            try
            {
                Console.WriteLine("sending email");
                email.Send(fromAddress, toAddress, subject, body);
                Console.WriteLine("Email sent");
            }
            catch(SmtpException e)
            {
                throw;

            }
        }
    }
}
