namespace AsynchronousProgramming.CancellationTokens.Helpers
{
    public class Account
    {
        public Account(int id, string customerName, bool active)
        {
            Id = id;
            CustomerName = customerName;
            Active = active;
        }

        public int Id { get; }
        public string CustomerName { get; }
        public bool Active { get; }
    }
}