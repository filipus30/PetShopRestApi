using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Petshop.Core.Entity;

namespace Petshop.Infrastructure.Data
{
    public static class FakeDB
    {
       
        public static List<Pet> filtered = new List<Pet>();
        public static List<PetType> filteredTypes = new List<PetType>();
        public static List<Owner> filteredOwners = new List<Owner>();
        public static List<Pet> PetsData = new List<Pet>();
        public static List<PetType> allPetTypes = new List<PetType>();
        public static int theOwnerCount { get; set; }
        public static List<Owner> allTheOwners = new List<Owner>();
        private static int Id = 1;
        private static int TypeId = 1;
        private static int OwnerId = 1;



        public static void InitData()
        {
            allTheOwners = new List<Owner>
            {
                new Owner{OwnerFirstName = "Bobby", OwnerLastName = "Tobby", OwnerAddress = "Street 4, 6700 Esbjerg", OwnerPhoneNr = "+45 1234 5678",OwnerId = OwnerId++},
                new Owner{OwnerFirstName = "John", OwnerLastName = "Paul", OwnerAddress = "Alley 6, 6705 Esbjerg Ø", OwnerPhoneNr = "+45 2549 6254",OwnerId = OwnerId++},
                new Owner{OwnerFirstName = "Anne", OwnerLastName = "Saunderson", OwnerAddress = "Kongensgade 33, 6700 Esbjerg", OwnerPhoneNr = "+45 8761 1624",OwnerId = OwnerId++},
                new Owner{OwnerFirstName = "Belinda", OwnerLastName = "Twain", OwnerAddress = "Nørregade 14, 6700 Esbjerg", OwnerPhoneNr = "+45 7365 5976",OwnerId = OwnerId++},
                new Owner{OwnerFirstName = "Roald", OwnerLastName = "Schwartz", OwnerAddress = "Lark Road 26, 6715 Esbjerg N", OwnerPhoneNr = "+45 7618 5234",OwnerId = OwnerId++},
                new Owner{OwnerFirstName = "Shiela", OwnerLastName = "Jesperson", OwnerAddress = "Daniels Road 45, 6700 Esbjerg", OwnerPhoneNr = "+45 7831 2561",OwnerId = OwnerId++},
                new Owner{OwnerFirstName = "Hansi", OwnerLastName = "Thompson", OwnerAddress = "Spooky Road 666, 6705 Esbjerg Ø", OwnerPhoneNr = "+45 1465 2845",OwnerId = OwnerId++},
                new Owner{OwnerFirstName = "Victoria", OwnerLastName = "Marks", OwnerAddress = "Birkelunden 8, 6705 Esbjerg Ø", OwnerPhoneNr = "+45 5956 4651",OwnerId = OwnerId++},
                new Owner{OwnerFirstName = "Niels", OwnerLastName = "Billson", OwnerAddress = "Folevej 3, 6715 Esbjerg N", OwnerPhoneNr = "+45 7286 9435",OwnerId = OwnerId++},
                new Owner{OwnerFirstName = "Emanuelle", OwnerLastName = "Johnson", OwnerAddress = "Foldgårdsvej 17, 6715 Esbjerg N", OwnerPhoneNr = "+45 7315 4255",OwnerId = OwnerId++}
            };
            allPetTypes = new List<PetType>
            {
                new PetType {PetTypeName = "Cat",PetTypeId = TypeId++},
                new PetType {PetTypeName = "Dog",PetTypeId = TypeId++},
                new PetType {PetTypeName = "Horse",PetTypeId = TypeId++},
                new PetType {PetTypeName = "Fish",PetTypeId = TypeId++},
                new PetType {PetTypeName = "Gerbil",PetTypeId = TypeId++},
                new PetType {PetTypeName = "Hamster",PetTypeId = TypeId++},
                new PetType {PetTypeName = "Rabbit",PetTypeId = TypeId++}
            };

            PetsData.Add(new Pet
            {
                Type = allPetTypes[1],
                Name = "Bob",
                Birthdate = DateTime.Now.AddYears(-5),
                SoldDate = DateTime.Now,
                Color = "Brown",
                PetOwner = allTheOwners[6],
                Price = 100,
                ID = Id++

            }); ;
            PetsData.Add(new Pet
            {
                Type = allPetTypes[1],
                Name = "Flamingo",
                Birthdate = DateTime.Now.AddYears(-3),
                SoldDate = DateTime.Now.AddYears(-1),
                Color = "White",
                PetOwner = allTheOwners[6],
                Price = 1000,
                ID = Id++

            }); ;
            PetsData.Add(new Pet
            {
                Type = allPetTypes[5],
                Name = "John",
                Birthdate = DateTime.Now.AddYears(-8),
                SoldDate = DateTime.Now.AddYears(-3),
                Color = "White",
                PetOwner = allTheOwners[5],
                Price = 10,
                ID = Id++

            }) ; ;
            PetsData.Add(new Pet
            {
                Type = allPetTypes[1],
                Name = "Lucy",
                Birthdate = DateTime.Now.AddYears(-4),
                SoldDate = DateTime.Now.AddYears(-2),
                Color = "White",
                PetOwner = allTheOwners[4],
                Price = 400,
                ID = Id++

            }); ;
            PetsData.Add(new Pet
            {
                Type = allPetTypes[1],
                Name = "Hector",
                Birthdate = DateTime.Now.AddYears(-2),
                SoldDate = DateTime.Now.AddYears(-1),
                Color = "Brown",
                PetOwner = allTheOwners[3],
                Price = 2000,
                ID = Id++

            }); ;
            PetsData.Add(new Pet
            {
                Type = allPetTypes[3],
                Name = "Thomas",
                Birthdate = DateTime.Now.AddYears(-3),
                SoldDate = DateTime.Now.AddYears(-2),
                Color = "Green",
                PetOwner = allTheOwners[2],
                Price = 500,
                ID = Id++

            }); ;
            PetsData.Add(new Pet
            {
                Type = allPetTypes[2],
                Name = "Nick",
                Birthdate = DateTime.Now.AddYears(-3),
                SoldDate = DateTime.Now.AddYears(-2),
                Color = "Black & White",
                PetOwner = allTheOwners[1],
                Price = 200,
                ID = Id++

            }); ;

            
           
           

        }

