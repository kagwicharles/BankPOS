using System.ComponentModel.DataAnnotations;

namespace BankPOS.DTOs
{

    public record CreateAccountRequest(
        Guid CustomerId,
        string AccountType,
        string BranchCode
    );

    public record CreateAccountResponse(
        Guid CustomerId,
        string AccountType,
        Guid AccountId
    );

    public record GetCustomerAccountsRequest(
        Guid CustomerId
    );

    public record GetCustomerAccountsResponse(
        Guid AccountId,
        Guid CustomerId,
        string AccountType,
        string AccountNumber,
        decimal Balance
    );
}