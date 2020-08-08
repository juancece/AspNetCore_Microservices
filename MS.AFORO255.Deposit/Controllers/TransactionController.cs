using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using MS.AFORO255.Deposit.DTO;
using MS.AFORO255.Deposit.RabbitMQ.Commands;
using MS.AFORO255.Deposit.Service;

namespace MS.AFORO255.Deposit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IEventBus _bus;
        private readonly ITransactionService _transactionService;

        public TransactionController(IEventBus bus, ITransactionService transactionService)
        {
            _bus = bus;
            _transactionService = transactionService;
        }

        [HttpPost("Deposit/")]
        public IActionResult Deposit([FromBody] TransactionRequest request)
        {
            Model.Transaction transaction = new Model.Transaction
            {
                AccountId = request.AccountId,
                Amount = request.Amount,
                CreationDate = DateTime.Now.ToShortDateString(),
                Type = "Deposit"
            };
            transaction = _transactionService.Deposit(transaction);
            
            var createCommand = new DepositCreateCommand(
                idTransaction: transaction.Id,
                amount: transaction.Amount,
                type: transaction.Type,
                creationDate: transaction.CreationDate,
                accountId: transaction.AccountId
                );
            _bus.SendCommand(createCommand);
            
            return Ok();
        }
    }
}