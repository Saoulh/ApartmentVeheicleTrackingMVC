using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IOwnerRepo
    {
        IEnumerable<Owners> GetOwners();

        bool AddOwner(Owners Owner);
        bool Update(Owners Owner);
        bool Delete(int OwnerID);
    }
}
