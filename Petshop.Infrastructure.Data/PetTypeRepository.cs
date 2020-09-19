using System;
using System.Collections.Generic;
using Petshop.Core.DomainService;
using Petshop.Core.Entity;

namespace Petshop.Infrastructure.Data
{
    public class PetTypeRepository : IPetTypeRepository
    {
        public List<PetType> ReadPetTypes()
        {
           return FakeDB.GetPetsTypeData();
        }

        public PetType FindPetTypeById(int id)
        {
            return FakeDB.FindPetTypeById(id);
        }

        public PetType AddPetType(PetType p)
        {
           return FakeDB.AddPetType(p);
        }

        public PetType UpdatePetType(int id, string name)
        {
            return FakeDB.UpdatePetType(id, name);
        }

        public PetType RemovePetType(int id, PetType pet)
        {
            return FakeDB.RemovePetType(id, pet);
        }

        public IEnumerable<PetType> FindPetTypesByName(string name)
        {
            return FakeDB.GetPetTypesFilteredByName(name);
        }
    }
}
