using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyWebAPICore.DataAccess;

namespace MyWebAPICore
{
    public class AccessAccounts : IAccessAccounts
    {
        private readonly EnergyDbContext _energyDbContext;
        public AccessAccounts(EnergyDbContext energyDbContext)
        {
            _energyDbContext = energyDbContext;
        }
        public IEnumerable<Account> GetAccounts() => _energyDbContext.Accounts.ToArray();

        public Account GetAccount(int AccountId) => _energyDbContext.Accounts.Find(AccountId);
    }
}