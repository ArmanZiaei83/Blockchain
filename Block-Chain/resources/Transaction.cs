namespace Block_Chain.resources
{
    public class Transaction
    {
        public Transaction(string seller, string buyer, double price)
        {
            Seller = seller;
            Buyer = buyer;
            Price = price;
        }

        public string Seller { get; }
        public string Buyer { get; }
        public double Price { get; }
    }
}