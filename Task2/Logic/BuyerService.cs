using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Data.API;

namespace Service
{
    public class BuyerService
    {
        private IRepository repository;
        public BuyerService(IRepository repository)
        {
            this.repository = repository;
        }
        public BuyerService()
        {
            this.repository = new Repository();
        }
        public IEnumerable<IBuyer> GetBuyers()
        {
            return repository.GetBuyers();
        }

        public IBuyer GetBuyer(string Phone)
        {
            return repository.GetBuyer(Phone);
        }

        public bool AddBuyer(string Name, string Surname, string Phone)
        {
            return repository.AddBuyer(Name, Surname, Phone);
        }

        public bool UpdateBuyer(int id, string Name, string Surname, string Phone)
        {
            return repository.UpdateBuyer(id, Name, Surname, Phone);
        }

        public bool DeleteBuyer(string Phone)
        {
            return repository.DeleteBuyer(Phone);
        }
    }
}
