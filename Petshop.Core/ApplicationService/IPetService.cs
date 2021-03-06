﻿using System;
using System.Collections.Generic;
using Petshop.Core.Entity;

namespace Petshop.Core.ApplicationService
{
    public interface IPetService
    {
        public List<Pet> GetPets();
        public Pet CreatePet(string Name,PetType Type,DateTime BirthDate,DateTime SoldDate,string Color,Owner owner,double Price);
        public Pet DeletePet(int id);
        public List<Pet> GetPetsByPrice();
        public Pet UpdatePet(int id, Pet pet);
        public Pet GetPetById(int id);
        public Pet NewPet(Pet pet);
        public List<Pet> GetPetsFiltered(FilterModel filter);
        

    }
}
