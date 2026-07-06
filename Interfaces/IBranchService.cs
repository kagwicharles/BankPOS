using BankPOS.Entities;

namespace BankPOS.Interfaces
{
    public interface IBranchService
    {
        public Task<Branch> OpenBranchAsync(Branch branch);
    }
}