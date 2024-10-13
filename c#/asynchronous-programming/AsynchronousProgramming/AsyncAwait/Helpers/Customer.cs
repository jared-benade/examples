namespace AsynchronousProgramming.AsyncAwait.Helpers
{
    public class Customer
    {
        public Customer(string name, string cellphone, string email)
        {
            Name = name;
            Cellphone = cellphone;
            Email = email;
        }

        public string Name { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
    }
}