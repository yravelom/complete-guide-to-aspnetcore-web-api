using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }
        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publisher.Add(_publisher);
            _context.SaveChanges();
        }
        public PublisherWithBooksAndAuthorVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publisher.Where(p=>p.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorVM()
            {
                Name = n.Name,
                BookAuthors = n.Books.Select(n => new BooksAuthorVM()
                { 
                    BookName = n.Title,
                    BooksAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                }).ToList()
            }).FirstOrDefault();
            return _publisherData;
        }

        public void DeletePublisherById(int publisherId)
        {
            var _publisher = _context.Publisher.FirstOrDefault(o => o.Id == publisherId);
            if (_publisher != null)
            {
                _context.Publisher.Remove(_publisher);
                _context.SaveChanges();
            }
        }
    }
}
