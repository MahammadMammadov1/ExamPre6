using ExamPre6.Business.CustomExceptions.Account;
using ExamPre6.Business.Service.Interfaces;
using ExamPre6.Business.ViewModel;
using ExamPre6.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre6.Business.Service.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task Login(LoginViewModel vm)
        {
            var user = await _userManager.FindByNameAsync(vm.UserName);
            if (user == null) throw new InvalidCredentialException("","Invalid Credential");

            var result = await _signInManager.PasswordSignInAsync(user,vm.Password,false,false);
            if (!result.Succeeded) throw new InvalidCredentialException("", "Invalid Credential");
        }
    }
}
