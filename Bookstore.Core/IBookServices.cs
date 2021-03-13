﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public interface IBookServices
    {
        List<Book> GetBooks();
        Book GetBookAuth();
        Book GetBookNoAuth();
        Book GetProtectedBook();


    }
}
