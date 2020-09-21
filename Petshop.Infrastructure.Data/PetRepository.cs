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

        public IEnumerable<Pet> FindPetsByColor(string color)
        {
            return FakeDB.GetPetsFilteredByColor(color);
        }

        public IEnumerable<Pet> FindPetsByName(string name)
        {
            return FakeDB.GetPetsFilteredByName(name);
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.GetPetsData();
        }

        public Pet RemovePet(int id,Pet pet)
        {
           return FakeDB.RemovePet(id,pet);
        }
        public Pet UpdatePet(int id,Pet pet)
        {
          return  FakeDB.UpdatePet(id,pet);
        }
    }
}
