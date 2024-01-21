using ExamPre6.Business.CustomExceptions.Account;
using ExamPre6.Business.Service.Interfaces;
using ExamPre6.Business.ViewModel;
using ExamPre6.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExamPre6.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(IAccountService accountService,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _accountService = accountService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if(!ModelState.IsValid) return View();
            try
            {
                await _accountService.Login(vm);
            }
            catch (InvalidCredentialException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Index","Dashboard");
        }


        public async Task<IActionResult> CreateAdmin()
        {
            AppUser user = new AppUser
            {
                UserName = "SuperAdmin",
                Fullname = "Mehemmed Memmedov",

            };

            await _userManager.CreateAsync(user, "Admin123@");
            await _userManager.AddToRoleAsync(user, "SuperAdmin");

            return Ok("yarandi");

        }

        public async Task<IActionResult> CreateRole()
        {
            IdentityRole role = new IdentityRole("SuperAdmin");
            IdentityRole role1 = new IdentityRole("Admin");
            IdentityRole role2 = new IdentityRole("Member");

            await _roleManager.CreateAsync(role);
            await _roleManager.CreateAsync(role1);
            await _roleManager.CreateAsync(role2);

            return Ok("yarandi");
        }
    }
}
