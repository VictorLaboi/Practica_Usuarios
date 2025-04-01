using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Services;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityManagment.Services
{
    public class AccountDataService : IAccountService
    {
        private DbContextFactory _factory;
        private NoQueryDataService<AccountModel> dataService; 
        public AccountDataService(DbContextFactory factory , NoQueryDataService<AccountModel> dataService)
        {
            this._factory = factory;
            this.dataService = dataService;
        }


        public async Task<AccountModel> Create(AccountModel item)
        {
            return await dataService.Create(item);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await dataService.Delete(id);    
        }

        public async Task<AccountModel> Get(Guid id)
        {
            using (KanbanDbContext context = _factory.createDbContext()) {
            
                AccountModel account = await context.Accounts
                    .Include(a => a.Workspace)
                    .Include(a => a.CurrentUser)
                    .FirstOrDefaultAsync((a) => a.Id == id);
                if (account == null) {
                    throw new ArgumentNullException();
                }
                return account;
            }
        }

        public Task<IEnumerable<AccountModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AccountModel> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<AccountModel> GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public Task<AccountModel> Update(Guid id, AccountModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
