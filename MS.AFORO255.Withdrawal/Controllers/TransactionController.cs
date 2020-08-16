using Microsoft.AspNetCore.Mvc;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using MS.AFORO255.Withdrawal.DTO;
using MS.AFORO255.Withdrawal.RabbitMQ.Commands;
using MS.AFORO255.Withdrawal.Service;
using System;

namespace MS.AFORO255.Withdrawal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly IEventBus _bus;
        private readonly ITransactionService _transactionService;
        private readonly IAccountService _accountService;

        public TransactionController(IEventBus bus, ITransactionService transactionService,
            IAccountService accountService)
        {
            _bus = bus;
            _transactionService = transactionService;
            _accountService = accountService;
        }

        [HttpPost("Withdrawal")]
        public IActionResult Withdrawal([FromBody] TransactionRequest request)
        {
            Model.Transaction transaction = new Model.Transaction()
            {
                AccountId = request.AccountId,
                Amount = request.Amount,
                CreationDate = DateTime.Now.ToShortDateString(),
                Type = "Withdrawal"
            };
            transaction = _transactionService.Withdrawal(transaction);
            bool isProccess = _accountService.Execute(transaction);
            if (isProccess)
            {

                var createCommand = new WithdrawalCreateCommand(
                idTransaction: transaction.Id,
                amount: transaction.Amount,
                type: transaction.Type,
                creationDate: transaction.CreationDate,
                accountId: transaction.AccountId
             );
                _bus.SendCommand(createCommand);

                var createCommandNotification = new NotificationCreateCommand(
                   idTransaction: transaction.Id,
                   amount: transaction.Amount,
                   type: transaction.Type,
                   accountId: transaction.AccountId
                );
                _bus.SendCommand(createCommandNotification);
            }
            return Ok();
        }

    }
}
