#region

using System.Collections.Generic;
using System.Linq;

#endregion

namespace Block_Chain.resources
{
    public class Blockchain
    {
        public Blockchain()
        {
            PendingTransactions = new List<Transaction>();
            ChainedBlocks = new List<Block> {CreateGenesisBlock()};
        }

        public List<Block> ChainedBlocks { get; }
        private List<Transaction> PendingTransactions { get; }

        private Block CreateGenesisBlock()
        {
            return new Block(PendingTransactions);
        }

        public void AddBlock(Block block)
        {
            var previousBlockHash = ChainedBlocks.Last().Hash;
            block.PreviousHash = previousBlockHash;
            ChainedBlocks.Add(block);
        }

        public bool IsChainValid()
        {
            for (var i = 1; i < ChainedBlocks.Count; i++)
            {
                var previousBlock = ChainedBlocks[i - 1];
                var currentBlock = ChainedBlocks[i];

                if (currentBlock.PreviousHash != previousBlock.Hash)
                    return false;
            }

            return true;
        }
    }
}