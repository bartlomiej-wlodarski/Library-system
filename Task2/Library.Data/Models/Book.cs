using System;

namespace Library.Data
{
    public class Book
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public BookGenre Genre { get; set; }
        public DateTime Date_of_publication { get; set; }
        public State State { get; set; }

        public Book(int id, string title, string author, int pages, BookGenre genre, DateTime date_of_publication)
        {
            Id = id;
            Title = title;
            Author = author;
            Pages = pages;
            Genre = genre;
            Date_of_publication = date_of_publication;
            State = new State();
        }
    }
}
