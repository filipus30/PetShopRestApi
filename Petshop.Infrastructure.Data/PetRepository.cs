using System;
using System.Collections.Generic;
using Petshop.Core.Entity;
using Petshop.Infrastructure.Data;

namespace Petshop.Core.DomainService.Implementation
{
    public class PetRepository : IPetRepository
    {
        public PetRepository()
        {
           
        }

        public void AddPet(Pet p)
        {
            FakeDB.AddPet(p);
        }

        public Pet FindPetById(int id)
        {
           return FakeDB.FindPetById(id);
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.GetPetsData();
        }

        public void RemovePet(int id)
        {
            FakeDB.RemovePet(id);
        }
        public Pet UpdatePetPrice(int id,double price)
        {
          return  FakeDB.UpdatePetPrice(id,price);
        }
    }
}
