using System.ComponentModel.DataAnnotations;

namespace BankPOS.DTOs
{
    public record CreateAccountResponse(
       [property: Required] int CustomerId,
        string AccountType
    );

    public record GetCustomerAccountsResponse(
        int AccountId,
        int CustomerId,
        string AccountType,
        string AccountNumber,
        decimal Balance
    );
}