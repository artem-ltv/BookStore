namespace BookStore.Core.Models
{
    public class Book
    {
        public const int MAX_TITLE_LENGTH = 140;

        public Guid Id { get; }
        public string Title {  get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }

        private Book (Guid id, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }

        public static (Book Book, string Error) Create(Guid id, string title, string description, decimal price)
        {
            var error = string.Empty;

            if(string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = $"Title can't be empty or longer then {MAX_TITLE_LENGTH} symbols.";
            }

            var book = new Book(id, title, description, price);

            return (book, error);
        }
    }
}
