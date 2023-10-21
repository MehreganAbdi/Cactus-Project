using CactusApplication.DTOs;
using CactusApplication.IService;
using CactusDomain.IRepository;
using CactusDomain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;
 
 
using System.Net.Mail;
using System.Net;   


namespace CactusApplication.Service
{
    public class AccountService : IAccountService 
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailService _emailService;
        private readonly IAccountRepository _accountRepository;
        public AccountService(IEmailService emailService, SignInManager<User> signInManager, Microsoft.AspNetCore.Identity.UserManager<User> userManager, IAccountRepository accountRepository)
        {
            _emailService = emailService;
            _signInManager = signInManager;
            _userManager = userManager;
            _accountRepository = accountRepository;
        }

        public async Task<EmailVerificationDTO> EmailRegistrationAsyncGet(EmailDTO emailDTO , string UserId)
        {
            await _emailService.SendRegistrationCodeByEmail(UserId);
            var emailVerificationDTO = new EmailVerificationDTO()
            {
                UserId = UserId,
                Code = null
            };
            
            return emailVerificationDTO;
        }

        public async Task<bool> EmailRegistrationAsyncPost(EmailVerificationDTO emailVerificationDTO, string UserId)
        {
            var user = await _accountRepository.GetUserByEmailAsync(emailVerificationDTO.UserId);

            if (emailVerificationDTO.Code == null || emailVerificationDTO.Code.Length < 4 || emailVerificationDTO.Code.Length > 4 || Convert.ToInt32(emailVerificationDTO.Code) != user.PassToken)
            {
                return false;
            }
            user.EmailConfirmed = true;
            user.RCode = 0;
            await _accountRepository.SaveAsync();
            return true;
        }

        public async Task<bool> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.EmailAddress);

            var passwordChecking = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (passwordChecking)
            {
                var signIn = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, false, false);
                if (signIn.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }


        public async Task<bool> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return true;
        }


        public async Task<bool> RegisterAsync(RegisterDTO registerDTO)
        {
            var user = await _userManager.FindByEmailAsync(registerDTO.EmailAddress);
            
            var newUser = new User()
            {
                Email = registerDTO.EmailAddress
                ,
                UserName = registerDTO.UserName.Replace(" ", "")
            };

            var createUser = await _userManager.CreateAsync(newUser, registerDTO.Password);
            if (createUser.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "user");
                var email = new EmailDTO()
                {
                    Reciever = newUser.Email,
                    message = $"You Registered Successfully To My WebSite , Welcome .\n\n" +
                  
                    $"MohammadHadi Abdi ",
                    Subject = "Registration"
                };
                await _emailService.SendEmail(email);

            }
            var signin = await _signInManager.PasswordSignInAsync(newUser, registerDTO.Password, false, false);
            if (signin.Succeeded)
                return true;

            return false;
        }
    }
}
