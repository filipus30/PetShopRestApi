using System;
using System.Collections.Generic;
using Petshop.Core.DomainService;
using Petshop.Core.Entity;

namespace Petshop.Infrastructure.SQL.Repositories
{
    public class PetTypeSQLRepository : IPetTypeRepository
    {
        private readonly PetshopDBContext _ctx;

        public PetTypeSQLRepository(PetshopDBContext ctx)
        {
            _ctx = ctx;
        }

        public PetType AddPetType(PetType p)
        {
            var petTypeCreated = _ctx.PetType.Add(p);
            _ctx.SaveChanges();
            return petTypeCreated.Entity;
        }

        public PetType FindPetTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PetType> FindPetTypesByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<PetType> ReadPetTypes()
        {
            throw new NotImplementedException();
        }

        public PetType RemovePetType(int id, PetType pet)
        {
            throw new NotImplementedException();
        }

        public PetType UpdatePetType(int id, string name)
        {
            throw new NotImplementedException();
        }
    }
}
