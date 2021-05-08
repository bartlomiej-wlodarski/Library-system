using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data
{
    public abstract class Event
    {
        [Key] public int Id { get; set; }
        public Client Client { get; set; }
        public DateTime Date { get; set; }
        //public State State { get; set; }
        public Book Book { get; set; }

        protected Event(int id, Client client, DateTime date, Book book)
        {
            Id = id;
            Client = client;
            Date = date;
            Book = book;
        }
    }
}
