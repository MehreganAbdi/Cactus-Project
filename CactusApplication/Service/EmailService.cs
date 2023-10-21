using CactusApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CactusDomain.Data;
using Microsoft.EntityFrameworkCore;
using CactusApplication.IService;

namespace CactusApplication.Service
{
    public class EmailService : IEmailService
    {
        private readonly ApplicationDbContext _context;
        public EmailService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> SendEmail(EmailDTO email)
        {
            var senderEmail = new MailAddress("mehreganabdiwebmail@gmail.com");
            var receiverEmail = new MailAddress(email.Reciever, "Receiver");
            var password = "kxbo ipin pkyn vgfo";
            var sub = email.Subject;
            var body = email.message + $"\n{DateTime.Now}\nThanks For Contacting , Good Luck .";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = sub,
                Body = body
            })
            {
                try
                {

                    smtp.Send(mess);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }


        }

        public async Task<bool> SendRegistrationCodeByEmail(string UserId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == UserId);

            var rnd = new Random();
            var x = rnd.Next(999, 9999);
            user.RCode = x;
            await _context.SaveChangesAsync();
            var email = new EmailDTO()
            {
                Reciever = user.Email,
                Subject = "Verification Code",
                message = "The Verification Code Is  : " + x.ToString()
            };
            try
            {
                await SendEmail(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
