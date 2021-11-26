#region

using System;
using System.Collections.Generic;
using Block_Chain.resources;

#endregion

namespace Block_Chain
{
    internal class Program
    {
        private const string FirstUser = "user1";
        private const string SecondUser = "user2";
        private static Blockchain _blockchain;

        private static void Main()
        {
            _blockchain = new Blockchain();

            var block =
                new Block(new List<Transaction>
                    {new(FirstUser, SecondUser, 50)});
            
            _blockchain.AddBlock(block);

            PrintChainValidation(_blockchain);
            HackBlockChain();
            PrintChainValidation(_blockchain);
        }

        private static void HackBlockChain()
        {
            _blockchain.ChainedBlocks[1] = new Block(new List<Transaction>
                {new(SecondUser, FirstUser, 120)});
        }

        private static void PrintChainValidation(Blockchain blockChain)
        {
            Console.WriteLine(blockChain.IsChainValid());
        }
    }
}