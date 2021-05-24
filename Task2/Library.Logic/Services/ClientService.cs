using Data;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace Library.Logic.Services
{
    public class ClientService
    {
        private readonly LibraryDataContext context;

        public ClientService(LibraryDataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Clients> GetClients()
        {
            IQueryable<Clients> query = from clients in context.Clients
                                        select clients;

            return query;
            //return context.Clients;
        }

        public void AddClient(int Id, string Name, string Surname, int Age)
        {
            Clients client = new Clients
            {
                Id = Id,
                Name = Name,
                Surname = Surname,
                Age = Age
            };
            context.Clients.InsertOnSubmit(client);
            context.SubmitChanges();
        }

        public void EditClient(int Id, string Name, string Surname, int Age)
        {
            Clients client = context.Clients.FirstOrDefault(x => x.Id.Equals(Id));

            if (client != null)
            {
                client.Name = Name;
                client.Surname = Surname;
                client.Age = Age;

                context.SubmitChanges();
            }
        }

        public void RemoveClient(int num)
        {
            Clients client = context.Clients.FirstOrDefault(x => x.Id.Equals(num));

            if (client != null)
            {
                context.Clients.DeleteOnSubmit(client);
                context.SubmitChanges();
            }
        }

        public Clients GetClient(int num)
        {
            IQueryable<Clients> query = from clients in context.Clients
                                        where clients.Id == num
                                        select clients;

            return query.First();
            //return context.Clients.FirstOrDefault(x => x.Id == num);
        }

        public int GetClientsNumber()
        {
            IQueryable<Clients> query = from clients in context.Clients
                                        select clients;

            return query.Count();

            //return context.Clients.Count();
        }
    }
}
