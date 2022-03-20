using System.Collections.Generic;

namespace MyWebAPICore.DataAccess
{
    public interface IAccessAccounts
    {
        IEnumerable<Account> GetAccounts();
        Account GetAccount(int AccountId);
    }
}