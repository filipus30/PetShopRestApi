using System;
using System.Collections.Generic;
using Petshop.Core.Entity;

namespace Petshop.Core.ApplicationService
{
    public interface IPetTypeService
    {
        
        public List<PetType> GetPetTypes();
        public PetType GetPetTypeById(int id);
        public PetType CreatePetType(PetType petType);
        public PetType UpdatePetType(int id, string name);
        public PetType DeletePetType(int id);
        public List<PetType> GetPetsTypesFiltered(FilterModel filter);
    }
}
