using CactusApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.IService
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(LoginDTO loginDTO);
        Task<bool> LogoutAsync();
        Task<bool> RegisterAsync(RegisterDTO registerDTO);
        Task<EmailVerificationDTO> EmailRegistrationAsyncGet(string UserId);
        Task<bool> EmailRegistrationAsyncPost(EmailVerificationDTO emailDTO, string UserId);
    }
}
