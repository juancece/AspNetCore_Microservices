using MS.AFORO255.Cross.RabbitMQ.Src.Events;

namespace MS.AFORO255.History.RabbitMQ.Events
{
    public class DepositCreatedEvent : Event
    {
        public DepositCreatedEvent(int idTransaction, decimal amount, string type, string creationDate, int accountId)
        {
            IdTransaction = idTransaction;
            Amount = amount;
            Type = type;
            CreationDate = creationDate;
            AccountId = accountId;
        }

        public int IdTransaction { get; protected set; }
        public decimal Amount { get; protected set; }
        public string Type { get; protected set; }
        public string CreationDate { get; protected set; }
        public int AccountId { get; protected set; }
    }
}