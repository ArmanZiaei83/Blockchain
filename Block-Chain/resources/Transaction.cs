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

        private string Seller { get; }
        private string Buyer { get; }
        private double Price { get; }
    }
}