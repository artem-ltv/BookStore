namespace BookStore.Core.Models
{
    public class Book
    {
        public const int MAX_TITLE_LENGTH = 150;

        public Guid Id { get; }
        public string Title {  get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price {  get; }

        private Book(Guid id, string title, string description, decimal price) 
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }

        public static (Book book, string Error) Create(Guid id, string title, string description, decimal price)
        {
            var error = string .Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH) 
            {
                error = "Error";
            }

            var book = new Book(id, title, description, price);

            return (book, error);
        }
    }
}
