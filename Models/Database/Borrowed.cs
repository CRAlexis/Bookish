using System;

namespace Bookish.Models.Database
{
    public class Borrowed
    {
        public int id { get; set; }
        public int copy_id { get; set; }
        public int members_id { get; set; }
        public DateTime checked_out { get; set; }
        public DateTime returned { get; set; }
        public DateTime due_date { get; set; }

    }
}