using MediatR;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using MS.AFORO255.Withdrawal.RabbitMQ.Commands;
using MS.AFORO255.Withdrawal.RabbitMQ.Events;
using System.Threading;
using System.Threading.Tasks;

namespace MS.AFORO255.Withdrawal.RabbitMQ.CommandHandlers
{
    public class WithdrawalCommandHandler : IRequestHandler<WithdrawalCreateCommand, bool>
    {
        private readonly IEventBus _bus;

        public WithdrawalCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(WithdrawalCreateCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new WithdrawalCreatedEvent(
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