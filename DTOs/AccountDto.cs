using System.ComponentModel.DataAnnotations;

namespace BankPOS.DTOs
{

    public record CreateAccountRequest(
        [property: Required] int CustomerId,
        string AccountType
    );

    public record CreateAccountResponse(
       [property: Required] int CustomerId,
        string AccountType,
        int AccountId
    );

    public record GetCustomerAccountsResponse(
        int AccountId,
        int CustomerId,
        string AccountType,
        string AccountNumber,
        decimal Balance
    );
}