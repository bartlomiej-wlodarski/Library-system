using Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Logic.Services
{
    public class ClientService
    {
        private readonly LibraryContext context;

        public ClientService(LibraryContext context)
        {
            this.context = context;
        }

        public IEnumerable<Client> GetClients()
        {
            return context.Set<Client>();
        }

        public void AddClient(Client client)
        {
            context.Set<Client>().Add(client);
            context.SaveChanges();
        }

        public void EditClient(Client client)
        {
            Client _client = context.Set<Client>().FirstOrDefault(x => x.Id.Equals(client.Id));

            if (_client != null)
            {
                _client.Name = client.Name;
                _client.Surname = client.Surname;
                _client.Age = client.Age;

                context.SaveChanges();
            }
        }

        public void RemoveClient(int num)
        {
            Client client = context.Set<Client>().FirstOrDefault(x => x.Id.Equals(num));

            if (client != null)
            {
                context.Set<Client>().Remove(client);
                context.SaveChanges();
            }
        }

        public IEnumerable<Client> GetClientCatalog()
        {
            return context.Set<Client>();
        }

        public Client GetClient(int num)
        {
            return context.Set<Client>().FirstOrDefault(x => x.Id == num);
        }

        public int GetClientsNumber()
        {
            return context.Set<Client>().Count();
        }
    }
}
