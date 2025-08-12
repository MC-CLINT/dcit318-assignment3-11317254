using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using FinanceManagementSystem.Accounts;
using FinanceManagementSystem.Processors;
using FinanceManagementSystem.Models;

namespace FinanceManagementSystem
{
    public class FinanceApp
    {
        public readonly List<FinanceManagementSystem.Models.Transaction> _tranactions = new();

        public void Run()
        {
            var account = new SavingsAccount("ACC11317254", 3000.00m);

            var tx1 = new FinanceManagementSystem.Models.Transaction(1, DateTime.Now, 150.00m, "Groceries");
            var tx2 = new FinanceManagementSystem.Models.Transaction(2, DateTime.Now, 400.00m, "Utilities");
            var tx3 = new FinanceManagementSystem.Models.Transaction(3, DateTime.Now, 750.00m, "Entertainment");

            var mobileProcessor = new MobileMoneyProcessor();
            var bankProcessor = new BankTransferProcessor();
            var cryptoProcessor = new CryptoWalletProcessor();


            mobileProcessor.Process(tx1.Amount, tx1.Category);
            bankProcessor.Process(tx2.Amount, tx2.Category);
            cryptoProcessor.Process(tx3.Amount, tx3.Category);

            account.ApplyTransaction(tx1);
            account.ApplyTransaction(tx2);
            account.ApplyTransaction(tx3);

            _tranactions.Add(tx1);
            _tranactions.Add(tx2);
            _tranactions.Add(tx3);

            Console.WriteLine($"\nFinal Balance: {account.Balance:0.00}");
            Console.WriteLine("\nTransaction Log:");
            foreach (var tx in _tranactions)
            {
                Console.WriteLine($"ID: {tx.Id}, Category: {tx.Category}, Amount: {tx.Amount}, Date: {tx.Date}");
            }
        }
    }
}
