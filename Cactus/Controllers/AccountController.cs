using CactusApplication.DTOs;
using CactusApplication.IService;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cactus.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View(new RegisterDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDTO);
            }

            var result = await accountService.RegisterAsync(registerDTO);
            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            TempData["Title"] = "Email May Be Already Exist " +
                "(Note that : Password Must Contain !,@,#,numbers,Aa,Bb,...)";
            return View(registerDTO);
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View(new LoginDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var res = await accountService.LoginAsync(loginDTO);
            if (res)
            {
                return RedirectToAction("Index", "Home");
            }
            TempData["Error"] = "Log in Failed ! Try Again";
            return View(loginDTO);
        }

        public async Task<IActionResult> Logout()
        {
            await accountService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> EmailVerification()
        {
            return View(await accountService.EmailRegistrationAsyncGet(User.Identity.GetUserId()));
        }
        [HttpPost]
        public async Task<IActionResult> EmailVerification(EmailVerificationDTO emailVerificationDTO)
        {
            var res = await accountService.EmailRegistrationAsyncPost(emailVerificationDTO, User.Identity.GetUserId());
            if (res)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new EmailVerificationDTO());
        }

    }
}
