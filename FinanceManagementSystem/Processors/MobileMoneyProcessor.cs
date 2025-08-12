using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceManagementSystem.Interfaces;

namespace FinanceManagementSystem.Processors
{
    public class MobileMoneyProcessor : ITransactionProcessor
    {
        public void Process(decimal amount, string Category)
        {
            Console.WriteLine($"[Mobile Money] {amount} sent for '{Category}' using mobile money.");
        }
    }
}
