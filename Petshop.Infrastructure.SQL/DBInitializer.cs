using System.Collections.Generic;
using Petshop.Core;
using Petshop.Core.DomainService;
using Petshop.Core.Entity;
using Petshop.RestAPI.Helper;

namespace Petshop.Infrastructure.SQL
{
    public class DBInitializer
    {
        private readonly IPetRepository _petRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IPetTypeRepository _petTypeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationHelper _authenticationHelper;
        public DBInitializer(IPetRepository petRepository,IOwnerRepository ownerRepository,IPetTypeRepository petTypeRepository,IUserRepository userRepository,IAuthenticationHelper authenticationHelper)
        {
            _authenticationHelper = authenticationHelper;
            _userRepository = userRepository;
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
                Name = "CattoButActuallyDoggoTooo",
                Price = 1000
            });
            owner.PetsOwned.Add(pet);
            owner2.PetsOwned.Add(pet2);
            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            _authenticationHelper.CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            _authenticationHelper.CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            List<User> users = new List<User>
            {
                new User {
                    Username = "UserJoe",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = false
                },
                new User {
                    Username = "AdminAnn",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn,
                    IsAdmin = true
                }
            };
            _userRepository.Add(users[0]);
            _userRepository.Add(users[1]);
   
        }


    }
}
