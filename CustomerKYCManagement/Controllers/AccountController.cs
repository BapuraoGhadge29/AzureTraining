using CustomerKYCManagement.DTOs;
using CustomerKYCManagement.services;
using Microsoft.AspNetCore.Mvc;
namespace CustomerKYCManagement.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController(IAccountService service) : ControllerBase
    {
        private readonly IAccountService _service = service;

        [HttpPost]
        public async Task<ActionResult<AccountResponse>> CreateAccount(AccountRequest request)
        {
            return Ok(await _service.CreateAccount(request));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<AccountResponse>> UpdateAccount(string id,UpdateAccountRequest request)
        {
            return Ok(await _service.UpdateAccount(request));
        }
        [HttpGet("{accountNumber}/balance")]
        public async Task<IActionResult> GetBalance(string accountNumber)
        {
            return Ok(await _service.GetBalance(accountNumber));
        }
        [HttpPost("transfer")]
        public async Task<IActionResult> TransferRequest(TransferRequest transferRequest)
        {
            return Ok(await _service.TransferFunds(transferRequest));
        }
    }
}