using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.ViewModels
{
    public class PublisherVM
    {
        public string Name { get; set; }
    }
    public class PublisherWithBooksAndAuthorVM
    {
        public string Name { get; set; }
        public List<BooksAuthorVM> BookAuthors { get; set; }
    }
    public class BooksAuthorVM
    {
        public string BookName { get; set; }
        public List<string> BooksAuthors { get; set; }
    }
}
