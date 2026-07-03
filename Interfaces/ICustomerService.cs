using BankPOS.Entities;

namespace BankPOS.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(Customer customer);

        Task<Customer> GetCustomerProfileAsync(int customerId);
    }
}