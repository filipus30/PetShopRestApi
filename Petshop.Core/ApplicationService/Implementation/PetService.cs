using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Petshop.Core.Entity;

namespace Petshop.Core.ApplicationService.Implementation
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;
        public PetService(IPetRepository PetRepository)
        {
            _petRepository = PetRepository;
        }


        public Pet CreatePet(string Name, string Type, DateTime BirthDate, DateTime SoldDate, string Color, string PreviousOwner, double Price)
        {
            Pet p = new Pet
            {
                Name = Name,
                Type = Type,
                Birthdate = BirthDate,
                SoldDate = SoldDate,
                Color = Color,
                PreviousOwner = PreviousOwner,
                Price = Price
            };
            _petRepository.AddPet(p);
            return p;
        }

        public void DeletePet(int id)
        {
            _petRepository.RemovePet(id);
        }

        public Pet GetPetById(int id)
        {
            Pet p = _petRepository.FindPetById(id);
           if(p == null)
            {
                throw new Exception("Wrong Id");
            }
           else
            {
                return p;
            }
        }

        public List<Pet> GetPets()
        {
            var v = _petRepository.ReadPets();
            if (v == null)

                throw new Exception("No Pets Found");
            else
                {
                return v.ToList();
                }
                
        }

        public List<Pet> GetPetsByPrice()
        {
            List<Pet> SortedList = GetPets().OrderBy(o => o.Price).ToList();
            return SortedList;
        }

        public IEnumerable<Pet> GetPetsByType(string type)
        {
            List<Pet> filtered = new List<Pet>();
            filtered = GetPets().FindAll(x => x.Type.ToLower().Equals(type.ToLower()));
            return filtered;
        }

        public void UpdatePetPrice(int id, double price)
        {
            _petRepository.UpdatePetPrice(id, price);
        }
        public List<Pet> SearchForPet(FilterModel filter)
        {
            string searchValue = filter.SearchValue;
            string toSearchString = filter.SearchTerm.ToLower();
            switch (toSearchString)
            {
                case "name":
                    return _petRepository.ReadPets().ToList();
                case "color":
                    return _petRepository.ReadPets().ToList();
                default:
                    throw new InvalidDataException(message: "search for name or color");
            }
        }

        public Pet NewPet(Pet pet)
        {
            if (pet.Name == null)
            {
                throw new InvalidDataException(message: "Name cannot be null");
            }
            else
            {
                _petRepository.AddPet(pet);
                return pet;
            }

        }
    }
}
