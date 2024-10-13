using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AsynchronousProgramming.CancellationTokens.Helpers;

namespace AsynchronousProgramming.CancellationTokens
{
    public class BasicUsage
    {
        private readonly AccountRepository _accountRepository;

        public BasicUsage()
        {
            _accountRepository = new AccountRepository();
        }

        public async Task<string> ActivateAllAccountsAsync(CancellationToken cancellationToken = new())
        {
            var inactiveAccounts = await _accountRepository.GetAllInactiveAccountsAsync();
            var accountIds = inactiveAccounts.Select(x => x.Id).ToList();

            if (cancellationToken.IsCancellationRequested)
            {
                // Cancel without a rollback since no data has been altered
                return "Nothing really happened :|";
            }

            await _accountRepository.ActivateAccountsAsync(accountIds);

            if (cancellationToken.IsCancellationRequested)
            {
                // cancellation occurred after data has been updated. Rollback changes
                await _accountRepository.RollbackChangesAsync();
                return "Had to rollback :(";
            }

            await _accountRepository.SaveChangesAsync();

            return "Changes were successfully applied :D";
        }

        public async Task<List<Account>> GetAllAccountsAsync()
        {
            return await _accountRepository.GetAllAccountsAsync();
        }
    }
}