using System;
using System.Collections.Generic;
using Petshop.Core.Entity;

namespace Petshop.Core.DomainService
{
    public interface IOwnerRepository
    {
        public IEnumerable<Owner> ReadOwners();
    }
}
