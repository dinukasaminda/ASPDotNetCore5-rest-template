using System;
using System.Collections.Generic;

namespace Bookstore.Core
{
    public class BookServices : IBookServices
    {
        public List<Book> GetBooks()
        {
            return new List<Book>
         {
             new Book
             {
                 Name="test book1",
                 Price= 12.00
             },
                  new Book
             {
                 Name="test book2",
                 Price= 12.00
             }
         };
        }

        public Book GetBookAuth() {
            return new Book
            {
                Name = "auth book2",
                Price = 200
            };
        }
        public Book GetBookNoAuth()
        {
            return new Book
            {
                Name = "no auth book2",
                Price = 401
            };
        }
        public Book GetProtectedBook()
        {
            return new Book
            {
                Name = "Protected",
                Price = 200
            };
        }
    }
}
