using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Book
    {
        public int Id { get; }
        public string Title { get; }
        public string Isbn { get; }
        public string Author { get; }
        public Book(int id,string isbn, string author, string title)
        {
            Id = id;
            Title = title;
            Isbn = isbn;
            Author = author;
        }
    }
}
