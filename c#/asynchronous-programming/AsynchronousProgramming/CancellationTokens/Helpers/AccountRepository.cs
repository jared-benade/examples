using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynchronousProgramming.CancellationTokens.Helpers
{
    public class AccountRepository
    {
        private List<Account> _accounts = new()
        {
            new Account(1, "Jimmy Jones", true),
            new Account(2, "Jane Doe", false)
        };

        private List<Account> _updatedState = new();

        public async Task<List<Account>> GetAllInactiveAccountsAsync()
        {
            await Task.Delay(100);
            return _accounts.Where(x => !x.Active).ToList();
        }

        public async Task ActivateAccountsAsync(List<int> accountIdsToActivate)
        {
            await Task.Delay(100);
            
            _updatedState = _accounts
                .Select(existing =>
                {
                    var isActive = accountIdsToActivate.Contains(existing.Id) || existing.Active;
                    return new Account(existing.Id, existing.CustomerName, isActive);
                })
                .ToList();
        }

        public async Task RollbackChangesAsync()
        {
            await Task.Delay(100);
            await ClearUpdatedTransactionState();
        }

        public async Task SaveChangesAsync()
        {
            await Task.Delay(50);
            _accounts = _updatedState;
            await ClearUpdatedTransactionState();
        }

        public async Task<List<Account>> GetAllAccountsAsync()
        {
            return await Task.FromResult(_accounts);
        }

        private async Task ClearUpdatedTransactionState()
        {
            await Task.Delay(20);
            _updatedState = new List<Account>();
        }
    }
}