using System;

namespace Bookish.Models.View
{
    public class BorrowedViewModel
    {
        public int members_id { get; set; }
        public DateTime checked_out { get; set; }
        public DateTime returned { get; set; }
        public DateTime due_date { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }
}