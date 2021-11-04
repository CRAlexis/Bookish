namespace Bookish.Models.View
{
    public class BookViewModel
    {
        public int book_id { get; set; }
        public int id { get; set; }
        
        public int author_id { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public int genre_id { get; set; }
        public string genre { get; set; }
        public int year_published { get; set; }
        public string image { get; set; }
    }
}