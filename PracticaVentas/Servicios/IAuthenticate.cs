using Kanban.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.AuthServices;

namespace Kanban.Servicios
{
    interface IAuthenticate
    {
        UserModel currentUser { get; }
        bool IsAuthenticated { get; }
        event Action AuthenticationChanged;
        Task<RegistrationResult> Register(string email, string user, string password);

        Task Login(string username, string password);

        void Logout();  
    }
}
