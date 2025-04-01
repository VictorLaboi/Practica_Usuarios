using Domain.Models;
using Kanban.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AuthServices
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists
    }
    internal interface IAuthenticateService
    {
        Task<RegistrationResult> Register (string email, string user, string password, string confirmPassword);
        Task <AccountModel> Login (string username, string password);   
    }
}
