using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Petshop.Core.DomainService;
using Petshop.Core.Entity;

namespace Petshop.Infrastructure.SQL.Repositories
{
    public class OwnerSQLRepository : IOwnerRepository
    {
        private readonly PetshopDBContext _ctx;

        public OwnerSQLRepository(PetshopDBContext ctx)
        {
            _ctx = ctx;
        }

        public Owner AddOwner(Owner o)
        { 
            var ownerCreated = _ctx.Owner.Add(o);
            _ctx.SaveChanges();
            return ownerCreated.Entity;
        }

        public Owner FindOwnerById(int id)
        {
               return _ctx.Owner.AsNoTracking()
                 .Include(po => po.PetsOwned)
                 .FirstOrDefault(o => o.OwnerId == id);
        }

        public IEnumerable<Owner> FindOwnersByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Owner> ReadOwners()
        {
            var list = new List<Owner>();
            list = _ctx.Owner
                .Include(o => o.PetsOwned)
                .ToList();

            return list;

        }

        public Owner RemoveOwner(int id, Owner o)
        {
            var ownerDelete = FindOwnerById(id);
            _ctx.Owner.Remove(FindOwnerById(id));
            _ctx.SaveChanges();
            return ownerDelete;
        }

        public Owner UpdateOwner(int id, Owner owner)
        {
            throw new NotImplementedException();
        }
    }
}
