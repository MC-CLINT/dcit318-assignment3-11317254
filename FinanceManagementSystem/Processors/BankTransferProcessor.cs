using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceManagementSystem.Interfaces;


namespace FinanceManagementSystem.Processors
{
    public class BankTransferProcessor : ITransactionProcessor
    {
        public void Process (decimal amount, string Category)
        {
            Console.WriteLine($"[Bank Transfer] Processed {amount} for '{Category}' via bank transfer.");
        }
    }
}
