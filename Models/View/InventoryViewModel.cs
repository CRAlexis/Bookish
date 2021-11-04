using System.Collections.Generic;
using Bookish.Models.Database;

namespace Bookish.Models.View
{
    public class InventoryViewModel
    {
        public List<Inventory> Inventory { get; set; }
        public List<Member> Members { get; set; }
        public string BookTitle { get; set; }

        public int BookId { get; set; }

        
    }
}