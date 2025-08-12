using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Accounts
{
    public sealed class SavingsAccount : Account
    {
        public SavingsAccount(string accountNumber, decimal initialBalance): base(accountNumber, initialBalance)
        {
        }

        public override void ApplyTransaction(Transaction transaction)
        {
           if (transaction.Amount > Balance)
            {
                Console.WriteLine("Insufficient Funds");
            }
           else
            {
                Balance -= transaction.Amount;
                Console.WriteLine("Transaction Successful. New Balance: {Balance:0.00}");
            }
        }
    }
}
