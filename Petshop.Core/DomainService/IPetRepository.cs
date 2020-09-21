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
        public Pet UpdatePet(int id, Pet pet);
        public Pet FindPetById(int id);
        public IEnumerable<Pet> FindPetsByName(string name);
        public IEnumerable<Pet> FindPetsByColor(string color);
    }
}
