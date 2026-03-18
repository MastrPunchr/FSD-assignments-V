namespace OOPlesson;

public class Book
{
    private string title;
    private string author;
    private string isbn;
    private bool isAvailable;

    public Book(string bookTitle, string bookAuthor, string bookISBN, bool inStock)
    {
        this.title = bookTitle;
        this.author = bookAuthor;
        this.isbn = bookISBN;
        this.isAvailable = inStock;
    }

    public override string ToString()
    {
        string availability = isAvailable ? "Available" : "Not Available";
        return $"Title: {title}, Author: {author}, Availability: {availability}";
    }
}