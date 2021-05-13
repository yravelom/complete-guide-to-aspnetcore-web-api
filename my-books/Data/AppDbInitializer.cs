using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if(!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "My Title 1",
                        Description = "Desc 1",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        DateAdded = DateTime.Now
                    },
                    new Book()
                    {
                        Title = "My Title 2",
                        Description = "Desc 2",
                        IsRead = false,
                        Genre = "Biography",
                        DateAdded = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
