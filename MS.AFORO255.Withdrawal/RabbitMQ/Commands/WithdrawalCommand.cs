using MS.AFORO255.Cross.RabbitMQ.Src.Commands;

namespace MS.AFORO255.Withdrawal.RabbitMQ.Commands
{
    public class WithdrawalCommand: Command
    {
        public int IdTransaction { get; protected  set; }
        public decimal Amount { get; protected set; }
        public string Type { get; protected set; }
        public string CreationDate { get; protected set; }
        public int AccountId { get; protected set; }
    }
}