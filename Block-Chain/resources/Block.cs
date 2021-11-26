#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace Block_Chain.resources
{
    public class Block
    {
        public Block(List<Transaction> transactions, string previousHash = "")
        {
            Transactions = transactions;
            Hash = CreateHash();
            PreviousHash = previousHash;
        }

        private List<Transaction> Transactions { get; }
        private string Data { get; set; }
        public string Hash { get; }
        public string PreviousHash { get; set; }

        private string CreateHash()
        {
            var transactionsData = GenerateTransactionsData();
            var dataForHash = PreviousHash + transactionsData + Data;
            using var hashCreator = SHA256.Create();
            var hashBytes =
                hashCreator.ComputeHash(Encoding.UTF8.GetBytes(dataForHash));
            var hash = Encoding.Default.GetString(hashBytes);
            Console.WriteLine(hash);
            return hash;
        }

        private string GenerateTransactionsData()
        {
            return Transactions
                .Aggregate("", (current, transaction) => current +
                    (transaction.Buyer +
                     transaction.Seller +
                     transaction.Price));
        }
    }
}