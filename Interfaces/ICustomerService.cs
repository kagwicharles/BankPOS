using BankPOS.Entities;

namespace BankPOS.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomer();
    }
}