        public static List<PetType>GetPetsTypeData()
        {
           
            return allPetTypes;
        }

        
        public static IEnumerable<Pet> GetPetsData()
        {
            List<Pet> list = new List<Pet>();
            var d = PetsData;
            foreach (Pet p in d)
            {
                list.Add(new Pet
                {
                    Birthdate = p.Birthdate,
                    Color = p.Color,
                    Name = p.Name,
                    ID = p.ID,
                    PetOwner = null,
                    Price = p.Price,
                    SoldDate = p.SoldDate,
                    Type = p.Type
                });
            }
            return list;
        }
        public static List<Owner> GetOwnerData()
        {
            return allTheOwners;
        }
        public static Pet AddPet(Pet p)
        {
            p.ID = Id++;
            PetsData.Add(p);
            return p;
        }
        public static PetType AddPetType(PetType p)
        {
            p.PetTypeId = TypeId++;
            allPetTypes.Add(p);
            return p;
        }
        public static Owner AddOwner(Owner o)
        {
            o.OwnerId = OwnerId++;
            allTheOwners.Add(o);
            return o;
        }
        public static Pet RemovePet(int id,Pet pet)
        {
            PetsData.Remove(pet);
            return pet;
        }
        public static PetType RemovePetType(int id,PetType pet)
        {
            allPetTypes.Remove(pet);
            var v = PetsData.FindAll(x => x.Type == pet);
            foreach (Pet p in v)
            {
                p.Type = null;
            }
            return pet;
        }
        public static Owner RemoveOwner(int id,Owner o)
        {
            allTheOwners.Remove(o);
           var v = PetsData.FindAll(x => x.PetOwner == o);
            foreach(Pet p in v)
            {
                p.PetOwner = null;
            }
            return o;
        }
        public static Pet UpdatePet(int id,Pet pet)
        {
            var obj = PetsData.FirstOrDefault(x => x.ID == id);
            if (obj != null)
            {
                obj.Price = pet.Price;
                obj.Birthdate = pet.Birthdate;
                obj.Color = pet.Color;
                obj.Name = pet.Name;
                obj.PetOwner = pet.PetOwner;
                obj.SoldDate = pet.SoldDate;
                obj.Type = pet.Type;
            }
            return obj;
        }
        public static PetType UpdatePetType(int id,string name)
        {
            var obj = allPetTypes.FirstOrDefault(x => x.PetTypeId == id);
            if (obj != null) obj.PetTypeName = name;
            return obj;

        }
        public static Owner UpdateOwner(int id,Owner owner)
        {
            var obj = allTheOwners.FirstOrDefault(x => x.OwnerId == id);
            if (obj != null)
            {
                obj.OwnerAddress = owner.OwnerAddress;
                obj.OwnerFirstName = owner.OwnerFirstName;
                obj.OwnerLastName = owner.OwnerLastName;
                obj.OwnerPhoneNr = owner.OwnerPhoneNr;
                obj.PetsOwned = owner.PetsOwned;
            }
            return owner;
        }
        public static Pet FindPetById(int id)
        {
            Pet pet = PetsData.Find(x => x.ID == id);
            return pet;
        }

