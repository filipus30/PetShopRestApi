using System;
using System.Collections.Generic;
using Petshop.Core.Entity;

namespace Petshop.Core
{
    public interface IPetRepository
    {
        public IEnumerable<Pet> ReadPets();
        public void AddPet(Pet p);
        public Pet RemovePet(int id,Pet pet);
        public Pet UpdatePetPrice(int id, double price);
        public Pet FindPetById(int id);
    }
}
