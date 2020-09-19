using System;
using System.Collections.Generic;
using Petshop.Core.Entity;

namespace Petshop.Core.DomainService
{
    public interface IPetTypeRepository
    {
        public List<PetType> ReadPetTypes();
    }
}
