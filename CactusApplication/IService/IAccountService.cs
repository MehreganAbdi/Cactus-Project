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
        bool Login(LoginDTO loginDTO);
        Task<bool> LoginAsync(LoginDTO loginDTO);
        bool Logout();
        Task<bool> LogoutAsync();
        bool Register(RegisterDTO registerDTO);
        Task<bool> RegisterAsync(RegisterDTO registerDTO);

    }
}
