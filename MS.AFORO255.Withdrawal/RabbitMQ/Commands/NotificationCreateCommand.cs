using MS.AFORO255.Cross.RabbitMQ.Src.Commands;

namespace MS.AFORO255.Withdrawal.RabbitMQ.Commands
{
    public class NotificationCreateCommand : Command
    {
        public NotificationCreateCommand(int idTransaction, decimal amount, string type, int accountId)
        {
            IdTransaction = idTransaction;
            Amount = amount;
            Type = type;
            AccountId = accountId;
        }

        public int IdTransaction { get; protected set; }
        public decimal Amount { get; protected set; }
        public string Type { get; protected set; }
        public int AccountId { get; protected set; }
    }
}