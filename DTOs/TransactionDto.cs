using System.ComponentModel.DataAnnotations;

namespace BankPOS.DTOs
{
    public record GetTransactionsResponse
    (
         [property: Required] string TransactionReference,
         int AccountNumber,
         decimal Amount,
         DateTime TransactionDate,
         string TransactionType
    );

    public record CreateTransactionRequest
    (
         int AccountId,
         decimal Amount,
         string TransactionType
    );

    public record GetTransactionsByAccountIdRequest
    (
        [property: Required] int AccountId
    );

    public record CreateTransactionResponse(
        string Reference,
        decimal Amount,
        DateTime TimeStamp,
        int AccountId,
        bool Status
    );
}