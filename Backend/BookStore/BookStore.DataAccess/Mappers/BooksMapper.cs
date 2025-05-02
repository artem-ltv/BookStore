using BookStore.Core.Models;
using BookStore.DataAccess.Entities;

namespace BookStore.DataAccess.Mappers
{
    public static class BooksMapper
    {
        public static Book MapToBook(this BookEntity entity)
        {
            var book = Book.Create(entity.Id, entity.Title, entity.Description, entity.Price);

            return book.Book;
        }
    }
}
