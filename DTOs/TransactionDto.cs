using System.ComponentModel.DataAnnotations;

namespace BankPOS.DTOs
{
    public record GetTransactionsResponse
    (
         [property: Required] string TransactionReference,
         Guid AccountNumber,
         decimal Amount,
         DateTime TransactionDate,
         string TransactionType
    );

    public record CreateTransactionRequest
    (
         Guid AccountId,
         decimal Amount,
         string TransactionType
    );

    public record GetTransactionsByAccountIdRequest
    (
        [property: Required] Guid AccountId
    );

    public record CreateTransactionResponse(
        string Reference,
        decimal Amount,
        DateTime TimeStamp,
        Guid AccountId,
        bool Status
    );
}