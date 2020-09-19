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
    }
}
