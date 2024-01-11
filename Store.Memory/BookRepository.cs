namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book (1,"ISBN 12312-31231","D.Knuth","Art Of Programming","Description Art Of Programming",7.19m),
            new Book (2,"ISBN 12312-31232", "M.Fowler", "Refactoring","Description Refactoring",12.45m),
            new Book (3,"ISBN 12312-31233", "B.Kernigha, D.Ritchie", "C Programming Language", "Description C Programming Language", 14.98m),
        };


        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Title.Contains(query) ||
                                        book.Author.Contains(query)).ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
    }
}