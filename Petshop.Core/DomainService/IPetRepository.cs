using System;
using System.Collections.Generic;
using Petshop.Core.Entity;

namespace Petshop.Core
{
    public interface IPetRepository
    {
        public IEnumerable<Pet> ReadPets();
        public void AddPet(Pet p);
        public void RemovePet(int id);
        public Pet UpdatePetPrice(int id, double price);
        public Pet FindPetById(int id);
    }
}
