using System;
using Microsoft.AspNetCore.Mvc;
using MS.AFORO255.Withdrawal.DTO;
using MS.AFORO255.Withdrawal.Service;

namespace MS.AFORO255.Withdrawal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("Withdrawal/")]
        public IActionResult Withdrawal([FromBody] TransactionRequest request)
        {
            Model.Transaction transaction = new Model.Transaction
            {
                AccountId = request.AccountId,
                Amount = request.Amount,
                CreationDate = DateTime.Now.ToShortDateString(),
                Type = "Withdrawal"
            };
            transaction = _transactionService.Withdrawal(transaction);
            return Ok();
        }
    }
}