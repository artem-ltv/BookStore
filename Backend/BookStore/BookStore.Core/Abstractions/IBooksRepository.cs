using BookStore.Core.Models;

namespace BookStore.Core.Abstractions
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> Get();
        Task<Guid> Create(Book book);
        Task<Guid> Update(Guid id, string title, string description, decimal price);
        Task<Guid> Delete(Guid id);
    }
}
