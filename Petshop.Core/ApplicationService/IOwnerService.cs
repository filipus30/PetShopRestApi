using System;
using System.Collections.Generic;
using Petshop.Core.Entity;

namespace Petshop.Core.ApplicationService
{
    
        public interface IOwnerService
        {
        public IEnumerable<Owner> GetOwners();


        }
    
}
