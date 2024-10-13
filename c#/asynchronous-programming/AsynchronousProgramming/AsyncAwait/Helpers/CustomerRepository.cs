using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynchronousProgramming.AsyncAwait.Helpers
{
    public class CustomerRepository
    {
        private readonly List<Customer> _customers = new();

        public async Task<List<Customer>> GetAllCustomers()
        {
            // Using await to handle tasks inside of method
            await Task.Delay(200);
            return _customers;
        }

        public Task SaveCustomers(IEnumerable<Customer> customers)
        {
            // Standard task usage without async / await
            Task.Delay(100).Wait();
            _customers.AddRange(customers);
            return Task.CompletedTask;
        }

        public Task<Customer> FindCustomerByName(string name)
        {
            var matchingCustomer = _customers.FirstOrDefault(x => x.Name == name);
            return matchingCustomer != null
                ? Task.FromResult(matchingCustomer)
                : throw new Exception("Could not find matching customer");
        }
    }
}