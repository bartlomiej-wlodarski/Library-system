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
            return context.Clients;
        }

        public void AddClient(Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();
        }

        public void EditClient(Client client)
        {
            Client _client = context.Clients.FirstOrDefault(x => x.Id.Equals(client.Id));

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
            Client client = context.Clients.FirstOrDefault(x => x.Id.Equals(num));

            if (client != null)
            {
                context.Clients.Remove(client);
                context.SaveChanges();
            }
        }

        public IEnumerable<Client> GetClientCatalog()
        {
            return context.Clients;
        }

        public Client GetClient(int num)
        {
            return context.Clients.FirstOrDefault(x => x.Id == num);
        }
    }
}
