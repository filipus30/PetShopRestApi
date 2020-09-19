using System;
using System.Collections.Generic;
using System.Linq;
using Petshop.Core.DomainService;
using Petshop.Core.Entity;

namespace Petshop.Infrastructure.Data
{
   
        public class OwnerRepository : IOwnerRepository
        {  

        public IEnumerable<Owner> ReadOwners()
        {
           return FakeDB.GetOwnerData();
        }
    }
    
}
