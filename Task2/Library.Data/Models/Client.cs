using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Data
{
    public class Client
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Client(int id, string name, string surname, int age)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
