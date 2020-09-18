﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Petshop.Core.Entity;

namespace Petshop.Infrastructure.Data
{
    public static class FakeDB
    {
        public static IEnumerable<Pet> allThePets { get; set; }
        public static IEnumerable<Owner> allTheOwners { get; set; }
        
        public static List<Pet> PetsData = new List<Pet>();
        public static int theOwnerCount { get; set; }
        private static int Id = 1;



        public static void InitData()
        {
            PetsData.Add(new Pet
            {
                Type = "Dog",
                Name = "Bob",
                Birthdate = DateTime.Now.AddYears(-5),
                SoldDate = DateTime.Now,
                Color = "Brown",
                PreviousOwner = "None",
                Price = 100,
                ID = Id++

            }); ;
            PetsData.Add(new Pet
            {
                Type = "Cat",
                Name = "Flamingo",
                Birthdate = DateTime.Now.AddYears(-3),
                SoldDate = DateTime.Now.AddYears(-1),
                Color = "White",
                PreviousOwner = "Karen",
                Price = 1000,
                ID = Id++

            }); ;
            PetsData.Add(new Pet
            {
                Type = "Cat",
                Name = "John",
                Birthdate = DateTime.Now.AddYears(-8),
                SoldDate = DateTime.Now.AddYears(-3),
                Color = "White",
                PreviousOwner = "Barack Gagama",
                Price = 10,
                ID = Id++

            }); ;
            PetsData.Add(new Pet
            {
                Type = "Sheep",
                Name = "Lucy",
                Birthdate = DateTime.Now.AddYears(-4),
                SoldDate = DateTime.Now.AddYears(-2),
                Color = "White",
                PreviousOwner = "Alice Boop",
                Price = 400,
                ID = Id++

            }); ;
            PetsData.Add(new Pet
            {
                Type = "Dog",
                Name = "Hector",
                Birthdate = DateTime.Now.AddYears(-2),
                SoldDate = DateTime.Now.AddYears(-1),
                Color = "Brown",
                PreviousOwner = "Anastasia Potter",
                Price = 2000,
                ID = Id++

            }); ;
            PetsData.Add(new Pet
            {
                Type = "Snake",
                Name = "Thomas",
                Birthdate = DateTime.Now.AddYears(-3),
                SoldDate = DateTime.Now.AddYears(-2),
                Color = "Green",
                PreviousOwner = "Lucy Brown",
                Price = 500,
                ID = Id++

            }); ;
            PetsData.Add(new Pet
            {
                Type = "Goat",
                Name = "Nick",
                Birthdate = DateTime.Now.AddYears(-3),
                SoldDate = DateTime.Now.AddYears(-2),
                Color = "Black & White",
                PreviousOwner = "George Clinton",
                Price = 200,
                ID = Id++

            }); ;

            List<Owner> allOwners = new List<Owner>
            {
                new Owner{OwnerFirstName = "Lars", OwnerLastName = "Rasmussen", OwnerAddress = "SweetStreet 4, 6700 Esbjerg", OwnerPhoneNr = "+45 1234 5678", OwnerEmail = "lars@rasmussen.dk"},
                new Owner{OwnerFirstName = "John", OwnerLastName = "Jackson", OwnerAddress = "The Alley 6, 6705 Esbjerg Ø", OwnerPhoneNr = "+45 2549 6254", OwnerEmail = "thesuper_awesome@hotmail.com"},
                new Owner{OwnerFirstName = "Maria", OwnerLastName = "Saunderson", OwnerAddress = "Kongensgade 33, 6700 Esbjerg", OwnerPhoneNr = "+45 8761 1624", OwnerEmail = "suuper_sexy88@gmail.com"},
                new Owner{OwnerFirstName = "Belinda", OwnerLastName = "Twain", OwnerAddress = "Nørregade 14, 6700 Esbjerg", OwnerPhoneNr = "+45 7365 5976", OwnerEmail = "blender_wizard@hotmail.com"},
                new Owner{OwnerFirstName = "Roald", OwnerLastName = "Schwartz", OwnerAddress = "Lark Road 26, 6715 Esbjerg N", OwnerPhoneNr = "+45 7618 5234", OwnerEmail = "the_cool_roald@msnmail.com"},
                new Owner{OwnerFirstName = "Shiela", OwnerLastName = "Jesperson", OwnerAddress = "Daniels Road 45, 6700 Esbjerg", OwnerPhoneNr = "+45 7831 2561", OwnerEmail = "shiela45@gmail.com"},
                new Owner{OwnerFirstName = "Hansi", OwnerLastName = "Thompson", OwnerAddress = "Spooky Road 666, 6705 Esbjerg Ø", OwnerPhoneNr = "+45 1465 2845", OwnerEmail = "theghost83@outlook.com"},
                new Owner{OwnerFirstName = "Victoria", OwnerLastName = "Marks", OwnerAddress = "Birkelunden 8, 6705 Esbjerg Ø", OwnerPhoneNr = "+45 5956 4651", OwnerEmail = "vicmarks@hotmail.com"},
                new Owner{OwnerFirstName = "Niels", OwnerLastName = "Billson", OwnerAddress = "Folevej 3, 6715 Esbjerg N", OwnerPhoneNr = "+45 7286 9435", OwnerEmail = "ne49billson@gmail.com"},
                new Owner{OwnerFirstName = "Emanuelle", OwnerLastName = "Johnson", OwnerAddress = "Foldgårdsvej 17, 6715 Esbjerg N", OwnerPhoneNr = "+45 7315 4255", OwnerEmail = "emanuelle-actor@outlook.com"}
            };
            foreach (var owner in allOwners)
            {
               addNewOwner(owner);
            }

        }

        
        public static IEnumerable<Pet> GetPetsData()
        {
            return PetsData;
        }
        public static void AddPet(Pet p)
        {
            p.ID = Id++;
            PetsData.Add(p);
        }
        public static void RemovePet(int id)
        {
            PetsData.RemoveAll(x => x.ID == id);
        }
        public static void UpdatePetPrice(int id,double price)
        {
            var obj = PetsData.FirstOrDefault(x => x.ID == id);
            if (obj != null) obj.Price = price;
        }

