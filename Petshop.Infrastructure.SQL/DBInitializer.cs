using System.Collections.Generic;
using Petshop.Core;
using Petshop.Core.DomainService;
using Petshop.Core.Entity;

namespace Petshop.Infrastructure.SQL
{
    public class DBInitializer
    {
        private readonly IPetRepository _petRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IPetTypeRepository _petTypeRepository;
        public DBInitializer(IPetRepository petRepository,IOwnerRepository ownerRepository,IPetTypeRepository petTypeRepository)
        {
            _petRepository = petRepository;
            _ownerRepository = ownerRepository;
            _petTypeRepository = petTypeRepository;
        }

        public void InitData()
        {
            PetType pt = _petTypeRepository.AddPetType(new PetType()
            {
                PetTypeName = "Dog"
            });
            Owner owner = _ownerRepository.AddOwner(new Owner()
            {
                OwnerAddress = "Esbjerg",
                OwnerFirstName = "John",
                OwnerLastName = "Don",
                OwnerPhoneNr = "55",
                PetsOwned = new List<Pet>()
            }) ;
            Owner owner2 = _ownerRepository.AddOwner(new Owner()
            {
                OwnerAddress = "Billund",
                OwnerFirstName = "Mike",
                OwnerLastName = "Spike",
                OwnerPhoneNr = "997",
                PetsOwned = new List<Pet>()
            });
            Pet pet = _petRepository.CreatePet(new Pet()
            {
               Color = "Black",
               PetOwner = owner,
               Type = pt,
               Name = "Doggo",
               Price = 100
            });
            Pet pet2 = _petRepository.CreatePet(new Pet()
            {
                Color = "White",
                PetOwner = owner2,
                Type = pt,
                Name = "CattoButActuallyDoggoToo",
                Price = 1000
            });
            owner.PetsOwned.Add(pet);
            owner2.PetsOwned.Add(pet2);
           
        }


    }
}
