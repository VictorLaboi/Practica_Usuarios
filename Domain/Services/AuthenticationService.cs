using Domain.AuthServices;
using Kanban.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Services
{
    internal class AuthenticationService : IAuthenticateService
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;
        public AuthenticationService(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        public async Task<AccountModel> Login(string username, string password)
        {
           AccountModel currentUser = await _accountService.GetUser(username);
            if (currentUser == null)
            {
                throw new Exception("User not found");
            }
            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(currentUser.CurrentUser.HashedPassword , password);
            if (passwordResult != PasswordVerificationResult.Success) {
                throw new Exception("No coinciden las contraseñas!"); 
            }
            return currentUser;

        }

        public async Task<RegistrationResult> Register(string email, string user, string password, string confirmPassword)
        {
            RegistrationResult registResult = RegistrationResult.Success;

            if (password != confirmPassword) {
                registResult = RegistrationResult.PasswordsDoNotMatch;
            }
            AccountModel userEmail = await _accountService.GetUser(email);
            if (userEmail is not null) {
                registResult = RegistrationResult.EmailAlreadyExists;                
            }

            AccountModel userAccount = await _accountService.GetUser(user);
            if (userAccount is not null) {
                registResult = RegistrationResult.UsernameAlreadyExists;
            }
            if (registResult is RegistrationResult.Success) {
                string hashPassword = _passwordHasher.HashPassword(password);
                UserModel regis = new UserModel()
                {
                    Name = user,
                    LastName = string.Empty,
                    Email = email,
                    HashedPassword = hashPassword,

                };

                AccountModel account = new AccountModel()
                {

                    CurrentUser = regis,
                    Workspace = new KanbanWorkspace()

                };
                await _accountService.Create(account);
            }
            return registResult;

        }

    }
}
