using Domain.Models;
using Kanban.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IAccountService : IDataService<AccountModel>
    {
        Task<AccountModel> GetUser(string username);
        Task<AccountModel> GetByEmail(string email);
    }
}
