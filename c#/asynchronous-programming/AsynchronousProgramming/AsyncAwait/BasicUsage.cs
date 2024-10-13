using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AsynchronousProgramming.AsyncAwait.Helpers;

namespace AsynchronousProgramming.AsyncAwait
{
    public class BasicUsage
    {
        private readonly CustomerRepository _customerRepository;

        public BasicUsage()
        {
            _customerRepository = new CustomerRepository();
        }

        public async Task<List<Customer>> GetCustomers()
        {
            // Can await task and return in single line
            return await _customerRepository.GetAllCustomers();
        }

        public async Task SaveNewCustomers()
        {
            var newCustomers = new List<Customer>
            {
                new("Jimmy", "0745698523", "jimmy@somemail.com"),
                new("Jones", "0845723692", "jones@somotheremail.com")
            };

            // Can use await for underlying method that returns a task, even if underlying method is not async
            await _customerRepository.SaveCustomers(newCustomers);
            
            // No need to specifically use return statement if method is async and return type is Task instead of Task<T>
        }

        public async Task<Customer> FindCustomer()
        {
            // Can use standard try / catch to handle exceptions thrown by asynchronous operations
            try
            {
                return await _customerRepository.FindCustomerByName("Customer that does not exist");
            }
            catch (Exception ex)
            {
                // Can handle exception as needed
                CustomLogger.LogException(ex);
                throw;
            }
        }
    }
}