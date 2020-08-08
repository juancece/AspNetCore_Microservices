using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using MS.AFORO255.Deposit.RabbitMQ.Commands;
using MS.AFORO255.Deposit.RabbitMQ.Events;

namespace MS.AFORO255.Deposit.RabbitMQ.CommandHandlers
{
    public class DepositCommandHandler : IRequestHandler<DepositCreateCommand, bool>
    {
        private readonly IEventBus _bus;

        public DepositCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(DepositCreateCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new DepositCreateEvent(
                request.IdTransaction,
                request.Amount,
                request.Type,
                request.CreationDate,
                request.AccountId
                ));
            return Task.FromResult(true);
        }
    }
}