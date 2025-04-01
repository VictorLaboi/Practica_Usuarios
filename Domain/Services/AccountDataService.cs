using Domain.AuthServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class AccountDataService : IAuthenticateService
    {
        private readonly BdService BdConnection; 

        public Task<AccountModel> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationResult> Register(string email, string user, string password, string confirmPassword)
        {
            throw new NotImplementedException();
        }
    }
}
