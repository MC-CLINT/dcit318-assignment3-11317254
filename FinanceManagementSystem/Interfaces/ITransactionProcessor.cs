using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FinanceManagementSystem.Interfaces
{
    internal interface ITransactionProcessor
    {
        void Process(decimal amount, string Category);
    }
}
