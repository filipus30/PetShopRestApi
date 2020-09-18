using System;
using System.Collections.Generic;
using System.Linq;
using Petshop.Core.DomainService;
using Petshop.Core.Entity;

namespace Petshop.Infrastructure.Data
{
   
        public class OwnerRepository : IOwnerRepository
        {

            public IEnumerable<Owner> GetAllOwners()
            {
                return FakeDB.allTheOwners;
            }

            public IEnumerable<Owner> FindOwnerByName(string searchValue)
            {
                IEnumerable<Owner> ownerByName = FakeDB.allTheOwners.Where(owner => owner.OwnerFirstName.Contains(searchValue) || owner.OwnerLastName.Contains(searchValue));
                return ownerByName;
            }

            public IEnumerable<Owner> FindOwnerByPhonenr(string searchValue)
            {
                IEnumerable<Owner> ownerByPhone = FakeDB.allTheOwners.Where(owner => owner.OwnerPhoneNr.Contains(searchValue));
                return ownerByPhone;
            }

            public IEnumerable<Owner> FindOwnerByAddress(string searchValue)
            {
                IEnumerable<Owner> ownerByAddress = FakeDB.allTheOwners.Where(owner => owner.OwnerAddress.Contains(searchValue));
                return ownerByAddress;
            }

            public IEnumerable<Owner> FindOwnerByEmail(string searchValue)
            {
                IEnumerable<Owner> ownerByEmail = FakeDB.allTheOwners.Where(owner => owner.OwnerEmail.Contains(searchValue));
                return ownerByEmail;
            }

            public Owner FindOwnerByID(int searchId)
            {
                List<Owner> foundOwners = (FakeDB.allTheOwners.Where(owner => owner.OwnerId == searchId)).ToList();
                if (foundOwners.Count <= 0 || foundOwners.Count > 1)
                {
                    throw new Exception(message: "I am sorry wrong amonut of pets found by ID.");
                }
                else
                {
                    return foundOwners[0];
                }
            }

            public Owner AddNewOwner(Owner theNewOwner)
            {
                return FakeDB.addNewOwner(theNewOwner);
            }

            public Owner UpdateFirstNameOfOwner(Owner updatedOwner, string updateValue)
            {
                return FakeDB.updateOwnerFirstName(updatedOwner, updateValue);
            }

            public Owner UpdateLastNameOfOwner(Owner updatedOwner, string updateValue)
            {
                return FakeDB.updateOwnerLastName(updatedOwner, updateValue);
            }

            public Owner UpdateAddressOfOwner(Owner updatedOwner, string updateValue)
            {
                return FakeDB.updateOwnerAddress(updatedOwner, updateValue);
            }

            public Owner UpdatePhoneNrOfOwner(Owner updatedOwner, string updateValue)
            {
                return FakeDB.updateOwnerPhoneNr(updatedOwner, updateValue);
            }

            public Owner UpdateEmailOfOwner(Owner updatedOwner, string updateValue)
            {
                return FakeDB.updateOwnerEmail(updatedOwner, updateValue);
            }

            public Owner DeleteOwnerById(int theId)
            {
                return FakeDB.DeleteOwnerById(theId);
            }

            public IEnumerable<Pet> FindAllPetsByOwner(Owner theOwner)
            {
                IEnumerable<Pet> petsByOwner = FakeDB.allThePets.Where(pet => pet.PetOwner == theOwner);
                return petsByOwner;
            }
        }
    
}