        public static Pet FindPetById(int id)
        {
            Pet pet = PetsData.Find(x => x.ID == id);
            return pet;
        }




        internal static Owner updateOwnerLastName(Owner updatedOwner, string updateValue)
        {
            List<Owner> foundOwners = (allTheOwners.Where(owner => owner == updatedOwner)).ToList();
            if (foundOwners.Count <= 0 || foundOwners.Count > 1)
            {
                throw new InvalidDataException(message: "I am sorry wrong amonut of owners found");
            }
            else
            {
                foundOwners[0].OwnerLastName = updateValue;
                return foundOwners[0];
            }
        }

        internal static Owner updateOwnerAddress(Owner updatedOwner, string updateValue)
        {
            List<Owner> foundOwners = (allTheOwners.Where(owner => owner == updatedOwner)).ToList();
            if (foundOwners.Count <= 0 || foundOwners.Count > 1)
            {
                throw new InvalidDataException(message: "I am sorry wrong amonut of owners found");
            }
            else
            {
                foundOwners[0].OwnerAddress = updateValue;
                return foundOwners[0];
            }
        }

        internal static Owner DeleteOwnerById(int theId)
        {
            List<Owner> deletedOwner = (allTheOwners.Where(owner => owner.OwnerId == theId)).ToList();

            if (deletedOwner.Count == 1)
            {
                allTheOwners = allTheOwners.Where(owner => owner != deletedOwner[0]);
                return deletedOwner[0];
            }
            else
            {
                throw new InvalidDataException(message: "Wrong number of the id have been found.");
            }
        }

        internal static Owner updateOwnerPhoneNr(Owner updatedOwner, string updateValue)
        {
            List<Owner> foundOwners = (allTheOwners.Where(owner => owner == updatedOwner)).ToList();
            if (foundOwners.Count <= 0 || foundOwners.Count > 1)
            {
                throw new InvalidDataException(message: "I am sorry wrong amonut of owners found");
            }
            else
            {
                foundOwners[0].OwnerPhoneNr = updateValue;
                return foundOwners[0];
            }
        }

        internal static Owner updateOwnerEmail(Owner updatedOwner, string updateValue)
        {
            List<Owner> foundOwners = (allTheOwners.Where(owner => owner == updatedOwner)).ToList();
            if (foundOwners.Count <= 0 || foundOwners.Count > 1)
            {
                throw new InvalidDataException(message: "I am sorry wrong amonut of owners found");
            }
            else
            {
                foundOwners[0].OwnerEmail = updateValue;
                return foundOwners[0];
            }
        }

        internal static Owner updateOwnerFirstName(Owner updatedOwner, string updateValue)
        {
            List<Owner> foundOwners = (allTheOwners.Where(owner => owner == updatedOwner)).ToList();
            if (foundOwners.Count <= 0 || foundOwners.Count > 1)
            {
                throw new InvalidDataException(message: "I am sorry wrong amonut of owners found");
            }
            else
            {
                foundOwners[0].OwnerFirstName = updateValue;
                return foundOwners[0];
            }
        }

        internal static Owner addNewOwner(Owner theNewOwner)
        {
            theNewOwner.OwnerId = theOwnerCount;
            theOwnerCount++;
            List<Owner> newOwner = new List<Owner> { theNewOwner };
            if (allTheOwners == null)
            {
                allTheOwners = newOwner;
            }
            else
            {
                allTheOwners = allTheOwners.Concat(newOwner);
            }

            return theNewOwner;
        }


    }
}
