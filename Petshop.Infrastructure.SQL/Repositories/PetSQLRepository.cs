using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Petshop.Core;
using Petshop.Core.Entity;

namespace Petshop.Infrastructure.SQL.Repositories
{
    public class PetSQLRepository : IPetRepository
    {
        private readonly PetshopDBContext _ctx;

        public PetSQLRepository(PetshopDBContext ctx)
        {
            _ctx = ctx;
        }
        public Pet CreatePet(Pet p)
        {
            if (p.Type != null && p.PetOwner != null)
            {
                _ctx.Attach(p.Type).State = EntityState.Unchanged;
                _ctx.Attach(p.PetOwner).State = EntityState.Unchanged;
            }
            var petCreated = _ctx.Pet.Add(p);
            _ctx.SaveChanges();
            return petCreated.Entity;
        }


        public Pet FindPetById(int id)
        {
            return _ctx.Pet
                .AsNoTracking()
                .Include(c => c.PetOwner)
                .Include(d => d.Type)
                .FirstOrDefault(c => c.ID == id);
        }

        public IEnumerable<Pet> FindPetsByColor(string color)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> FindPetsByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> ReadPets()
        {
            var list = new List<Pet>();
//list.Count() = _ctx.Pet.Count();
            list = _ctx.Pet
                .Include(o => o.PetOwner)
                .Include(t => t.Type)
                .ToList();
            return list;
        }

        public Pet RemovePet(int id, Pet pet)
        {
            var petDelete = FindPetById(id);
            _ctx.Pet.Remove(FindPetById(id));
            _ctx.SaveChanges();
            return petDelete;
        }

        public Pet UpdatePet(int id, Pet pet)
        {
            var petEntry = _ctx.Update(pet);
            _ctx.SaveChanges();
            return petEntry.Entity;
        }
    }
}
