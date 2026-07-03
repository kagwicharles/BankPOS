using BankPOS.Data;
using BankPOS.Entities;
using BankPOS.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankPOS.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly BankPosDbContext _context;

        public CustomerService(BankPosDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> GetCustomerProfileAsync(int customerId)
        {
            return await _context.Customers
            .Where(c => c.CustomerId == customerId).FirstAsync();
        }
    }
}