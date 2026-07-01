using System.Transactions;
using BankPOS.DTOs;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            var transactions = await _transactionService.GetTransactionsAsync();
            var dtos = transactions.Select(t => new TransactionDto
            {
                TransactionReference = t.Reference,
                AccountNumber = t.AccountId
            });
            return Ok(dtos);
        }
    }
}