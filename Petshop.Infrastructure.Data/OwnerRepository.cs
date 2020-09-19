using System;
using System.Collections.Generic;
using System.Linq;
using Petshop.Core.DomainService;
using Petshop.Core.Entity;

namespace Petshop.Infrastructure.Data
{
   
        public class OwnerRepository : IOwnerRepository
        {
        public Owner AddOwner(Owner o)
        {
            return FakeDB.AddOwner(o);
        }

        public Owner FindOwnerById(int id)
        {
            return FakeDB.FindOwnerById(id);
        }

        public IEnumerable<Owner> FindOwnersByName(string name)
        {
            return FakeDB.GetOwnersFilteredByName(name);
        }

        public IEnumerable<Owner> ReadOwners()
        {
           return FakeDB.GetOwnerData();
        }
    }
    
}
