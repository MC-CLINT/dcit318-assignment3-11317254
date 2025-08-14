using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryRecordsSystem
{
    namespace InventoryRecordsSystem
    {
        public record InventoryItem : IInventoryEntity
        {
            public int Id { get; init; }
            public string Name { get; init; }
            public int Quantity { get; init; }
            public DateTime DateAdded { get; init; }

        }
    }
}
