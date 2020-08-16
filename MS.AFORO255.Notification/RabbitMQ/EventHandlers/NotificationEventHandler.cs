using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using MS.AFORO255.Notification.Model;
using MS.AFORO255.Notification.RabbitMQ.Events;
using MS.AFORO255.Notification.Repository;
using System;
using System.Threading.Tasks;

namespace MS.AFORO255.Notification.RabbitMQ.EventHandlers
{
    public class NotificationEventHandler : IEventHandler<NotificationCreatedEvent>
    {
        private readonly IMailRepository _mailRepository;

        public NotificationEventHandler(IMailRepository mailRepository)
        {
            _mailRepository = mailRepository;
        }

        public Task Handle(NotificationCreatedEvent @event)
        {
            _mailRepository.Add(new SendMail() {
                SendDate = DateTime.Now.ToShortDateString(),
                AccountId = @event.AccountId
            });
            return Task.CompletedTask;
        }
    }
}