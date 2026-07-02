using BankPOS.DTOs;
using BankPOS.Entities;
using BankPOS.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankPOS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("/api/GetTransactions")]
        public async Task<ActionResult<IEnumerable<GetTransactionsResponse>>> GetTransactions()
        {
            var transactions = await _transactionService.GetTransactionsAsync();
            var dtos = transactions.Select(t => new GetTransactionsResponse
            (
                t.Reference,
                t.AccountId,
                t.Amount,
                t.TimeStamp,
                t.TransactionType
            ));
            return Ok(dtos);
        }

        [HttpPost("/api/GetTransactionsByAccountId")]
        public async Task<ActionResult<IEnumerable<GetTransactionsResponse>>> GetTransactionsByAccountId([FromBody] GetTransactionsByAccountIdRequest request)
        {
            var transactions = await _transactionService.GetTransactionsByAccountIdAsync(request.AccountId);
            var dtos = transactions.Select(t => new GetTransactionsResponse
            (
                t.Reference,
                t.AccountId,
                t.Amount,
                t.TimeStamp,
                t.TransactionType
            ));
            return Ok(dtos);
        }

        [HttpPost("/api/CreateTransaction")]
        public async Task<ActionResult<CreateTransactionResponse>> CreateTransaction([FromBody] CreateTransactionRequest request)
        {
            var transaction = new Transaction
            {
                AccountId = request.AccountId,
                Amount = request.Amount,
                TransactionType = request.TransactionType
            };
            var createdTransaction = await _transactionService.CreateTransactionAsync(transaction);
            return Ok(new CreateTransactionResponse
            (
                createdTransaction.Reference,
                createdTransaction.Amount,
                createdTransaction.TimeStamp,
                createdTransaction.AccountId,
                createdTransaction.Status
            ));
        }
    }
}