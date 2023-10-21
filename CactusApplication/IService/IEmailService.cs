using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.IService
{
    public interface IEmailService
    {
        Task<bool> SendEmail(EmailDTO email);
        Task<bool> SendRegistrationCodeByEmail(string UserId);
    }
}
