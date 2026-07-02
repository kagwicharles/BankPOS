using BankPOS.DTOs;
using BankPOS.Entities;
using BankPOS.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankPOS.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("/api/createAccount")]
        public async Task<ActionResult<Account>> CreateAccount([FromBody] CreateAccountRequest request)
        {
            var account = new Account
            {
                CustomerId = request.CustomerId,
                AccountType = request.AccountType
            };
            var createdAccount = await _accountService.CreateAccountAsync(account);
            return Ok(new CreateAccountResponse
            (
                createdAccount.CustomerId,
                createdAccount.AccountType,
                createdAccount.AccountId
            ));
        }
    }
}