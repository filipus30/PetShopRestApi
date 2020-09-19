using System;
using System.Collections.Generic;
using Petshop.Core.Entity;

namespace Petshop.Core.DomainService
{
    public interface IPetTypeRepository
    {
        public List<PetType> ReadPetTypes();
        public PetType FindPetTypeById(int id);
        public PetType AddPetType(PetType p);
        public PetType UpdatePetType(int id, string name);
       
    }
}
