using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.API;

namespace Model
{
    public interface IBuyerViewModel
    {
        void AddBuyer();
        void UpdateBuyer();
        void DeleteBuyer();
        void RefreshBuyers();
    }
}
