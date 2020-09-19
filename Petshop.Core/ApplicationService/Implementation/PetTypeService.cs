using System;
using System.Collections.Generic;
using Petshop.Core.DomainService;
using Petshop.Core.Entity;

namespace Petshop.Core.ApplicationService.Implementation
{
    public class PetTypeService : IPetTypeService
    {
        private IPetTypeRepository _petTypeRepository;
        public PetTypeService(IPetTypeRepository PetTypeRepository)
        {
            _petTypeRepository = PetTypeRepository;
        }
        public List<PetType> GetPetTypes()
        {
           return  _petTypeRepository.ReadPetTypes();
        }
    }
}
