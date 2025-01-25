
using System.ComponentModel.DataAnnotations;
namespace LibraryManagementSystem.Domain;

public class Author : BaseModel
{
    // DO NOT MODIFY ABOVE THIS LINE
    
    public string? Name { get; set; }

    
    // An author may have written multiple books.
    // This will make the relationship between Book and Author many-to-many
    public ICollection<Book> Books { get; set; } = new List<Book>();
    
    // DO NOT MODIFY BELOW THIS LINE

    public string BooksToString()
    {
        // If there are no books, return an empty string
    if (!Books.Any())
        return string.Empty;

    var bookTitles = Books.Select(book => book.Title ?? "unknown").ToList();

    // If there is only one book, return its title
    if (bookTitles.Count == 1)
        return bookTitles[0];

    // If there are multiple books, format them properly
    return string.Join(", ", bookTitles.Take(bookTitles.Count - 1)) + " and " + bookTitles.Last();
        // DO NOT MODIFY BELOW THIS LINE
    }
}