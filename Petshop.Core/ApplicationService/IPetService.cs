using System;
using System.Collections.Generic;
using Petshop.Core.Entity;

namespace Petshop.Core.ApplicationService
{
    public interface IPetService
    {
        public List<Pet> GetPets();
        public Pet CreatePet(string Name,string Type,DateTime BirthDate,DateTime SoldDate,string Color,string PreviousOwner,double Price);
        public void DeletePet(int id);
        public IEnumerable<Pet> GetPetsByType(string type);
        public List<Pet> GetPetsByPrice();
        public void UpdatePetPrice(int id, double price);
        public Pet GetPetById(int id);
        public Pet NewPet(Pet pet);
        
    }
}
