using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceManagementSystem.Interfaces;

namespace FinanceManagementSystem.Processors
{
    internal class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(decimal amount, string Category)
        {
            Console.WriteLine($"[Crypto Wallet] {amount} worth of crypto used for '{Category}' transaction.");
        }
    }
}
