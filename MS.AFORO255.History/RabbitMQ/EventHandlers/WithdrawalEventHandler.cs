using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using MS.AFORO255.History.Model;
using MS.AFORO255.History.RabbitMQ.Events;
using MS.AFORO255.History.Service;
using System.Threading.Tasks;

namespace MS.AFORO255.History.RabbitMQ.EventHandlers
{
    public class WithdrawalEventHandler : IEventHandler<WithdrawalCreatedEvent>
    {
        private readonly IHistoryService _historyService;

        public WithdrawalEventHandler(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        public Task Handle(WithdrawalCreatedEvent @event)
        {
            _historyService.Add(new HistoryTransaction() { 
                IdTransaction = @event.IdTransaction,
                Amount = @event.Amount,
                Type = @event.Type,
                CreationDate = @event.CreationDate,
                AccountId = @event.AccountId

            });
            return Task.CompletedTask;
        }
    }
}