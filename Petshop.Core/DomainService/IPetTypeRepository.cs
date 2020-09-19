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
        public PetType RemovePetType(int id, PetType pet);
        public IEnumerable<PetType> FindPetTypesByName(string name);
       
    }
}