        public static PetType FindPetTypeById(int id)
        {
            PetType pet = allPetTypes.Find(x => x.PetTypeId == id);
            PetType petcloned = new PetType
            {
                PetTypeId = pet.PetTypeId,
                PetTypeName = pet.PetTypeName,
            };

            return petcloned;
        }

        public static Owner FindOwnerById(int id)
        {
            Owner owner = allTheOwners.Find(x => x.OwnerId == id);

            Owner ownercloned = new Owner
            {
                OwnerId = owner.OwnerId,
                OwnerFirstName = owner.OwnerFirstName,
                OwnerAddress = owner.OwnerAddress,
                OwnerLastName = owner.OwnerLastName,
                OwnerPhoneNr = owner.OwnerPhoneNr,

            };
            var d = PetsData.FindAll(x => x.PetOwner.OwnerId == ownercloned.OwnerId);
            List<Pet> list = new List<Pet>();
          
            foreach (Pet p in d)
            {
                list.Add(new Pet
                {
                    Birthdate = p.Birthdate,
                    Color = p.Color,
                    Name = p.Name,
                    ID = p.ID,
                    PetOwner = null,
                    Price = p.Price,
                    SoldDate = p.SoldDate,
                    Type = p.Type
                });
            }
            ownercloned.PetsOwned = list;
            return ownercloned;
        }


        public static IEnumerable<Pet> GetPetsFilteredByName(string name)
        {
            filtered = PetsData.FindAll(x => x.Name.ToLower() == name.ToLower()).ToList();
            return filtered;
        }

        public static IEnumerable<Pet> GetPetsFilteredByColor(string color)
        {
            filtered = PetsData.FindAll(x => x.Color.ToLower() == color.ToLower()).ToList();
            return filtered;
        }
        public static IEnumerable<PetType> GetPetTypesFilteredByName(string name)
        {
            filteredTypes = allPetTypes.FindAll(x => x.PetTypeName.ToLower() == name.ToLower()).ToList();
            return filteredTypes;
        }


        public static IEnumerable<Owner> GetOwnersFilteredByName(string name)
        {
            filteredOwners = allTheOwners.FindAll(x => x.OwnerFirstName.ToLower() == name.ToLower()).ToList();
            return filteredOwners;
        }

        

        

    }
}

