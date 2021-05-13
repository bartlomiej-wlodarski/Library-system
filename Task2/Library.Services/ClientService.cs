using Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Services
{
    public class ClientService
    {
        public IEnumerable<Client> GetClients()
        {
            using (var context = new LibraryDataContext())
            {
                return context.Client.ToList();
            }
        }

        static public Client GetClient(string fName, string lName)
        {
            using (var context = new LibraryDataContext())
            {
                foreach (Client r in context.Client.ToList())
                {
                    if (r.Name.Equals(fName) && r.Surname.Equals(lName))
                    {
                        return r;
                    }
                }
                return null;
            }
        }

        public Client GetClientById(int id)
        {
            using (var context = new LibraryDataContext())
            {
                foreach (Client r in context.Client.ToList())
                {
                    if (r.Id.Equals(id))
                    {
                        return r;
                    }
                }
                return null;
            }
        }

        static public int GetMaxId()
        {
            using (var context = new LibraryDataContext())
            {
                if (context.Client.Count() == 0)
                    return 0;
                else
                    return context.Client.OrderByDescending(p => p.Id).First().Id;
            }
        }

        static public bool AddClient(string fName, string lName)
        {
            using (var context = new LibraryDataContext())
            {
                if (GetClient(fName, lName) == null && !fName.Equals(null) && !lName.Equals(null))
                {
                    Client newClient = new Client
                    {
                        Name = fName,
                        Surname = lName
                    };
                    context.Client.InsertOnSubmit(newClient);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        static public bool UpdateClient(int id, string fName, string lName)
        {
            using (var context = new LibraryDataContext())
            {
                Client Client = context.Client.SingleOrDefault(i => i.Id == id);
                if (GetClient(fName, lName) == null) 
                {
                    Client.Name = fName;
                    Client.Surname = lName;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        static public bool DeleteClient(string fName, string lName)
        {
            using (var context = new LibraryDataContext())
            {
                Client Client = context.Client.SingleOrDefault(i => i.Name.Equals(fName) 
                        && i.Name.Equals(lName));
                Eventervice.DeleteEventForClient(Client.Id);
                context.Client.DeleteOnSubmit(Client);
                context.SubmitChanges();
                return true;
            }
        }
    }
}
