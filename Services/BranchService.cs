using BankPOS.Data;
using BankPOS.Entities;
using BankPOS.Interfaces;

namespace BankPOS.Services
{
    public class BranchService : IBranchService
    {
        private readonly BankPosDbContext _context;

        public BranchService(BankPosDbContext context)
        {
            _context = context;
        }
        public async Task<Branch> OpenBranchAsync(Branch branch)
        {
            _context.Branches.Add(branch);
            await _context.SaveChangesAsync();
            return branch;
        }
    }
}