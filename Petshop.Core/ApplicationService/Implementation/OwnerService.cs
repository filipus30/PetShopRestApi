using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Petshop.Core.DomainService;
using Petshop.Core.Entity;

namespace Petshop.Core.ApplicationService.Implementation
{
    
        public class OwnerService : IOwnerService
        {
            private IOwnerRepository _ownerRepository;
            public OwnerService(IOwnerRepository ownerRepository)
            {
                _ownerRepository = ownerRepository;
            }

        public IEnumerable<Owner> GetOwners()
        {
           var v = _ownerRepository.ReadOwners();
             if (v == null)

                    throw new Exception("No Owners Found");
                else
                {
                    return v.ToList();
                }
        }
    }
    
}

