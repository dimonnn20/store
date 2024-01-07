namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book (1,"ISBN 12312-31231","D.Knuth","Art Of Programming"),
            new Book (2,"ISBN 12312-31232", "M.Fowler", "Refactoring"),
            new Book (3,"ISBN 12312-31233", "B.Kernigha, D.Ritchie", "C Programming Language"),
        };

        public Book[] GetAllByTitle(string titlePart)
        {
            return books.Where(book => book.Title.Contains(titlePart)).ToArray();
        }
    }
}