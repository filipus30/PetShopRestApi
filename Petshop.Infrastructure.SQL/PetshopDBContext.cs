using System;
using Microsoft.EntityFrameworkCore;
using Petshop.Core.Entity;

namespace Petshop.Infrastructure.SQL
{
    public class PetshopDBContext : DbContext
    {
        public PetshopDBContext(DbContextOptions<PetshopDBContext> opt) : base(opt) {}
        public DbSet<Pet> Pet { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<PetType> PetType { get; set; }

    }
}
