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


        public Pet CreatePet(string Name, PetType Type, DateTime BirthDate, DateTime SoldDate, string Color, Owner Owner, double Price)
        {
            Pet p = new Pet
            {
                Name = Name,
                Type = Type,
                Birthdate = BirthDate,
                SoldDate = SoldDate,
                Color = Color,
                PetOwner = Owner,
                Price = Price
            };
            _petRepository.CreatePet(p);
            return p;
        }

        public Pet DeletePet(int id)
        {
           Pet p = _petRepository.FindPetById(id);
            if (p == null)
            {
                throw new Exception("Pet not found");
            }
            else
            {
                return _petRepository.RemovePet(id, p);
            }
        }

        public Pet GetPetById(int id)
        {
            Pet p = _petRepository.FindPetById(id);
           if(p == null)
            {
                throw new InvalidDataException("Wrong Id");
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

        //public IEnumerable<Pet> GetPetsByType(string type)
        //{
        //    List<Pet> filtered = new List<Pet>();
        //    filtered = GetPets().FindAll(x => x.Type.ToLower().Equals(type.ToLower()));
        //    return filtered;
        //}

        public Pet UpdatePet(int id, Pet pet)
        {
            var p = _petRepository.UpdatePet(id, pet);
            if (p == null)
            {
                throw new Exception(message: "pet not found");
            }
            else
            {
                return _petRepository.UpdatePet(id, pet);
            }
        }
        public List<Pet> GetPetsFiltered(FilterModel filter)
        {
            string value = filter.SearchValue;
            string filterby = filter.SearchTerm.ToLower();
            switch (filterby)
            {
                case "name":
                    var v = _petRepository.FindPetsByName(value).ToList();
                    if (v.Count == 0)
                        throw new Exception(message: "no results found");
                    return v;
                case "color":
                    var b = _petRepository.FindPetsByColor(value).ToList();
                    if (b.Count == 0)
                        throw new Exception(message: "no results found");
                    return b;
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
                _petRepository.CreatePet(pet);
                return pet;
            }

        }

        
    }
}
