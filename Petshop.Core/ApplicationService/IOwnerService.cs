using System;
using System.Collections.Generic;
using Petshop.Core.Entity;

namespace Petshop.Core.ApplicationService
{
    
        public interface IOwnerService
        {
        public IEnumerable<Owner> GetOwners();
        public List<Owner> GetOwnersFiltered(FilterModel filter);
        public Owner GetOwnerById(int id);
        public Owner NewOwner(Owner o);
        public Owner UpdateOwnerAddress(int id, string address);


        }
    
}
