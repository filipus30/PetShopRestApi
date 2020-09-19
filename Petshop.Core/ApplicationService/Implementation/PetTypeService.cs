using System;
using System.Collections.Generic;
using System.IO;
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
          var p =  _petTypeRepository.ReadPetTypes();
            if (p == null)
            {
                throw new Exception("No PetTypes Found");
            }
            else
            {
                return p;
            }
        }

        public PetType GetPetTypeById(int id)
        {
            PetType p = _petTypeRepository.FindPetTypeById(id);
            if (p == null)
            {
                throw new InvalidDataException("Wrong Id");
            }
            else
            {
                return p;
            }
           
        }

        public PetType CreatePetType(PetType petType)
        {
          
            if(petType.PetTypeName == null)
            {
                throw new InvalidDataException(message: "Name cannot be null");
            }
            else
            {
                return _petTypeRepository.AddPetType(petType);
            }
        }

        public PetType UpdatePetType(int id, string name)
        {
            var p = _petTypeRepository.FindPetTypeById(id);
            if (p == null)
            {
                throw new Exception(message: "pet not found");
            }
            else
            {
                return _petTypeRepository.UpdatePetType(id, name);
            }
        }
    }
}
